using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour11
{
    public class Octopus
    {
        public int NiveauEnergie { get; private set; }

        public bool AFlasher { get; private set; }

        public Octopus(int pNiveauEnergie)
        {
            NiveauEnergie = pNiveauEnergie;
        }

        public void AugmenterNiveauEnergie()
        {
            if (AFlasher == false)
            {
                NiveauEnergie++;
            }            
        }

        public bool DoitFlasher => NiveauEnergie > 9 && AFlasher == false;

        public void FaireFlasher()
        {
            if (DoitFlasher)
            {
                AFlasher = true;
                NiveauEnergie = 0;
            }            
        }

        public void ReinitialiserEtatFlash()
        {
            AFlasher = false;
        }
    }
}
