using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;


namespace AdventOfCode.ObjetsMetier.A2023.Jour17
{
    public class PiscineDelave
    {
        private int[][] _Bassin;
        private Quartier[][] _CarteBassin;

        private int _Hauteur;
        private int _Largeur;

        public PiscineDelave(int[][] pBassin)
        {
            _Bassin = pBassin;

            _Hauteur = _Bassin.Length;
            _Largeur = _Bassin.First().Length;

            _CarteBassin = _DonneCarte();
        }

        private const int _LONGUEUR_MAX = 3;


        public int DonneDeperditionDeChaleurMinimal()
        {
            Quartier lQDepart = _CarteBassin[0][0];

            List<QuartierVisite> lATraiter = new List<QuartierVisite>();

            //Init

            Dictionary<string, QuartierVisite> lDicoCases = new Dictionary<string, QuartierVisite>();

            QuartierVisite lDepart = new QuartierVisite()
            {
                Quartier = lQDepart,
                Sens = SensVenu.Gauche,
                Longueur = 0,
                DeperditionDepuisDepart = 0,
            };
            QuartierVisite lDepart2 = new QuartierVisite()
            {
                Quartier = lQDepart,
                Sens = SensVenu.Haut,
                Longueur = 0,
                DeperditionDepuisDepart = 0,
            };

            lDicoCases.Add(lDepart.Cle, lDepart);
            lDicoCases.Add(lDepart2.Cle, lDepart2);

            List<QuartierVisite> lFins = new List<QuartierVisite>();

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    for (int lLongueur = 1; lLongueur <= 3; lLongueur++)
                    {
                        foreach (SensVenu lSens in EnumHelper.DonneValeurs<SensVenu>())
                        {
                            QuartierVisite lPossibilité = new QuartierVisite()
                            {
                                Longueur = lLongueur,
                                Sens = lSens,
                                Quartier = _CarteBassin[lIndexLigne][lIndexColonne],
                            };

                            if (lIndexLigne == 0 && lIndexColonne == 0)
                            {
                                lPossibilité.DeperditionDepuisDepart = 0;
                            }

                            lDicoCases.Add(lPossibilité.Cle, lPossibilité);
                        }

                    }
                }
            }

            lATraiter.Add(lDicoCases[lDepart.Cle]);
            lATraiter.Add(lDicoCases[lDepart2.Cle]);

