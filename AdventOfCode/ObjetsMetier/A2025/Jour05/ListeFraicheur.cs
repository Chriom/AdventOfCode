using AdventOfCode.Commun.Utilitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2025.Jour05
{
    public class ListeFraicheur
    {
        private List<PlageValeur<decimal>> _PlagesFraiche = new List<PlageValeur<decimal>>();

        private List<decimal> _IdentifiantsProduit;

        public ListeFraicheur(List<PlageValeur<decimal>> pPlagesFraiche, List<decimal> pIdentifiantsProduit)
        {
            _PlagesFraiche = pPlagesFraiche;
            _IdentifiantsProduit = pIdentifiantsProduit;
        }

        public decimal DonneNombreIdsFrais()
        {
            decimal lNombreFrais = 0;

            foreach(decimal lId in _IdentifiantsProduit)
            {
                foreach(PlageValeur<decimal> lPlage in _PlagesFraiche)
                {
                    if (lPlage.EstDansPlage(lId))
                    {
                        lNombreFrais++;
                        break;
                    }
                }
            }


            return lNombreFrais;
        }

        public decimal DonneTotalIdsFrais()
        {
            List<PlageValeur<decimal>> lPlages = _PlagesFraiche;


            //Fusion des plages : pas opti mais flemme
            int lIndexGlobal = 0;
            bool lFin = false;
            do
            {
                lPlages = lPlages.OrderBy(o => o.BorneInferieur).ToList();

                List<PlageValeur<decimal>> lPlagesFusionnees = new List<PlageValeur<decimal>>();

                PlageValeur<decimal> lPlageTest = lPlages[lIndexGlobal];

                for(int lIndexAjout = 0; lIndexAjout < lIndexGlobal; lIndexAjout++)
                {
                    //Ajout des plage avant le global
                    lPlagesFusionnees.Add(lPlages[lIndexAjout]);
                }

                bool lFusion = false;

                //Parcours du début de l'index global
                for (int lIndex = lIndexGlobal + 1; lIndex < lPlages.Count; lIndex++)
                {
                    List<PlageValeur<decimal>> lResultat = lPlageTest.EnglobePlageSiPossible(lPlages[lIndex]).ToList();

                    if(lResultat.Count == 1)
                    {
                        lFusion = true;
                    }

                    lPlagesFusionnees.AddRange(lResultat);
                }


                lPlagesFusionnees = lPlagesFusionnees.Distinct().ToList();

                if (lFusion)
                {
                    //Y'a au moins une fusion de plage donc faut jarter la plage de test
                    lPlagesFusionnees.Remove(lPlageTest);
                }



                if (lPlages.Count == lPlagesFusionnees.Count && lIndexGlobal >= lPlages.Count - 2)
                {
                    //Plus de fusion possible
                    if (lFin)
                    {
                        break;
                    }
                    //Un tour en plus pour la peine
                    lFin = true;    

                }
                else if(lPlages.Count == lPlagesFusionnees.Count)
                {
                    //Rien qui bouge on passe au suivant
                    lIndexGlobal++;
                }
                else
                {
                    lPlages = lPlagesFusionnees;
                    lIndexGlobal = 0;
                    lFin = false;
                }
                

            } while (true);

            return lPlages.Sum(o => o.NombreEntiersDansPlage);
        }
    }
}
