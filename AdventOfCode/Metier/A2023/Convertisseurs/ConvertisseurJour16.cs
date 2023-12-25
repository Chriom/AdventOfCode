using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour16;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour16 : IConvertisseurEntree<Machine>
    {
        public IEnumerable<Machine> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeDeCase[][] lCases = new TypeDeCase[lEntrees.Count][];

            int lIndex = 0;
            foreach(string lEntree in pEntrees)
            {
                lCases[lIndex] = lEntree.Select(o => EnumHelper.DonneValeurDepuisDescription<TypeDeCase>(o.ToString()))
                                        .ToArray();

                lIndex++;
            }

            yield return new Machine(lCases);
        }
    }
}
