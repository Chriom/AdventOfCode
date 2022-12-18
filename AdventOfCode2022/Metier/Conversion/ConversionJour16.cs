using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour16;

namespace AdventOfCode2022.Metier.Conversion
{
    public class ConversionJour16 : IConvertisseurEntree<Valve>
    {
        //Valve OT has flow rate=9; tunnels lead to valves YR, BJ, OX, UU, HJ
        private readonly Regex _Regex = new Regex(@"Valve (?<Cle>[A-Z]{2}) has flow rate=(?<Pression>[0-9]{1,}); tunnel([s]{0,1}) lead([s]{0,1}) to valve([s]{0,1}) (?<Valves>[A-Z\s,]{2,})");

        public IEnumerable<Valve> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Dictionary<string, Valve> lValves = new Dictionary<string, Valve>();

            foreach(string lEntree in pEntrees)
            {
                Match lMatch = _Regex.Match(lEntree);

                string lCle = lMatch.Groups["Cle"].ToString();
                string lPressionStr = lMatch.Groups["Pression"].ToString();
                int lPression = int.Parse(lPressionStr);

                string[] lAutreValves = lMatch.Groups["Valves"].ToString()
                                                               .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                lValves.Add(lCle, new Valve(lCle, lPression, lAutreValves.ToList()));
            }


            foreach(Valve lValve in lValves.Values)
            {
                lValve.AssocierValves(lValves);
            }

            foreach (Valve lValve in lValves.Values)
            {
                lValve.CalculerDistanceValves(lValves);
            }

            return lValves.Select(o => o.Value)
                          .ToList();
        }
    }
}
