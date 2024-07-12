using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour11;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour11 : AJour<PlanSousMarin>
    {
        public override int NumeroJour => 11;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            PlanSousMarin lPlan = _Entrees.First();

            return lPlan.SimulerEtapes(100).ToString();
        }

        public override string DonneResultatDeux()
        {
            PlanSousMarin lPlan = _Entrees.First();

            return lPlan.DonneNumeroEtapeOuTousLeMondeFlash().ToString();
        }        
    }
}
