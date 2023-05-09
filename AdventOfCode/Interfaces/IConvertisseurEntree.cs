using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Interfaces
{
    internal interface IConvertisseurEntree<T>
    {
        IEnumerable<T> ConvertirEntrees(IEnumerable<string> pEntrees);
    }
}
