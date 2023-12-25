using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public class Sequence
    {
        public Sens Sens { get; set; }

        public int NombreCases { get; set; }

        public Couleur Couleur { get; private set; }

        public Sequence(Sens pSens, int pNombreCases, Couleur pCouleur)
        {
            Sens = pSens;
            NombreCases = pNombreCases;
            Couleur = pCouleur;
        }
    }
}
