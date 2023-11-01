using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour05
{
    public class Plateau
    {
        private int _Taille_X;
        private int _Taille_Y;

        private int[][] _Plateau;

        private List<Ligne> _Lignes;

        public Plateau(List<Ligne> pLignes)
        {
            _Lignes = pLignes;

            _Initialiser();
        }

        private void _Initialiser()
        {
            _DeterminerDimensions();

            _Plateau = new int[_Taille_Y][];

            for (int lIndex = 0; lIndex < _Taille_Y; lIndex++)
            {
                _Plateau[lIndex] = new int[_Taille_X];
            }
        }

        private void _DeterminerDimensions()
        {
            int lX = 0;
            int lY = 0;

            foreach(Ligne lLigne in  _Lignes)
            {
                lX = Math.Max(lX, Math.Max(lLigne.X1, lLigne.X2));
                lY = Math.Max(lY, Math.Max(lLigne.Y1, lLigne.Y2));
            }

            _Taille_X = lX + 1;
            _Taille_Y = lY + 1;
        }

        public int DonneNombreCasesHorizontaleOuVerticalSeChevauchant()
        {
            foreach(Ligne lLigne in _Lignes.Where(o => o.EstHorizontaleOuVerticale))
            {
                _DessinerLigne(lLigne);
            }

            return _DonneNombreCasesDepassantNombre(2);
        }

        public int DonneNombreCasesSeChevauchant()
        {
            foreach (Ligne lLigne in _Lignes)
            {
                _DessinerLigne(lLigne);
            }

            return _DonneNombreCasesDepassantNombre(2);
        }

        private void _DessinerLigne(Ligne pLigne)
        {
            if (pLigne.EstHorizontale)
            {
                int lDebut = Math.Min(pLigne.X1, pLigne.X2);
                int lFin = Math.Max(pLigne.X1, pLigne.X2);
                for(int lIndex = lDebut; lIndex <= lFin; lIndex++)
                {
                    _Plateau[pLigne.Y1][lIndex]++;
                }
            }
            else if (pLigne.EstVerticale)
            {
                int lDebut = Math.Min(pLigne.Y1, pLigne.Y2);
                int lFin = Math.Max(pLigne.Y1, pLigne.Y2);

                for (int lIndex = lDebut; lIndex <= lFin; lIndex++)
                {
                    _Plateau[lIndex][pLigne.X1]++;
                }
            }
            else 
            { 
                int lNombreCases = Math.Abs(pLigne.X1 - pLigne.X2);

                int lSensX = pLigne.X1 < pLigne.X2 ? 1 : -1;
                int lSensY = pLigne.Y1 < pLigne.Y2 ? 1 : -1;

                for(int lIndex = 0; lIndex <= lNombreCases; lIndex++)
                {
                    _Plateau[pLigne.Y1 + (lIndex * lSensY)][pLigne.X1 + (lIndex * lSensX)]++;
                }
            }
        }

        private int _DonneNombreCasesDepassantNombre(int pNombre)
        {
            return _Plateau.Sum(o => o.Count(p => p >= pNombre));
        }


    }
}
