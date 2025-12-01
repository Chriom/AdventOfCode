using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour12
{
    [DebuggerDisplay("{X} - {Y} - coins : {NombreCoin}")]
    public class Parcelle
    {
        public char Valeur { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int NombreAdjacentRegionDifferente { get; set; }

        public int NombreCoin { get; set; }

        public Region RegionAffectee { get; set; }

        public bool EstTraitee { get; set; }
    }
}
