using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour03;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour03 : AJour<Plan>
    {
        public override int NumeroJour => 3;
        public override int Annee => 2023;

        protected override IEnumerable<Plan> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Plan(pEntrees.ToList());
        }

        public override string DonneResultatUn()
        {
            Plan lPlan = _Entrees.First();

            return lPlan.InstructionAvecNumeroPiece
                        .Sum(o => o.Nombre)
                        .ToString();
        }

        public override string DonneResultatDeux()
        {
            Plan lPlan = _Entrees.First();

            return lPlan.DonneEngrenage()
                        .Sum(o => o.Ratio)
                        .ToString();
        }

    }
}
