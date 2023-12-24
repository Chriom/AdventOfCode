using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour24
{
    [DebuggerDisplay("{X}x + {Y}y + {C} = 0")]
    public class EquationLigne
    {
        /// <summary>
        ///De la forme aX + bY + C = 0
        /// </summary>
        public EquationLigne()
        {

        }

        public decimal X { get; private set; }
        public decimal Y { get; private set; }        
        public decimal C { get; private set; }

        public static EquationLigne EquationDepuisDeuxPositions(Position2D<decimal> pPosition1, Position2D<decimal> pPosition2)
        {
            //https://www.omnicalculator.com/math/line-equation-from-two-points

            EquationLigne lEquation = new EquationLigne();

            lEquation.X = pPosition2.Y - pPosition1.Y;
            lEquation.Y = pPosition1.X - pPosition2.X;
            lEquation.C = pPosition1.Y * (pPosition2.X - pPosition1.X) - (pPosition2.Y - pPosition1.Y) * pPosition1.X;

            return lEquation;
        }

        public Position2D<decimal> DonnePointIntersection(EquationLigne pLigneTest)
        {
            //https://www.omnicalculator.com/math/intersection-of-two-lines

            decimal lDenominateur = this.X * pLigneTest.Y - pLigneTest.X * this.Y;

            if(lDenominateur == 0)
            {
                //Lignes parallèle
                return null;
            }

            decimal lX = (this.Y*pLigneTest.C - pLigneTest.Y*this.C) / lDenominateur;

            decimal lY = (this.C * pLigneTest.X - pLigneTest.C * this.X) / lDenominateur;

            return new Position2D<decimal>(lX, lY);
        }
    }
}
