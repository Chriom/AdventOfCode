using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.ObjetsMetier.Jour15;

namespace AdventOfCode2022.Metier.Conversion
{
    internal class ConversionJour15 : IConvertisseurEntree<Capteurs>
    {
        private readonly Regex _RegexLecture = new Regex(@"Sensor at x=(?<CapteurX>[0-9-]{1,}), y=(?<CapteurY>[0-9-]{1,}): closest beacon is at x=(?<BaliseX>[0-9-]{1,}), y=(?<BaliseY>[0-9-]{1,})");

        public IEnumerable<Capteurs> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                var lMatch = _RegexLecture.Match(lEntree);

                Position lCapteur = new Position() {
                    X = decimal.Parse(lMatch.Groups["CapteurX"].ToString()),
                    Y = decimal.Parse(lMatch.Groups["CapteurY"].ToString()),
                };

                Position lBalise = new Position()
                {
                    X = decimal.Parse(lMatch.Groups["BaliseX"].ToString()),
                    Y = decimal.Parse(lMatch.Groups["BaliseY"].ToString()),
                };

                yield return new Capteurs(lCapteur, lBalise);
            }
        }
    }
}
