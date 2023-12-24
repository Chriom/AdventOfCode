using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.ObjetsUtilitaire
{
    [DebuggerDisplay("{X} - {Y}")]
    public class Position2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position2D(int pX, int pY)
        {
            X = pX;
            Y = pY;
        }

        public string Cle => $"{X}|{Y}";
    }
}
