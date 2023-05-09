using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour10
{
    public class ResultatExecutionInstruction
    {
        public TypeInstruction TypeExecuté { get; init; }

        public int Cycle { get; init; }

        public int RegistreX { get; init; }
        public int RegistreXCycleSuivant { get; init; }
    }
}
