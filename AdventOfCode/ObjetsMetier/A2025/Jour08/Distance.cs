using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.ObjetsMetier.A2025.Jour08
{
    [DebuggerDisplay("{DistanceEntreBoite}")]
    public class Distance
    {
        public decimal DistanceEntreBoite { get; set;  }

        public BoiteDerivation Boite1 { get; set;  }

        public BoiteDerivation Boite2 { get; set;  }
    }
}
