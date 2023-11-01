using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour03;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour03 : AJour<Donnees>
    {
        public override int NumeroJour => 3;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            AnalyseurDeDonnees lAnalyseur = new AnalyseurDeDonnees(_Entrees);

            return lAnalyseur.DonneEpsilonEtGamma()
                             .SommeDesDeux
                             .ToString();

        }

        public override string DonneResultatDeux()
        {
            AnalyseurDeDonnees lAnalyseur = new AnalyseurDeDonnees(_Entrees);

            int lOxygene = lAnalyseur.DonneOxygene();
            int lCO2 = lAnalyseur.DonneCO2();

            return (lOxygene * lCO2).ToString(); ;
        }        
    }
}
