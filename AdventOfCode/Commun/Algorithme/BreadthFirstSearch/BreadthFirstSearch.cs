using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.Commun.Algorithme.BreadthFirstSearch
{
    public class BreadthFirstSearch<T> where T : ElementBFS<T>, IElementBFS
    {
        private ParcoursBFS<T> _Parcours;

        private int _Hauteur;
        private int _Largeur;

        public bool ModeDeTest { get; set; }

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
            ElementBFSAParcourir<T> lDepart = new ElementBFSAParcourir<T>()
            {
                Element = _DonnePremierElement(),
                OrigineX = -1,
                OrigineY = -1,
            };

            lDepart.Element.Profondeur = 0;

            int lNombreTest = 0;

            Queue<ElementBFSAParcourir<T>> lElementsAParcourir = new Queue<ElementBFSAParcourir<T>>();
            lElementsAParcourir.Enqueue(lDepart);

            ElementBFSAParcourir<T> lElement = lElementsAParcourir.Dequeue();

            do
            {
                lElement.Element.NombreAcces++;

                T lElementATester = lElement.Element;
                IEnumerable<T> lElementsSuivant = lElementATester.DonneElementsAccessible(_Parcours, lElement.OrigineX, lElement.OrigineY);
                
                foreach(T lElementSuivant in lElementsSuivant)
                {
                    if (lElementSuivant.EstVisitee)
                    {
                        lElementSuivant.NombreAcces++;
                    }
                    else
                    {
                        lElementSuivant.Profondeur = lElementATester.Profondeur + 1;

                        ElementBFSAParcourir<T> lSuivant = new ElementBFSAParcourir<T>()
                        {
                            Element = lElementSuivant,
                            OrigineX = lElementATester.PositionX,
                            OrigineY = lElementATester.PositionY
                        };

                        lElementsAParcourir.Enqueue(lSuivant);
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

                if ((ModeDeTest || EntreesHelper.EstEnmodeTest)  && (lNombreTest % 1000 == 0 || lElement == null))
                {
                    _DessinerGrille();
                }

                lNombreTest++;

            } while (lElement != null && lElement.Element.EstALaFin == false);

            return _Parcours;
        }

        private T _DonnePremierElement()
        {
            return _Parcours.Cases.SelectMany(o => o)
                                  .First(o => o.EstAuDepart);
        }

        private void _DessinerGrille()
        {
            if(EntreesHelper.EstEnmodeTest == false)
            {
                Console.Clear();

                foreach (T[] lLigne in _Parcours.Cases)
                {
                    Console.WriteLine(string.Join("", lLigne.Select(o => o.ToString())));
                }
            }
            else
            {
                Debug.WriteLine("");
                Debug.WriteLine(string.Join("", Enumerable.Repeat("-", _Largeur)));
                Debug.WriteLine("");

                foreach (T[] lLigne in _Parcours.Cases)
                {
                    Debug.WriteLine(string.Join("", lLigne.Select(o => o.ToString())));
                }
            }
            
            
            
            
        }
    }
}
