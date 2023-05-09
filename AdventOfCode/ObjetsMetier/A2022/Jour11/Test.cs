using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour11
{
    public class Test
    {
        public int DivisiblePar { get; init; }

        public int NumeroSingeSiVrai { get; init; }

        public int NumeroSingeSiFaux { get; init; }

        public int DonneSingeSuivant(decimal pNiveauInquiétude)
        {
            if (pNiveauInquiétude % DivisiblePar == 0)
            {
                return NumeroSingeSiVrai;
            }

            return NumeroSingeSiFaux;
        }
    }
}
