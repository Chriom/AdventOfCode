using AdventOfCode.Commun.Helpers;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.Commun.Utilitaires;

namespace AdventOfCode.ObjetsMetier.A2025.Jour09
{
    public class FaiseurDeRectangle
    {
        private List<Position2D> _PositionCaseRouge;

        private List<Rectangle> _Rectangles;

        private List<Rectangle> _Bordures;

        private Dictionary<int, int> _CorrespondanceX;
        private Dictionary<int, int> _CorrespondanceXInverse;
        private Dictionary<int, int> _CorrespondanceY;
        private Dictionary<int, int> _CorrespondanceYInverse;

        private List<Position2D> _PositionsReduite;
        private List<Rectangle> _RectangleReduit;

        private Case[,] _PositionsValide;

        public FaiseurDeRectangle(List<Position2D> pPositionCaseRouge)
        {
            _PositionCaseRouge = pPositionCaseRouge;

            _CreerRectangles();
        }

        public decimal DonneAirePlusGrandRectangle()
        {
            return _Rectangles.Max(o => o.AireAvecBordure);
        }

        public decimal DonneAirePlusGrandRectangleAvecReglesALaCon()
        {
            _ReduirePositions();
            _RemplirGrille();

            foreach(Rectangle lRectangle in _Rectangles.OrderByDescending(o => o.AireAvecBordure))
            {
                Rectangle lRectangleReduit = new Rectangle(new Position2D(_CorrespondanceXInverse[lRectangle.Coin1.X], _CorrespondanceYInverse[lRectangle.Coin1.Y]), new Position2D(_CorrespondanceXInverse[lRectangle.Coin2.X], _CorrespondanceYInverse[lRectangle.Coin2.Y]));

                if (_RectangleEstValide(lRectangleReduit))
                {
                    return lRectangle.AireAvecBordure;
                }
            }

            throw new Exception("Aucun rectangle valide trouvé");
        }

        private void _CreerRectangles()
        {
            _Rectangles = new List<Rectangle>();

            for (int lIndex = 0; lIndex < _PositionCaseRouge.Count - 1; lIndex++)
            {
                for (int lIndex2 = lIndex + 1; lIndex2 < _PositionCaseRouge.Count; lIndex2++)
                {
                    _Rectangles.Add(new Rectangle(_PositionCaseRouge[lIndex], _PositionCaseRouge[lIndex2]));
                }
            }
        }

        

        private void _ReduirePositions()
        {
            _CorrespondanceX = new Dictionary<int, int>();
            _CorrespondanceXInverse = new Dictionary<int, int>();
            _CorrespondanceY = new Dictionary<int, int>();
            _CorrespondanceYInverse = new Dictionary<int, int>();

            _PositionsReduite = new List<Position2D>();

            int lIndex = 1;
            foreach(Position2D lPosition in _PositionCaseRouge.OrderBy(o => o.X))
            {
                if(_CorrespondanceXInverse.TryAdd(lPosition.X, lIndex))
                {
                    _CorrespondanceX.Add(lIndex, lPosition.X);
                    lIndex+=2;
                }
            }

            lIndex = 1;

            foreach (Position2D lPosition in _PositionCaseRouge.OrderBy(o => o.Y))
            {
                if(_CorrespondanceYInverse.TryAdd(lPosition.Y, lIndex))
                {
                    _CorrespondanceY.Add(lIndex, lPosition.Y);
                    lIndex += 2;
                }                
            }

            foreach(Position2D lPosition in _PositionCaseRouge)
            {
                _PositionsReduite.Add(new Position2D(_CorrespondanceXInverse[lPosition.X], _CorrespondanceYInverse[lPosition.Y]));
            }
        }

