using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour03
{
    public class Donnees
    {
        public Donnees(string pBinaire) 
        {
            _Binaire = pBinaire;

            DonneesBinaire = _Binaire.Select(o => o == '1')
                              .ToArray();
        }

        private string _Binaire;

        public bool[] DonneesBinaire { get; private set; }

        public override string ToString()
        {
            return _Binaire;
        }
    }
}
