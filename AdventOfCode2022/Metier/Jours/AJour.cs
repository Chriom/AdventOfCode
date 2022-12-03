using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AdventOfCode2022.Helpers;
using AdventOfCode2022.Interfaces;

namespace AdventOfCode2022.Metier.Jours
{
    public abstract class AJour<T> : IJour
    { 
        public abstract int NumeroJour { get; }

        protected IEnumerable<T> _Entrees;

        public AJour(bool pModeTest)
        {
            _Entrees = EntreesHelper.ChargerEntrees<T>(NumeroJour, pModeTest);
        }

        public abstract string DonneResultatUn();
        public abstract string DonneResultatDeux();

    }
}
