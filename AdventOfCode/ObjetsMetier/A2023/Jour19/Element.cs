using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour19
{
    public class Element
    {
        public int ExtremementBeauARegarder { get; set; }
        public int Musical { get; set; }
        public int Aerodynamique { get; set; }
        public int Brillant { get; set; }

        public int SommeTotal => ExtremementBeauARegarder + Musical + Aerodynamique + Brillant;
    }
}
