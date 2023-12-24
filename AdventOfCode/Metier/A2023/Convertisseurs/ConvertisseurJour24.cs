using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour24;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour24 : IConvertisseurEntree<Grelon>
    {
        public IEnumerable<Grelon> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split("@", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                

                decimal[] lPositionSplit = lEntreeSplit[0].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                          .Select(o => decimal.Parse(o))
                                                          .ToArray();
                Position3D<decimal> lPosition = new Position3D<decimal>(lPositionSplit[0], lPositionSplit[1], lPositionSplit[2]);

                decimal[] lMouvementSplit = lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                           .Select(o => decimal.Parse(o))
                                                           .ToArray();

                Vecteur3D<decimal> lMouvement = new Vecteur3D<decimal>(lMouvementSplit[0], lMouvementSplit[1], lMouvementSplit[2]);

                yield return new Grelon(lPosition, lMouvement);
            }
        }
    }
}
