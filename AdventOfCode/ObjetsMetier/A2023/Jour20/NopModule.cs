using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    public class NopModule : ModuleBase
    {
        public NopModule()
        {
            EtatInterne = "nop";
        }
        public override IEnumerable<ImpulsionDiffusee> TraiterImpulsion(ImpulsionDiffusee pImpulsion)
        {
            yield break;
        }

        public override void ApresLiaisonModules()
        {
            
        }
    }
}
