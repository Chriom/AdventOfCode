using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour09;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour09 : IConvertisseurEntree<Instruction>
    {
        public IEnumerable<Instruction> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(' ');
                int lNombreEtape = int.Parse(lSplit[1]);

                yield return lSplit[0] switch
                {
                    "U" => new Instruction(Direction.Haut, lNombreEtape),
                    "D" => new Instruction(Direction.Bas, lNombreEtape),
                    "L" => new Instruction(Direction.Gauche, lNombreEtape),
                    "R" => new Instruction(Direction.Droite, lNombreEtape),
                    _ => throw new Exception("Instruction illisible")
                };
            }
        }
    }
}
