using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour16
{
    [DebuggerDisplay("{Cle}")]
    public class Valve
    {
        public string Cle { get; private set; }

        public int Pression { get; private set; }

        public bool PeutEtreFermee => Pression != 0;

        public List<Valve> ValvesConnectees { get; private set; }

        public Dictionary<string, int> DistanceAutreValves { get; private set; }


        private List<string> _ValvesConnectees;

        public Valve(string pCle, int pPression, List<string> pValvesConnectees)
        {
            Cle = pCle;
            Pression = pPression;
            _ValvesConnectees = pValvesConnectees;
        }

        public void AssocierValves(Dictionary<string, Valve> pValves)
        {
            ValvesConnectees = new List<Valve>();

            foreach (string lValve in _ValvesConnectees)
            {
                ValvesConnectees.Add(pValves[lValve]);
            }
        }

        public void CalculerDistanceValves(Dictionary<string, Valve> pValves)
        {
            DistanceAutreValves = new Dictionary<string, int>();

            foreach (Valve lValve in pValves.Values)
            {
                if (lValve.Cle != Cle && lValve.PeutEtreFermee)
                {
                    int lDistance = _DonneDistanceValve(lValve);
                    DistanceAutreValves.Add(lValve.Cle, lDistance);
                }
            }
        }

        private int _DonneDistanceValve(Valve pValve)
        {
            Queue<Valve> lValvesSuivante = new Queue<Valve>();

            Valve lValve = this;

            Dictionary<string, int> lDicoDistance = new Dictionary<string, int>();
            lDicoDistance.Add(lValve.Cle, 0);

            do
            {
                foreach (Valve lValveSuivante in lValve.ValvesConnectees)
                {
                    if (lValveSuivante.Cle == pValve.Cle)
                    {
                        return lDicoDistance[lValve.Cle] + 1;
                    }
                    else if (lDicoDistance.ContainsKey(lValveSuivante.Cle) == false)
                    {
                        lDicoDistance.Add(lValveSuivante.Cle, lDicoDistance[lValve.Cle] + 1);
                        lValvesSuivante.Enqueue(lValveSuivante);
                    }
                }


                if (lValvesSuivante.Count > 0)
                {
                    lValve = lValvesSuivante.Dequeue();
                }
                else
                {
                    lValve = null;
                }

            } while (lValve != null);


            throw new Exception("Impossible d'atteindre la valve");
        }

    }
}
