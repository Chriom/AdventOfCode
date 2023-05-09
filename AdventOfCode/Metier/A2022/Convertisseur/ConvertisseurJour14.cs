using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour14;

namespace AdventOfCode.Metier.A2022.Convertisseur
{
    internal class ConvertisseurJour14 : IConvertisseurEntree<CoordonneesRocher>
    {
        public IEnumerable<CoordonneesRocher> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new CoordonneesRocher(o));
        }
    }
}
