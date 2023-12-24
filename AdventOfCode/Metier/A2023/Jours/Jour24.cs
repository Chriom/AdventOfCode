using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour24;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour24 : AJour<Grelon>
    {
        public override int NumeroJour => 24;

        public override int Annee => 2023;


        private const decimal _PLAGE_MINIMALE = 200000000000000;
        private const decimal _PLAGE_MAXIMALE = 400000000000000;

        public override string DonneResultatUn()
        {
            return DonneResultatUn(_PLAGE_MINIMALE, _PLAGE_MAXIMALE);
        }

        public string DonneResultatUn(decimal pPlageMinimal, decimal pPlageMaximale)
        {
            ColisionneurDeGrelons lColisionneur = new ColisionneurDeGrelons(_Entrees);

            return lColisionneur.DonneNombreDeColissionDansLaZone2D(pPlageMinimal, pPlageMaximale).ToString();
        }

        public override string DonneResultatDeux()
        {
            ColisionneurDeGrelons lColisionneur = new ColisionneurDeGrelons(_Entrees);

            return lColisionneur.DonneSommeCoordonneeGrelonInterception().ToString();
        }

    }
}
