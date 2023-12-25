using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour07;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour07 : IConvertisseurEntree<Main>
    {
        public IEnumerable<Main> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                yield return new Main(lSplit[0], int.Parse(lSplit[1]));
            }
        }
    }
}
