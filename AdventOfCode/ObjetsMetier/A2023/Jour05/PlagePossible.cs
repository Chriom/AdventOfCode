using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Utilitaires;

namespace AdventOfCode.ObjetsMetier.A2023.Jour05
{
    public class PlagePossible
    {
        public PlageValeur<decimal> Source { get; set; }
        public PlageValeur<decimal> Destination { get; set; }

        public decimal Longueur { get; set; }
    }
}
