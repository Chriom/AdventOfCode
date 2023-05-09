using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour12
{
    public class Carte
    {
        private const char _CHARACTERE_DEBUT = 'S';
        private const char _CHARACTERE_FIN = 'E';

        private char[][] _Carte;
        private bool[][] _Parcourue;

        private int _TailleX;
        private int _TailleY;

        public Carte(char[][] pCarte)
        {
            _Carte = pCarte;
            _TailleY = _Carte.Length;
            _TailleX = _Carte.First().Length;


        }

        public Chemin ParcourirDepuisLeDepart()
        {
            Position lDepart = _DonnePositionDepart();

            return _ParcourirDepuisPosition(lDepart);
        }

        public Chemin DonneCheminLePlusCoursDepuisNimporteQuelPosition()
        {
            Chemin lMeilleurChemin = null;

            for (int lY = 0; lY < _TailleY; lY++)
            {
                for (int lX = 0; lX < _TailleX; lX++)
                {
                    char lHauteur = _DonneHauteur(new Position(lX, lY));

                    if (lHauteur == 'a')
                    {
                        char lHaut = lY == 0 ? 'a' : _DonneHauteur(new Position(lX, lY - 1));
                        char lDroite = lX + 1 >= _TailleX ? 'a' : _DonneHauteur(new Position(lX + 1, lY));
                        char lBas = lY + 1 >= _TailleY ? 'a' : _DonneHauteur(new Position(lX, lY + 1));
                        char lGauche = lX == 0 ? 'a' : _DonneHauteur(new Position(lX - 1, lY));

                        if (lHaut == 'b' || lDroite == 'b' || lBas == 'b' || lGauche == 'b')
                        {
                            Chemin lChemin = _ParcourirDepuisPosition(new Position(lX, lY));

                            if (lMeilleurChemin == null || lMeilleurChemin.DonneNiveauPlusBasALarrive() > lChemin.DonneNiveauPlusBasALarrive())
                            {
                                lMeilleurChemin = lChemin;
                            }
                        }
                    }

                }
            }


            return lMeilleurChemin;
        }

        private Chemin _ParcourirDepuisPosition(Position pPositionDepart)
        {
            _InitialiseParcourue();

            Chemin lCheminDepart = new Chemin()
            {
                CheminPrecedent = null,
                Niveau = 0,
                Hauteur = _DonneHauteur(pPositionDepart),
                Position = pPositionDepart,
                ViensDe = Mouvement.Aucun,
                EstALarrive = _EstALArrivee(pPositionDepart),
            };

            Chemin lChemin = lCheminDepart;
            _MarquerVisite(lChemin.Position);

            Queue<Chemin> lCheminsATraiter = new Queue<Chemin>();

            lCheminsATraiter.Enqueue(lChemin);

            do
            {
                if (lChemin.EstALarrive)
                {
                    return lCheminDepart;
                }

                //Chargement des enfants si pas encore passé dessue
                if (lChemin.EstParcourue == false && lChemin.CheminsSuivant.Count == 0)
                {
                    _AjouterCheminPossible(lChemin);
                    foreach (Chemin lCheminSuivant in lChemin.CheminsSuivant)
                    {
                        lCheminsATraiter.Enqueue(lCheminSuivant);
                    }

                }

                if (lCheminsATraiter.Count > 0)
                {
                    lChemin = lCheminsATraiter.Dequeue();
                }
                else
                {
                    lChemin = null;
                }


            } while (lChemin != null);

            return lCheminDepart;
        }

        private void _InitialiseParcourue()
        {
            _Parcourue = new bool[_TailleY][];
            for (int lIndex = 0; lIndex < _TailleY; lIndex++)
            {
                _Parcourue[lIndex] = new bool[_TailleX];
            }
        }

        private Position _DonnePositionDepart()
        {
            for (int lX = 0; lX < _TailleX; lX++)
            {
                for (int lY = 0; lY < _TailleY; lY++)
                {
                    if (_Carte[lY][lX] == _CHARACTERE_DEBUT)
                    {
                        return new Position(lX, lY);
                    }
                }
            }

            throw new Exception("Départ introuvable");
        }

        private char _DonneHauteur(Position pPosition)
        {
            char lHauteur = _Carte[pPosition.Y][pPosition.X];

            if (lHauteur == _CHARACTERE_DEBUT)
            {
                return 'a';
            }
            else if (lHauteur == _CHARACTERE_FIN)
            {
                return 'z';
            }

            return lHauteur;

        }



        private bool _EstALArrivee(Position pPosition)
        {
            bool lEstALarrive = _Carte[pPosition.Y][pPosition.X] == _CHARACTERE_FIN;

            return lEstALarrive;
        }

        private bool _DeplacementEstPossible(Chemin pChemin, Position pPositionDestination)
        {
            return _DeplacementEstPossible(pChemin.Position, pPositionDestination);
        }


        private bool _DeplacementEstPossible(Position pPositionSource, Position pPositionDestination)
        {
            if (pPositionDestination.X < 0 || pPositionDestination.X + 1 > _TailleX || pPositionDestination.Y < 0 || pPositionDestination.Y + 1 > _TailleY)
            {
                return false;
            }

            if (_PositionEstDejaVisite(pPositionDestination))
            {
                return false;
            }

            char lHauteur = _DonneHauteur(pPositionSource);


            if (lHauteur < 'z')
            {
                lHauteur = (char)(lHauteur + 1);
            }

            return lHauteur >= _DonneHauteur(pPositionDestination);
        }

        private bool _PositionEstDejaVisite(Position pPosition)
        {
            return _Parcourue[pPosition.Y][pPosition.X];
        }

        private void _MarquerVisite(Position pPosition)
        {
            _Parcourue[pPosition.Y][pPosition.X] = true;
        }

        private void _AjouterCheminPossible(Chemin pChemin)
        {
            //Récupération des directions possible
            Position lHaut = new Position(pChemin.Position.X, pChemin.Position.Y - 1);
            Position lDroite = new Position(pChemin.Position.X + 1, pChemin.Position.Y);
            Position lBas = new Position(pChemin.Position.X, pChemin.Position.Y + 1);
            Position lGauche = new Position(pChemin.Position.X - 1, pChemin.Position.Y);

            if (_DeplacementEstPossible(pChemin, lHaut))
            {
                pChemin.CheminsSuivant.Add(new Chemin()
                {
                    CheminPrecedent = pChemin,
                    Niveau = pChemin.Niveau + 1,
                    Hauteur = _DonneHauteur(lHaut),
                    Position = lHaut,
                    ViensDe = Mouvement.Bas,
                    EstALarrive = _EstALArrivee(lHaut),
                });
                _MarquerVisite(lHaut);
            }

            if (_DeplacementEstPossible(pChemin, lDroite))
            {
                pChemin.CheminsSuivant.Add(new Chemin()
                {
                    CheminPrecedent = pChemin,
                    Niveau = pChemin.Niveau + 1,
                    Hauteur = _DonneHauteur(lDroite),
                    Position = lDroite,
                    ViensDe = Mouvement.Gauche,
                    EstALarrive = _EstALArrivee(lDroite),
                });
                _MarquerVisite(lDroite);
            }

            if (_DeplacementEstPossible(pChemin, lBas))
            {
                pChemin.CheminsSuivant.Add(new Chemin()
                {
                    CheminPrecedent = pChemin,
                    Niveau = pChemin.Niveau + 1,
                    Hauteur = _DonneHauteur(lBas),
                    Position = lBas,
                    ViensDe = Mouvement.Haut,
                    EstALarrive = _EstALArrivee(lBas),
                });
                _MarquerVisite(lBas);
            }

            if (_DeplacementEstPossible(pChemin, lGauche))
            {
                pChemin.CheminsSuivant.Add(new Chemin()
                {
                    CheminPrecedent = pChemin,
                    Niveau = pChemin.Niveau + 1,
                    Hauteur = _DonneHauteur(lGauche),
                    Position = lGauche,
                    ViensDe = Mouvement.Droite,
                    EstALarrive = _EstALArrivee(lGauche),
                });
                _MarquerVisite(lGauche);
            }
        }
    }
}
