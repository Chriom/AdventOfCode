using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour10
{
    public interface IInstruction
    {
        string Instruction { get; init; }

        TypeInstruction Type { get; }

        IEnumerable<ResultatExecutionInstruction> Executer(int pCycleDebut, int pValeurRegistreX);

    }
}
