using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour11 : IConvertisseurEntree<CarteStellaire>
    {
        public IEnumerable<CarteStellaire> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new CarteStellaire(pEntrees);
        }
    }
}
