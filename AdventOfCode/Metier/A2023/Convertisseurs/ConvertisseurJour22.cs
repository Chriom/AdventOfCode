using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour22;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour22 : IConvertisseurEntree<Brique>
    {
        public IEnumerable<Brique> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            int lIndexBrique = 1;
            foreach(string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split("~", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                
                int[] lDebut = lEntreeSplit[0].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                              .Select(o => int.Parse(o))
                                              .ToArray();


                int[] lFin = lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                            .Select(o => int.Parse(o))
                                            .ToArray();

                yield return new Brique()
                {
                    Identifiant = lIndexBrique++,
                    Debut = new Commun.ObjetsUtilitaire.Position3D(lDebut[0], lDebut[1], lDebut[2]),
                    Fin = new Commun.ObjetsUtilitaire.Position3D(lFin[0], lFin[1], lFin[2]),
                };
            }
        }
    }
}
