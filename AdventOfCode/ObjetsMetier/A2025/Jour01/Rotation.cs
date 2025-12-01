using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2025.Jour01
{
    [DebuggerDisplay("{Direction} - {Pas}")]
    public class Rotation
    {
        public Rotation() { }

        public int Pas { get; set;  }

        public DirectionRotation Direction { get; set; }

        public enum DirectionRotation
        {
            Gauche,
            Droite
        }
    }
}
