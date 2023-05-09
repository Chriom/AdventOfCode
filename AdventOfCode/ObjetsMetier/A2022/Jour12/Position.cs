using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour12
{
    [DebuggerDisplay("{X} - {Y}")]
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
