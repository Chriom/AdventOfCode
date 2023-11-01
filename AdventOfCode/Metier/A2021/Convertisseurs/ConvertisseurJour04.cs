using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Extension;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour04;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    internal class ConvertisseurJour04 : IConvertisseurEntree<Bingo>
    {
        private const int _DECALAGE_LIGNES_EN_TETE = 2;
        private const int _NOMBRE_LIGNES_GRILLES = 5;
        private const int _NOMBRE_LIGNES_ENTRE_DEUX_GRILLES = 6;

        public IEnumerable<Bingo> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Bingo lBingo = new Bingo()
            {
                Numeros = pEntrees.First()
                                  .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(o => int.Parse(o))
                                  .ToList(),
            };

            foreach(IEnumerable<string> lEntrees in pEntrees.Skip(_DECALAGE_LIGNES_EN_TETE).SplitEnListe(_NOMBRE_LIGNES_ENTRE_DEUX_GRILLES))
            {
                lBingo.Grilles.Add(new Grille(lEntrees.Take(_NOMBRE_LIGNES_GRILLES)));
            }

            yield return lBingo;
        }
    }
}
