using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour05
{
    public class RegleEtOrdreDeFabrication
    {
        private List<Regle> _Regles { get; set; }

        Dictionary<int, List<int>> _DicoRegles;

        private List<OrdreDeFabrication> _Ordres { get; set; }

        public RegleEtOrdreDeFabrication(List<Regle> pRegles, List<OrdreDeFabrication> pOrdres)
        {
            _Regles = pRegles;
            _Ordres = pOrdres;

            _DicoRegles = _Regles.GroupBy(o => o.NumeroPageAvant)
                                 .ToDictionary(o => o.Key, o => o.Select(p => p.NumeroPageApres)
                                                                 .ToList());
        }

        public int DonneSommePageCentraleValide()
        {
            int lTotal = 0;

            foreach(OrdreDeFabrication lOrdre in _Ordres)
            {
                if (lOrdre.EstValide(_DicoRegles))
                {
                    lTotal += lOrdre.NumeroPageCentrale;
                }
            }

            return lTotal;
        }

        public int DonneSommePageCentraleAvecReordonnemant()
        {
            return _Ordres.Where(o => o.EstValide(_DicoRegles) == false)
                          .Sum(o => o.DonnePageCentralAvecOrdreDansLeBonOrdre(_DicoRegles));
        }
    }
}
