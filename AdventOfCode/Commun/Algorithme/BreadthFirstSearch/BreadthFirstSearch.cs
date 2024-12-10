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

        public ParcoursBFS<T> ParcourirDepuisLeDepart(int pPositionDepart = 0)
        {
            ElementBFSAParcourir<T> lDepart = new ElementBFSAParcourir<T>()
            {
                Element = _DonneNiemeElement(pPositionDepart),
                OrigineX = -1,
                OrigineY = -1,
            };

            lDepart.Element.Profondeur = 0;

            Queue<ElementBFSAParcourir<T>> lElementsAParcourir = new Queue<ElementBFSAParcourir<T>>();
            lElementsAParcourir.Enqueue(lDepart);
            return _Parcourir(lElementsAParcourir);
        }

        public ParcoursBFS<T> ParcoursDepuisTousLesDeparts()
        {
            Queue<ElementBFSAParcourir<T>> lElementsAParcourir = new Queue<ElementBFSAParcourir<T>>();

            foreach(T lDepart in _DonneTousLesPremiersElements())
            {
                ElementBFSAParcourir<T> lElement = new ElementBFSAParcourir<T>()
                {
                    Element = lDepart,
                    OrigineX = -1,
                    OrigineY = -1,
                };

                lElement.Element.Profondeur = 0;

                lElementsAParcourir.Enqueue(lElement);
            }

            return _Parcourir(lElementsAParcourir);
        }

        private ParcoursBFS<T> _Parcourir(Queue<ElementBFSAParcourir<T>> pElementsAParcourir)
        {
            if(pElementsAParcourir.Count == 0)
            {
                return _Parcours;
            }

            ElementBFSAParcourir<T> lElement = pElementsAParcourir.Dequeue();
            int lNombreTest = 0;
            do
            {
                lElement.Element.NombreAcces++;

                T lElementATester = lElement.Element;
                IEnumerable<T> lElementsSuivant = lElementATester.DonneElementsAccessible(_Parcours, lElement.OrigineX, lElement.OrigineY);

                foreach (T lElementSuivant in lElementsSuivant)
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

                        pElementsAParcourir.Enqueue(lSuivant);
                    }
                }

                if (pElementsAParcourir.Count == 0)
                {
                    lElement = null;
                }
                else
                {
                    lElement = pElementsAParcourir.Dequeue();
                }

                if ((ModeDeTest || EntreesHelper.EstEnmodeTest) && (lNombreTest % 1000 == 0 || lElement == null))
                {
                    _DessinerGrille();
                }

                lNombreTest++;

            } while (lElement != null && lElement.Element.EstALaFin == false);

            return _Parcours;
        }

        private T _DonneNiemeElement(int pPosition)
        {
            return _Parcours.Cases.SelectMany(o => o)
                                  .Where(o => o.EstAuDepart)
                                  .Skip(pPosition)
                                  .First();
        }

        private IEnumerable<T> _DonneTousLesPremiersElements()
        {
            return _Parcours.Cases.SelectMany(o => o)
                                  .Where(o => o.EstAuDepart);
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
