using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour19;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour19 : AJour<DonneesDeTravail>
    {
        public override int NumeroJour => 19;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            DonneesDeTravail lDonnees = _Entrees.First();

            return lDonnees.ExecuterFluxDeTravail().ToString();
        }

        public override string DonneResultatDeux()
        {
            DonneesDeTravail lDonnees = _Entrees.First();

            return lDonnees.DonneToutesLesCombinaisonsPossible().ToString();
        }


    }
}
