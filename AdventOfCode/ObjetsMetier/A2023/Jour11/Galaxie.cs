using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour11
{
    public class Galaxie
    {
        public int Identifiant { get; set; }

        public decimal PositionX { get; set; }
        public decimal PositionY { get; set; }

        public decimal PositionXApresExpension { get; private set; }
        public decimal PositionYApresExpension { get; private set; }

        public void DefinirExpensionEnX(decimal pTaille, int pIndiceExpension)
        {
            PositionXApresExpension = PositionX + (pTaille * pIndiceExpension);
        }

        public void DefinirExpensionEnY(decimal pTaille, int pIndiceExpension)
        {
            PositionYApresExpension = PositionY + (pTaille * pIndiceExpension);
        }

        public decimal DistanceDe(Galaxie pAutre)
        {
            return Math.Abs((decimal)(PositionXApresExpension - pAutre.PositionXApresExpension)) + Math.Abs((decimal)(PositionYApresExpension - pAutre.PositionYApresExpension));
        }
    }
}
