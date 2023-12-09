using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour09;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour09 : IConvertisseurEntree<Sequence>
    {
        public IEnumerable<Sequence> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                List<decimal> lValeurs = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                .Select(o => decimal.Parse(o))
                                                .ToList();

                yield return new Sequence(lValeurs);
            }
        }
    }
}
