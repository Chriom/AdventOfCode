using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour15 : IConvertisseurEntree<Procedure>
    {
        public IEnumerable<Procedure> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                yield return new Procedure(lEntree);
            }
        }
    }
}
