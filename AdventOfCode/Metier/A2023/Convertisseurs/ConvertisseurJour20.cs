using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour20;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour20 : IConvertisseurEntree<IModule>
    {
        public IEnumerable<IModule> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                IModule lModule;

                string lCle = lEntreeSplit[0];
                if (lCle == "broadcaster")
                {
                    lModule = new DiffuseurModule();
                }
                else if (lCle.StartsWith("&"))
                {
                    lModule = new ConjonctionModule();
                    lCle = lCle.Replace("&", string.Empty);
                }
                else if(lCle.StartsWith("%"))
                {
                    lModule = new FlipFlopModule();
                    lCle = lCle.Replace("%", string.Empty);
                }
                else
                {
                    throw new Exception("Cas non géré");
                }

                lModule.Cle = lCle;
                lModule.CleModulesEnfant = lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                       .ToList();

                yield return lModule;
            }
        }
    }
}
