using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour05
{
    public class Ligne
    {
        public int X1 { get; init; }
        public int Y1 { get; init; }

        public int X2 { get; init; }
        public int Y2 { get; init; }

        public Ligne(int pX1, int pY1, int pX2, int pY2)
        {
            X1 = pX1;
            Y1 = pY1;
            X2 = pX2;
            Y2 = pY2;
        }
                
        public bool EstHorizontale => Y1 == Y2;
        public bool EstVerticale => X1 == X2;
        public bool EstHorizontaleOuVerticale => EstHorizontale || EstVerticale;
    }
}
