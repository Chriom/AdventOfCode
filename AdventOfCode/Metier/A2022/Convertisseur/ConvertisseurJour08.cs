using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour08;

namespace AdventOfCode.Metier.A2022.Convertisseur
{
    internal class ConvertisseurJour08 : IConvertisseurEntree<Foret>
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
