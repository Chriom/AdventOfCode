using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Extension;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour08;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour08 : IConvertisseurEntree<Signal>
    { 
        public IEnumerable<Signal> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split('|', StringSplitOptions.TrimEntries);

                IEnumerable<string> lEntrees = lSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<string> lSorties = lSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);

                yield return new Signal(lEntrees, lSorties);
            }
            


        }
    }
}
