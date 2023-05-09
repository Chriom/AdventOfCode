using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour09
{
    [DebuggerDisplay("{Instruction} {Etape} - T : {Tete} Q : {Queue}")]
    internal class ResultatEtapeSimulation
    {
        public PositionCorde Tete => NoeudsCorde.First().Value;
        public PositionCorde Queue => NoeudsCorde.Last().Value;

        public SortedDictionary<int, PositionCorde> NoeudsCorde { get; set; }

        public Instruction Instruction { get; init; }

        public int Etape { get; init; }
    }
}
