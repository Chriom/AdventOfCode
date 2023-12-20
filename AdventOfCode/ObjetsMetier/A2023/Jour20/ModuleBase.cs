using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    [DebuggerDisplay("{Cle} -- {this.GetType().Name} -- {EtatInterne}")]
    public abstract class ModuleBase : IModule
    {
        public string Cle { get; set; }

        public List<string> CleModulesParent { get; set; } = new List<string>();
        public List<string> CleModulesEnfant { get; set; } = new List<string>();

        public string EtatInterne { get; set; }

        public List<IModule> ModulesParent { get; set; } = new List<IModule>();
        public List<IModule> ModulesEnfant { get; set; } = new List<IModule>();

        public void LierModules(Dictionary<string, IModule> pDicoModules)
        {

            foreach(string lCleEnfant in CleModulesEnfant)
            {
                if(pDicoModules.TryGetValue(lCleEnfant, out IModule lEnfant) == false)
                {
                    //Pas de module : on crée un nop
                    lEnfant = new NopModule()
                    {
                        Cle = lCleEnfant,
                    };

                    pDicoModules.Add(lEnfant.Cle, lEnfant);
                    
                }

                ModulesEnfant.Add(lEnfant);

                lEnfant.CleModulesParent.Add(this.Cle);
                lEnfant.ModulesParent.Add(this);
            }
        }

        public abstract void ApresLiaisonModules();

        public abstract IEnumerable<ImpulsionDiffusee> TraiterImpulsion(ImpulsionDiffusee pImpulsion);
    }
}
