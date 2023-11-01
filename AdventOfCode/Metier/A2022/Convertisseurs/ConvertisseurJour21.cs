using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour21;

namespace AdventOfCode.Metier.A2022.Convertisseurs
{
    internal class ConvertisseurJour21 : IConvertisseurEntree<Singe>
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
