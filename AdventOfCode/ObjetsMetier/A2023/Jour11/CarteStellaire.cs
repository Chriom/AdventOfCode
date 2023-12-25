using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour11
{
    public class CarteStellaire
    {
        private List<string> _DonneesSource;

        private int _LargeurOrigine;
        private int _HauteurOrigine;

        private List<Galaxie> _Galaxies = new List<Galaxie>();

        public CarteStellaire(IEnumerable<string> pDonneesSource)
        {
            _DonneesSource = pDonneesSource.ToList();

            _HauteurOrigine = _DonneesSource.Count;
            _LargeurOrigine = _DonneesSource.First().Length;

            _ExtraireGalaxies();
        }

        private void _ExtraireGalaxies()
        {
            int lIdGalaxie = 1;

            for(int lIndexLigne = 0; lIndexLigne < _HauteurOrigine; lIndexLigne++)
            {
                for(int lIndexColonne = 0; lIndexColonne < _LargeurOrigine; lIndexColonne++)
                {
                    char lElement = _DonneesSource[lIndexLigne][lIndexColonne];

                    if(lElement == '#')
                    {
                        _Galaxies.Add(new Galaxie()
                        {
                            Identifiant = lIdGalaxie,
                            PositionX = lIndexColonne,
                            PositionY= lIndexLigne,
                        });

                        lIdGalaxie++;
                    }
                    
                }
            }
        }

        public void AppliquerExtensionUnivers(int pIndiceExpension = 1)
        {
            List<int> lExtensionEnX = new List<int>();
            List<int> lExtensionEnY = new List<int>();


            List<decimal> lPositionsXOccupe = _Galaxies.Select(o => o.PositionX)
                                                       .Distinct()
                                                       .OrderBy(o => o)
                                                       .ToList();

            List<decimal> lPositionsYOccupe = _Galaxies.Select(o => o.PositionY)
                                                       .Distinct()
                                                       .OrderBy(o => o)
                                                       .ToList();

            //Inti des valeurs de ce qui bouge pas
            foreach(Galaxie lGalaxie in _Galaxies)
            {
                lGalaxie.DefinirExpensionEnX(0, pIndiceExpension);
                lGalaxie.DefinirExpensionEnY(0, pIndiceExpension);
            }

            //Ajout en X
            int lExpensionX = 0;
            for(int lIndex = 0; lIndex < _LargeurOrigine; lIndex++)
            {
                if(lPositionsXOccupe.Contains(lIndex) == false)
                {
                    lExpensionX++;

                    foreach(Galaxie lGalaxie in _Galaxies.Where(o => o.PositionX > lIndex))
                    {
                        lGalaxie.DefinirExpensionEnX(lExpensionX, pIndiceExpension);
                    }
                }
            }

            //Ajout en Y
            int lExpensionY = 0;
            for (int lIndex = 0; lIndex < _HauteurOrigine; lIndex++)
            {
                if (lPositionsYOccupe.Contains(lIndex) == false)
                {
                    lExpensionY++;

                    foreach (Galaxie lGalaxie in _Galaxies.Where(o => o.PositionY > lIndex))
                    {
                        lGalaxie.DefinirExpensionEnY(lExpensionY, pIndiceExpension);
                    }
                }
            }
        }

        public decimal DonneSommeDesDistances()
        {
            decimal lSommeDistance = 0;

            for(int lIndex = 0; lIndex < _Galaxies.Count - 1; lIndex++)
            {
                Galaxie lGalaxieUn = _Galaxies[lIndex];
                for(int lIndexDeux = lIndex + 1; lIndexDeux < _Galaxies.Count; lIndexDeux++)
                {
                    Galaxie lGalaxieDeux = _Galaxies[lIndexDeux];

                    lSommeDistance += lGalaxieUn.DistanceDe(lGalaxieDeux);
                }
            }

            return lSommeDistance;
        }

    }
}
