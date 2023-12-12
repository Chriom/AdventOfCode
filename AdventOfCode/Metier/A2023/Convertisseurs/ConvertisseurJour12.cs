using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour12 : IConvertisseurEntree<Enregistrement>
    {
        public IEnumerable<Enregistrement> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                List<int> lTailles = lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                    .Select(o => int.Parse(o))
                                                    .ToList();

                yield return new Enregistrement(lEntreeSplit[0], lTailles);
            }
        }
    }
}
