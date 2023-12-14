using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.ObjetsMetier.A2023.Jour14
{
    public class Plateforme
    {
        private int _Hauteur;
        private int _Largeur;

        private TypeElement[][] _Plateforme;

        public Plateforme(TypeElement[][] pPlateforme)
        {
            _Hauteur = pPlateforme.Length;
            _Largeur = pPlateforme.First().Length;

            _Plateforme = pPlateforme;
        }

        public void Deplacer(Direction pDirection)
        {
            if (pDirection == Direction.Nord)
            {
                //Pas besoin de traiter la première ligne
                for (int lIndexHaut = 1; lIndexHaut < _Hauteur; lIndexHaut++)
                {
                    for (int lIndexLigne = 0; lIndexLigne < _Largeur; lIndexLigne++)
                    {
                        if (_Plateforme[lIndexHaut][lIndexLigne] == TypeElement.PierreRoulante)
                        {
                            //Il faut la remonter
                            int lIndexPrecedent = lIndexHaut - 1;

                            int lDerniereCaseValide = lIndexHaut;

                            while (lIndexPrecedent >= 0)
                            {
                                if (_Plateforme[lIndexPrecedent][lIndexLigne] == TypeElement.Vide)
                                {
                                    lDerniereCaseValide = lIndexPrecedent;
                                }
                                if (_Plateforme[lIndexPrecedent][lIndexLigne] == TypeElement.PierreRoulante ||
                                    _Plateforme[lIndexPrecedent][lIndexLigne] == TypeElement.PierreCarree)
                                {
                                    break;
                                }

                                lIndexPrecedent--;
                            }

                            if (lDerniereCaseValide != lIndexHaut)
                            {
                                _Plateforme[lDerniereCaseValide][lIndexLigne] = TypeElement.PierreRoulante;
                                _Plateforme[lIndexHaut][lIndexLigne] = TypeElement.Vide;
                            }

                        }
                    }
                }
            }
            else if (pDirection == Direction.Sud)
            {
                //Pas besoin de traiter la dernière ligne
                for (int lIndexBas = _Hauteur - 2; lIndexBas >= 0; lIndexBas--)
                {
                    for (int lIndexLigne = 0; lIndexLigne < _Largeur; lIndexLigne++)
                    {
                        if (_Plateforme[lIndexBas][lIndexLigne] == TypeElement.PierreRoulante)
                        {
                            //Il faut la descendre
                            int lIndexPrecedent = lIndexBas + 1;

                            int lDerniereCaseValide = lIndexBas;

                            while (lIndexPrecedent < _Largeur)
                            {
                                if (_Plateforme[lIndexPrecedent][lIndexLigne] == TypeElement.Vide)
                                {
                                    lDerniereCaseValide = lIndexPrecedent;
                                }
                                if (_Plateforme[lIndexPrecedent][lIndexLigne] == TypeElement.PierreRoulante ||
                                    _Plateforme[lIndexPrecedent][lIndexLigne] == TypeElement.PierreCarree)
                                {
                                    break;
                                }

                                lIndexPrecedent++;
                            }

                            if (lDerniereCaseValide != lIndexBas)
                            {
                                _Plateforme[lDerniereCaseValide][lIndexLigne] = TypeElement.PierreRoulante;
                                _Plateforme[lIndexBas][lIndexLigne] = TypeElement.Vide;
                            }

                        }
                    }
                }
            }
            else if (pDirection == Direction.Est)
            {
                for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
                {
                    //Traitement ligne par ligne
                    //Pas besoin de traiter tout à droite
                    for(int lIndexDroite = _Largeur - 2; lIndexDroite >= 0; lIndexDroite--)
                    {
                        if (_Plateforme[lIndexLigne][lIndexDroite] == TypeElement.PierreRoulante)
                        {
                            int lIndexPrecedent = lIndexDroite + 1;

                            int lDerniereCaseValide = lIndexDroite;

                            while (lIndexPrecedent < _Largeur)
                            {
                                if (_Plateforme[lIndexLigne][lIndexPrecedent] == TypeElement.Vide)
                                {
                                    lDerniereCaseValide = lIndexPrecedent;
                                }
                                if (_Plateforme[lIndexLigne][lIndexPrecedent] == TypeElement.PierreRoulante ||
                                    _Plateforme[lIndexLigne][lIndexPrecedent] == TypeElement.PierreCarree)
                                {
                                    break;
                                }

                                lIndexPrecedent++;
                            }

                            if (lDerniereCaseValide != lIndexDroite)
                            {
                                _Plateforme[lIndexLigne][lDerniereCaseValide] = TypeElement.PierreRoulante;
                                _Plateforme[lIndexLigne][lIndexDroite] = TypeElement.Vide;
                            }

                        }
                    }
                }
            }
            else if (pDirection == Direction.Ouest)
            {
                for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
                {
                    //Traitement ligne par ligne
                    //Pas besoin de traiter tout à gauche
                    for (int lIndexGauche = 1; lIndexGauche < _Largeur; lIndexGauche++)
                    {
                        if (_Plateforme[lIndexLigne][lIndexGauche] == TypeElement.PierreRoulante)
                        {
                            int lIndexPrecedent = lIndexGauche - 1;

                            int lDerniereCaseValide = lIndexGauche;

                            while (lIndexPrecedent >= 0)
                            {
                                if (_Plateforme[lIndexLigne][lIndexPrecedent] == TypeElement.Vide)
                                {
                                    lDerniereCaseValide = lIndexPrecedent;
                                }
                                if (_Plateforme[lIndexLigne][lIndexPrecedent] == TypeElement.PierreRoulante ||
                                    _Plateforme[lIndexLigne][lIndexPrecedent] == TypeElement.PierreCarree)
                                {
                                    break;
                                }

                                lIndexPrecedent--;
                            }

                            if (lDerniereCaseValide != lIndexGauche)
                            {
                                _Plateforme[lIndexLigne][lDerniereCaseValide] = TypeElement.PierreRoulante;
                                _Plateforme[lIndexLigne][lIndexGauche] = TypeElement.Vide;
                            }

                        }
                    }
                }
            }
        }

        public void AfficheCarte()
        {
            Console.WriteLine();
            Console.WriteLine(_DonneCarte());
        }

        private string _DonneCarte()
        {
            return string.Join("\r\n", _Plateforme.Select(o => string.Join("", o.Select(p => p.DonneDescription()))));
        }

        public int DonneChargeTotal()
        {
            int lTotal = 0;

            int lHauteur = _Hauteur;
            foreach (TypeElement[] lElement in _Plateforme)
            {
                lTotal += (lElement.Count(o => o == TypeElement.PierreRoulante) * lHauteur);

                lHauteur--;
            }

            return lTotal;
        }

        private const int _NOMBRE_CICLE = 1000000000;
        

        private Dictionary<string, CachePlateforme> _CacheCycle;

        public void EffectuerCycles()
        {
            _CacheCycle = new Dictionary<string, CachePlateforme>();

            string lCle = _DonneCarte();
            bool lPassageFait = false;

            for (int lNumeroCycle = 1; lNumeroCycle <= _NOMBRE_CICLE; lNumeroCycle++)
            {
                
                if(_CacheCycle.TryGetValue(lCle, out CachePlateforme lPlateformeCache))
                {
                    //Récupération dans le cache
                    if(lPassageFait == false)
                    {
                        int lNombreCycleEcoule = lNumeroCycle - lPlateformeCache.NumeroCycle;

                        int lNombreDeCycleAPasser = (int)Math.Floor((_NOMBRE_CICLE - lNumeroCycle) / (decimal)lNombreCycleEcoule);

                        lNumeroCycle += (lNombreDeCycleAPasser * lNombreCycleEcoule);

                        lPassageFait = true;
                    }

                    _Plateforme = lPlateformeCache.Plateforme;
                    lCle = _DonneCarte();
                    continue;
                }


                Deplacer(Direction.Nord);
                Deplacer(Direction.Ouest);
                Deplacer(Direction.Sud);
                Deplacer(Direction.Est);


                _CacheCycle.Add(lCle, new CachePlateforme()
                {
                    NumeroCycle = lNumeroCycle,
                    Plateforme = _CopierPlateforme(),
                });

                lCle = _DonneCarte();

                if (lNumeroCycle == 1 || lNumeroCycle == 2 || lNumeroCycle == 3 || lNumeroCycle % 10000 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Cycle n°{lNumeroCycle}");
                    AfficheCarte();
                }
            }
        }

        private TypeElement[][] _CopierPlateforme()
        {
            TypeElement[][] lPlateformeCopie = new TypeElement[_Hauteur][];


            for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                lPlateformeCopie[lIndexLigne] = new TypeElement[_Largeur];
                for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lPlateformeCopie[lIndexLigne][lIndexColonne] = _Plateforme[lIndexLigne][lIndexColonne];
                }
            }

            return lPlateformeCopie;
        }
    }
}
