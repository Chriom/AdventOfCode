using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour07
{
    public class DeplaceurDeCrabe
    {
        private List<int> _Crabes;

        public DeplaceurDeCrabe(List<int> pCrabes)
        {
            _Crabes = pCrabes;
        }


        public int DonneCoutFuelPourDeplacerCrabes()
        {
            List<int> lCrabesTries = _Crabes.OrderBy(o => o)
                                            .ToList();

            int lMediane = lCrabesTries[lCrabesTries.Count/2];

            return _Crabes.Sum(o => Math.Abs(o - lMediane));
        }

        public int DonneCoutFuelIncrementalPourDeplacerCrabes()
        {
            decimal lMoyenne = _Crabes.Sum() / (decimal)_Crabes.Count;
            List<int> lCrabesTries = _Crabes.OrderBy(o => o)
                                            .ToList();

            int lMoyenneMoins = (int)Math.Floor(lMoyenne);
            int lMoyennePlus = (int)Math.Ceiling(lMoyenne);

            int lSommeMoins = _Crabes.Sum(o => _SommeEntier(Math.Abs(o - lMoyenneMoins)));
            int lSommePlus = _Crabes.Sum(o => _SommeEntier(Math.Abs(o - lMoyennePlus)));

            return Math.Min(lSommeMoins, lSommePlus);
        }

        private int _SommeEntier(int pNombre)
        {
            //n*(n+1)/2

            return (pNombre * (pNombre + 1)) / 2;
        }
    }
}
