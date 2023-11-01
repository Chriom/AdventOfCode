using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour03;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour03 : IConvertisseurEntree<Donnees>
    {
        public IEnumerable<Donnees> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                yield return new Donnees(lEntree);
            }
        }
    }
}
