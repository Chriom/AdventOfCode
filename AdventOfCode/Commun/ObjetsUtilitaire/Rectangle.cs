using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Commun.ObjetsUtilitaire
{
    [DebuggerDisplay("{X1} {Y1} - {X2} {Y2}")]
    public class Rectangle
    {
        public Position2D Coin1 { get; private set;  }

        public Position2D Coin2 { get; private set; }

        public Rectangle(Position2D pCoin1, Position2D pCoin2)
        {
            Coin1 = pCoin1;
            Coin2 = pCoin2;
        }

        public int X1 => Math.Min(Coin1.X, Coin2.X);
        public int Y1 => Math.Min(Coin1.Y, Coin2.Y);
        public int X2 => Math.Max(Coin1.X, Coin2.X);

        public int Y2 => Math.Max(Coin1.Y, Coin2.Y);

        public int Largeur => X2 - X1;
        public int Hauteur => Y2 - Y1;

        public decimal Aire
        {
            get
            {
                int lLargeur = X2 - X1;
                int lHauteur = Math.Max(Coin1.Y, Coin2.Y) - Math.Min(Coin1.Y, Coin2.Y);

                return (decimal)Largeur * (decimal)Hauteur;
            }
        }

        public decimal AireAvecBordure
        {
            get
            {
                int lLargeur = Math.Max(Coin1.X, Coin2.X) - Math.Min(Coin1.X, Coin2.X);
                int lHauteur = Math.Max(Coin1.Y, Coin2.Y) - Math.Min(Coin1.Y, Coin2.Y);

                return (decimal)(Largeur + 1) * (decimal)(Hauteur + 1);
            }
        }
    }
}
