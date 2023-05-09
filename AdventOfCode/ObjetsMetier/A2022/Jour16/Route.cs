using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour16
{
    [DebuggerDisplay("{Valve} - {Action} - {Minutes}m - {PressionLibererParValve}")]
    internal class Route
    {
        public ActionFaite Action { get; set; }

        public int Minutes { get; set; }

        public Valve Valve { get; set; }

        public Route Precedent { get; set; }

        public List<Route> Suivant { get; set; } = new List<Route>();

        public HashSet<string> ValvesFermes { get; set; } = new HashSet<string>();
        public int PressionLibererParValve
        {
            get
            {
                if (Valve.PeutEtreFermee && Action == ActionFaite.FermetureValve)
                {
                    return Valve.Pression * (ExplorateurCave.MINUTES_TOTAL - Minutes);
                }

                return 0;
            }
        }

        public int TotalePressionLibere
        {
            get
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
