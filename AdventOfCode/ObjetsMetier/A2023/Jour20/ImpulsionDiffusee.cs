using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    public class ImpulsionDiffusee
    {
        public TypeImpulsion Impulsion { get; set; }

        public IModule ModuleSource { get; set; }
        public IModule ModuleDestination { get; set; }
    }
}
