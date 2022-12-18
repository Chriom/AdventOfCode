using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour16
{
    [DebuggerDisplay("P {ValvePersonnage} - {ActionPersonnage} - {MinutesPersonnage}m - E {ValveElephant} - {ActionElephant} - {MinutesElephant}m - {PressionLibererParValve}")]
    internal class RouteAvecElephant
    {
        public ActionFaite ActionPersonnage { get; set; }
        public ActionFaite ActionElephant { get; set; }

        public int MinutesPersonnage { get; set; }

        public int MinutesElephant { get; set; }

        public Valve ValvePersonnage { get; set; }

        public Valve ValveElephant { get; set; }

        public RouteAvecElephant Precedent { get; set; }

        public List<RouteAvecElephant> Suivant { get; set; } = new List<RouteAvecElephant>();

        public HashSet<string> ValvesFermes { get; set; } = new HashSet<string>();

        public int PressionLibererParValve
        {
            get
            {
                int lPression = 0;

                if (ValvePersonnage.PeutEtreFermee && ActionPersonnage == ActionFaite.FermetureValve)
                {
                    lPression += ValvePersonnage.Pression * (ExplorateurCave.MINUTES_TOTAL - MinutesPersonnage);
                }

                if (ValveElephant.PeutEtreFermee && ActionElephant == ActionFaite.FermetureValve)
                {
                    lPression += ValveElephant.Pression * (ExplorateurCave.MINUTES_TOTAL - MinutesElephant);
                }

                return lPression;
            }
        }

        public int TotalePressionLibere
        {
            get
            {
                
                lock (Suivant)
                {
                    if (Suivant.Count == 0)
                    {
                        return PressionLibererParValve;
                    }

                    return PressionLibererParValve + Suivant.Max(o => o.TotalePressionLibere);
                }
                
            }
        }
    }
}
