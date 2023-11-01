using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour09;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour09 : AJour<CarteHauteur>
    {
        public override int NumeroJour => 9;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            CarteHauteur lCarte = _Entrees.First();

            lCarte.DeterminerPointsLesPlusBas();
            return lCarte.DonneNiveauDeRisque().ToString();
        }

        public override string DonneResultatDeux()
        {
            CarteHauteur lCarte = _Entrees.First();

            lCarte.DeterminerBassinVersant();

            return lCarte.DonneTailleDesPlusGrandBassins().ToString();

        }
    }
}
