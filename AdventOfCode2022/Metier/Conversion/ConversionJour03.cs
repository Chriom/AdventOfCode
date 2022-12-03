using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour03;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour03 : IConvertisseurEntree<ContenuSac>
    {
        public IEnumerable<ContenuSac> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new ContenuSac(o));
        }
    }
}
