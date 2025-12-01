using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Extension
{
    public static class StringSplitOptionsExtension
    {
        public static StringSplitOptions RemoveAndTrim = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
    }
}
