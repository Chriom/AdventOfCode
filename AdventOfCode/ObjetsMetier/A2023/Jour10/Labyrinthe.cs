using System.Diagnostics;
using System.Text;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.ObjetsMetier.A2023.Jour10
{
    public class Labyrinthe
    {

        private TypeTuyau[][] _Labyrinthe;

        private int _Hauteur;
        private int _Largeur;

        public Labyrinthe(TypeTuyau[][] pLabyrinthe)
        {
            _Labyrinthe = pLabyrinthe;

            _Hauteur = _Labyrinthe.Length;
            _Largeur = _Labyrinthe[0].Length;

        }

        public int DonneLongeurPlusGrandeBoucle()
        {
            ParcoursBFS<CaseLabyrinthe> lParcours = _ParcourirBoucle();

            return lParcours.Cases.SelectMany(o => o)
                                  .Where(o => o.NombreAcces >= 2)
                                  .Max(o => o.Profondeur);
        }

        private ParcoursBFS<CaseLabyrinthe> _ParcourirBoucle()
        {
            BreadthFirstSearch<CaseLabyrinthe> lBFS = new BreadthFirstSearch<CaseLabyrinthe>(_DonneCases());

            ParcoursBFS<CaseLabyrinthe> lParcours = lBFS.ParcourirDepuisLeDepart();

            return lParcours;
        }

        private CaseLabyrinthe[][] _DonneCases()
        {
            CaseLabyrinthe[][] lCases = new CaseLabyrinthe[_Hauteur][];
            
            for(int lIndexLigne = 0 ; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                lCases[lIndexLigne] = new CaseLabyrinthe[_Largeur];
                
                for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lCases[lIndexLigne][lIndexColonne] = new CaseLabyrinthe(_Labyrinthe[lIndexLigne][lIndexColonne], lIndexColonne, lIndexLigne);
                }
            }

            return lCases;
        }

        public int DonneNombreDeCasesALInterieurDeLaBoucle()
        {
            //Parcour du tuyau
            ParcoursBFS<CaseLabyrinthe> lParcours = _ParcourirBoucle();
            _RemplacerTypeCaseDeDépart(lParcours);

            int lNombreCases = 0;
                       

            for(int lLigne = 0; lLigne < _Hauteur; lLigne++)
            {
                bool lEstDehors = true;
                StringBuilder lSb = new StringBuilder();

                TypeTuyau lPointEntree = TypeTuyau.Sol;

                for (int lColonne = 0; lColonne < _Largeur; lColonne++)
                {
                    //ça a été parcouru : donc dans le tuyau
                    CaseLabyrinthe lCase = lParcours.Cases[lLigne][lColonne];

                    if (lCase.EstVisitee)
                    {
                        if(lCase.TypeCase == TypeTuyau.NordEtSud)
                        {
                            //Vertical : ça traverse
                            lEstDehors = !lEstDehors;
                        }
                        else if(lCase.TypeCase == TypeTuyau.NordEtEst ||
                                lCase.TypeCase == TypeTuyau.NordEtOuest ||
                                lCase.TypeCase == TypeTuyau.SudEtEst ||
                                lCase.TypeCase == TypeTuyau.SudEtOuest)
                        {
                            //Un coude
                            if(lPointEntree == TypeTuyau.Sol)
                            {
                                //Début du coude
                                lPointEntree = lCase.TypeCase;
                            }
                            else
                            {
                                //Faut cherche l'autre bout voir si ça rentre et sort
                                if((lPointEntree == TypeTuyau.NordEtEst && lCase.TypeCase == TypeTuyau.NordEtOuest) ||
                                   (lPointEntree == TypeTuyau.NordEtOuest && lCase.TypeCase == TypeTuyau.NordEtEst) ||
                                   (lPointEntree == TypeTuyau.SudEtEst && lCase.TypeCase == TypeTuyau.SudEtOuest) ||
                                   (lPointEntree == TypeTuyau.SudEtOuest && lCase.TypeCase == TypeTuyau.SudEtEst))
                                {
                                    //ça compte pas

                                }
                                else
                                {
                                    //ça compte
                                    lEstDehors = !lEstDehors;
                                }

                                lPointEntree = TypeTuyau.Sol;
                            }

                        }
                        

                        lSb.Append(_CaractereDebug(lCase.TypeCase));
                    }
                    else
                    {
                        if (lEstDehors)
                        {
                            lSb.Append(_CaractereDebug(TypeTuyau.Exterieur));
                        }
                        else
                        {
                            lNombreCases++;
                            lSb.Append(_CaractereDebug(TypeTuyau.Interieur));
                        }
                    }
                }


                if (EntreesHelper.EstEnmodeTest)
                {
                    Debug.WriteLine(lSb.ToString());
                }
                else
                {
                    Console.WriteLine(lSb.ToString());
                }
                
            }



            return lNombreCases;
        }

        private void _RemplacerTypeCaseDeDépart(ParcoursBFS<CaseLabyrinthe> pParcours)
        {
            CaseLabyrinthe lDépart = pParcours.Cases.SelectMany(o => o)
                                                    .First(o => o.EstAuDepart);


            bool lPointeNord = false;
            bool lPointeSud = false;
            bool lPointeEst = false;
            bool lPointeOuest = false;

            if(lDépart.PositionY > 0)
            {
                CaseLabyrinthe lHaut = pParcours.Cases[lDépart.PositionY - 1][lDépart.PositionX];

                if(lHaut.TypeCase == TypeTuyau.NordEtSud ||
                   lHaut.TypeCase == TypeTuyau.SudEtOuest ||
                   lHaut.TypeCase == TypeTuyau.SudEtEst)
                {
                    lPointeNord = true;
                }
            }

            if (lDépart.PositionY < pParcours.Hauteur - 1)
            {
                CaseLabyrinthe lBas = pParcours.Cases[lDépart.PositionY + 1][lDépart.PositionX];

                if (lBas.TypeCase == TypeTuyau.NordEtSud ||
                   lBas.TypeCase == TypeTuyau.NordEtOuest ||
                   lBas.TypeCase == TypeTuyau.NordEtEst)
                {
                    lPointeSud = true;
                }
            }

            if (lDépart.PositionX > 0)
            {
                CaseLabyrinthe lGauche = pParcours.Cases[lDépart.PositionY][lDépart.PositionX - 1];

                if (lGauche.TypeCase == TypeTuyau.EstEtOuest ||
                   lGauche.TypeCase == TypeTuyau.SudEtEst ||
                   lGauche.TypeCase == TypeTuyau.NordEtEst)
                {
                    lPointeOuest = true;
                }
            }

            if (lDépart.PositionX < pParcours.Largeur - 1)
            {
                CaseLabyrinthe lDroite = pParcours.Cases[lDépart.PositionY][lDépart.PositionX + 1];

                if (lDroite.TypeCase == TypeTuyau.EstEtOuest ||
                   lDroite.TypeCase == TypeTuyau.SudEtOuest ||
                   lDroite.TypeCase == TypeTuyau.NordEtOuest)
                {
                    lPointeEst = true;
                }
            }


            if(lPointeNord && lPointeSud)
            {
                lDépart.TypeCase = TypeTuyau.NordEtSud;
            }
            else if (lPointeOuest && lPointeEst)
            {
                lDépart.TypeCase = TypeTuyau.EstEtOuest;
            }
            else if(lPointeNord && lPointeEst)
            {
                lDépart.TypeCase = TypeTuyau.NordEtEst;
            }
            else if (lPointeNord && lPointeOuest)
            {
                lDépart.TypeCase = TypeTuyau.NordEtOuest;
            }
            else if (lPointeSud && lPointeEst)
            {
                lDépart.TypeCase = TypeTuyau.SudEtEst;
            }
            else if (lPointeSud && lPointeOuest)
            {
                lDépart.TypeCase = TypeTuyau.SudEtOuest;
            }


        }

        private string _CaractereDebug(TypeTuyau pType)
        {
            return pType switch
            {
                TypeTuyau.Depart => "S",
                TypeTuyau.NordEtSud => "║",
                TypeTuyau.EstEtOuest => "═",
                TypeTuyau.SudEtEst => "╔",
                TypeTuyau.SudEtOuest => "╗",
                TypeTuyau.NordEtEst => "╚",
                TypeTuyau.NordEtOuest => "╝",
                TypeTuyau.Exterieur => "¤",
                TypeTuyau.Interieur => "■",
                TypeTuyau.Sol => " ",

            };
        }
    }
}
