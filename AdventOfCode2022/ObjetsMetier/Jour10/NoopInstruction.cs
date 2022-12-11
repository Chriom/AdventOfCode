using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour10
{
    internal class NoopInstruction : IInstruction
    {
        public string Instruction { get; init; }
        public TypeInstruction Type => TypeInstruction.Noop;

        public NoopInstruction(string pInstruction)
        {
            Instruction = pInstruction;
        }

        public IEnumerable<ResultatExecutionInstruction> Executer(int pCycleDebut, int pValeurRegistreX)
        {
            yield return new ResultatExecutionInstruction()
            {
                TypeExecuté = Type,
                Cycle = pCycleDebut,
                RegistreX = pValeurRegistreX,
                RegistreXCycleSuivant = pValeurRegistreX
            };
        }
    }
}
