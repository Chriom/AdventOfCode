using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour05;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour05 : AJour<Almanach>
    {
        public override int NumeroJour => 5;
        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            Almanach lAlmanach = _Entrees.First();

            return lAlmanach.DonneGraineAvecPlusPetitLieux().ToString();
        }

        public override string DonneResultatDeux()
        {
            Almanach lAlmanach = _Entrees.First();

            return lAlmanach.DonneGraineAvecPlusPetitLieuxPlageValeur().ToString();

        }
    }
}
