using AdventOfCode.ObjetsMetier.A2023.Jour09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour15
{
    public class Procedure
    {
        private string _Instructions;
        private List<Etape> _Etapes;

        public Procedure(string pInstructions)
        {
            _Instructions = pInstructions;

            _Etapes = pInstructions.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(o => new Etape(o))
                                   .ToList();
        }

        public decimal DonneSommeDesHash()
        {
            decimal lSomme = 0;

            foreach(Etape lEtape in _Etapes)
            {
                lSomme += lEtape.CalculerHashComplet();
            }

            return lSomme;
        }

        private const int _NOMBRE_BOITES = 256;

        public decimal TrierBoites()
        {
            List<Boite> lBoites = new List<Boite>();

            for(int lIndex = 0; lIndex < _NOMBRE_BOITES; lIndex++)
            {
                lBoites.Add(new Boite() { Numero = lIndex });
            }

            //Traitement des étapes
            foreach(Etape lEtape in _Etapes)
            {
                int lBoite = lEtape.CalculerHashCoupé();

                if (lEtape.Operation == Etape.RETRAIT_LENTILLE)
                {
                    lBoites[lBoite].RetireLentille(lEtape.SequenceCoupé);
                }
                else
                {
                    lBoites[lBoite].AjouterLentille(lEtape.SequenceCoupé, lEtape.LongueurFocal);
                }
            }


            //Calcul du total
            return lBoites.Sum(o => o.DonneValeurDansBoite());
        }
    }
}
