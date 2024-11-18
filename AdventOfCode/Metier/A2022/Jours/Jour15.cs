using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour15;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour15 : AJour<Capteurs>
    {
        public override int NumeroJour => 15;
        public override int Annee => 2022;

        private readonly Regex _RegexLecture = new Regex(@"Sensor at x=(?<CapteurX>[0-9-]{1,}), y=(?<CapteurY>[0-9-]{1,}): closest beacon is at x=(?<BaliseX>[0-9-]{1,}), y=(?<BaliseY>[0-9-]{1,})");

        protected override IEnumerable<Capteurs> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                var lMatch = _RegexLecture.Match(lEntree);

                Position lCapteur = new Position()
                {
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

        public override string DonneResultatUn()
        {
            return DonneResultatUn(2000000);
        }

        public string DonneResultatUn(int pNumeroLigne)
        {
            List<PlageValeur> lPlages = _Entrees.Select(o => o.DonnePlagePorterDeBalisePourLaLigne(pNumeroLigne))
                                                .Where(o => o != null)
                                                .ToList();

            List<PlageValeur> lPlagesFusion = PlageValeur.FusionnerPlages(lPlages);

            int lNombreBaliseSurLaLigne = _Entrees.Select(o => o.BaliseLaPlusProche)
                                                  .Distinct()
                                                  .Count(o => o.Y == pNumeroLigne);

            return (lPlagesFusion.Sum(o => o.TotalDistance + 1) - lNombreBaliseSurLaLigne).ToString();
        }

        public override string DonneResultatDeux()
        {
            return DonneResultatDeux(4000000);
        }

        public string DonneResultatDeux(decimal pNombreLigneRecherche)
        {
            List<PlageValeur> lPlagesBalise = new List<PlageValeur>();
            decimal lYBalise = -1;

            for (decimal lIndexLigne = 0; lIndexLigne < pNombreLigneRecherche; lIndexLigne++)
            {
                lYBalise = lIndexLigne;

                List<PlageValeur> lPlages = _Entrees.Select(o => o.DonnePlagePorterDeBalisePourLaLigne(lIndexLigne))
                                                                  .Where(o => o != null)
                                                                  .ToList();
                lPlagesBalise = PlageValeur.FusionnerPlages(lPlages);

                if (lPlagesBalise.Count > 1)
                {
                    break;
                }
            }

            decimal lResultat = (lPlagesBalise.First().Fin + 1) * 4000000 + lYBalise;

            return lResultat.ToString();



        }


    }
}
