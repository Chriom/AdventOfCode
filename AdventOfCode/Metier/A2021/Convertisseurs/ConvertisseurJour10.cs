using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour10;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    public class ConvertisseurJour10 : IConvertisseurEntree<Ligne>
    {
        public IEnumerable<Ligne> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                yield return new Ligne(lEntree);
            }            
        }
    }
}
