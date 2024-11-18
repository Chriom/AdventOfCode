using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour14;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour14 : AJour<Plateforme>
    {
        public override int NumeroJour => 14;

        public override int Annee => 2023;

        protected override IEnumerable<Plateforme> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignes = pEntrees.ToList();

            TypeElement[][] lCarte = new TypeElement[lLignes.Count][];

            for (int lIndex = 0; lIndex < lLignes.Count; lIndex++)
            {
                lCarte[lIndex] = lLignes[lIndex].Select(o => EnumHelper.DonneValeurDepuisDescription<TypeElement>(o.ToString()))
                                                .ToArray();
            }

            yield return new Plateforme(lCarte);
        }

        public override string DonneResultatUn()
        {
            Plateforme lPlateforme = _Entrees.First();

            lPlateforme.AfficheCarte();

            lPlateforme.Deplacer(Direction.Nord);

            lPlateforme.AfficheCarte();

            return lPlateforme.DonneChargeTotal()
                              .ToString();
        }

        public override string DonneResultatDeux()
        {
            Plateforme lPlateforme = _Entrees.First();

            lPlateforme.EffectuerCycles();

            return lPlateforme.DonneChargeTotal().ToString();
        }


    }
}
