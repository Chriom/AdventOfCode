using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour12;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour12 : AJour<Carte>
    {
        public override int NumeroJour => 12;

        public override string DonneResultatUn()
        {
            Carte lCarte = _Entrees.First();


            Chemin lChemin = lCarte.ParcourirDepuisLeDepart();

            int lNiveau = lChemin.DonneNiveauPlusBasALarrive();

            return lNiveau.ToString();
        }

        public override string DonneResultatDeux()
        {
            Carte lCarte = _Entrees.First();


            Chemin lChemin = lCarte.DonneCheminLePlusCoursDepuisNimporteQuelPosition();

            int lNiveau = lChemin.DonneNiveauPlusBasALarrive();

            return lNiveau.ToString();
        }

       
    }
}
