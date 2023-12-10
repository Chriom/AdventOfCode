using AdventOfCode.Commun.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour08
{
    public class Carte
    {
        private List<Mouvement> _Directions;

        private List<Noeud> _Noeuds;

        public Carte(List<Mouvement> pMouvements, List<Noeud> pNoeuds)
        {
            _Directions = pMouvements;
            _Noeuds = pNoeuds;
        }

        public int DonneNombreEtapePourParcourirJusquaLaFin()
        {
            
            Noeud lNoeud = _Noeuds.First(o => o.EstAuDebut);

            int lNombreEtape = 0;
            Queue<Mouvement> lMouvements = new Queue<Mouvement>();


            do
            {
                if (lMouvements.Count == 0)
                {
                    _AjouterALaQueue(lMouvements);
                }

                Mouvement lMouvement = lMouvements.Dequeue();

                lNoeud = lMouvement switch
                {
                    Mouvement.Gauche => lNoeud.Gauche,
                    Mouvement.Droite => lNoeud.Droite,
                    _ => throw new ArgumentOutOfRangeException(nameof(lMouvement))
                };

                lNombreEtape++;
            } while (lNoeud.EstALaFin == false);

            return lNombreEtape;
        }

        public decimal DonneNombreEtapePourParcourirJusquaLaFinPourUnFamtome()
        {
            List<Noeud> lNoeuds = _Noeuds.Where(o => o.EstAuDebutPourUnFamtome)
                                         .ToList();

            Queue<Mouvement> lMouvements = new Queue<Mouvement>();

            Dictionary<Noeud, List<int>> lDicoResultats = new Dictionary<Noeud, List<int>>();
            foreach(Noeud lNoeud in lNoeuds)
            {
                lDicoResultats.Add(lNoeud, _ParcourirNoeudFamtome(lNoeud));
            }


            //Recherche du plus Petit Commun Multiple
            List<decimal> lMultiplesCandidat = _DonneListeMultiplicateur(lDicoResultats.Select(o => o.Value).ToList());



            return lMultiplesCandidat.Min();
        }

        private List<int> _ParcourirNoeudFamtome(Noeud pNoeud)
        {
            List<int> lEtapesFin = new List<int>();
            int lNombreEtape = 0;
            Queue<Mouvement> lMouvements = new Queue<Mouvement>();
            _AjouterALaQueue(lMouvements);

            int lNombreNoeudFin = _Noeuds.Count(o => o.EstALaFinPourUnFamtome);
            do
            {
                if (lMouvements.Count == 0)
                {
                    if(lEtapesFin.Count == lNombreNoeudFin)
                    {
                        break;
                    }
                    _AjouterALaQueue(lMouvements);
                }

                
                Mouvement lMouvement = lMouvements.Dequeue();

                pNoeud = lMouvement switch
                {
                    Mouvement.Gauche => pNoeud.Gauche,
                    Mouvement.Droite => pNoeud.Droite,
                    _ => throw new ArgumentOutOfRangeException(nameof(lMouvement))
                };

                lNombreEtape++;

                if (pNoeud.EstALaFinPourUnFamtome)
                {
                    lEtapesFin.Add(lNombreEtape);
                }

            } while (true);

            return lEtapesFin;
        }


        private void _AjouterALaQueue(Queue<Mouvement> pQueue)
        {
            foreach(Mouvement lMouvement in _Directions)
            {
                pQueue.Enqueue(lMouvement);
            }
        }

        private List<decimal> _DonneListeMultiplicateur(List<List<int>> pListeATraiter)
        {
            List<decimal> lResultats = new List<decimal>();

            List<int> lPrincipal = pListeATraiter.First();
            
            List<List<int>> lSuivante = pListeATraiter.Skip(1).ToList();

            if(lSuivante.Count > 1)
            {
                //Encore des sous Liste
                List<decimal> lSuiteChaine = _DonneListeMultiplicateur(lSuivante);

                foreach (int lUn in lPrincipal)
                {
                    foreach (decimal lDeux in lSuiteChaine)
                    {
                        lResultats.Add(MathsHelper.PlusPetitCommunMultiplicateur(lUn, lDeux));
                    }
                }
            }
            else
            {
                //Ajout des résultats
                List<int> lSeconde = lSuivante.First();

                foreach(int lUn in lPrincipal)
                {
                    foreach(int lDeux in lSeconde)
                    {
                        lResultats.Add(MathsHelper.PlusPetitCommunMultiplicateur(lUn, lDeux));
                    }
                }
            }


            return lResultats.Distinct()
                             .ToList();
        }
    }
}
