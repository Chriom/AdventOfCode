using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    public interface IModule
    {
        string Cle { get; set; }

        List<string> CleModulesParent { get; set; }
        List<string> CleModulesEnfant { get; set; }

        List<IModule> ModulesParent { get; set; }
        List<IModule> ModulesEnfant { get; set; }

        string EtatInterne { get; set; }

        IEnumerable<ImpulsionDiffusee> TraiterImpulsion(ImpulsionDiffusee pImpulsion);

        void LierModules(Dictionary<string, IModule> pDicoModules);
    }
}
