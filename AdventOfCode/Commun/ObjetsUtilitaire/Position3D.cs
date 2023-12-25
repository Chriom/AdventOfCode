﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.ObjetsUtilitaire
{
    [DebuggerDisplay("{X} - {Y} - {Z}")]
    public class Position3D<T> where T : INumber<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }

        public Position3D(T pX, T pY, T pZ)
        {
            X = pX;
            Y = pY;
            Z = pZ;
        }

        public string Cle => $"{X}|{Y}|{Z}";
    }



    public class Position3D : Position3D<int>
    {
        public Position3D(int pX, int pY, int pZ) : base(pX, pY, pZ)
        {
        }
    }
}
