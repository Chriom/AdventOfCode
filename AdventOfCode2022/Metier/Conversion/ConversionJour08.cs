using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour08;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour08 : IConvertisseurEntree<Foret>
    {
        public IEnumerable<Foret> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Foret lForet = new Foret(pEntrees.Count(), pEntrees.First().Length);

            int lIndexLigne = 0;
            foreach(string lEntree in pEntrees)
            {
                int[] lRangee = lEntree.Select(o => int.Parse(o.ToString()))
                                       .ToArray();

                lForet.AjouterRangeeArbre(lIndexLigne, lRangee);
                lIndexLigne++;
            }


            yield return lForet;
        }
    }
}
