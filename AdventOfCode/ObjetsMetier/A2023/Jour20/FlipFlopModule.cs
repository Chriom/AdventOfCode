using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    public class FlipFlopModule : ModuleBase
    {

        private const string _ETEINT = "off";
        private const string _ALLUMEE = "On";
        public FlipFlopModule() 
        {
            EtatInterne = _ETEINT;
        }

        public override IEnumerable<ImpulsionDiffusee> TraiterImpulsion(ImpulsionDiffusee pImpulsion)
        {
            if(pImpulsion.Impulsion == TypeImpulsion.Basse)
            {
                TypeImpulsion lImpulsionEnfant = TypeImpulsion.Basse;

                if(EtatInterne == _ETEINT)
                {
                    EtatInterne = _ALLUMEE;
                    lImpulsionEnfant = TypeImpulsion.Haute;
                }
                else
                {
                    EtatInterne = _ETEINT;
                    lImpulsionEnfant = TypeImpulsion.Basse;
                }


                foreach(IModule lEnfant in ModulesEnfant)
                {
                    yield return new ImpulsionDiffusee()
                    {
                        Impulsion = lImpulsionEnfant,
                        ModuleSource = this,
                        ModuleDestination = lEnfant,
                    };
                }
            }
        }

        public override void ApresLiaisonModules()
        {
            
        }
    }
}
