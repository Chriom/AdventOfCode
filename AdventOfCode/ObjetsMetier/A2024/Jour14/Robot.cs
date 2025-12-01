using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2024.Jour14
{
    public class Robot
    {
        public Position2D Position { get; private set; }

        public Position2D Deplacement { get; private set; }

        public Robot(Position2D pPosition, Position2D pDeplacement)
        {
            Position = pPosition;
            Deplacement = pDeplacement;
        }

        public void Deplacer(int pLargeur, int pHauteur)
        {
            int lNouveauX = Position.X + Deplacement.X;

            if(lNouveauX < 0)
            {
                lNouveauX = pLargeur + lNouveauX;
            }
            else if(lNouveauX >= pLargeur)
            {
                lNouveauX = lNouveauX - pLargeur;
            }
            Position.X = lNouveauX;

            int lNouveauY = Position.Y + Deplacement.Y;

            if(lNouveauY < 0)
            {
                lNouveauY = pHauteur + lNouveauY;
            }
            else if (lNouveauY >= pHauteur)
            {
                lNouveauY = lNouveauY - pHauteur;
            }

            Position.Y = lNouveauY;
        }
    }
}
