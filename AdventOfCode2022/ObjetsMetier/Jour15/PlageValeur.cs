using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour15
{
    [DebuggerDisplay("{Debut} -> {Fin} | {TotalDistance}")]
    public class PlageValeur
    {
        public decimal Debut { get; init; }
        public decimal Fin { get; init; }

        public PlageValeur(decimal pDebut, decimal pFin)
        {
            Debut = pDebut;
            Fin = pFin;
        }

        public decimal TotalDistance => Fin - Debut;

        public override bool Equals(object pObjet)
        {
            PlageValeur lPlage = pObjet as PlageValeur;

            if (lPlage == null)
            {
                return false;
            }

            return this.Debut == lPlage.Debut && this.Fin == lPlage.Fin;
        }

        public override int GetHashCode()
        {
            return this.Debut.GetHashCode() ^ this.Fin.GetHashCode();
        }

        public static List<PlageValeur> FusionnerPlages(List<PlageValeur> pPlageValeurs)
        {
            List<PlageValeur> lPlagesACombiner = pPlageValeurs.OrderBy(o => o.Debut)
                                                              .ToList();
            int lNombreDebut = lPlagesACombiner.Count;

            if(lNombreDebut <= 1)
            {
                return lPlagesACombiner;
            }

            bool lIdentique = false;
            HashSet<PlageValeur> lPlagesFusionnees = new HashSet<PlageValeur>();

            do
            {
                lPlagesFusionnees = new HashSet<PlageValeur>();
                PlageValeur lPlage1 = lPlagesACombiner[0];

                for(int lIndex = 1; lIndex < lPlagesACombiner.Count; lIndex++)
                {
                    PlageValeur lPlage2 = lPlagesACombiner[lIndex];

                    List<PlageValeur> lResultat = PlageValeur.FusionnerPlage(lPlage1, lPlage2);

                    if(lResultat.Count == 1)
                    {
                        lPlagesFusionnees.Remove(lPlage1);
                    }

                    foreach (PlageValeur lCombine in lResultat)
                    {
                        lPlagesFusionnees.Add(lCombine);
                        lPlage1 = lCombine;
                    }                    
                }

                lIdentique = lPlagesACombiner.All(o => lPlagesFusionnees.Contains(o));
                
               
                lPlagesACombiner = lPlagesFusionnees.OrderBy(o => o.Debut).ToList();

            } while (lIdentique == false && lPlagesFusionnees.Count != 1);

            return lPlagesFusionnees.ToList();
        }

        public static List<PlageValeur> FusionnerPlage(PlageValeur pPlage1, PlageValeur pPlage2)
        {
            if(pPlage1.Fin < pPlage2.Debut || pPlage2.Fin < pPlage1.Debut)
            {
                //Deux plages qui ne se survolent pas
                return  new List<PlageValeur>() { pPlage1, pPlage2 };
            }

            //Dans les autres cas, ça se survole
            return new List<PlageValeur>() { new PlageValeur(Math.Min(pPlage1.Debut, pPlage2.Debut), Math.Max(pPlage1.Fin, pPlage2.Fin)) };
        }
    }
}
