using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour10
{
    public enum TypeTuyau
    {
        [Description("|")]
        NordEtSud,
        [Description("-")]
        EstEtOuest,
        [Description("L")]
        NordEtEst,
        [Description("J")]
        NordEtOuest,
        [Description("7")]
        SudEtOuest,
        [Description("F")]
        SudEtEst,
        [Description(".")]
        Sol,
        [Description("S")]
        Depart,
        Interieur,
        Exterieur,
    }
}
