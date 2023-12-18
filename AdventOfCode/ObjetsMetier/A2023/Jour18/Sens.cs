using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public enum Sens
    {
        [Description("R")]
        Droite = 0,
        [Description("D")]
        Bas = 1,
        [Description("L")]
        Gauche = 2,
        [Description("U")]
        Haut = 3,
    }
}
