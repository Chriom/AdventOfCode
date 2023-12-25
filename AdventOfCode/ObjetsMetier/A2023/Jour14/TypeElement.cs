using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour14
{
    public enum TypeElement
    {
        [Description(".")]
        Vide = 0,
        [Description("O")]
        PierreRoulante = 1,
        [Description("#")]
        PierreCarree = 2,
        
    }
}
