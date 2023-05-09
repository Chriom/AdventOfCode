using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour05
{
    public class Instruction
    {
        public int Numero { get; init; }

        public int NombreConteneurs { get; init; }

        public int PileDepart { get; init; }

        public int PileArrivee { get; init; }

        public Instruction(int pNumero, int pNombreConteneurs, int pPileDepart, int pPileArrivee)
        {
            Numero = pNumero;
            NombreConteneurs = pNombreConteneurs;
            PileDepart = pPileDepart;
            PileArrivee = pPileArrivee;
        }
    }
}
