using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour03;

namespace AdventOfCode.Metier.A2022.Convertisseurs
{
    internal class ConvertisseurJour03 : IConvertisseurEntree<ContenuSac>
    {
        public IEnumerable<ContenuSac> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new ContenuSac(o));
        }
    }
}
