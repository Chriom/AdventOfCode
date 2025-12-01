using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour02
{
    public class SuiteNombre
    {
        public List<int> Nombres { get; set; } = new List<int>();

        public bool EstSur()
        {
            const int SEUIL_BAS = 1;
            const int SEUIL_HAUT = 3;

            bool lIncrement = Nombres[0] < Nombres[1];
            for (int lIndex = 1; lIndex < Nombres.Count; lIndex++)
            {
                int lNombre1 = Nombres[lIndex - 1];
                int lNombre2 = Nombres[lIndex];

                if((lIncrement && lNombre1 > lNombre2) ||
                   (lIncrement == false && lNombre1 < lNombre2))
                {
        
                    return false;
                }

                int lDifference = Math.Abs(lNombre1 - lNombre2);
                if(lDifference < SEUIL_BAS || lDifference > SEUIL_HAUT)
                {
                    return false;
                }


            }

            return true;
        }

        public bool EstSurAvecTotelerance()
        {
            if (this.EstSur())
            {
                return true;
            }

            for (int lIndex = 0; lIndex < Nombres.Count; lIndex++)
            {
                SuiteNombre lSuiteTest = new SuiteNombre();

                lSuiteTest.Nombres.AddRange(Nombres.Take(lIndex));
                lSuiteTest.Nombres.AddRange(Nombres.Skip(lIndex + 1).Take(Nombres.Count - lIndex - 1));

                if (lSuiteTest.EstSur())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
