using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour04;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour04 : AJour<Bingo>
    {
        public override int NumeroJour => 4;

        public override int Annee => 2021;

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
