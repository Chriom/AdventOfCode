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

        protected override IEnumerable<Carte> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            int lY = lEntrees.Count;

            char[][] lCarte = new char[lY][];

            for (int lIndex = 0; lIndex < lY; lIndex++)
            {
                string lEntree = lEntrees[lIndex];
                lCarte[lIndex] = lEntree.Select(o => o)
                                        .ToArray();
            }

            yield return new Carte(lCarte);
        }
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
