using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour10;

namespace AdventOfCode.Metier.A2022.Convertisseurs
{
    internal class ConvertisseurJour10 : IConvertisseurEntree<IInstruction>
    {
        public IEnumerable<IInstruction> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                yield return InstructionFactory.DonneInstruction(lEntree);
            }
        }
    }
}
