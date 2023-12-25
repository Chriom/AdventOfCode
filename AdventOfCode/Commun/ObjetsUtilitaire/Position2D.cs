using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.ObjetsUtilitaire
{
    [DebuggerDisplay("{X} - {Y}")]
    public class Position2D<T> where T : INumber<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public Position2D(T pX, T pY)
        {
            X = pX;
            Y = pY;
        }

        public string Cle => $"{X}|{Y}";
    }


    public class Position2D : Position2D<int>
    {
        public Position2D(int pX, int pY) : base(pX, pY)
        {
        }
    }
}
