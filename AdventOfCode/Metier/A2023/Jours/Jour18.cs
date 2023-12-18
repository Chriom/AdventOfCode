using AdventOfCode.ObjetsMetier.A2023.Jour18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour18 : AJour<Sequence>
    {
        public override int NumeroJour => 18;

        public override int Annee => 2023;
        public override string DonneResultatUn()
        {
            PlanDeCreusage lPlan = new PlanDeCreusage(_Entrees);
            return lPlan.DonneNombreDeCasesCreusees()
                        .ToString();
        }

        public override string DonneResultatDeux()
        {
            PlanDeCreusage lPlan = new PlanDeCreusage(_Entrees);
            return lPlan.DonneNombreDeCasesCreuseesDepuisCouleur()
                        .ToString();
        }

    }
}
