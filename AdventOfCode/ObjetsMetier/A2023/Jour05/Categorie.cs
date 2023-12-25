using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour05
{
    public enum Categorie
    {
        [Description("seed")]
        Graine,
        [Description("soil")]
        Sol,
        [Description("fertilizer")]
        Fertilisant,
        [Description("water")]
        Eau,
        [Description("light")]
        Lumiere,
        [Description("temperature")]
        Temperature,
        [Description("humidity")]
        Humidité,
        [Description("location")]
        Lieux,
    }
}
