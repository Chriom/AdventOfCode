using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour10
{
    public class Ecran
    {
        private const int _NOMBRE_COLONNES = 40;
        private const int _NOMBRE_LIGNES = 6;

        private bool[][] _Ecran;

        public Ecran()
        {
            _InitialiseEcran();
        }

        private void _InitialiseEcran()
        {
            _Ecran = new bool[_NOMBRE_LIGNES][];

            for (int lIndex = 0; lIndex < _NOMBRE_LIGNES; lIndex++)
            {
                _Ecran[lIndex] = new bool[_NOMBRE_COLONNES];
            }
        }

        public void ActualiserEcran(ResultatExecutionInstruction pInstruction)
        {
            int lLigne = (pInstruction.Cycle - 1) / _NOMBRE_COLONNES;
            int lColonne = (pInstruction.Cycle - 1) % _NOMBRE_COLONNES;

            bool lSpriteEstSurColonne = lColonne - 1 <= pInstruction.RegistreX && lColonne + 1 >= pInstruction.RegistreX;

            _Ecran[lLigne][lColonne] = lSpriteEstSurColonne;


        }

        public List<string> DonneAffichageEcran()
        {
            List<string> lLignes = new List<string>();

            foreach (bool[] lLigne in _Ecran)
            {
                lLignes.Add(string.Join("", lLigne.Select(o => o ? "#" : ".")));
            }

            return lLignes;
        }
    }
}
