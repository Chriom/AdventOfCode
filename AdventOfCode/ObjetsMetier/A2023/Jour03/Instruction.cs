using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour03
{
    public class Instruction
    {
        public int XDebut { get; set; }
        public int XFin { get; set; }
        public int YDebut { get; set; }
        
        public int Nombre { get; set; }
        
        public char CaractereAdjacent { get; set; } = '.';
        public int XCaractere { get; set; }
        public int YCaractere { get; set; }

        public bool PossedeUnCaractereAdjacent => CaractereAdjacent != '.';
    }
}
