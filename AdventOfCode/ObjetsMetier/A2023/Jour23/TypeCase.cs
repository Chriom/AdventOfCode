using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour23
{
    public enum TypeCase
    {
        [Description(".")]
        Chemin,
        [Description("#")]
        Foret,
        [Description("^")]
        PenteHaut,
        [Description(">")]
        PenteDroite,
        [Description("v")]
        PenteBas,
        [Description("<")]
        PenteGauche
    }
}
