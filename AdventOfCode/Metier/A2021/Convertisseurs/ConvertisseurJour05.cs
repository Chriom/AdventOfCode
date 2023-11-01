using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Extension;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour04;
using AdventOfCode.ObjetsMetier.A2021.Jour05;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour05 : IConvertisseurEntree<Ligne>
    {
        public IEnumerable<Ligne> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            
            foreach(string lEntree in pEntrees)
            {
                string[] lCoordonnees = lEntree.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                int[] lDepart = lCoordonnees[0].Split(',').Select(o => int.Parse(o)).ToArray();
                int[] lArrive = lCoordonnees[1].Split(',').Select(o => int.Parse(o)).ToArray();

                yield return new Ligne(lDepart[0], lDepart[1], lArrive[0], lArrive[1]);
            }
        }
    }
}
