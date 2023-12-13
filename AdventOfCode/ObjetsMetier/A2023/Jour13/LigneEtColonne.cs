using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour13
{
    [DebuggerDisplay("{Id} - {Hash}")]
    public class LigneEtColonne
    {
        public int Id { get; set; }
        public int Hash { get; set; }

        public LigneOuColonne Type { get; set; }
    }
}
