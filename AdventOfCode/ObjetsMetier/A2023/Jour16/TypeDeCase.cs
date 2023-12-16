using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour16
{
    public enum TypeDeCase
    {
        [Description(".")]
        Vide,
        [Description("/")]
        Miroir,
        [Description(@"\")]
        AntiMiroir,
        [Description("-")]
        DiviseurHorizontal,
        [Description("|")]
        DiviseurVertical
    }
}
