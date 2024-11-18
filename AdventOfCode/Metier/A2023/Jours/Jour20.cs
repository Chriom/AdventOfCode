using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour20;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour20 : AJour<IModule>
    {
        public override int NumeroJour => 20;

        public override int Annee => 2023;

        protected override IEnumerable<IModule> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
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
                else if (lCle.StartsWith("%"))
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

        public override string DonneResultatUn()
        {
            SimulateurElectronique lSimulateur = new SimulateurElectronique(_Entrees.ToList());

            return lSimulateur.DonneNombreImpulsionApresAppuisSurBouton(1000).ToString();
        }
        public override string DonneResultatDeux()
        {
            SimulateurElectronique lSimulateur = new SimulateurElectronique(_Entrees.ToList());

            return lSimulateur.DonneNombreAppuiSurBoutonPourActiverModuleRx().ToString();
        }

    }
}
