using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour13
{
    public class IleDeLave
    {
        private const char _CENDRE = '.';
        private const char _CAILLOU = '#';


        private char[][] _Ile;

        private Dictionary<int, LigneEtColonne> _Lignes;
        private Dictionary<int, LigneEtColonne> _Colonnes;

        private int _Largeur;
        private int _Hauteur;

        public IleDeLave(char[][] pIle)
        {
            _Ile = pIle;

            _Largeur = _Ile.First().Length;
            _Hauteur = _Ile.Length;

            _Analyser();
        }

        private void _Analyser()
        {
            _Lignes = new Dictionary<int, LigneEtColonne>();
            _Colonnes = new Dictionary<int, LigneEtColonne>();

            //Lignes
            for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                string lBits = "";
                for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++) 
                {
                    lBits += _Ile[lIndexLigne][lIndexColonne] == _CENDRE ? "1" : "0";
                }

                LigneEtColonne lLigne = new LigneEtColonne()
                {
                    Id = lIndexLigne + 1,
                    Hash = Convert.ToInt32(lBits, 2),
                    Type = LigneOuColonne.Ligne,
                };

                _Lignes.Add(lLigne.Id, lLigne);
            }

            //Colonne
            for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
            {
                string lBits = "";
                for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
                {
                    lBits += _Ile[lIndexLigne][lIndexColonne] == _CENDRE ? "1" : "0";
                }

                LigneEtColonne lLigne = new LigneEtColonne()
                {
                    Id = lIndexColonne + 1,
                    Hash = Convert.ToInt32(lBits, 2),
                    Type = LigneOuColonne.Colonne,
                };

                _Colonnes.Add(lLigne.Id, lLigne);
            }
        }

        public int DonneResume()
        {
            int lLigneSymetrie = _DonneIdentifiantSymetrie(_Lignes);

            int lColonneSymetrie = _DonneIdentifiantSymetrie(_Colonnes);

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Ligne - {lLigneSymetrie} | Colonne - {lColonneSymetrie}");
            Console.WriteLine();
            Console.WriteLine(string.Join("\r\n", _Ile.Select(o => new string(o))));

            return lLigneSymetrie * 100 + lColonneSymetrie;
        }

        public int DonneResumeAvecReparation()
        {

            int lLigneSymetrieAvant = _DonneIdentifiantSymetrie(_Lignes);

            int lColonneSymetrieAvant = _DonneIdentifiantSymetrie(_Colonnes);

            _ChercheCorrectif(_Lignes);
            _ChercheCorrectif(_Colonnes);

            int lLigneSymetrie = _DonneIdentifiantSymetrie(_Lignes, lLigneSymetrieAvant);
            int lColonneSymetrie = _DonneIdentifiantSymetrie(_Colonnes, lColonneSymetrieAvant);


            Console.WriteLine();
            Console.WriteLine($"Ligne - {lLigneSymetrieAvant}/{lLigneSymetrie} | Colonne - {lColonneSymetrieAvant}/{lColonneSymetrie}");
            Console.WriteLine();
            Console.WriteLine(string.Join("\r\n", _Ile.Select(o => new string(o))));
            Console.WriteLine("--------------------------------------------------");

            if(lLigneSymetrie == 0 && lColonneSymetrie == 0)
            {
                Debugger.Break();
            }

            return lLigneSymetrie * 100 + lColonneSymetrie;

        }

        private static readonly List<int> _PUISSANCE_DE_DEUX = new List<int>()
        {
            1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576
        };

        private bool _CorrectifApplique = false;

        private int _DonneIdentifiantSymetrie(Dictionary<int, LigneEtColonne> pDico, int pNombreInterdit = -1)
        {
            int lIndexMin = pDico.Keys.Min();
            int lIndexMax = pDico.Keys.Max();


            for(int lIndex = lIndexMin + 1; lIndex <= lIndexMax; lIndex++)
            {
                //Test
                int lNombreATester = Math.Min(lIndex - lIndexMin, lIndexMax - lIndex + 1);

                if(lIndex -1 == pNombreInterdit)
                {
                    continue;
                }

                for(int lTest = 0; lTest < lNombreATester; lTest++)
                {
                    int lIndexMinTest = lIndex - 1 - lTest;
                    int lIndexMaxTest = lIndex + lTest;

                    if (lIndexMinTest < lIndexMin || lIndexMaxTest > lIndexMax)
                    {
                        break;
                    }

                    LigneEtColonne lMin = pDico[lIndexMinTest];
                    LigneEtColonne lMax = pDico[lIndexMaxTest];

                    //Pas de correctif ou mirroir corrigé => sortie de la ligne de réflexion
                    if (lMin.Hash != lMax.Hash)
                    {
                        //Pas de symétrie;
                        break;
                    }

                    if (lTest == lNombreATester - 1)
                    {
                        //Parcouru l'ensemble => c'est bon
                        return lIndex - 1;
                    }
                }

            }

            return 0;
        }

        private void _ChercheCorrectif(Dictionary<int, LigneEtColonne> pDico)
        {
            int lIndexMin = pDico.Keys.Min();
            int lIndexMax = pDico.Keys.Max();


            int lIndexCorrectifMin = -1;
            int lIndexCorrectifMax = -1;
            LigneOuColonne lType = LigneOuColonne.Ligne;

            for (int lIndex = lIndexMin + 1; lIndex <= lIndexMax; lIndex++)
            {
                if (_CorrectifApplique)
                {
                    break;
                }

                //Test
                int lNombreATester = Math.Min(lIndex - lIndexMin, lIndexMax - lIndex + 1);

                for (int lTest = 0; lTest < lNombreATester; lTest++)
                {
                    int lIndexMinTest = lIndex - 1 - lTest;
                    int lIndexMaxTest = lIndex + lTest;

                    if (lIndexMinTest < lIndexMin || lIndexMaxTest > lIndexMax)
                    {
                        break;
                    }

                    LigneEtColonne lMin = pDico[lIndexMinTest];
                    LigneEtColonne lMax = pDico[lIndexMaxTest];

                    
                    int lDifference = Math.Abs(lMin.Hash - lMax.Hash);

                    if (_PUISSANCE_DE_DEUX.Contains(lDifference) && lIndexCorrectifMin < 0 && lIndexCorrectifMax < 0)
                    {
                        //ça colle : mais faut quand même tester la suite
                        Console.WriteLine($"{lMin.Type} - {lMin.Id} - {lMax.Id}");
                        lType = lMin.Type;
                        lIndexCorrectifMin = lMin.Id;
                        lIndexCorrectifMax = lMax.Id;
                    }
                    else if(lMin.Hash != lMax.Hash)
                    {
                        lIndexCorrectifMin = -1;
                        lIndexCorrectifMax = -1;
                        break;
                    }
                }


                if (_CorrectifApplique == false && lIndexCorrectifMin > 0 && lIndexCorrectifMax > 0)
                {
                    //Tous colle
                    _Corriger(lType, lIndexCorrectifMin, lIndexCorrectifMax);
                    _CorrectifApplique = true;
                }
            }
        }

        private void _Corriger(LigneOuColonne pType, int pIndexMin, int pIndexMax)
        {
            if(pType == LigneOuColonne.Ligne)
            {
                char[] lMin = _Ile[pIndexMin - 1];

                _Ile[pIndexMax - 1] = lMin;
            }
            else
            {
                foreach (char[] lLigne in _Ile)
                {
                    lLigne[pIndexMin -1] = lLigne[pIndexMax - 1];
                }
            }

            _Analyser();
        }
    }
}
