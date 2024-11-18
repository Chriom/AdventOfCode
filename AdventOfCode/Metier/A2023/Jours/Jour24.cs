using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.ObjetsMetier.A2023.Jour24;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour24 : AJour<Grelon>
    {
        public override int NumeroJour => 24;

        public override int Annee => 2023;

        protected override IEnumerable<Grelon> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split("@", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);



                decimal[] lPositionSplit = lEntreeSplit[0].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                          .Select(o => decimal.Parse(o))
                                                          .ToArray();
                Position3D<decimal> lPosition = new Position3D<decimal>(lPositionSplit[0], lPositionSplit[1], lPositionSplit[2]);

                decimal[] lMouvementSplit = lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                           .Select(o => decimal.Parse(o))
                                                           .ToArray();

                Vecteur3D<decimal> lMouvement = new Vecteur3D<decimal>(lMouvementSplit[0], lMouvementSplit[1], lMouvementSplit[2]);

                yield return new Grelon(lPosition, lMouvement);
            }
        }


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
