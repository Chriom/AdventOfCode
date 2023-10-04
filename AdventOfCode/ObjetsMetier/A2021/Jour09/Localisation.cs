using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour09
{
    [DebuggerDisplay("{X}-{Y} : {Hauteur}")]
    public class Localisation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Hauteur { get; set; }

        public bool EstLePointLePlusBas { get; set; }

        public Bassin BassinVersant { get; set; }

        public bool EstTraite { get; set; }

        public int NiveauDeRisque => EstLePointLePlusBas ? Hauteur + 1 : 0;
    }
}
