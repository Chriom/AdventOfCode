using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour01;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour01 : IConvertisseurEntree<Profondeur>
    {
        public IEnumerable<Profondeur> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                yield return new Profondeur() { Mesure = int.Parse(lEntree) };
            }
        }
    }
}
