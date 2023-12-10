using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour10;

namespace AdventOfCode.Commun.Algorithme.BreadthFirstSearch
{
    public class BreadthFirstSearch<T> where T : ElementBFS<T>, IElementBFS
    {
        private ParcoursBFS<T> _Parcours;

        private int _Hauteur;
        private int _Largeur;

        public BreadthFirstSearch(T[][] pCases)
        {
            T[][] lCases = pCases;

            _Hauteur = lCases.Length;
            _Largeur = lCases.First().Length;

            _Parcours = new ParcoursBFS<T>()
            {
                Cases = lCases,
                Hauteur = _Hauteur,
                Largeur = _Largeur,
            };
        }

        public ParcoursBFS<T> ParcourirDepuisLeDepart()
        {
            T lDepart = _DonnePremierElement();
            lDepart.Profondeur = 0;

            Queue<T> lElementsAParcourir = new Queue<T>();
            lElementsAParcourir.Enqueue(lDepart);

            T lElement = lElementsAParcourir.Dequeue();

            do
            {
                lElement.NombreAcces++;

                IEnumerable<T> lElementsSuivant = lElement.DonneElementsAccessible(_Parcours);
                
                foreach(T lElementSuivant in lElementsSuivant)
                {
                    if (lElementSuivant.EstVisitee)
                    {
                        lElementSuivant.NombreAcces++;
                    }
                    else
                    {
                        lElementSuivant.Profondeur = lElement.Profondeur + 1;
                        lElementsAParcourir.Enqueue(lElementSuivant);
                    }
                }

                if (lElementsAParcourir.Count == 0)
                {
                    lElement = null;
                }
                else
                {
                    lElement = lElementsAParcourir.Dequeue();
                }



            } while (lElement != null && lElement.EstALaFin == false);

            return _Parcours;
        }

        private T _DonnePremierElement()
        {
            return _Parcours.Cases.SelectMany(o => o)
                                  .First(o => o.EstAuDepart);
        }

    }
}
