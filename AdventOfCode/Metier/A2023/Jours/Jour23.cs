using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour23;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour23 : AJour<CarteRandonnee>
    {
        public override int NumeroJour => 23;

        public override int Annee => 2023;

        protected override IEnumerable<CarteRandonnee> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeCase[][] lCarte = new TypeCase[lEntrees.Count][];

            for (int lIndex = 0; lIndex < lEntrees.Count; lIndex++)
            {
                lCarte[lIndex] = lEntrees[lIndex].Select(o => EnumHelper.DonneValeurDepuisDescription<TypeCase>(o.ToString()))
                                                 .ToArray();
            }

            yield return new CarteRandonnee(lCarte);
        }

        public override string DonneResultatUn()
        {
            CarteRandonnee lCarte = _Entrees.First();

            return lCarte.DonnePlusLongChemin().ToString();
        }

        public override string DonneResultatDeux()
        {
            CarteRandonnee lCarte = _Entrees.First();

            return lCarte.DonnePlusLongChemin(false).ToString();
        }

        
    }
}
