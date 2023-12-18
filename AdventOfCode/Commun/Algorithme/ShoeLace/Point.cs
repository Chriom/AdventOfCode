using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Algorithme.ShoeLace
{
    public class Point
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public Point(decimal pX, decimal pY)
        {
            X = pX;
            Y = pY;
        }
    }
}