        private void _RemplirGrille()
        {
            int lLargeur = _PositionsReduite.Max(o => o.X) + 1;
            int lHauteur = _PositionsReduite.Max(o => o.Y) + 1;

            _PositionsValide = new Case[lLargeur, lHauteur];


            //Les contours
            Position2D lPositionPrecedente = _PositionsReduite.Last();
            _PositionsValide[lPositionPrecedente.X, lPositionPrecedente.Y] = Case.Rouge;

            for (int lIndexPosition = 0; lIndexPosition < _PositionsReduite.Count; lIndexPosition++)
            {
                Position2D lPosition = _PositionsReduite[lIndexPosition];

                _PositionsValide[lPosition.X, lPosition.Y] = Case.Rouge;


                if(lPositionPrecedente.X == lPosition.X)
                {
                    for(int lLigne = Math.Min(lPositionPrecedente.Y, lPosition.Y); lLigne <= Math.Max(lPositionPrecedente.Y, lPosition.Y); lLigne++)
                    {
                        Case lCase = _PositionsValide[lPosition.X, lLigne];

                        if(lCase == Case.Vide)
                        {
                            _PositionsValide[lPosition.X, lLigne] = Case.Vert;
                        }
                    }
                }
                else
                {
                    for (int lColonne = Math.Min(lPositionPrecedente.X, lPosition.X); lColonne <= Math.Max(lPositionPrecedente.X, lPosition.X); lColonne++)
                    {
                        Case lCase = _PositionsValide[lColonne, lPosition.Y];

                        if (lCase == Case.Vide)
                        {
                            _PositionsValide[lColonne, lPosition.Y] = Case.Vert;
                        }
                    }
                }


                lPositionPrecedente = lPosition;
            }

            //Le remplissage
            Queue<Position2D> lATraiter = new Queue<Position2D>();


            //Recherche d'un point au milieu
            for(int lIndexLigne = 0; lIndexLigne < lHauteur - 1; lIndexLigne++)
            {
                for(int lIndexColonne = 0; lIndexColonne < lLargeur - 1; lIndexColonne++)
                {
                    Case lCase = _PositionsValide[lIndexColonne, lIndexLigne];

                    if(lCase == Case.Rouge || lCase == Case.Vert)
                    {
                        Case lCaseDroite = _PositionsValide[lIndexColonne + 1, lIndexLigne];

                        if(lCaseDroite == Case.Vide)
                        {
                            lATraiter.Enqueue(new Position2D(lIndexColonne + 1, lIndexLigne));
                        }


                        break;
                    }
                }

                if(lATraiter.Count > 0)
                {
                    break;
                }
            }


            //Flood Fill
            Position2D lPositionActuelle = lATraiter.Dequeue();

            do
            {
                Case lActuelle = _PositionsValide[lPositionActuelle.X, lPositionActuelle.Y];

                if (lActuelle == Case.Vide)
                {
                    _PositionsValide[lPositionActuelle.X, lPositionActuelle.Y] = Case.Rempli;

                    if (lPositionActuelle.X > 0 && _PositionsValide[lPositionActuelle.X - 1, lPositionActuelle.Y] == Case.Vide)
                    {
                        lATraiter.Enqueue(new Position2D(lPositionActuelle.X - 1, lPositionActuelle.Y));
                    }
                    if (lPositionActuelle.X < lLargeur - 1 && _PositionsValide[lPositionActuelle.X + 1, lPositionActuelle.Y] == Case.Vide)
                    {
                        lATraiter.Enqueue(new Position2D(lPositionActuelle.X + 1, lPositionActuelle.Y));
                    }
                    if (lPositionActuelle.Y > 0 && _PositionsValide[lPositionActuelle.X, lPositionActuelle.Y - 1] == Case.Vide)
                    {
                        lATraiter.Enqueue(new Position2D(lPositionActuelle.X, lPositionActuelle.Y - 1));
                    }
                    if (lPositionActuelle.Y < lHauteur - 1 && _PositionsValide[lPositionActuelle.X, lPositionActuelle.Y + 1] == Case.Vide)
                    {
                        lATraiter.Enqueue(new Position2D(lPositionActuelle.X, lPositionActuelle.Y + 1));
                    }
                }


                


                if (lATraiter.Count > 0)
                {
                    lPositionActuelle = lATraiter.Dequeue();
                }
                else
                {
                    lPositionActuelle = null;
                }

            } while (lPositionActuelle != null);



            //for(int lIndexLigne = 0; lIndexLigne < lHauteur; lIndexLigne++)
            //{
            //    for(int lIndexColonne = 0; lIndexColonne < lLargeur; lIndexColonne++)
            //    {
            //        string lCaractere = _PositionsValide[lIndexColonne, lIndexLigne] switch
            //        {
            //            Case.Vide => ".",
            //            Case.Rouge => "#",
            //            Case.Vert => "O",
            //            Case.Rempli => "o",
            //            _ => "",
            //        };

            //        Console.Write(lCaractere);
            //    }

            //    Console.WriteLine();
            //}
        }

        private bool _RectangleEstValide(Rectangle pRectangle)
        {
            for(int lIndexColonne = pRectangle.X1; lIndexColonne <= pRectangle.X2; lIndexColonne++)
            {
                for(int lIndexLigne = pRectangle.Y1; lIndexLigne <= pRectangle.Y2; lIndexLigne++)
                {
                    if (_PositionsValide[lIndexColonne, lIndexLigne] == Case.Vide)
                    {
                        return false;
                    }
                }
            }

            return true;
        }



    }
}

