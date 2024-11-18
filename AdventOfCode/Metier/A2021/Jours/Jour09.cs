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

        protected override IEnumerable<CarteHauteur> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignes = pEntrees.ToList();

            CarteHauteur lCarte = new CarteHauteur();

            int lNombreLignes = lLignes.Count;
            int lLargeurLigne = lLignes.First().Length;

            lCarte.Carte = new Localisation[lNombreLignes][];

            lCarte.Hauteur = lNombreLignes;
            lCarte.Largeur = lLargeurLigne;

            for (int lIndex = 0; lIndex < lNombreLignes; lIndex++)
            {
                lCarte.Carte[lIndex] = new Localisation[lLargeurLigne];

                string lLigne = lLignes[lIndex];

                for (int lIndexColonne = 0; lIndexColonne < lLargeurLigne; lIndexColonne++)
                {
                    int lHauteur = int.Parse(lLigne[lIndexColonne].ToString());

                    lCarte.Carte[lIndex][lIndexColonne] = new Localisation()
                    {
                        X = lIndexColonne,
                        Y = lIndex,
                        Hauteur = lHauteur,
                    };
                }
            }

            yield return lCarte;
        }

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
