using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Algorithme.ShoeLace
{
    public static class ShoeLace
    {

        public static decimal CalculerAire(List<Point> pPoints)
        {
            //https://en.wikipedia.org/wiki/Shoelace_formula#Shoelace_formula

            if(pPoints.Count <= 2)
            {
                throw new Exception("Impossible de calculer l'aire");
            }

            decimal lTotal = 0;

            for(int lIndex = 0; lIndex < pPoints.Count - 1; lIndex++)
            {
                lTotal += _SommeDeterminant(pPoints[lIndex], pPoints[lIndex + 1]);
            }

            //Le dernier avec le premier
            lTotal += _SommeDeterminant(pPoints.Last(), pPoints.First());

            return Math.Abs(lTotal / 2);
        }

        private static decimal _SommeDeterminant(Point pPoint1, Point pPoint2)
        {
            checked
            {
                return pPoint1.X * pPoint2.Y - pPoint1.Y * pPoint2.X;
            }
            
        }
    }
}
