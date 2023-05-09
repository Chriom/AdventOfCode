using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour13;

namespace AdventOfCode.Metier.A2022.Convertisseur
{
    internal class ConvertisseurJour13 : IConvertisseurEntree<PairePaquets>
    {
        public IEnumerable<PairePaquets> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();
            int lIndexPaire = 1;

            for(int lIndex = 0; lIndex < lEntrees.Count; lIndex += 3)
            {
                yield return new PairePaquets(lIndexPaire++, new Paquet(lEntrees[lIndex]), new Paquet(lEntrees[lIndex + 1]));
            }
        }
    }
}
