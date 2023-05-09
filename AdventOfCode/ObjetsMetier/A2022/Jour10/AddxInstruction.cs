using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour10
{
    internal class AddxInstruction : IInstruction
    {
        public string Instruction { get; init; }
        public TypeInstruction Type => TypeInstruction.Addx;

        private int _Ajout;

        public AddxInstruction(string pInstruction)
        {
            Instruction = pInstruction;

            _Ajout = int.Parse(pInstruction.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
        }

        public IEnumerable<ResultatExecutionInstruction> Executer(int pCycleDebut, int pValeurRegistreX)
        {
            yield return new ResultatExecutionInstruction()
            {
                TypeExecuté = Type,
                Cycle = pCycleDebut,
                RegistreX = pValeurRegistreX,
                RegistreXCycleSuivant = pValeurRegistreX,
            };

            yield return new ResultatExecutionInstruction()
            {
                TypeExecuté = Type,
                Cycle = pCycleDebut + 1,
                RegistreX = pValeurRegistreX,
                RegistreXCycleSuivant = pValeurRegistreX + _Ajout,
            };
        }
    }
}
