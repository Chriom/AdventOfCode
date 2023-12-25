using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;

namespace AdventOfCode.ObjetsMetier.A2023.Jour16
{
    public class Machine
    {
        TypeDeCase[][] _TypeCases;

        private int _Hauteur;
        private int _Largeur;
        public Machine(TypeDeCase[][] pTypeCases)
        {
            _TypeCases = pTypeCases;

            _Hauteur = _TypeCases.Length;
            _Largeur = _TypeCases.First().Length;
        }

        public int DonneNombreDeCasesEnergisees()
        {
            return _DonneNombreDeCasesEnergisees(0, 0, false, false, false, true);
        }

        private int _DonneNombreDeCasesEnergisees(int pLigneDepart, int pColonneDepart, bool pNord, bool pSud, bool pEst, bool pOuest)
        {
            Case[][] lCases = _DonneCases();

            
            lCases[pLigneDepart][pColonneDepart].EstAuDepart = true;

            if(pNord)
            {
                lCases[pLigneDepart][pColonneDepart].EnergiseNord = true;
            }
            if (pSud)
            {
                lCases[pLigneDepart][pColonneDepart].EnergiseSud = true;
            }
            if (pEst)
            {
                lCases[pLigneDepart][pColonneDepart].EnergiseEst = true;
            }
            if (pOuest)
            {
                lCases[pLigneDepart][pColonneDepart].EnergiseOuest = true;
            }




            BreadthFirstSearch<Case> lBfs = new BreadthFirstSearch<Case>(lCases);

            
            ParcoursBFS<Case> lParcours = lBfs.ParcourirDepuisLeDepart();

            return lParcours.Cases.SelectMany(o => o)
                                  .Count(o => o.EnergiseNord || o.EnergiseSud || o.EnergiseEst || o.EnergiseOuest);
        }

        public int DonneNombreMaximumDeCasesEnergise()
        {
            int lNombreCasesMax = 0;
            //Passage de toutes les lignes
            for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                //Gauche
                int lResultat = _DonneNombreDeCasesEnergisees(lIndexLigne, 0, false, false, false, true);

                if(lResultat > lNombreCasesMax)
                {
                    lNombreCasesMax = lResultat;
                }

                //Droite
                lResultat = _DonneNombreDeCasesEnergisees(lIndexLigne, _Largeur - 1, false, false, true, false);

                if (lResultat > lNombreCasesMax)
                {
                    lNombreCasesMax = lResultat;
                }
            }

            //Passage de toutes les colonnes
            for(int lIndexColonne = 0; lIndexColonne< _Largeur; lIndexColonne++)
            {
                //Haut
                int lResultat = _DonneNombreDeCasesEnergisees(0, lIndexColonne, true, false, false, false);

                if (lResultat > lNombreCasesMax)
                {
                    lNombreCasesMax = lResultat;
                }

                //Bas
                lResultat = _DonneNombreDeCasesEnergisees(_Hauteur - 1, lIndexColonne, false, true, false, false);

                if (lResultat > lNombreCasesMax)
                {
                    lNombreCasesMax = lResultat;
                }
            }


            return lNombreCasesMax;
        }

        private Case[][] _DonneCases()
        {
            Case[][] lCases = new Case[_Hauteur][];


            for(int lIndex = 0; lIndex < _Hauteur; lIndex++)
            {
                lCases[lIndex] = new Case[_Largeur];

                for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lCases[lIndex][lIndexColonne] = new Case(_TypeCases[lIndex][lIndexColonne])
                    {
                        PositionX = lIndexColonne,
                        PositionY = lIndex,
                    };
                }
            }

            return lCases;

        }
    }
}
