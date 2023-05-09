using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour08
{
    public class Foret
    {
        private int _Hauteur;
        private int _Largeur;
        private int[][] _Foret;

        public Foret(int pLargeur, int pHauteur)
        {
            _Hauteur = pHauteur;
            _Largeur = pLargeur;
            _Foret = new int[pHauteur][];
        }

        public void AjouterRangeeArbre(int pNumeroLigne, int[] pRangee)
        {
            _Foret[pNumeroLigne] = pRangee;
        }

        public int NombreArbresVisible()
        {
            //Init
            bool[][] lVisibilitee = new bool[_Hauteur][];


            for (int lLigne = 0; lLigne < _Hauteur; lLigne++)
            {
                lVisibilitee[lLigne] = new bool[_Largeur];
                //Gauche droite
                int lMaxLigne = -1;
                for (int lColonne = 0; lColonne < _Largeur; lColonne++)
                {
                    if (_Foret[lLigne][lColonne] > lMaxLigne)
                    {
                        lMaxLigne = _Foret[lLigne][lColonne];
                        lVisibilitee[lLigne][lColonne] = true;
                    }

                    if (lMaxLigne == 9)
                    {
                        break;
                    }
                }

                //Droite gauche
                lMaxLigne = -1;
                for (int lColonne = _Largeur - 1; lColonne >= 0; lColonne--)
                {
                    if (_Foret[lLigne][lColonne] > lMaxLigne)
                    {
                        lMaxLigne = _Foret[lLigne][lColonne];
                        lVisibilitee[lLigne][lColonne] = true;
                    }

                    if (lMaxLigne == 9)
                    {
                        break;
                    }
                }
            }


            for (int lColonne = 0; lColonne < _Largeur; lColonne++)
            {
                //Haut bas
                int lMaxColonne = -1;
                for (int lLigne = 0; lLigne < _Hauteur; lLigne++)
                {
                    if (_Foret[lLigne][lColonne] > lMaxColonne)
                    {
                        lMaxColonne = _Foret[lLigne][lColonne];
                        lVisibilitee[lLigne][lColonne] = true;
                    }

                    if (lMaxColonne == 9)
                    {
                        break;
                    }
                }

                //Bas haut
                lMaxColonne = -1;
                for (int lLigne = _Hauteur - 1; lLigne >= 0; lLigne--)
                {
                    if (_Foret[lLigne][lColonne] > lMaxColonne)
                    {
                        lMaxColonne = _Foret[lLigne][lColonne];
                        lVisibilitee[lLigne][lColonne] = true;
                    }

                    if (lMaxColonne == 9)
                    {
                        break;
                    }
                }
            }


            return lVisibilitee.Sum(o => o.Count(p => p));
        }

        public int DonneMeilleurScoreScenic()
        {
            //parce que les elfs roule en Renault

            //Init
            int[][] lScoreScenic = new int[_Hauteur][];

            //Pas de parcours de la première et dernière
            lScoreScenic[0] = new int[_Largeur];
            lScoreScenic[_Hauteur - 1] = new int[_Largeur];


            for (int lLigne = 1; lLigne < _Hauteur - 1; lLigne++)
            {
                lScoreScenic[lLigne] = new int[_Largeur];

                for (int lColonne = 1; lColonne < _Largeur - 0; lColonne++)
                {
                    int lScore = 1;

                    int lHauteurArbre = _Foret[lLigne][lColonne];


                    //Vers la gauche
                    int lNombreVue = 0;
                    for (int lGauche = lColonne - 1; lGauche >= 0; lGauche--)
                    {
                        lNombreVue++;

                        if (_Foret[lLigne][lGauche] >= lHauteurArbre)
                        {
                            break;
                        }
                    }


                    lScore *= lNombreVue;

                    //Vers le haut
                    lNombreVue = 0;
                    for (int lHaut = lLigne - 1; lHaut >= 0; lHaut--)
                    {
                        lNombreVue++;

                        if (_Foret[lHaut][lColonne] >= lHauteurArbre)
                        {
                            break;
                        }
                    }

                    lScore *= lNombreVue;

                    //Vers la droite
                    lNombreVue = 0;
                    for (int lDroite = lColonne + 1; lDroite < _Largeur; lDroite++)
                    {
                        lNombreVue++;

                        if (_Foret[lLigne][lDroite] >= lHauteurArbre)
                        {
                            break;
                        }
                    }

                    lScore *= lNombreVue;

                    //Vers le bas
                    lNombreVue = 0;

                    for (int lBas = lLigne + 1; lBas < _Hauteur; lBas++)
                    {
                        lNombreVue++;

                        if (_Foret[lBas][lColonne] >= lHauteurArbre)
                        {
                            break;
                        }
                    }

                    lScore *= lNombreVue;

                    lScoreScenic[lLigne][lColonne] = lScore;
                }
            }

            return lScoreScenic.Max(o => o.Max());
        }

    }
}
