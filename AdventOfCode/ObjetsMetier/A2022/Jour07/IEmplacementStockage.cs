﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour07
{
    public interface IEmplacementStockage
    {
        string Nom { get; init; }

        public decimal Taille { get; }

        public Dossier Parent { get; init; }
    }
}
