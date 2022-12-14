using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour12;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour12 : IConvertisseurEntree<Carte>
    {
        public IEnumerable<Carte> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            int lY = lEntrees.Count;

            char[][] lCarte = new char[lY][];

            for(int lIndex = 0; lIndex < lY; lIndex++)
            {
                string lEntree = lEntrees[lIndex];
                lCarte[lIndex] = lEntree.Select(o => o)
                                        .ToArray();
            }

            yield return new Carte(lCarte);
        }
    }
}
