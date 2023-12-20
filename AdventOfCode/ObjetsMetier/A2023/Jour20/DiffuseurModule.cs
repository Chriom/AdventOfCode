using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    public class DiffuseurModule : ModuleBase
    {

        public DiffuseurModule()
        {
            EtatInterne = "Diffuseur";
        }

        public override IEnumerable<ImpulsionDiffusee> TraiterImpulsion(ImpulsionDiffusee pImpulsion)
        {
            foreach(IModule lEnfant in ModulesEnfant)
            {
                yield return new ImpulsionDiffusee()
                {
                   Impulsion = pImpulsion.Impulsion,
                   ModuleSource = this,
                   ModuleDestination = lEnfant,
                };
            }
        }

        public override void ApresLiaisonModules()
        {
        }
    }
}
