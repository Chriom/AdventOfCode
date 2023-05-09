using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour02;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour02 : IConvertisseurEntree<Instruction>
    {
        public IEnumerable<Instruction> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                Instruction lInstruction = new Instruction();

                string[] lSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                lInstruction.Mouvement = lSplit[0] switch
                {
                    "forward" => Mouvement.Avancer,
                    "down" => Mouvement.Descendre,
                    "up" => Mouvement.Monter,
                    _ => throw new NotImplementedException(),
                };

                lInstruction.Distance = int.Parse(lSplit[1]);

                yield return lInstruction;
            }
        }
    }
}
