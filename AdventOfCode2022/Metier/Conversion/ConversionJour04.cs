using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour03;
using AdventOfCode2022.ObjetsMetier.Jour04;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour04 : IConvertisseurEntree<Tache>
    {
        public IEnumerable<Tache> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new Tache(o));
        }
    }
}
