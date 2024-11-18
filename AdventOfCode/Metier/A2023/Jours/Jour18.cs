using AdventOfCode.Commun.Helpers;
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

        protected override IEnumerable<Sequence> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                Sens lSens = EnumHelper.DonneValeurDepuisDescription<Sens>(lEntreeSplit[0]);
                int lNombreCase = int.Parse(lEntreeSplit[1]);

                Couleur lCouleur = new Couleur(lEntreeSplit[2].Replace("(", string.Empty).Replace(")", string.Empty));

                yield return new Sequence(lSens, lNombreCase, lCouleur);
            }
        }

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
