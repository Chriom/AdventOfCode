using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour20
{
    [DebuggerDisplay("{IndexDepart} - {Valeur} - {EstTraitee}")]
    public class Donnees
    {
        public int IndexDepart { get; set; }
        public bool EstTraitee { get; set; }
        public decimal Valeur { get; set; }

        public Donnees Precedent { get; set; }

        public Donnees Suivant { get; set; }
    }
}
