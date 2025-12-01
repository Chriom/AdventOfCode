using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.ObjetsMetier.A2023.Jour23;

namespace AdventOfCode.ObjetsMetier.A2024.Jour16
{
    public class Labyrinthe
    {
        private TypeCase[][] _Labyrinthe { get; set; }
        private int _Hauteur;
        private int _Largeur;

        private CaseLabyrinthe[][] _LabyrintheBFS { get; set; }

        public Labyrinthe(TypeCase[][] pLabyrinthe)
        {
            _Labyrinthe = pLabyrinthe;

            _TransformerLabyrinthe();
        }

        private void _TransformerLabyrinthe()
        {
            _Hauteur = _Labyrinthe.Length;
            _Largeur = _Labyrinthe[0].Length;

            _LabyrintheBFS = new CaseLabyrinthe[_Hauteur][];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                _LabyrintheBFS[lIndexLigne] = new CaseLabyrinthe[_Largeur];
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    _LabyrintheBFS[lIndexLigne][lIndexColonne] = new CaseLabyrinthe()
                    {
                        TypeDeCase = _Labyrinthe[lIndexLigne][lIndexColonne],
                        PositionX = lIndexColonne,
                        PositionY = lIndexLigne,
                    };
                }
            }
        }


        public int DonneValeurMeilleurChemin()
        {
            BreadthFirstSearch<CaseLabyrinthe> lBfs = new BreadthFirstSearch<CaseLabyrinthe>(_LabyrintheBFS);
            ParcoursBFS<CaseLabyrinthe> lParcours = lBfs.ParcourirDepuisLeDepart();


            return lParcours.Cases.SelectMany(o => o)
                                  .First(o => o.TypeDeCase == TypeCase.Sortie)
                                  .Score;
        }

        public int DonneNombreDeMeilleurBanc()
        {
            BreadthFirstSearch<CaseLabyrinthe> lBfs = new BreadthFirstSearch<CaseLabyrinthe>(_LabyrintheBFS);
            ParcoursBFS<CaseLabyrinthe> lParcours = lBfs.ParcourirDepuisLeDepart();

            int lScoreMax = lParcours.Cases.SelectMany(o => o).First(o => o.TypeDeCase == TypeCase.Sortie).Score;

            Queue<LabyrintheHistorique> lATraiter = new Queue<LabyrintheHistorique>();

            HashSet<string> lMauvaisesRoutes = new HashSet<string>();

            CaseLabyrinthe lCase = lParcours.Cases.SelectMany(o => o).First(o => o.EstAuDepart);

            LabyrintheHistorique lHistoriqueATraiter = new LabyrintheHistorique(_Hauteur, _Largeur)
            {
                PositionCourante = new Commun.ObjetsUtilitaire.Position2D(lCase.PositionX, lCase.PositionY),
                DirectionCourante = Direction.Droite,
                ScoreCourant = 0,
            };

            lHistoriqueATraiter.CleCreation = $"{lHistoriqueATraiter.PositionCourante.X} --- {lHistoriqueATraiter.PositionCourante.Y} --- {lHistoriqueATraiter.DirectionCourante}";

            lHistoriqueATraiter.Parcouru[lCase.PositionY, lCase.PositionX] = true;

            List<LabyrintheHistorique> lHistoriquesAuBout = new List<LabyrintheHistorique>();
            
            do
            {
                List<(int Score, Position2D Position, Direction Direction)> lSuivants = new List<(int, Position2D, Direction)>();

                if (_LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X].TypeDeCase == TypeCase.Sortie)
                {
                    //Arrivé dans un bout
                    if (lHistoriqueATraiter.ScoreCourant == lScoreMax)
                    {
                        lHistoriquesAuBout.Add(lHistoriqueATraiter);
                    }
                }
                else if (lMauvaisesRoutes.Contains(lHistoriqueATraiter.CleCreation))
                {
                    //Passe au suivant
                    string x = "nop";
                }
                else
                {
                    //Case suivant la direction
                    CaseLabyrinthe lCaseDirection = lHistoriqueATraiter.DirectionCourante switch
                    {
                        Direction.Haut => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y - 1][lHistoriqueATraiter.PositionCourante.X],
                        Direction.Bas => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y + 1][lHistoriqueATraiter.PositionCourante.X],
                        Direction.Droite => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X + 1],
                        Direction.Gauche => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X - 1],
                        _ => throw new NotImplementedException()
                    };

                    if (lCaseDirection.TypeDeCase != TypeCase.Mur && lHistoriqueATraiter.Parcouru[lCaseDirection.PositionY, lCaseDirection.PositionX] == false && lCaseDirection.Score < int.MaxValue)
                    {
                        lSuivants.Add((1, new Position2D(lCaseDirection.PositionX, lCaseDirection.PositionY), lHistoriqueATraiter.DirectionCourante));
                    }

                    //90° a gauche
                    CaseLabyrinthe lCase90Gauche = lHistoriqueATraiter.DirectionCourante switch
                    {
                        Direction.Haut => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X - 1],
                        Direction.Bas => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X + 1],
                        Direction.Droite => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y - 1][lHistoriqueATraiter.PositionCourante.X],
                        Direction.Gauche => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y + 1][lHistoriqueATraiter.PositionCourante.X],
                        _ => throw new NotImplementedException()
                    };

                    if (lCase90Gauche.TypeDeCase != TypeCase.Mur && lHistoriqueATraiter.Parcouru[lCase90Gauche.PositionY, lCase90Gauche.PositionX] == false && lCase90Gauche.Score < int.MaxValue)
                    {
                        lSuivants.Add((1001, new Position2D(lCase90Gauche.PositionX, lCase90Gauche.PositionY), _DonneDirection(lHistoriqueATraiter.DirectionCourante, -1)));
                    }

                    //90° a droite
                    CaseLabyrinthe lCase90Droite = lHistoriqueATraiter.DirectionCourante switch
                    {
                        Direction.Haut => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X + 1],
                        Direction.Bas => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y][lHistoriqueATraiter.PositionCourante.X - 1],
                        Direction.Droite => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y + 1][lHistoriqueATraiter.PositionCourante.X],
                        Direction.Gauche => _LabyrintheBFS[lHistoriqueATraiter.PositionCourante.Y - 1][lHistoriqueATraiter.PositionCourante.X],
                        _ => throw new NotImplementedException()
                    };

                    if (lCase90Droite.TypeDeCase != TypeCase.Mur && lHistoriqueATraiter.Parcouru[lCase90Droite.PositionY, lCase90Droite.PositionX] == false && lCase90Droite.Score < int.MaxValue)
                    {
                        lSuivants.Add((1001, new Position2D(lCase90Droite.PositionX, lCase90Droite.PositionY), _DonneDirection(lHistoriqueATraiter.DirectionCourante, 1)));
                    }


                    if (lSuivants.Count == 1)
                    {
                        //Juste un on repart dans le même
                        var lSuivant = lSuivants.First();
                        lHistoriqueATraiter.ScoreCourant += lSuivant.Score;
                        lHistoriqueATraiter.PositionCourante = lSuivant.Position;
                        lHistoriqueATraiter.DirectionCourante = lSuivant.Direction;
                        lHistoriqueATraiter.Parcouru[lSuivant.Position.Y, lSuivant.Position.X] = true;

                        continue;
                    }
                    else
                    {
                        //Intersection : on copie et traite la suite
                        foreach (var lSuivant in lSuivants)
                        {
                            LabyrintheHistorique lNouveau = lHistoriqueATraiter.CopieInstance();
                            lNouveau.ScoreCourant += lSuivant.Score;
                            lNouveau.PositionCourante = lSuivant.Position;
                            lNouveau.DirectionCourante = lSuivant.Direction;
                            lNouveau.Parcouru[lSuivant.Position.Y, lSuivant.Position.X] = true;
                            lNouveau.CleCreation = $"{lNouveau.PositionCourante.X} --- {lNouveau.PositionCourante.Y} --- {lNouveau.DirectionCourante}";

                            if (lNouveau.ScoreCourant <= lScoreMax && lMauvaisesRoutes.Contains(lNouveau.CleCreation) == false)
                            {
                                lATraiter.Enqueue(lNouveau);
                            }
                        }
                    }

                    if (lSuivants.Count == 0)
                    {
                        //Plus de suivant et pas à la fin
                        lMauvaisesRoutes.Add(lHistoriqueATraiter.CleCreation);
                    }
                }
                
               


                if ((lSuivants.Count != 1 && lATraiter.Count > 0))
                {
                    lHistoriqueATraiter = lATraiter.Dequeue();
                }
                else
                {
                    lHistoriqueATraiter = null;
                }


            } while (lHistoriqueATraiter != null);


            //Nombre de case
            HashSet<string> lParcouru = new HashSet<string>();

            foreach(LabyrintheHistorique lHistorique in lHistoriquesAuBout)
            {
                for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
                {
                    for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                    {
                        if (lHistorique.Parcouru[lIndexLigne, lIndexColonne])
                        {
                            lParcouru.Add($"{lIndexLigne} --- {lIndexColonne}");
                        }
                    }
                }
            }



            return lParcouru.Count;
        }

        private Direction _DonneDirection(Direction pDirection, int pPas)
        {
            int lDirection = (int)pDirection + pPas;

            if (lDirection < 0)
            {
                lDirection = 3;
            }
            else if (lDirection > 3)
            {
                lDirection = 0;
            }

            return (Direction)lDirection;
        }

        public int DonneNombreDeMeilleurSiege()
        {
            BreadthFirstSearch<CaseLabyrinthe> lBfs = new BreadthFirstSearch<CaseLabyrinthe>(_LabyrintheBFS);
            ParcoursBFS<CaseLabyrinthe> lParcours = lBfs.ParcourirDepuisLeDepart();

            //Convertion du parcour
            CaseAvecBanc[][] lParcoursInverse = new CaseAvecBanc[_Hauteur][];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++) 
            {
                lParcoursInverse[lIndexLigne] = new CaseAvecBanc[_Largeur];

                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    CaseLabyrinthe lCase = lParcours.Cases[lIndexLigne][lIndexColonne];

                    lParcoursInverse[lIndexLigne][lIndexColonne] = new CaseAvecBanc()
                    {
                        Direction = lCase.Direction,
                        PositionX = lCase.PositionX,
                        PositionY = lCase.PositionY,
                        Score = lCase.Score,
                        TypeDeCase = lCase.TypeDeCase,
                    };
                }
            }

            BreadthFirstSearch<CaseAvecBanc> lBfsRetour = new BreadthFirstSearch<CaseAvecBanc>(lParcoursInverse);

            ParcoursBFS<CaseAvecBanc> lResultat = lBfsRetour.ParcourirDepuisLeDepart();

            string lBordel = "";

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                string lLigne = "";
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    CaseAvecBanc lCase = lResultat.Cases[lIndexLigne][lIndexColonne];

                    //if(lCase.TypeDeCase == TypeCase.Mur)
                    //{
                    //    lLigne += "#";
                    //}
                    //else
                    //{
                    //    lLigne += lCase.EstVisitee ? "o" : ".";
                    //}

                    if(lCase.TypeDeCase == TypeCase.Mur)
                    {
                        lLigne += "####\t######\t";
                    }
                    else
                    {
                        lLigne += lCase.EstVisitee ? "o " : "_ ";

                        lLigne += lCase.Direction switch
                        {
                            Direction.Haut => "^ \t",
                            Direction.Droite => "> \t",
                            Direction.Bas => "v \t",
                            Direction.Gauche => "< \t",
                        };

                        if (lCase.Score != int.MaxValue)
                        {
                            lLigne += lCase.Score.ToString("D6") + "\t";
                        }
                        else
                        {
                            lLigne += "      \t";
                        }
                    }

                    
                }

                lBordel += lLigne + "\r\n";
            }

            return lResultat.Cases.SelectMany(o => o)
                                  .Count(o => o.EstVisitee);
        }
    }
}
