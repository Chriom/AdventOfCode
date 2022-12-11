using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour10
{
    internal static class InstructionFactory
    {
        public static IInstruction DonneInstruction(string pInstruction)
        {
            string[] lSplit = pInstruction.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return lSplit[0] switch
            {
                "noop" => new NoopInstruction(pInstruction),
                "addx" => new AddxInstruction(pInstruction),
                _ => throw new Exception("Impossible de lire l'instruction")
            };
        }

    }
}
