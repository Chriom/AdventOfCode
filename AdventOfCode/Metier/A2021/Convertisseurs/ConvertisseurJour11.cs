using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour11;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    public class ConvertisseurJour11 : IConvertisseurEntree<PlanSousMarin>
    {
        public IEnumerable<PlanSousMarin> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignes = pEntrees.ToList();

            int lHauteur = lLignes.Count;
            int lLargeur = lLignes.First().Length;

            Octopus[][] lPlan = new Octopus[lHauteur][];


            for(int lIndex = 0; lIndex < lHauteur; lIndex++)
            {
                lPlan[lIndex] = new Octopus[lLargeur];

                string lLigne = lLignes[lIndex];

                for(int lIndexLargeur = 0; lIndexLargeur < lLargeur; lIndexLargeur++)
                {
                    lPlan[lIndex][lIndexLargeur] = new Octopus(int.Parse(lLigne[lIndexLargeur].ToString()));
                }
            }


            yield return new PlanSousMarin(lPlan, lHauteur, lLargeur);
        }
    }
}
