using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour22;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour22 : AJour<Brique>
    {
        public override int NumeroJour => 22;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            Jenga lJenga = new Jenga(_Entrees);

            return lJenga.DonneNombreBriquePouvantEtreDesintegree().ToString();
        }

        public override string DonneResultatDeux()
        {
            Jenga lJenga = new Jenga(_Entrees);

            return lJenga.DonneNombreDeBriqueQuiVontTomberEnChaine().ToString();
        }

    }
}
