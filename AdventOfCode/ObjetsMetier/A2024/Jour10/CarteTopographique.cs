using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;

namespace AdventOfCode.ObjetsMetier.A2024.Jour10
{
    public class CarteTopographique
    {
        private int[][] _Carte { get; set; }
        private int _Hauteur { get; set; }
        private int _Largeur { get; set; }

        public CarteTopographique(int[][] pCarte)
        {
            _Carte = pCarte;
            _Hauteur = pCarte.Length;
            _Largeur = pCarte[0].Length;
        }

        public int DonneNombreDeParcoursPossible()
        {
            int lTotal = 0;

            int lNombreDepart = _Carte.SelectMany(o => o)
                                      .Count(o => o == 0);

            for(int lDepart = 0; lDepart < lNombreDepart; lDepart++)
            {
                BreadthFirstSearch<CaseCarte> lBfs = new BreadthFirstSearch<CaseCarte>(_DonneCases());

                ParcoursBFS<CaseCarte> lParcours = lBfs.ParcourirDepuisLeDepart(lDepart);



                lTotal += lParcours.Cases.SelectMany(o => o)
                                         .Count(o => o.EstALaFin && o.NombreAcces > 0);

            }


            return lTotal;


        }

        public int DonneNombreDeParcoursDifferentPossible()
        {
            BreadthFirstSearch<CaseCarte> lBfs = new BreadthFirstSearch<CaseCarte>(_DonneCases());

            ParcoursBFS<CaseCarte> lParcours = lBfs.ParcoursDepuisTousLesDeparts();



            return lParcours.Cases.SelectMany(o => o)
                                  .Where(o => o.EstALaFin && o.NombreAcces > 0)
                                  .Sum(o => o.NombreAcces);
        }

        private CaseCarte[][] _DonneCases()
        {
            CaseCarte[][] lCases = new CaseCarte[_Hauteur][];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                lCases[lIndexLigne] = new CaseCarte[_Largeur];

                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lCases[lIndexLigne][lIndexColonne] = new CaseCarte
                    {
                        PositionX = lIndexColonne,
                        PositionY = lIndexLigne,
                        HauteurCase = _Carte[lIndexLigne][lIndexColonne]
                    };
                }
            }

            return lCases;
        }
    }
}
