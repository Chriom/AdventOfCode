using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour01;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour01 : IConvertisseurEntree<Elf>
    {
        IEnumerable<Elf> IConvertisseurEntree<Elf>.ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            int lNumeroElf = 1;

            List<int> lCaloriesElf = new List<int>();
            foreach(string lEntree in pEntrees)
            {


                if (string.IsNullOrEmpty(lEntree))
                {
                    yield return new Elf(lNumeroElf++, lCaloriesElf);
                    lCaloriesElf = new List<int>();
                }
                else
                {
                    lCaloriesElf.Add(int.Parse(lEntree));
                }
            }

            if(lCaloriesElf.Count > 0)
            {
                yield return new Elf(lNumeroElf++, lCaloriesElf);
            }
        }
    }
}
