using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour07
{
    public enum CarteChameau
    {
        Joker = -1,
        [Description("2")]
        Deux = 2,
        [Description("3")]
        Trois = 3,
        [Description("4")]
        Quatre = 4,
        [Description("5")]
        Cinq = 5,
        [Description("6")]
        Six = 6,
        [Description("7")]
        Sept = 7,
        [Description("8")]
        Huit = 8,
        [Description("9")]
        Neuf = 9,
        [Description("T")]
        Dix = 10,
        [Description("J")]
        Valet = 11,
        [Description("Q")]
        Reine = 12,
        [Description("K")]
        Roi = 13,
        [Description("A")]
        As = 14,
    }
}
