using AdventOfCode.ObjetsMetier.A2023.Jour11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour11 : AJour<CarteStellaire>
    {
        public override int NumeroJour => 11;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            CarteStellaire lCarte = _Entrees.First();

            lCarte.AppliquerExtensionUnivers();

            return lCarte.DonneSommeDesDistances().ToString();
        }

        public override string DonneResultatDeux()
        {
            CarteStellaire lCarte = _Entrees.First();

            lCarte.AppliquerExtensionUnivers(999999);

            return lCarte.DonneSommeDesDistances().ToString();
        }

        public string DonneResultatDeux(int pIndiceExpension)
        {
            CarteStellaire lCarte = _Entrees.First();

            lCarte.AppliquerExtensionUnivers(pIndiceExpension);

            return lCarte.DonneSommeDesDistances().ToString();
        }
    }
}
