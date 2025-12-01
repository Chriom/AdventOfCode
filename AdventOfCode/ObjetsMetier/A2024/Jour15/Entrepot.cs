using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2024.Jour15
{
    public class Entrepot
    {
        public Element[,] PlantEntrepot;
        public int Largeur;
        public int Hauteur;

        public List<Direction> Instructions;

        private Position2D _PositionRobot;

        public Entrepot(Element[,] pEntrepot, int pLargeur, int pHauteur, List<Direction> pInstructions)
        {
            PlantEntrepot = pEntrepot;
            Largeur = pLargeur;
            Hauteur = pHauteur;
            Instructions = pInstructions;
        }

        public decimal ExecuterInstructions()
        {
            _ChercherRobot();

            foreach (Direction lDirection in Instructions)
            {
                //_DessinerEntrepot(lDirection);
                _DeplacerRobot(lDirection);
            }

            //_DessinerEntrepot(Direction.Stop);

            return _DonnerSommeCoordonneesGPS();
        }

        private void _ChercherRobot()
        {
            for (int lIndexLigne = 0; lIndexLigne < Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < Largeur; lIndexColonne++)
                {
                    if(PlantEntrepot[lIndexLigne, lIndexColonne] == Element.Robot)
                    {
                        _PositionRobot = new Position2D(lIndexColonne, lIndexLigne);
                        return;
                    }
                }
            }
        }

        private void _DeplacerRobot(Direction pDirection)
        {
            switch (pDirection)
            {
                case Direction.Haut:
                    _DeplacerRobotVertical(-1);
                    break;
                case Direction.Droite:
                    _DeplacerRobotHorizontal(1);
                    break;
                case Direction.Bas:
                    _DeplacerRobotVertical(1);
                    break;
                case Direction.Gauche:
                    _DeplacerRobotHorizontal(-1);
                    break;
            }
        }

        private void _DeplacerRobotVertical(int pIncrementPosition)
        {
            int lIndexArret = _PositionRobot.Y;
            Element lElementPrecedent = Element.Robot;

            while (lIndexArret > 0 && lIndexArret < Hauteur - 1)
            {
                if (PlantEntrepot[lIndexArret + pIncrementPosition, _PositionRobot.X] == Element.Vide && lElementPrecedent == Element.Vide)
                {
                    //Deux vide : on sort au précédent
                    break;
                }
                else if (PlantEntrepot[lIndexArret + pIncrementPosition, _PositionRobot.X] == Element.Vide && (lElementPrecedent == Element.Boite || lElementPrecedent == Element.Robot))
                {
                    //Vide avec robot ou boite précédent : ça va pas plus loin
                    lIndexArret += pIncrementPosition;
                    break;
                }
                else if (PlantEntrepot[lIndexArret + pIncrementPosition, _PositionRobot.X] == Element.Vide)
                {
                    lElementPrecedent = Element.Vide;
                    lIndexArret += pIncrementPosition;
                }
                else if(PlantEntrepot[lIndexArret + pIncrementPosition, _PositionRobot.X] == Element.Mur)
                {
                    //Mur : on sort
                    break;
                }
                else if(PlantEntrepot[lIndexArret + pIncrementPosition, _PositionRobot.X] == Element.Boite)
                {
                    lElementPrecedent = Element.Boite;
                    lIndexArret += pIncrementPosition;
                }
            }

            //Déplacer les éléments
            bool lDeplacement = false;

            for (int lIndexDeplacement = lIndexArret; lIndexDeplacement != _PositionRobot.Y; lIndexDeplacement -= pIncrementPosition)
            {
                if (PlantEntrepot[lIndexDeplacement, _PositionRobot.X] == Element.Vide)
                {
                    lDeplacement = true;
                    PlantEntrepot[lIndexDeplacement, _PositionRobot.X] = PlantEntrepot[lIndexDeplacement - pIncrementPosition, _PositionRobot.X];
                    PlantEntrepot[lIndexDeplacement - pIncrementPosition, _PositionRobot.X] = Element.Vide;
                }
            }

            if(lDeplacement)
            {
                _PositionRobot.Y = _PositionRobot.Y + pIncrementPosition;
            }
        }

        private void _DeplacerRobotHorizontal(int pIncrementPosition)
        {
            int lIndexArret = _PositionRobot.X;
            Element lElementPrecedent = Element.Robot;

            while (lIndexArret >= 0 && lIndexArret < Largeur - 1)
            {
                if (PlantEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Vide && lElementPrecedent == Element.Vide)
                {
                    //Deux vide : on sort au précédent
                    break;
                }
                else if (PlantEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Vide && (lElementPrecedent == Element.Boite || lElementPrecedent == Element.Robot))
                {
                    //Vide avec robot ou boite précédent : ça va pas plus loin
                    lIndexArret += pIncrementPosition;
                    break;
                }
                else if (PlantEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Vide)
                { 
                    lElementPrecedent = Element.Vide;
                    lIndexArret += pIncrementPosition;
                }
                else if (PlantEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Mur)
                {
                    //Mur : on sort
                    break;
                }
                else if (PlantEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Boite)
                {
                    lElementPrecedent = Element.Boite;
                    lIndexArret += pIncrementPosition;
                }
            }

            //Déplacer les éléments
            bool lDeplacement = false;

            for (int lIndexDeplacement = lIndexArret; lIndexDeplacement != _PositionRobot.X; lIndexDeplacement -= pIncrementPosition)
            {
                if (PlantEntrepot[_PositionRobot.Y, lIndexDeplacement] == Element.Vide)
                {
                    lDeplacement = true;
                    PlantEntrepot[_PositionRobot.Y, lIndexDeplacement] = PlantEntrepot[_PositionRobot.Y, lIndexDeplacement - pIncrementPosition];
                    PlantEntrepot[_PositionRobot.Y, lIndexDeplacement - pIncrementPosition] = Element.Vide;
                }
            }

            if(lDeplacement)
            {
                _PositionRobot.X = _PositionRobot.X + pIncrementPosition;
            }
        }

        private decimal _DonnerSommeCoordonneesGPS()
        {
            decimal lTotal = 0;

            for (int lIndexLigne = 0; lIndexLigne < Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < Largeur; lIndexColonne++)
                {
                    if (PlantEntrepot[lIndexLigne, lIndexColonne] == Element.Boite)
                    {
                        lTotal +=  100 * lIndexLigne + lIndexColonne;
                    }
                }
            }

            return lTotal;
        }

        private void _DessinerEntrepot(Direction pDirection)
        {
            Console.WindowHeight = Hauteur + 5;
            Console.WindowWidth = Largeur + 15;
            Console.SetCursorPosition(0, 0);
            
            for (int lIndexLigne = 0; lIndexLigne < Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < Largeur; lIndexColonne++)
                {
                    switch(PlantEntrepot[lIndexLigne, lIndexColonne])
                    {
                        case Element.Vide:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                            break;
                        case Element.Mur:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("#");
                            break;
                        case Element.Boite:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("O");
                            break;
                        case Element.Robot:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("@");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Direction : {pDirection}");

            //Thread.Sleep(100);
            //Console.ReadLine();
        }
    }
}
