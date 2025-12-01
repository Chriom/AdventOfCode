using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour05
{
    public class OrdreDeFabrication
    {
        public List<int> NumerosPage { get; set; } = new List<int>();

        public int NumeroPageCentrale => NumerosPage[(int)Math.Floor((decimal)(NumerosPage.Count) / 2)];

        public bool EstValide(Dictionary<int, List<int>> pRegles)
        {
            for(int lIndex = 1; lIndex < NumerosPage.Count; lIndex++)
            {
                int lNumeroPage = NumerosPage[lIndex];

                if (pRegles.ContainsKey(lNumeroPage)) 
                {
                    if (NumerosPage.Take(lIndex).Intersect(pRegles[lNumeroPage]).Count() > 0)
                    {
                        return false;
                    }
                }
                
            }

            return true;
        }

        public int DonnePageCentralAvecOrdreDansLeBonOrdre(Dictionary<int, List<int>> pRegles)
        {
            OrdreDeFabrication lOrdre = this;

            while (lOrdre.EstValide(pRegles) == false)
            {
                for (int lIndex = 0; lIndex < lOrdre.NumerosPage.Count; lIndex++)
                {
                    int lNumeroPage = lOrdre.NumerosPage[lIndex];

                    if (pRegles.ContainsKey(lNumeroPage))
                    {
                        List<int> lIntersect = lOrdre.NumerosPage.Take(lIndex)
                                                                 .Intersect(pRegles[lNumeroPage])
                                                                 .ToList();

                        if(lIntersect.Count > 0)
                        {
                            OrdreDeFabrication lOrdrePresqueTrie = new OrdreDeFabrication();

                            //Reprise du début
                            for (int lIndexNouveau = 0; lIndexNouveau < lIndex; lIndexNouveau++)
                            {
                                if (lIntersect.Contains(lOrdre.NumerosPage[lIndexNouveau]))
                                {
                                    continue;
                                }

                                lOrdrePresqueTrie.NumerosPage.Add(lOrdre.NumerosPage[lIndexNouveau]);
                            }
                            
                            //Ajout du nombre actuel
                            lOrdrePresqueTrie.NumerosPage.Add(lNumeroPage);

                            //Ajout des suivant avant le nom
                            foreach (int lNumeroApres in lIntersect)
                            {
                                lOrdrePresqueTrie.NumerosPage.Add(lNumeroApres);
                            }



                            //Ajout des restant
                            foreach (int lALaFin in lOrdre.NumerosPage.Skip(lIndex + 1)
                                                                     .Where(o => lIntersect.Contains(o) == false))
                            {
                                lOrdrePresqueTrie.NumerosPage.Add(lALaFin);
                            }

                            lOrdre = lOrdrePresqueTrie;
                            break;
                        }
                        
                    }

                }
            }

            return lOrdre.NumeroPageCentrale;
        }
    }
}
