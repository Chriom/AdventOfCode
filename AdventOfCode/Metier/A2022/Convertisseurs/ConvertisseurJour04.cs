using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour04;

namespace AdventOfCode.Metier.A2022.Convertisseurs
{
    internal class ConvertisseurJour04 : IConvertisseurEntree<Tache>
    {
        public IEnumerable<Tache> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new Tache(o));
        }
    }
}
