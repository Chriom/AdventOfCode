using AdventOfCode.ObjetsMetier.A2023.Jour08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour08 : AJour<Carte>
    {
        public override int NumeroJour => 8;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            Carte lCarte = _Entrees.First();


            return lCarte.DonneNombreEtapePourParcourirJusquaLaFin().ToString();
        }

        public override string DonneResultatDeux()
        {
            Carte lCarte = _Entrees.First();


            return lCarte.DonneNombreEtapePourParcourirJusquaLaFinPourUnFamtome().ToString();
        }


    }
}
