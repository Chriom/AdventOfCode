using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour23;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour23 : IConvertisseurEntree<CarteRandonnee>
    {
        public IEnumerable<CarteRandonnee> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeCase[][] lCarte = new TypeCase[lEntrees.Count][];

            for(int lIndex = 0; lIndex < lEntrees.Count; lIndex++)
            {
                lCarte[lIndex] = lEntrees[lIndex].Select(o => EnumHelper.DonneValeurDepuisDescription<TypeCase>(o.ToString()))
                                                 .ToArray();
            }

            yield return new CarteRandonnee(lCarte);
        }
    }
}
