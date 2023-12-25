using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour17
{
    public class Quartier
    {
        

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public int DeperditionChaleur { get; set; }
        

        public HashSet<string> CaseOrigine { get; set; } = new HashSet<string>();
    }
}
