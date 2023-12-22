using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.ObjetsUtilitaire
{
    [DebuggerDisplay("{X} - {Y} - {Z}")]
    public class Position3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position3D(int pX, int pY, int pZ)
        {
            X = pX;
            Y = pY;
            Z = pZ;
        }
    }
}
