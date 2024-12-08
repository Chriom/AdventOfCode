using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour07
{
    public class Pont
    {
        public decimal ValeurNecessaire { get; set; }

        public decimal ValeurCourante { get; set; }
        public List<decimal> Nombres { get; set; }

        public void Initialiser()
        {
            ValeurCourante = Nombres[0];

            Nombres.RemoveAt(0);
        }

        public void AppliquerOperation(Operateur pOperateur)
        {
            ValeurCourante = pOperateur switch
            {
                Operateur.Addition => ValeurCourante + Nombres[0],
                Operateur.Multiplication => ValeurCourante * Nombres[0],
                Operateur.Concatenation => decimal.Parse(ValeurCourante.ToString() + Nombres[0].ToString()),
                _ => throw new NotImplementedException()
            };

            if(Nombres.Count >= 1)
            {
                Nombres.RemoveAt(0);
            }
        }

        public bool EstALaFin => Nombres.Count == 0;

        public bool EstValide => ValeurCourante == ValeurNecessaire && EstALaFin;

        public bool EstEncorePossible => EstALaFin == false && ValeurCourante <= ValeurNecessaire;
    }
}
