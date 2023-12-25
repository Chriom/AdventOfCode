using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour03
{
    public class Engrenage
    {
        public Instruction Instruction1 { get; set; }
        public Instruction Instruction2 { get; set; }

        public decimal Ratio => Instruction1.Nombre * Instruction2.Nombre;
    }
}
