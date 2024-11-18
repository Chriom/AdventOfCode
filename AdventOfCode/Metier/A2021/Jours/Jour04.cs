using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2021.Jour04;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour04 : AJour<Bingo>
    {
        public override int NumeroJour => 4;

        public override int Annee => 2021;

        private const int _DECALAGE_LIGNES_EN_TETE = 2;
        private const int _NOMBRE_LIGNES_GRILLES = 5;
        private const int _NOMBRE_LIGNES_ENTRE_DEUX_GRILLES = 6;

        protected override IEnumerable<Bingo> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Bingo lBingo = new Bingo()
            {
                Numeros = pEntrees.First()
                                  .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(o => int.Parse(o))
                                  .ToList(),
            };

            foreach (IEnumerable<string> lEntrees in pEntrees.Skip(_DECALAGE_LIGNES_EN_TETE).SplitEnListe(_NOMBRE_LIGNES_ENTRE_DEUX_GRILLES))
            {
                lBingo.Grilles.Add(new Grille(lEntrees.Take(_NOMBRE_LIGNES_GRILLES)));
            }

            yield return lBingo;
        }
        public override string DonneResultatUn()
        {
            Bingo lBingo = _Entrees.First();

            int lScore = lBingo.DonneScoreGrilleGagnante();
            return lScore.ToString();
        }

        public override string DonneResultatDeux()
        {
            Bingo lBingo = _Entrees.First();

            int lScore = lBingo.DonneScoreDerniereGrilleGagnante();
            return lScore.ToString();
        }
    }
}
