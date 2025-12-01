using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour04
{
    public class RechercheurDeTexte
    {
        private char[][] _Texte;

        private int _Largeur;
        private int _Hauteur;

        public RechercheurDeTexte(List<string> pLignes)
        {
            _Largeur = pLignes.First().Length;
            _Hauteur = pLignes.Count();

            _Texte = new char[_Hauteur][];

            for(int lIndexLignes = 0; lIndexLignes < _Hauteur; lIndexLignes++)
            {
                _Texte[lIndexLignes] = pLignes[lIndexLignes].ToArray();
            }


        }

        private const string _XMAS = "XMAS";

        public int DonneNombreXmas()
        {
            int lNombre = 0;

            for (int lIndexLigne = 0; lIndexLigne < _Largeur; lIndexLigne++)
            {
                for(int lIndexColonne = 0; lIndexColonne < _Hauteur; lIndexColonne++)
                {
                    if (_Texte[lIndexLigne][lIndexColonne] == _XMAS[0])
                    {
                        lNombre += _RechercherMotAPartirDePosition(lIndexLigne, lIndexColonne);
                    }
                }
            }


            return lNombre;
        }

        private int _RechercherMotAPartirDePosition(int pLigne, int pColonne)
        {
            int lNombreMots = 0;


            //Vers le haut
            if(pLigne >= _XMAS.Length - 1)
            {
                //Vertical gauche haut
                if(pColonne >= _XMAS.Length - 1 && _MotEstDansGrille(pLigne, pColonne, -1, -1))
                {
                    lNombreMots++;
                }


                //Haut
                if (_MotEstDansGrille(pLigne, pColonne, -1, 0))
                {
                    lNombreMots++;
                }

                //Vertical droite haut
                if (pColonne + _XMAS.Length - 1 < _Largeur && _MotEstDansGrille(pLigne, pColonne, -1, 1))
                {
                    lNombreMots++;
                }
            }

            //Gauche
            if (pColonne >= _XMAS.Length - 1 && _MotEstDansGrille(pLigne, pColonne, 0, -1))
            {
                lNombreMots++;
            }

            //Droite
            if (pColonne + _XMAS.Length - 1 < _Largeur && _MotEstDansGrille(pLigne, pColonne, 0, 1))
            {
                lNombreMots++;
            }


            //Vers le bas
            if (pLigne + _XMAS.Length - 1 < _Hauteur)
            {
                //Vertical gauche bas
                if (pColonne >= _XMAS.Length - 1 && _MotEstDansGrille(pLigne, pColonne, 1, -1))
                {
                    lNombreMots++;
                }


                //Bas
                if (_MotEstDansGrille(pLigne, pColonne, 1, 0))
                {
                    lNombreMots++;
                }

                //Vertical droite bas
                if (pColonne + _XMAS.Length - 1 < _Largeur && _MotEstDansGrille(pLigne, pColonne, 1, 1))
                {
                    lNombreMots++;
                }
            }

            return lNombreMots;
        }

        private bool _MotEstDansGrille(int pLigne, int pColonne, int pIncrementLigne, int pIncrementColonne)
        {
            for (int lIndex = 1; lIndex < _XMAS.Length; lIndex++)
            {
                if (_Texte[pLigne + (pIncrementLigne * lIndex)][pColonne + (pIncrementColonne * lIndex)] != _XMAS[lIndex])
                {
                    break;
                }
                if (lIndex == _XMAS.Length - 1)
                {
                    return true;
                }
            }

            return false;
        }

        public int DonneNombreX_Mas()
        {
            int lNombre = 0;

            for (int lIndexLigne = 1; lIndexLigne < _Largeur - 1; lIndexLigne++)
            {
                for (int lIndexColonne = 1; lIndexColonne < _Hauteur - 1; lIndexColonne++)
                {
                    if (_Texte[lIndexLigne][lIndexColonne] == 'A')
                    {
                        if(_EstUnMas(lIndexLigne, lIndexColonne))
                        {
                            lNombre++;
                        }
                    }
                }
            }

            return lNombre; 
        }

        private bool _EstUnMas(int pLigne, int pColonne)
        {
            if (_Texte[pLigne - 1][pColonne - 1] == 'M' && _Texte[pLigne - 1][pColonne + 1] == 'M' && _Texte[pLigne + 1][pColonne - 1] == 'S' && _Texte[pLigne + 1][pColonne + 1] == 'S')
            {
                return true;
            }

            if (_Texte[pLigne - 1][pColonne - 1] == 'S' && _Texte[pLigne - 1][pColonne + 1] == 'S' && _Texte[pLigne + 1][pColonne - 1] == 'M' && _Texte[pLigne + 1][pColonne + 1] == 'M')
            {
                return true;
            }

            if (_Texte[pLigne - 1][pColonne - 1] == 'M' && _Texte[pLigne - 1][pColonne + 1] == 'S' && _Texte[pLigne + 1][pColonne - 1] == 'M' && _Texte[pLigne + 1][pColonne + 1] == 'S')
            {
                return true;
            }

            if (_Texte[pLigne - 1][pColonne - 1] == 'S' && _Texte[pLigne - 1][pColonne + 1] == 'M' && _Texte[pLigne + 1][pColonne - 1] == 'S' && _Texte[pLigne + 1][pColonne + 1] == 'M')
            {
                return true;
            }

            return false;
        }
    }
}
