using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour10;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour10 : IConvertisseurEntree<IInstruction>
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
