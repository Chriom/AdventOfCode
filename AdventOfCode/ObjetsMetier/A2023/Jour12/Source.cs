using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour12
{
    public enum Source
    {
        [Description(".")]
        Operationel,
        [Description("#")]
        Endommagé,
        [Description("?")]
        Inconnu,

    }
}
