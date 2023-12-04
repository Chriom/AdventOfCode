using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour04
{
    public class Partie
    {
        public int NumeroPartie { get; set; }

        public List<int> NumeroCartes { get; set; } = new List<int>();

        public List<int> NumeroValide { get; set; } = new List<int>();

        public int DonneNombreDeCarteValide()
        {
            return NumeroCartes.Intersect(NumeroValide).Count();
        }
    }
}
