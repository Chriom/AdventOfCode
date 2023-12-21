using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour21;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour21 : IConvertisseurEntree<CarteJardin>
    {
        public IEnumerable<CarteJardin> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeCase[][] lCases = new TypeCase[lEntrees.Count][];


            for(int lIndex = 0; lIndex < lEntrees.Count; lIndex++)
            {
                string lEntree = lEntrees[lIndex];
                lCases[lIndex] = lEntree.Select(o => EnumHelper.DonneValeurDepuisDescription<TypeCase>(o.ToString()))
                                        .ToArray();
            }


            yield return new CarteJardin(lCases);
        }
    }
}
