using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour20;

namespace AdventOfCode.ObjetsMetier.A2021.Jour03
{
    public class AnalyseurDeDonnees
    {
        private List<Donnees> _Donnees;

        public AnalyseurDeDonnees(IEnumerable<Donnees> pDonnees)
        {
            _Donnees = pDonnees.ToList();
        }

        public EpsilonEtGamma DonneEpsilonEtGamma()
        {
            int[] lCompteur = new int[_Donnees.First().DonneesBinaire.Length];

            foreach (Donnees lDonnee in _Donnees)
            {
                for (int lIndex = 0; lIndex < lDonnee.DonneesBinaire.Length; lIndex++)
                {
                    if (lDonnee.DonneesBinaire[lIndex])
                    {
                        lCompteur[lIndex]++;
                    }
                }
            }

            //Resultat
            string lEpsilon = string.Empty;
            string lGamma = string.Empty;


            foreach (int lComptage in lCompteur)
            {
                if (lComptage > _Donnees.Count / 2)
                {
                    lEpsilon += "1";
                    lGamma += "0";
                }
                else
                {
                    lEpsilon += "0";
                    lGamma += "1";
                }
            }

            return new EpsilonEtGamma()
            {
                Epsilon = Convert.ToInt32(lEpsilon, 2),
                Gamma = Convert.ToInt32(lGamma, 2)
            };
        }

        public int DonneOxygene()
        {
            return _DonneMesure(true);
        }

        public int DonneCO2()
        {
            return _DonneMesure(false);
        }

        /// <summary>
        /// Donne la mesure
        /// </summary>
        /// <param name="pRecherchePlusCommun">true : plus commun, false : moins commun</param>
        /// <returns></returns>
        private int _DonneMesure(bool pRecherchePlusCommun)
        {
            int lLongueur = _Donnees.First().DonneesBinaire.Length;

            List<Donnees> lDonneesRestante = _Donnees;


            for (int lIndex = 0; lIndex < lLongueur; lIndex++)
            {
                int lTotalUn = 0;

                foreach (Donnees lDonnee in lDonneesRestante)
                {
                    if (lDonnee.DonneesBinaire[lIndex])
                    {
                        lTotalUn++;
                    }
                }

                //Recherche du max

                bool lBitGardé = false;

                if (lTotalUn >= lDonneesRestante.Count / (decimal)2)
                {
                    lBitGardé = pRecherchePlusCommun;
                }
                else
                {
                    lBitGardé = pRecherchePlusCommun == false;
                }

                lDonneesRestante = lDonneesRestante.Where(o => o.DonneesBinaire[lIndex] == lBitGardé).ToList();

                if(lDonneesRestante.Count == 1)
                {
                    return Convert.ToInt32(lDonneesRestante.First().ToString(), 2);
                }
            }


            throw new Exception("Impossible de déterminer une unique mesure");
        }
    }
}
