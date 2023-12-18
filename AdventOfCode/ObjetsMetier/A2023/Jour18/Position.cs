using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int pX, int pY)
        {
            X = pX;
            Y = pY;
        }
    }
}
