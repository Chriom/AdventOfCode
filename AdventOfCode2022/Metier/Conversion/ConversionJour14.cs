using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour14;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour14 : IConvertisseurEntree<CoordonneesRocher>
    {
        public IEnumerable<CoordonneesRocher> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new CoordonneesRocher(o));
        }
    }
}
