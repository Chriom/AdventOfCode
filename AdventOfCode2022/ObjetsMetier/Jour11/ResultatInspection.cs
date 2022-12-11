﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour11
{
    [DebuggerDisplay("{NumeroSinge} - {PrioriteObjet}")]
    public class ResultatInspection
    {
        public decimal PrioriteObjet { get; init; }
        public int NumeroSinge { get; init; }
    }
}
