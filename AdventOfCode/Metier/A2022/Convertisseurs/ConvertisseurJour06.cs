using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2022.Convertisseurs
{
    internal class ConvertisseurJour06 : IConvertisseurEntree<MessageEncode>
    {
        public IEnumerable<MessageEncode> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new MessageEncode(o));
        }
    }
}
