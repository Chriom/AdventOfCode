using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour22
{
    public class Jenga
    {
        private List<Brique> _Briques;

        private Dictionary<int, Brique> _DicoBriques;


        private int[][][] _Tour;

        private int _X;
        private int _Y;
        private int _Z;

        public Jenga(IEnumerable<Brique> pBriques)
        {
            _Briques = pBriques.OrderBy(o => Math.Min(o.Debut.Z, o.Fin.Z))
                               .ToList();

            _DicoBriques = _Briques.ToDictionary(o => o.Identifiant, o => o);

            _ConstruireTour();
        }

        private void _ConstruireTour()
        {
            _InitialiserTour();

            _PlacerBriques();

            _FaireTomberBrique();

            _DeterminerQuiReposentSurQui();          
        }

        private void _InitialiserTour()
        {
            _X = _Briques.Max(o => Math.Max(o.Debut.X, o.Fin.X)) + 1;
            _Y = _Briques.Max(o => Math.Max(o.Debut.Y, o.Fin.Y)) + 1;
            _Z = _Briques.Max(o => Math.Max(o.Debut.Z, o.Fin.Z)) + 1;

            _Tour = new int[_Z + 1][][];

            //Initialisation
            for (int lIndexZ = 0; lIndexZ < _Z + 1; lIndexZ++)
            {
                _Tour[lIndexZ] = new int[_Y][];
                for (int lIndexY = 0; lIndexY < _Y; lIndexY++)
                {
                    _Tour[lIndexZ][lIndexY] = new int[_X];
                }
            }
        }

        private void _PlacerBriques()
        {
            foreach(Brique lBrique in _Briques)
            {
                foreach(Position3D lPosition in lBrique.DonnePositions())
                {
                    _Tour[lPosition.Z][lPosition.Y][lPosition.X] = lBrique.Identifiant;
                }
            }
        }

        private void _FaireTomberBrique()
        {
            //Bidouille s'il faut passer deux fois mais normalement non
            int lNombreMouvement = 0;
            do
            {
                lNombreMouvement = 0;

                foreach (Brique lBrique in _Briques)
                {
                    //Trié par Z donc en théorie théorique, on les fait dans l'ordre
                    List<Position3D> lPositionsBrique = lBrique.DonnePositions().ToList();

                    if (lPositionsBrique.Any(o => o.Z == 1))
                    {
                        //Déja en bas
                        continue;
                    }

                    //On descend les briques
                    if (lBrique.Orientation == Orientation.Vertical)
                    {
                        //On cherche juste en dessous
                        int lZBrique = lBrique.Debut.Z;
                        for(int lZ = lZBrique - 1; lZ >= 0; lZ--)
                        {
                            if (_Tour[lZ][lBrique.Debut.Y][lBrique.Debut.X] != 0)
                            {
                                break;
                            }

                            //Maj Tour
                            _Tour[lBrique.Fin.Z][lBrique.Fin.Y][lBrique.Fin.X] = 0; //Haut => 0
                            _Tour[lZ][lBrique.Fin.Y][lBrique.Fin.X] = lBrique.Identifiant; // Dessous => Identifiant

                            //Maj Brique
                            lBrique.Debut.Z -= 1;
                            lBrique.Fin.Z -= 1;

                            

                            lNombreMouvement++;
                        }
                    }
                    else
                    {
                        //Faut voir la ligne complète
                        int lZBrique = lBrique.Debut.Z;
                        for (int lZ = lZBrique - 1; lZ > 0; lZ--)
                        {
                            if (lPositionsBrique.All(o => _Tour[lZ][o.Y][o.X] == 0))
                            {
                                //Toute les positions dégagé => on descend la ligne

                                foreach(Position3D lPosition in lPositionsBrique)
                                {
                                    _Tour[lZ + 1][lPosition.Y][lPosition.X] = 0; //Haut => 0
                                    _Tour[lZ][lPosition.Y][lPosition.X] = lBrique.Identifiant; // Dessous => Identifiant
                                }


                                lBrique.Debut.Z -= 1;
                                lBrique.Fin.Z -= 1;

                                lNombreMouvement++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            } while (lNombreMouvement > 0);
            
        }

        private void _DeterminerQuiReposentSurQui()
        {
            for (int lIndexZ = _Z - 1; lIndexZ > 0; lIndexZ--)
            {
                for (int lIndexY = 0; lIndexY < _Y; lIndexY++)
                {
                    for(int lIndexX = 0; lIndexX < _X; lIndexX++)
                    {
                        int lIndexBrique = _Tour[lIndexZ][lIndexY][lIndexX];
                        int lIndexBriqueHaut = _Tour[lIndexZ + 1][lIndexY][lIndexX];

                        if(lIndexBrique > 0 && lIndexBriqueHaut > 0 && lIndexBrique != lIndexBriqueHaut)
                        {
                            //Une autre brique sur celle-ci
                            Brique lEnBas = _DicoBriques[lIndexBrique];
                            Brique lEnHaut = _DicoBriques[lIndexBriqueHaut];


                            if(lEnBas.BriquesDessus.Any(o => o.Identifiant == lIndexBriqueHaut) == false)
                            {
                                lEnBas.BriquesDessus.Add(lEnHaut);
                            }
                            if (lEnHaut.BriquesDessous.Any(o => o.Identifiant == lIndexBrique) == false)
                            {
                                lEnHaut.BriquesDessous.Add(lEnBas);
                            }
                        }
                    }
                }
            }
        }

        public int DonneNombreBriquePouvantEtreDesintegree()
        {
            int lNombreBrique = 0;

            foreach(Brique lBrique in _Briques)
            {
                if(lBrique.BriquesDessus.Count == 0 || lBrique.BriquesDessus.All(o => o.BriquesDessous.Count > 1))
                {
                    lNombreBrique++;
                }
            }

            return lNombreBrique;
        }

        public int DonneNombreDeBriqueQuiVontTomberEnChaine()
        {
            int lNombreBrique = 0;

            foreach(Brique lBrique in _Briques)
            {
                //Si au moins une brique dessu ne repose que sur celle la
                if (lBrique.BriquesDessus.Any(o => o.BriquesDessous.Count == 1))
                {
                    //ça tombe
                    Queue<Brique> lBriquesAChopperLesParents = new Queue<Brique>();
                    List<int> lIdentifiantEnHaut = new List<int>();


                    foreach(Brique lBriqueDessu in lBrique.BriquesDessus.Where(o => o.BriquesDessous.Count == 1))
                    {
                        lBriquesAChopperLesParents.Enqueue(lBriqueDessu);
                    }

                    Brique lBriqueTest = lBriquesAChopperLesParents.Dequeue();
                    do
                    {
                        lIdentifiantEnHaut.Add(lBriqueTest.Identifiant);

                        //Les brique au dessue qui repose que sur celle la ou si toutes les brique dessou sont entrain de tomber
                        foreach (Brique lParent in lBriqueTest.BriquesDessus.Where(o => o.BriquesDessous.Count == 1 || o.BriquesDessous.All(o => lIdentifiantEnHaut.Contains(o.Identifiant))))
                        {
                            lBriquesAChopperLesParents.Enqueue(lParent);
                        }

                        if (lBriquesAChopperLesParents.Count > 0)
                        {
                            lBriqueTest = lBriquesAChopperLesParents.Dequeue();
                        }
                        else
                        {
                            lBriqueTest = null;
                        }

                    } while (lBriqueTest != null);

                    lNombreBrique += lIdentifiantEnHaut.Distinct()
                                                       .Count();
                }
            }

            return lNombreBrique;
        }
   
    }
}
