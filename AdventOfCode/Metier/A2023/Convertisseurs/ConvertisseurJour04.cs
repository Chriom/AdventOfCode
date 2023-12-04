using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour04 : IConvertisseurEntree<Partie>
    {
        public IEnumerable<Partie> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                Partie lPartie = new Partie();
                string[] lPartieSplit = lEntree.Split(':', StringSplitOptions.TrimEntries);

                lPartie.NumeroPartie = int.Parse(lPartieSplit[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[1]);

                string[] lNombresSplit = lPartieSplit[1].Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                lPartie.NumeroCartes = lNombresSplit[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                       .Select(o => int.Parse(o))
                                                       .ToList();

                lPartie.NumeroValide = lNombresSplit[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                       .Select(o => int.Parse(o))
                                                       .ToList();

                yield return lPartie;
            }
        }
    }
}
