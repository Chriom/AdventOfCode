using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour01;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour01 : AJour<Elf>
    {
        public override int NumeroJour => 1;
        public override int Annee => 2022;

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
