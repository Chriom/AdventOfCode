using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour01;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour01 : AJour<Instruction>
    {
        public override int NumeroJour => 1;
        public override int Annee => 2023;

        protected override IEnumerable<Instruction> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                yield return new Instruction(lEntree);
            }
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneCode())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {

            return _Entrees.Select(o =>
                           {
                               o.Convertir();
                               return o;
                           })
                           .Sum(o => o.DonneCode())
                           .ToString();
        }
    }
}