            do
            {
                lATraiter = lATraiter.OrderBy(o => o.DeperditionDepuisDepart).ToList();

                QuartierVisite lQuartier = lATraiter.First();
                lATraiter.Remove(lQuartier);

                if (lQuartier.Quartier.PositionX == _Largeur - 1 && lQuartier.Quartier.PositionY == _Hauteur - 1)
                {
                    //A la fin => on fait rien
                    lFins.Add(lQuartier);
                }
                else
                {

                    if (lQuartier.Quartier.PositionX > 0 && lQuartier.Sens != SensVenu.Gauche && ((lQuartier.Sens == SensVenu.Droite && lQuartier.Longueur == _LONGUEUR_MAX) == false))
                    {
                        //Vers la gauche
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Droite ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Droite,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY][lQuartier.Quartier.PositionX - 1],
                        };

                        lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                        if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                        {
                            int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                            if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                            {
                                lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                lNoeudEnfant.Precedent = lQuartier;
                                lATraiter.Add(lNoeudEnfant);
                            }
                        }
                    }
                    if (lQuartier.Quartier.PositionX + 1 < _Largeur && lQuartier.Sens != SensVenu.Droite && ((lQuartier.Sens == SensVenu.Gauche && lQuartier.Longueur == _LONGUEUR_MAX) == false))
                    {
                        //Vers la droite
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Gauche ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Gauche,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY][lQuartier.Quartier.PositionX + 1],
                        };

                        lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                        if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                        {
                            int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                            if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                            {
                                lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                lNoeudEnfant.Precedent = lQuartier;
                                lATraiter.Add(lNoeudEnfant);
                            }
                        }

                    }
                    if (lQuartier.Quartier.PositionY > 0 && lQuartier.Sens != SensVenu.Haut && ((lQuartier.Sens == SensVenu.Bas && lQuartier.Longueur == _LONGUEUR_MAX) == false))
                    {
                        //Vers le haut
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Bas ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Bas,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY - 1][lQuartier.Quartier.PositionX],
                        };

                        lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                        if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                        {
                            int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                            if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                            {
                                lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                lNoeudEnfant.Precedent = lQuartier;
                                lATraiter.Add(lNoeudEnfant);
                            }
                        }

                    }
                    if (lQuartier.Quartier.PositionY + 1 < _Hauteur && lQuartier.Sens != SensVenu.Bas && ((lQuartier.Sens == SensVenu.Haut && lQuartier.Longueur == _LONGUEUR_MAX) == false))
                    {
                        //Vers le bas
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Haut ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Haut,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY + 1][lQuartier.Quartier.PositionX],
                        };

                        lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                        if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                        {
                            int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                            if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                            {
                                lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                lNoeudEnfant.Precedent = lQuartier;
                                lATraiter.Add(lNoeudEnfant);
                            }

                        }

                    }
                }

            } while (lATraiter.Count > 0);


            _DessinerCarte(lFins.OrderBy(o => o.DeperditionDepuisDepart).First());

            //Récup du dernier quartier

            return lFins.Min(o => o.DeperditionDepuisDepart);
        }

        private const int _LONGUEUR_MAX_ULTRA = 10;
        private const int _DISTANCE_TOURNE_ULTRA = 4;

        public int DonneDeperditionDeChaleurMinimalUltraCrucible()
        {
            Quartier lQDepart = _CarteBassin[0][0];

            List<QuartierVisite> lATraiter = new List<QuartierVisite>();

            //Init

            Dictionary<string, QuartierVisite> lDicoCases = new Dictionary<string, QuartierVisite>();

            QuartierVisite lDepart = new QuartierVisite()
            {
                Quartier = lQDepart,
                Sens = SensVenu.Gauche,
                Longueur = 0,
                DeperditionDepuisDepart = 0,
            };
            QuartierVisite lDepart2 = new QuartierVisite()
            {
                Quartier = lQDepart,
                Sens = SensVenu.Haut,
                Longueur = 0,
                DeperditionDepuisDepart = 0,
            };

            lDicoCases.Add(lDepart.Cle, lDepart);
            lDicoCases.Add(lDepart2.Cle, lDepart2);

            List<QuartierVisite> lFins = new List<QuartierVisite>();

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    for (int lLongueur = 1; lLongueur <= 10; lLongueur++)
                    {
                        foreach (SensVenu lSens in EnumHelper.DonneValeurs<SensVenu>())
                        {
                            QuartierVisite lPossibilité = new QuartierVisite()
                            {
                                Longueur = lLongueur,
                                Sens = lSens,
                                Quartier = _CarteBassin[lIndexLigne][lIndexColonne],
                            };

                            if (lIndexLigne == 0 && lIndexColonne == 0)
                            {
                                lPossibilité.DeperditionDepuisDepart = 0;
                            }

                            lDicoCases.Add(lPossibilité.Cle, lPossibilité);
                        }

                    }
                }
            }

            lATraiter.Add(lDicoCases[lDepart.Cle]);
            lATraiter.Add(lDicoCases[lDepart2.Cle]);

            do
            {
                lATraiter = lATraiter.OrderBy(o => o.DeperditionDepuisDepart).ToList();

                QuartierVisite lQuartier = lATraiter.First();
                lATraiter.Remove(lQuartier);

                if (lQuartier.Quartier.PositionX == _Largeur - 1 && lQuartier.Quartier.PositionY == _Hauteur - 1)
                {
                    //A la fin => on fait rien
                    lFins.Add(lQuartier);
                }
                else
                {

                    if (lQuartier.Quartier.PositionX > 0 && lQuartier.Sens != SensVenu.Gauche &&
                        ((lQuartier.Sens != SensVenu.Droite && lQuartier.Longueur >= _DISTANCE_TOURNE_ULTRA) || (lQuartier.Sens == SensVenu.Droite && lQuartier.Longueur < _LONGUEUR_MAX_ULTRA)))
                    {



                        //Vers la gauche
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Droite ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Droite,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY][lQuartier.Quartier.PositionX - 1],
                        };


                        lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                        if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                        {
                            int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                            if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                            {
                                lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                lNoeudEnfant.Precedent = lQuartier;
                                lATraiter.Add(lNoeudEnfant);
                            }
                        }
                    }
                    if (lQuartier.Quartier.PositionX + 1 < _Largeur && lQuartier.Sens != SensVenu.Droite &&
                        ((lQuartier.Sens != SensVenu.Gauche && lQuartier.Longueur >= _DISTANCE_TOURNE_ULTRA) || (lQuartier.Sens == SensVenu.Gauche && lQuartier.Longueur < _LONGUEUR_MAX_ULTRA)))
                    {
                        //Vers la droite
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Gauche ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Gauche,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY][lQuartier.Quartier.PositionX + 1],
                        };

                        bool lBien = true;

                        if (lNoeudEnfant.Quartier.PositionX == _Largeur - 1)
                        {
                            if (lNoeudEnfant.Longueur < _DISTANCE_TOURNE_ULTRA)
                            {
                                lBien = false;
                            }
                        }

                        if (lBien)
                        {
                            lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                            if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                            {
                                int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                                if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                                {
                                    lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                    lNoeudEnfant.Precedent = lQuartier;
                                    lATraiter.Add(lNoeudEnfant);
                                }
                            }
                        }


                    }
                    if (lQuartier.Quartier.PositionY > 0 && lQuartier.Sens != SensVenu.Haut &&
                        ((lQuartier.Sens != SensVenu.Bas && lQuartier.Longueur >= _DISTANCE_TOURNE_ULTRA) || (lQuartier.Sens == SensVenu.Bas && lQuartier.Longueur < _LONGUEUR_MAX_ULTRA)))
                    {
                        //Vers le haut
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Bas ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Bas,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY - 1][lQuartier.Quartier.PositionX],
                        };

                        lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                        if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                        {
                            int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                            if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                            {
                                lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                lNoeudEnfant.Precedent = lQuartier;
                                lATraiter.Add(lNoeudEnfant);
                            }
                        }

                    }
                    if (lQuartier.Quartier.PositionY + 1 < _Hauteur && lQuartier.Sens != SensVenu.Bas &&
                        ((lQuartier.Sens != SensVenu.Haut && lQuartier.Longueur >= _DISTANCE_TOURNE_ULTRA) || (lQuartier.Sens == SensVenu.Haut && lQuartier.Longueur < _LONGUEUR_MAX_ULTRA)))
                    {
                        //Vers le bas
                        QuartierVisite lNoeudEnfant = new QuartierVisite()
                        {
                            Longueur = lQuartier.Sens == SensVenu.Haut ? lQuartier.Longueur + 1 : 1,
                            Sens = SensVenu.Haut,
                            Quartier = _CarteBassin[lQuartier.Quartier.PositionY + 1][lQuartier.Quartier.PositionX],
                        };

                        bool lBien = true;

                        if (lNoeudEnfant.Quartier.PositionY == _Hauteur - 1)
                        {
                            if (lNoeudEnfant.Longueur < _DISTANCE_TOURNE_ULTRA)
                            {
                                lBien = false;
                            }
                        }

                        if (lBien)
                        {
                            lNoeudEnfant = lDicoCases[lNoeudEnfant.Cle];

                            if (lNoeudEnfant.Quartier.CaseOrigine.Add(lQuartier.Cle))
                            {
                                int lDistance = lQuartier.DeperditionDepuisDepart + lNoeudEnfant.Quartier.DeperditionChaleur;

                                if (lDistance < lNoeudEnfant.DeperditionDepuisDepart)
                                {
                                    lNoeudEnfant.DeperditionDepuisDepart = lDistance;
                                    lNoeudEnfant.Precedent = lQuartier;
                                    lATraiter.Add(lNoeudEnfant);
                                }
                            }
                        }
                    }
                }

            } while (lATraiter.Count > 0);


            _DessinerCarte(lFins.OrderBy(o => o.DeperditionDepuisDepart).First());

            //Récup du dernier quartier

            Console.WriteLine(string.Join(" ,", lFins.OrderBy(o => o.DeperditionDepuisDepart).Select(o => o.DeperditionDepuisDepart)));

            return lFins.Min(o => o.DeperditionDepuisDepart);
        }


        private void _DessinerCarte(QuartierVisite pFin)
        {
            //Parcour pour voir les bonnes cases
            bool[][] lParcouru = new bool[_Hauteur][];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                lParcouru[lIndexLigne] = new bool[_Largeur];
            }


            QuartierVisite lQuartierCourant = pFin;


            do
            {
                lParcouru[lQuartierCourant.Quartier.PositionY][lQuartierCourant.Quartier.PositionX] = true;

                lQuartierCourant = lQuartierCourant.Precedent;

            } while (lQuartierCourant != null);


            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    Console.ForegroundColor = lParcouru[lIndexLigne][lIndexColonne] ? ConsoleColor.Green : ConsoleColor.White;

                    Console.Write(_CarteBassin[lIndexLigne][lIndexColonne].DeperditionChaleur + " ");
                }

                Console.WriteLine();
            }
        }

        private Quartier[][] _DonneCarte()
        {
            Quartier[][] lCarte = new Quartier[_Hauteur][];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                lCarte[lIndexLigne] = new Quartier[_Largeur];
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lCarte[lIndexLigne][lIndexColonne] = new Quartier()
                    {
                        DeperditionChaleur = _Bassin[lIndexLigne][lIndexColonne],
                        PositionX = lIndexColonne,
                        PositionY = lIndexLigne,
                    };
                }
            }

            return lCarte;
        }
    }
}
