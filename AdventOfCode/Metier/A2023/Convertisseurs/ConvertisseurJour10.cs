using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour10;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour10 : IConvertisseurEntree<Labyrinthe>
    {
        public IEnumerable<Labyrinthe> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeTuyau[][] lCases = new TypeTuyau[lEntrees.Count][];

            for(int lIndex = 0; lIndex < lEntrees.Count; lIndex++)
            {
                lCases[lIndex] = lEntrees[lIndex].Select(o => EnumHelper.DonneValeurDepuisDescription<TypeTuyau>(o.ToString()))
                                                .ToArray();
            }

            yield return new Labyrinthe(lCases);
        }
    }
}
