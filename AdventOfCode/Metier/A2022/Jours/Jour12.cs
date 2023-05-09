using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour12;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour12 : AJour<Carte>
    {
        public override int NumeroJour => 12;
        public override int Annee => 2022;

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
