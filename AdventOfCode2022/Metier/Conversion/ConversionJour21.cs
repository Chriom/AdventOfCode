using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour21;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour21 : IConvertisseurEntree<Singe>
    {
        public IEnumerable<Singe> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Dictionary<string, Singe> lSinges = new Dictionary<string, Singe>();

            foreach (string lEntree in pEntrees)
            {
                Singe lSinge = new Singe(lEntree);

                lSinges.Add(lSinge.Nom, lSinge);
            }


            foreach(Singe lSinge in lSinges.Values)
            {
                lSinge.AssocierSinges(lSinges);
                yield return lSinge;
            }

        }
    }
}
