using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Helpers
{
    public static class MathsHelper
    {
        public static decimal PlusPetitCommunMultiplicateur(decimal pNombre1, decimal pNombre2)
        {
            return Math.Abs(pNombre1 * pNombre2) / PlusGrandCommunDiviseur(pNombre1, pNombre2);
        }

        public static decimal PlusGrandCommunDiviseur(decimal pNombre1, decimal pNombre2)
        {
            decimal lTemp = pNombre1 % pNombre2;
            if (lTemp == 0)
            {
                return pNombre2;
            }

            return PlusGrandCommunDiviseur(pNombre2, lTemp);
        }
    }
}
