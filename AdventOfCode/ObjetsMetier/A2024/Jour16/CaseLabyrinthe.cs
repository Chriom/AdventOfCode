using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;

namespace AdventOfCode.ObjetsMetier.A2024.Jour16
{
    public class CaseLabyrinthe : ElementBFS<CaseLabyrinthe>, IElementBFS
    {
        public TypeCase TypeDeCase { get; set; }

        public Direction Direction { get; set; } = Direction.Droite;

        public override bool EstAuDepart { get => TypeDeCase == TypeCase.Entrée; set => throw new NotImplementedException(); }

        public override bool EstALaFin => false;

        public override IEnumerable<CaseLabyrinthe> DonneElementsAccessible(ParcoursBFS<CaseLabyrinthe> pParcours, int pXPrecedent, int pYPrecedent)
        {
            //Case suivant la direction
            CaseLabyrinthe lCaseDirection = Direction switch
            {
                Direction.Haut => pParcours.Cases[PositionY - 1][PositionX],
                Direction.Bas => pParcours.Cases[PositionY + 1][PositionX],
                Direction.Droite => pParcours.Cases[PositionY][PositionX + 1],
                Direction.Gauche => pParcours.Cases[PositionY][PositionX - 1],
                _ => throw new NotImplementedException()
            };

            if (lCaseDirection.TypeDeCase != TypeCase.Mur && lCaseDirection.Score >= Score + 1)
            {
                lCaseDirection.Score = Score + 1;
                lCaseDirection.Direction = Direction;
                yield return lCaseDirection;
            }

            //90° a gauche
            CaseLabyrinthe lCase90Gauche = Direction switch
            {
                Direction.Haut => pParcours.Cases[PositionY][PositionX - 1],
                Direction.Bas => pParcours.Cases[PositionY][PositionX + 1],
                Direction.Droite => pParcours.Cases[PositionY - 1][PositionX],
                Direction.Gauche => pParcours.Cases[PositionY + 1][PositionX],
                _ => throw new NotImplementedException()
            };

            if (lCase90Gauche.TypeDeCase != TypeCase.Mur && lCase90Gauche.Score >= Score + 1001)
            {
                lCase90Gauche.Score = Score + 1001;
                lCase90Gauche.Direction = _DonneDirection(-1);
                yield return lCase90Gauche;
            }
            //90° a droite
            CaseLabyrinthe lCase90Droite = Direction switch
            {
                Direction.Haut => pParcours.Cases[PositionY][PositionX + 1],
                Direction.Bas => pParcours.Cases[PositionY][PositionX - 1],
                Direction.Droite => pParcours.Cases[PositionY + 1][PositionX],
                Direction.Gauche => pParcours.Cases[PositionY - 1][PositionX],
                _ => throw new NotImplementedException()
            };

            if (lCase90Droite.TypeDeCase != TypeCase.Mur && lCase90Droite.Score >= Score + 1001)
            {
                lCase90Droite.Score = Score + 1001;
                lCase90Droite.Direction = _DonneDirection(1);
                yield return lCase90Droite;
            }

        }

        private Direction _DonneDirection(int pPas)
        {
            int lDirection = (int)Direction + pPas;

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

        private int _Score = int.MaxValue;

        public int Score { get => EstAuDepart ? 0 : _Score; set => _Score = value; }

        public override bool EstVisitee => false;

        public override string ToString()
        {
            //switch(TypeDeCase)
            //{
            //    case TypeCase.Mur:
            //        return "#";
            //    default:
            //        return Score < int.MaxValue ? "x" : ".";

            //}

            switch (TypeDeCase)
            {
                case TypeCase.Mur:
                    return "#########";
                default:
                    string lDirection = Direction switch
                    {
                        Direction.Haut => "^",
                        Direction.Bas => "v",
                        Direction.Droite => ">",
                        Direction.Gauche => "<",
                        _ => throw new NotImplementedException()
                    };

                    return Score < int.MaxValue ? "." + lDirection + "." + Score.ToString("D5") + "." : ".........";

            }
        }
    }
}
