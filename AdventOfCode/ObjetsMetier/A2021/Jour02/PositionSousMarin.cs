using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour02
{
    internal class PositionSousMarin
    {
        public int Horizontale { get; set; } = 0;

        public int Profondeur { get; set; } = 0;

        public int Cible { get; set; } = 0;

        public bool UtiliserCiblage = false;

        public void Avancer(int pDistance)
        {
            Horizontale += pDistance;
            
            if(UtiliserCiblage)
            {
                Profondeur += pDistance * Cible;
            }
            
        }

        public void Descendre(int pDistance)
        {
            if (UtiliserCiblage == false)
            {
                Profondeur += pDistance;
            }
            else
            {
                Cible += pDistance;
            }
        }

        public void Monter(int pDistance)
        {
            if (UtiliserCiblage == false)
            {
                Profondeur -= pDistance;
            }
            else
            {
                Cible -= pDistance;
            }
        }
    }
}
