using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour05
{
    [DebuggerDisplay("{CategorieDepart} => {CategorieArrivé}")]
    public class Carte
    {
        public Categorie CategorieDepart { get; set; }
        public Categorie CategorieArrivé { get; set; }

        public List<PlagePossible> PlagesPossible { get; set; } = new List<PlagePossible>();
    }
}
