﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Metier
{
    public abstract class AJour<T> : IJour
    {
        public abstract int NumeroJour { get; }
        public abstract int Annee { get; }

        protected IEnumerable<T> _Entrees;

        public AJour()
        {
            _Entrees = _ConvertirEntrees(EntreesHelper.ChargerEntrees(this.Annee, this.NumeroJour));
        }

        protected abstract IEnumerable<T> _ConvertirEntrees(IEnumerable<string> pEntrees);

        public abstract string DonneResultatUn();
        public abstract string DonneResultatDeux();

        

    }
}
