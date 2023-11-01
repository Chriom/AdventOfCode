using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour09
{
    public class Bassin
    {
        public int NumeroBassin { get; set; }
        public List<Localisation> Localisations { get; set; } = new List<Localisation>();

        public int Taille => Localisations.Count;
    }
}
