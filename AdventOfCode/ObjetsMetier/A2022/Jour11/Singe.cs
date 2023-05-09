using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode.ObjetsMetier.A2022.Jour11
{
    [DebuggerDisplay("{Numero} - {NombreInspections} - {_Objets.Count} - ({string.Join(\", \", _Objets)})")]
    public class Singe
    {
        public int Numero { get; init; }

        private Queue<decimal> _Objets { get; init; } = new Queue<decimal>();

        public Func<decimal, decimal> OperationChangementNiveau { get; init; }

        public Test TestObjet { get; init; }


        private int _NombreInspections = 0;

        public int NombreInspections => _NombreInspections;

        public List<decimal> ListeObjets => _Objets.ToList();

        public void AjouterObjet(decimal pNiveauInquiétude)
        {
            _Objets.Enqueue(pNiveauInquiétude);
        }

        public ResultatInspection InspecterObjetSuivant(int pDivisionNiveauInquietude = 1)
        {
            if (_Objets.Count == 0)
            {
                return null;
            }

            decimal lPrioriteObjet = _Objets.Dequeue();

            decimal lNouvellePriorite = OperationChangementNiveau(lPrioriteObjet);

            if (pDivisionNiveauInquietude > 1)
            {
                lNouvellePriorite = Math.Floor(lNouvellePriorite / pDivisionNiveauInquietude);
            }

            int lNouveauSinge = TestObjet.DonneSingeSuivant(lNouvellePriorite);

            _NombreInspections++;
            return new ResultatInspection()
            {
                NumeroSinge = lNouveauSinge,
                PrioriteObjet = lNouvellePriorite,
            };
        }

        public void MiseALEchelleObjet(decimal pDiviseur)
        {
            if (_Objets.Count > 0)
            {

                for (int lIndex = 0; lIndex < _Objets.Count; lIndex++)
                {
                    decimal lNombre = _Objets.Dequeue();

                    lNombre = lNombre % pDiviseur;

                    _Objets.Enqueue(lNombre);
                }

            }


        }
    }
}
