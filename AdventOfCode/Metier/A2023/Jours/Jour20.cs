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
