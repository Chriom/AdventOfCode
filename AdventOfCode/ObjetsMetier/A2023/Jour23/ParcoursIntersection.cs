using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour23
{
    public class ParcoursIntersection
    {
        public HashSet<string> IntersectionParcouru { get; set; }  = new HashSet<string>();

        public Intersection IntersectionCourante { get; set; }

        public int DistanceTotale { get; set; }


        public List<ParcoursIntersection> DonneParcoursEnfant(Dictionary<string, int> pDicoDistance)
        {
            List<ParcoursIntersection> lIntersectionsRestante = new List<ParcoursIntersection>();

            foreach(Intersection lEnfant in IntersectionCourante.IntersectionLies)
            {
                if(IntersectionParcouru.Contains(lEnfant.Cle) == false)
                {
                    //Sinon c'est déja parcouru
                    ParcoursIntersection lIntersectionEnfant = new ParcoursIntersection()
                    {
                        DistanceTotale = DistanceTotale + pDicoDistance[$"{IntersectionCourante.Cle}__{lEnfant.Cle}"] - 1,
                        IntersectionCourante = lEnfant,
                    };

                    //Copie du parcour
                    foreach(string lCleParcouru in IntersectionParcouru)
                    {
                        lIntersectionEnfant.IntersectionParcouru.Add(lCleParcouru);
                    }
                    lIntersectionEnfant.IntersectionParcouru.Add(lEnfant.Cle);

                    lIntersectionsRestante.Add(lIntersectionEnfant);
                }
            }

            return lIntersectionsRestante;
        }
    }
}
