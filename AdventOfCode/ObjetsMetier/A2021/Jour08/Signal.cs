using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour08
{
    public class Signal
    {
        private Dictionary<TypeSegment, char> _DicoAnalyse = new Dictionary<TypeSegment, char>();


        private List<Digit> _Entrees = new List<Digit>();
        private List<Afficheur> _Sorties = new List<Afficheur>();

        private static readonly Dictionary<TypeSegment, List<int>> _DicoSegmentDigitsEnCommun = new Dictionary<TypeSegment, List<int>>()
        {
            [TypeSegment.Haut] = new List<int>() { 0, 2, 3, 5, 6, 7, 8, 9 },
            [TypeSegment.HautGauche] = new List<int>() { 0, 4, 5, 6, 8, 9 },
            [TypeSegment.HautDroite] = new List<int>() { 0, 1, 2, 3, 4, 7, 8, 9 },
            [TypeSegment.Centre] = new List<int>() { 2, 3, 4, 5, 6, 8, 9 },
            [TypeSegment.BasGauche] = new List<int>() { 0, 2, 6, 8 },
            [TypeSegment.BasDroite] = new List<int>() { 0, 1, 3, 4, 5, 6, 7, 8, 9 },
            [TypeSegment.Bas] = new List<int>() { 0, 2, 3, 5, 6, 8, 9 },

        };

        public Signal(IEnumerable<string> pEntrees, IEnumerable<string> pSorties)
        {
            _Entrees = pEntrees.Select(o => new Digit(o))
                               .ToList();

            _Sorties = pSorties.Select(o => new Afficheur(o))
                               .ToList();
        }


        public void AnalyserSorties()
        {
            foreach(Afficheur lAfficheur in _Sorties) 
            {
                lAfficheur.AnalyserChaine(_DicoAnalyse);
            }
        }

        public List<Afficheur> Afficheurs
        {
            get
            {
                return _Sorties;
            }
        }

        public void AnalyserEntrees()
        {
            do
            {
                
                foreach (Digit lDigit in _Entrees)
                {
                    if(lDigit.EstTrouve == false)
                    {
                        lDigit.AnalyserDigit(_DicoAnalyse);
                    }                 
                }

                List<int> lTrouve = _Entrees.Where(o => o.EstTrouve)
                                            .Select(o => o.DigitTrouve)
                                            .ToList();

                foreach (Digit lDigit in _Entrees)
                {
                    if (lDigit.EstTrouve == false)
                    {
                        lDigit.SupprimerTrouverDesPossible(lTrouve);
                    }
                }

                _AnalyserResultat();

            } while (_DicoAnalyse.Count < 7);
           
        }

        private void _AnalyserResultat()
        {
            Dictionary<int, Digit> lDicoResultats = _Entrees.Where(o => o.EstTrouve)
                                                            .ToDictionary(o => o.DigitTrouve, o => o);

            if(_DicoAnalyse.ContainsKey(TypeSegment.Haut) == false)
            {
                _RechercheHaut(lDicoResultats);
            }

            if (_DicoAnalyse.ContainsKey(TypeSegment.BasGauche) == false)
            {
                _RechercheBasGauche(lDicoResultats);
            }

            if (_DicoAnalyse.ContainsKey(TypeSegment.HautDroite) == false)
            {
                _RechercheHautDroite(lDicoResultats);
            }

            if (_DicoAnalyse.ContainsKey(TypeSegment.BasDroite) == false)
            {
                _RechercheBasDroite(lDicoResultats);
            }

            if (_DicoAnalyse.ContainsKey(TypeSegment.HautGauche) == false)
            {
                _RechercheHautGauche(lDicoResultats);
            }

            if (_DicoAnalyse.ContainsKey(TypeSegment.Centre) == false)
            {
                _RechercheCentre(lDicoResultats);
            }

            if (_DicoAnalyse.ContainsKey(TypeSegment.Bas) == false)
            {
                _RechercheBas(lDicoResultats);
            }

        }

        private void _RechercheHaut(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 7 mais pas dans le 1
            char? lCharHaut = _DonneCharactereUnique(7, 1, pDicoResultats);

            if(lCharHaut.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.Haut, lCharHaut.Value);
                return;
            }                
        }

        private void _RechercheBasGauche(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 6 mais pas dans le 5
            char? lCharBasGauche = _DonneCharactereUnique(6, 5, pDicoResultats);

            if (lCharBasGauche.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.BasGauche, lCharBasGauche.Value);
                return;
            }

            //Charactère dans le 2 mais pas dans les 3 et 5 ni dans le 4
            lCharBasGauche = _DonneCharactereUniqueEnTenantCompteDesPossible(new List<int>() { 2, 3, 5, 4 });

            if (lCharBasGauche.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.BasGauche, lCharBasGauche.Value);
                return;
            }
        }

        private void _RechercheHautDroite(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 8 mais pas dans le 6
            char? lCharHautDroite = _DonneCharactereUnique(8, 6, pDicoResultats);

            if (lCharHautDroite.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.HautDroite, lCharHautDroite.Value);
                return;
            }
        }

        private void _RechercheBasDroite(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 1 mais pas dans le 6

            char? lCharBasDroite = _DonneCharactereUnique(1, 6, pDicoResultats);

            if (lCharBasDroite.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.BasDroite, lCharBasDroite.Value);
                return;
            }
            //Charactère dans le 7 mais pas dans le 2
            lCharBasDroite = _DonneCharactereUnique(7, 2, pDicoResultats);

            if (lCharBasDroite.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.BasDroite, lCharBasDroite.Value);
                return;
            }
        }

        private void _RechercheHautGauche(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 4 mais pas dans le 3
            char? lCharHautGauche = _DonneCharactereUnique(4, 3, pDicoResultats);

            if (lCharHautGauche.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.HautGauche, lCharHautGauche.Value);
                return;
            }
        }

        private void _RechercheCentre(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 8 mais pas dans le 0
            char? lCharCentre = _DonneCharactereUnique(8, 0, pDicoResultats);

            if (lCharCentre.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.Centre, lCharCentre.Value);
                return;
            }

            //Charactère dans le 6 mais pas les 0 et 7
            lCharCentre = _DonneCharactereUniqueEnTenantCompteDesPossible(new List<int> { 6, 0, 7});

            if (lCharCentre.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.Centre, lCharCentre.Value);
                return;
            }
        }

        private void _RechercheBas(Dictionary<int, Digit> pDicoResultats)
        {
            //Charactère dans le 9 mais pas les 4 et 7
            char? lCharBas = _DonneCharactereUnique(9, new List<int>() {4, 7}, pDicoResultats);

            if (lCharBas.HasValue)
            {
                _DicoAnalyse.Add(TypeSegment.Bas, lCharBas.Value);
                return;
            }

        }

        private char? _DonneCharactereUnique(int pDigitAvec, int pDigitSans, Dictionary<int, Digit> pDicoResultats)
        {
            return _DonneCharactereUnique(pDigitAvec, new List<int>() { pDigitSans }, pDicoResultats);
        }

        private char? _DonneCharactereUnique(int pDigitAvec, List<int> pDigitsSans, Dictionary<int, Digit> pDicoResultats)
        {
            if (pDicoResultats.ContainsKey(pDigitAvec) && pDigitsSans.All(o => pDicoResultats.ContainsKey(o)))
            {
                List<char> lCharUniqueARetirer = pDigitsSans.SelectMany(o => pDicoResultats[o].Characteres)
                                                            .ToList();

                return pDicoResultats[pDigitAvec].Characteres.Except(lCharUniqueARetirer)
                                                             .First();
            }

            return null;
        }

        private char? _DonneCharactereUniqueEnTenantCompteDesPossible(List<int> pDigitsPossible)
        {
            List<Digit> lDigitsPossible = _Entrees.Where(o => pDigitsPossible.Any(p => o.DigitsPossible.Contains(p)))
                                                  .ToList();

            var lCharUnique = lDigitsPossible.SelectMany(o => o.Characteres)
                                             .GroupBy(o => o)
                                             .Where(o => o.Count() == 1);

            if(lCharUnique.Count() == 1)
            {
                return lCharUnique.First().Key;
            }

            return null;
        }

        public int NombreAffiche => int.Parse(string.Join("", Afficheurs.Select(o => o.Digit)));
        
    }
}
