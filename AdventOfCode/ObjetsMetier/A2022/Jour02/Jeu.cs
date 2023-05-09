using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;

namespace AdventOfCode.ObjetsMetier.A2022.Jour02
{
    public class Jeu
    {
        public Forme Opposant { get; init; }
        public Forme Joueur { get; set; }

        public EtatPartie EtatPartieTour2 { get; init; }




        public Jeu(Forme pFormeOpposant, Forme pFormeJoueurTour1, EtatPartie pResultatTour2)
        {
            Opposant = pFormeOpposant;
            Joueur = pFormeJoueurTour1;

            EtatPartieTour2 = pResultatTour2;
        }

        public bool EstGagnant
        {
            get
            {
                if (Opposant == Forme.Pierre && Joueur == Forme.Papier ||
                    Opposant == Forme.Papier && Joueur == Forme.Ciseau ||
                    Opposant == Forme.Ciseau && Joueur == Forme.Pierre)
                {
                    return true;
                }

                return false;
            }
        }

        public bool EstEgalite
        {
            get
            {
                return Opposant == Joueur;
            }
        }

        public int ScoreForme
        {
            get
            {
                switch (Joueur)
                {
                    case Forme.Pierre:
                        return 1;
                    case Forme.Papier:
                        return 2;
                    case Forme.Ciseau:
                        return 3;
                }

                return -1;
            }
        }

        public int ScoreVictoire
        {
            get
            {
                if (EstGagnant)
                {
                    return 6;
                }
                else if (EstEgalite)
                {
                    return 3;
                }
                return 0;
            }
        }

        public int Score
        {
            get
            {
                return ScoreForme + ScoreVictoire;
            }
        }

        public void ChangerJeuJoueurPourEtat()
        {
            switch (EtatPartieTour2)
            {
                case EtatPartie.Egalite:
                    Joueur = Opposant;
                    break;
                case EtatPartie.Perdue:
                    {
                        switch (Opposant)
                        {
                            case Forme.Pierre:
                                Joueur = Forme.Ciseau;
                                break;
                            case Forme.Papier:
                                Joueur = Forme.Pierre;
                                break;
                            case Forme.Ciseau:
                                Joueur = Forme.Papier;
                                break;
                        }
                    }
                    break;
                case EtatPartie.Victoire:
                    {
                        switch (Opposant)
                        {
                            case Forme.Pierre:
                                Joueur = Forme.Papier;
                                break;
                            case Forme.Papier:
                                Joueur = Forme.Ciseau;
                                break;
                            case Forme.Ciseau:
                                Joueur = Forme.Pierre;
                                break;
                        }
                    }
                    break;
            }
        }

    }
}
