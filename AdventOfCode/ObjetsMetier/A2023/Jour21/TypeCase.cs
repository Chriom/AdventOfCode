using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour21
{
    public enum TypeCase
    {
        [Description("S")]
        Depart = 0,
        [Description(".")]
        Vide = 1,
        [Description("#")]
        Pierre = 2,
        [Description("O")]
        Potager = 3,
        
    }
}
