using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour06
{
    public class Aquarium
    {
        private List<int> _Poissons;

        private int _CompteurApresReproduction;
        private int _CompteurApresNaissance;

        public Aquarium(List<int> pPoissons, int pCompteurApresReproduction, int pCompteurApresNaissance)
        {
            _Poissons = pPoissons;
            _CompteurApresReproduction = pCompteurApresReproduction;
            _CompteurApresNaissance = pCompteurApresNaissance;
        }


        public decimal DonneNombrePoissonsApresNombreJour(int pNombreJour)
        {
            Dictionary<int, decimal> lDicoPoissons = _InitialiserDictionnairePoissons();

            for(int lJour = 1; lJour <= pNombreJour; lJour++)
            {
                Dictionary<int, decimal> lDicoPoissonsJourSuivant = new Dictionary<int, decimal>();

                for(int lIndex = 0; lIndex <= _CompteurApresNaissance; lIndex++)
                {
                    decimal lNombrePoisson = lDicoPoissons[lIndex];

                    if(lIndex == 0)
                    {
                        //Reproduction
                        _AJouterAuDictionnaire(lDicoPoissonsJourSuivant, _CompteurApresReproduction, lNombrePoisson);
                        _AJouterAuDictionnaire(lDicoPoissonsJourSuivant, _CompteurApresNaissance, lNombrePoisson);
                    }
                    else
                    {
                        _AJouterAuDictionnaire(lDicoPoissonsJourSuivant, lIndex - 1, lNombrePoisson);
                    }
                }


                lDicoPoissons = lDicoPoissonsJourSuivant;
            }

            return lDicoPoissons.Sum(o => o.Value);
        }

        private Dictionary<int, decimal> _InitialiserDictionnairePoissons()
        {
            Dictionary<int, decimal> lDicoPoissons = new Dictionary<int, decimal>();

            var lGroupePoissons = _Poissons.GroupBy(o => o, o => o);

            for(int lIndex = 0; lIndex <= _CompteurApresNaissance; lIndex++)
            {
                decimal lNombrePoissons = lGroupePoissons.FirstOrDefault(o => o.Key == lIndex)?.Count() ?? 0;

                lDicoPoissons.Add(lIndex, lNombrePoissons);
            }

            return lDicoPoissons;
        }

        private void _AJouterAuDictionnaire(Dictionary<int, decimal> pDictionnaire, int pCle, decimal pQuantite)
        {
            if (pDictionnaire.ContainsKey(pCle))
            {
                pDictionnaire[pCle] += pQuantite;
            }
            else
            {
                pDictionnaire.Add(pCle, pQuantite);
            }
        }
    }
}
