using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2025.Jour03
{
    public class BlocBatterie
    {
        private string _Joltages;

        private int[] _JoltagesBatteries;

        public BlocBatterie(string pJoltages)
        {
            _Joltages = pJoltages;

            _JoltagesBatteries = new int[_Joltages.Length];

            for (int lIndex = 0; lIndex < _Joltages.Length; lIndex++)
            {
                _JoltagesBatteries[lIndex] = int.Parse(_Joltages[lIndex].ToString());
            }
        }

        public int JoltageMaximal()
        {
            int lDizaine = 0;
            int lUnite = 0;

            for (int lIndex = 0; lIndex < _JoltagesBatteries.Length - 1; lIndex++)
            {
                if (_JoltagesBatteries[lIndex] > lDizaine)
                {
                    lDizaine = _JoltagesBatteries[lIndex];
                    lUnite = 0;
                }

                for (int lIndexUnite = lIndex + 1; lIndexUnite < _JoltagesBatteries.Length; lIndexUnite++)
                {
                    if (_JoltagesBatteries[lIndexUnite] > lUnite )
                    {
                        lUnite = _JoltagesBatteries[lIndexUnite];
                    }
                }
            }

            return lDizaine * 10 + lUnite;
        }

        private static Dictionary<string, CacheResultat> _Cache = new Dictionary<string, CacheResultat>();

        public decimal JoltageMaximalDouzeBatteries()
        {
            return _JoltageMaximalNBatteries(12, 0);
        }

        private decimal _JoltageMaximalNBatteries(int pNombreBatteries, int pIndexDebut)
        {
            

            int lFinCle = _JoltagesBatteries.Length - pNombreBatteries + 1 - pIndexDebut;

            string lCle = $"{_Joltages.Substring(pIndexDebut, lFinCle)}_{pNombreBatteries}";

            decimal lJoltageMax = 0;

            int lIndexMaximal = 0;

            if (_Cache.TryGetValue(lCle, out CacheResultat lCacheJoltage))
            {
                lJoltageMax = lCacheJoltage.Joltage;
                lIndexMaximal = lCacheJoltage.IndexDecalage;
            }
            else
            {
                int lIndexFin = _JoltagesBatteries.Length - pNombreBatteries + 1;
                int lMaximal = 0;
                

                for (int lIndex = pIndexDebut; lIndex < lIndexFin; lIndex++)
                {
                    if (_JoltagesBatteries[lIndex] == 9)
                    {
                        lMaximal = 9;
                        lIndexMaximal = lIndex;
                        break;
                    }

                    if (lMaximal < _JoltagesBatteries[lIndex])
                    {
                        lMaximal = _JoltagesBatteries[lIndex];
                        lIndexMaximal = lIndex;
                    }
                }

                lJoltageMax = (decimal)(lMaximal * Math.Pow(10, pNombreBatteries - 1));

                if (_Cache.ContainsKey(lCle) == false)
                {
                    _Cache.Add(lCle, new CacheResultat() { Joltage = lJoltageMax, IndexDecalage = lIndexMaximal });
                }
            }
            

            if (pNombreBatteries > 1)
            {
                lJoltageMax += _JoltageMaximalNBatteries(pNombreBatteries - 1, lIndexMaximal + 1);

            }

            return lJoltageMax;
        }

        private record CacheResultat
        {
            public decimal Joltage { get; init; }
            public int IndexDecalage { get; init; }
        }
    }


}


