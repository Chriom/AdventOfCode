using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour23;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour23 : AJour<CarteRandonnee>
    {
        public override int NumeroJour => 23;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            CarteRandonnee lCarte = _Entrees.First();

            return lCarte.DonnePlusLongChemin().ToString();
        }

        public override string DonneResultatDeux()
        {
            CarteRandonnee lCarte = _Entrees.First();

            return lCarte.DonnePlusLongChemin(false).ToString();
        }

        
    }
}
