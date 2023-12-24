using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.ObjetsUtilitaire
{
    public class Vecteur3D<T> where T : INumber<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public T Z { get; set; }

        public Vecteur3D(T pX, T pY, T pZ)
        {
            X = pX;
            Y = pY;
            Z = pZ;
        }
    }
}
