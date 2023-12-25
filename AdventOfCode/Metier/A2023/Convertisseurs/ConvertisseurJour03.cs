using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour03;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour03 : IConvertisseurEntree<Plan>
    {
        IEnumerable<Plan> IConvertisseurEntree<Plan>.ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Plan(pEntrees.ToList());     
        }
    }
}
