using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Extension;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour04;
using AdventOfCode.ObjetsMetier.A2021.Jour05;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour06 : IConvertisseurEntree<int>
    {
        public IEnumerable<int> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.First()
                           .Split(',')
                           .Select(o => int.Parse(o));
        }
    }
}
