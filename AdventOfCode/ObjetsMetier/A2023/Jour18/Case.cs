using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public class Case
    {
        public bool EstCreuse { get; set; }

        public Couleur Haut { get; set; }
        public Couleur Bas { get; set; }
        public Couleur Gauche { get; set; }
        public Couleur Droite { get; set; }

    }
}
