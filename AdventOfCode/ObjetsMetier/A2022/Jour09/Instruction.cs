using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour09
{
    [DebuggerDisplay("{DirectionDeplacement} {NombreEtape}")]
    public class Instruction
    {
        public Direction DirectionDeplacement { get; init; }

        public int NombreEtape { get; init; }

        public Instruction(Direction pDirection, int pNombreEtape)
        {
            DirectionDeplacement = pDirection;
            NombreEtape = pNombreEtape;
        }
    }
}
