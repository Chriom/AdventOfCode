using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour04
{
    public class Grille
    {
        private int[][] _Grille;
        private bool[][] _GrilleSelectionnee;

        private const int _TAILLE_GRILLE = 5;

        public Grille(IEnumerable<string> pNumeros)
        {
            _Initialiser(pNumeros.ToList());


        }

        private void _Initialiser(List<string> pNumeros)
        {
            _Grille = new int[_TAILLE_GRILLE][];
            _GrilleSelectionnee = new bool[_TAILLE_GRILLE][];

            for(int lIndex = 0; lIndex < _TAILLE_GRILLE; lIndex++)
            {
                _Grille[lIndex] = pNumeros[lIndex].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                  .Select(o => int.Parse(o))
                                                  .ToArray();

                _GrilleSelectionnee[lIndex] = new bool[_TAILLE_GRILLE];
            }
        }

        public void JouerNumero(int pNumero)
        {
            for (int lIndexLigne = 0; lIndexLigne < _TAILLE_GRILLE; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _TAILLE_GRILLE; lIndexColonne++)
                {
                    if (_Grille[lIndexLigne][lIndexColonne] == pNumero)
                    {
                        _GrilleSelectionnee[lIndexLigne][lIndexColonne] = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Cache pour ne pas reparcourir la grille une fois qu'elle est gagnante
        /// </summary>
        private bool _EstGagnante { get; set; }

        public bool EstGagnante
        {
            get
            {
                if (_EstGagnante)
                {
                    return true;
                }

                //Horizontale
                for(int lIndexLigne = 0; lIndexLigne < _TAILLE_GRILLE; lIndexLigne++)
                {
                    bool lLigneEstValide = true;
                    for(int lIndexColonne = 0; lIndexColonne < _TAILLE_GRILLE; lIndexColonne++)
                    {
                        if (_GrilleSelectionnee[lIndexLigne][lIndexColonne] == false)
                        {
                            lLigneEstValide = false;
                            break;
                        }
                    }

                    if (lLigneEstValide)
                    {
                        _EstGagnante = true;
                        return true;
                    }
                }

                //Verticale
                for (int lIndexColonne = 0; lIndexColonne < _TAILLE_GRILLE; lIndexColonne++)
                {
                    bool lLigneEstValide = true;
                    for (int lIndexLigne = 0; lIndexLigne < _TAILLE_GRILLE; lIndexLigne++)
                    {
                        if (_GrilleSelectionnee[lIndexLigne][lIndexColonne] == false)
                        {
                            lLigneEstValide = false;
                            break;
                        }
                    }

                    if (lLigneEstValide)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public int Score
        {
            get
            {
                int lScore = 0;
                for (int lIndexLigne = 0; lIndexLigne < _TAILLE_GRILLE; lIndexLigne++)
                {
                    for (int lIndexColonne = 0; lIndexColonne < _TAILLE_GRILLE; lIndexColonne++)
                    {
                        if (_GrilleSelectionnee[lIndexLigne][lIndexColonne] == false)
                        {
                            lScore += _Grille[lIndexLigne][lIndexColonne];
                        }
                    }
                }

                return lScore;
            }
        }
    }
}
