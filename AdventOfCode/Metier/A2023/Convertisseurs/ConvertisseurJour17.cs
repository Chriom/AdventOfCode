using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour17;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour17 : IConvertisseurEntree<PiscineDelave>
    {
        public IEnumerable<PiscineDelave> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            int[][] lBassin = new int[lEntrees.Count][];


            int lIndex = 0;
            foreach(string lEntree in lEntrees)
            {
                lBassin[lIndex] = lEntree.Select(o => int.Parse(o.ToString()))
                                         .ToArray();
                lIndex++;
            }

            yield return new PiscineDelave(lBassin);
        }
    }
}
