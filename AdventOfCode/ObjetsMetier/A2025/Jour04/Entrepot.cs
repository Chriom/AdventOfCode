using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2025.Jour04
{
    public class Entrepot
    {
        private bool[,] _Entrepot;

        private int _NombreLignes;
        private int _NombreColonnes;

        private const char _ROULEAU = '@';

        public Entrepot(IEnumerable<string> pLignes)
        {
            List<string> lLignes = pLignes.ToList();
            _NombreLignes = lLignes.Count;
            _NombreColonnes = lLignes.First().Length;

            _Entrepot = new bool[_NombreLignes, _NombreColonnes];

            for (int lIndexLigne = 0; lIndexLigne < _NombreLignes; lIndexLigne++)
            {
                string lLigne = lLignes[lIndexLigne];

                for (int lIndexColonne = 0; lIndexColonne < _NombreColonnes; lIndexColonne++)
                {
                    if (lLigne[lIndexColonne] == _ROULEAU)
                    {
                        _Entrepot[lIndexLigne, lIndexColonne] = true;
                    }
                    else
                    {
                        _Entrepot[lIndexLigne, lIndexColonne] = false;
                    }
                }
            }
        }



        public (int NombreRouleaux, bool[,] NouvelEtat) DonneNombreRouleauxAccessible()
        {
            int lNombreRouleauxAccessible = 0;
            bool[,] lNouvelEtat = new bool[_NombreLignes, _NombreColonnes];

            for (int lIndexLigne = 0; lIndexLigne < _NombreLignes; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _NombreColonnes; lIndexColonne++)
                {
                    if (_Entrepot[lIndexLigne, lIndexColonne] == false)
                    {
                        continue;
                    }

                    int lNombreRouleauxAdjacent = 0;
                    if(lIndexLigne > 0)
                    {
                        if (lIndexColonne > 0 && _Entrepot[lIndexLigne - 1, lIndexColonne - 1])
                        {
                            lNombreRouleauxAdjacent++;
                        }
                        if (_Entrepot[lIndexLigne - 1, lIndexColonne])
                        {
                            lNombreRouleauxAdjacent++;
                        }
                        if (lIndexColonne + 1 < _NombreColonnes && _Entrepot[lIndexLigne - 1, lIndexColonne + 1])
                        {
                            lNombreRouleauxAdjacent++;
                        }
                    }

                    if (lIndexColonne > 0 && _Entrepot[lIndexLigne, lIndexColonne - 1])
                    {
                        lNombreRouleauxAdjacent++;
                    }

                    if (lIndexColonne + 1 < _NombreColonnes && _Entrepot[lIndexLigne, lIndexColonne + 1])
                    {
                        lNombreRouleauxAdjacent++;
                    }

                    if(lIndexLigne + 1 < _NombreLignes)
                    {
                        if (lIndexColonne > 0 && _Entrepot[lIndexLigne + 1, lIndexColonne - 1])
                        {
                            lNombreRouleauxAdjacent++;
                        }
                        if (_Entrepot[lIndexLigne + 1, lIndexColonne])
                        {
                            lNombreRouleauxAdjacent++;
                        }
                        if (lIndexColonne + 1 < _NombreColonnes && _Entrepot[lIndexLigne + 1, lIndexColonne + 1])
                        {
                            lNombreRouleauxAdjacent++;
                        }
                    }

                    if(lNombreRouleauxAdjacent < 4)
                    {
                        lNombreRouleauxAccessible++;
                        lNouvelEtat[lIndexLigne, lIndexColonne] = false;
                    }
                    else
                    {
                        lNouvelEtat[lIndexLigne, lIndexColonne] = true;
                    }
                }
            }

            return (lNombreRouleauxAccessible, lNouvelEtat);
        }

        public int DonneNombreRouleauxEnTravaillant()
        {
            int lRouleauxDeplacable = 0;
            int lRetourCeTour = 0;

            do
            {
                (lRetourCeTour, bool[,] lNouvelEtat) = DonneNombreRouleauxAccessible();

                _Entrepot = lNouvelEtat;

                lRouleauxDeplacable += lRetourCeTour;

            } while (lRetourCeTour > 0);

            return lRouleauxDeplacable;
        }
    }
}
