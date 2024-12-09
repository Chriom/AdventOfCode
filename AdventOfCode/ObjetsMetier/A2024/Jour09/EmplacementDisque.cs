using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour09
{
    [DebuggerDisplay("{Fichier?.Identifiant}-{Block}")]
    public class EmplacementDisque
    {
        public Fichier Fichier { get; set; }

        public int Block { get; set; }
    }
}
