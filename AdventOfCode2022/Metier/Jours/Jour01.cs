using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour01;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour01 : AJour<Elf>
    {
        public override int NumeroJour => 1;

        public override string DonneResultatUn()
        {
            return _Entrees.OrderByDescending(o => o.TotalCalories)
                           .First()
                           .TotalCalories
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.OrderByDescending(o => o.TotalCalories)
                           .Take(3)
                           .Sum(o => o.TotalCalories)
                           .ToString();
        }        
    }
}
