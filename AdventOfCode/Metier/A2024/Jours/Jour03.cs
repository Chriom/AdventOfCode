using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour03;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour03 : AJour<Instruction>
    {
        public override int NumeroJour => 3;

        public override int Annee => 2024;

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.ExtraireInstructionsMul())
                           .ToString();
        }
        public override string DonneResultatDeux()
        {
            return _Entrees.Sum(o => o.ExtraireEnTenantCompteDesStops())
                           .ToString();  
        }


        protected override IEnumerable<Instruction> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {

                yield return new Instruction(lEntree);
            }
        }
    }
}
