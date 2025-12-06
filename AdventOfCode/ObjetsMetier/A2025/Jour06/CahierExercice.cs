using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.ObjetsMetier.A2025.Jour06
{
    public class CahierExercice
    {
        private List<Exercice> _Exercices = new List<Exercice>();


        private List<Exercice> _ExercicesLectureCorrecte = new List<Exercice>();

        public CahierExercice(IEnumerable<Exercice> pExercices, IEnumerable<Exercice> pExercicesCorrecte)
        {
            _Exercices = pExercices.ToList();
            _ExercicesLectureCorrecte = pExercicesCorrecte.ToList();
        }

        public decimal SommeOperation()
        {
            return _Exercices.Sum(o => o.Calculer());
        }

        public decimal SommeOperationCorrecte()
        {
            return _ExercicesLectureCorrecte.Sum(o => o.Calculer());
        }

        public class Exercice
        {
            public List<decimal> Nombres { get; set; } = new List<decimal>();

            public Operation OperationNombres { get; set; }

            public decimal Calculer()
            {
                decimal lResultat = Nombres[0];

                for (int lIndex = 1; lIndex < Nombres.Count; lIndex++)
                {
                    switch (OperationNombres)
                    {
                        case Operation.Addition:
                            lResultat += Nombres[lIndex];
                            break;
                        case Operation.Multiplication:
                            lResultat *= Nombres[lIndex];
                            break;
                    }
                }

                return lResultat;
            }

            public enum Operation
            {
                Indefini,
                Addition,
                Multiplication,
            }
        }
    }
}
