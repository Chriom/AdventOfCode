using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Algorithme.BreadthFirstSearch
{
    internal class ElementBFSAParcourir<T>
    {
        public T Element { get; set; }

        public int OrigineX { get; set; }
        public int OrigineY { get; set; }
    }
}
