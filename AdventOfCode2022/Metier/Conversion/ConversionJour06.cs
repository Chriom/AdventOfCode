using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour06 : IConvertisseurEntree<MessageEncode>
    {
        public IEnumerable<MessageEncode> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new MessageEncode(o));
        }
    }
}
