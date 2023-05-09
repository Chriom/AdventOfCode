using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour01
{
    public class Elf
    {
        public int Numero { get; init; }

        public IEnumerable<int> Calories { get; init; }

        public Elf(int pNumero, IEnumerable<int> pCalories)
        {
            Numero = pNumero;
            Calories = pCalories;
        }

        public int TotalCalories => Calories.Sum();
    }
}
