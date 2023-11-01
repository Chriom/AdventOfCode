using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2021.Jour09;

namespace AdventOfCode.Metier.A2021.Convertisseurs
{
    public class ConvertisseurJour09 : IConvertisseurEntree<CarteHauteur>
    {
        public IEnumerable<CarteHauteur> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignes = pEntrees.ToList();

            CarteHauteur lCarte = new CarteHauteur();

            int lNombreLignes = lLignes.Count;
            int lLargeurLigne = lLignes.First().Length;

            lCarte.Carte = new Localisation[lNombreLignes][];

            lCarte.Hauteur = lNombreLignes;
            lCarte.Largeur = lLargeurLigne;

            for(int lIndex = 0; lIndex < lNombreLignes; lIndex++)
            {
                lCarte.Carte[lIndex] = new Localisation[lLargeurLigne];

                string lLigne = lLignes[lIndex];

                for(int lIndexColonne = 0; lIndexColonne < lLargeurLigne; lIndexColonne++)
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
    }
}
