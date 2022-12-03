using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour02;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour02 : IConvertisseurEntree<Jeu>
    {
        private static readonly Dictionary<string, Forme> _DicoConversion = new Dictionary<string, Forme>()
        {
            ["A"] = Forme.Pierre,
            ["B"] = Forme.Papier,
            ["C"] = Forme.Ciseau,
            ["X"] = Forme.Pierre,
            ["Y"] = Forme.Papier,
            ["Z"] = Forme.Ciseau,
        };

        private static readonly Dictionary<string, EtatPartie> _DicoConversionEtat = new Dictionary<string, EtatPartie>()
        {
            ["X"] = EtatPartie.Perdue,
            ["Y"] = EtatPartie.Egalite,
            ["Z"] = EtatPartie.Victoire,
        };

        public IEnumerable<Jeu> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<Jeu> lJeux = new List<Jeu>();

            foreach(string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Forme lOpposant = _DicoConversion[lSplit[0]];
                Forme lJoueur = _DicoConversion[lSplit[1]];

                EtatPartie lEtat = _DicoConversionEtat[lSplit[1]];

                lJeux.Add(new Jeu(lOpposant, lJoueur, lEtat));
            }

            return lJeux;
        }
    }
}
