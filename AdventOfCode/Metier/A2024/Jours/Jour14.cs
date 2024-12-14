using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.ObjetsMetier.A2024.Jour14;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour14 : AJour<Robot>
    {
        public override int NumeroJour => 14;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            DeplaceurDeRobots lDeplaceur = new DeplaceurDeRobots(_Entrees.ToList());
            lDeplaceur.DeplacerTousLesRobots(100);

            return lDeplaceur.DonneFacteurDeSecurite()
                             .ToString();
        }

        public override string DonneResultatDeux()
        {
            DeplaceurDeRobots lDeplaceur = new DeplaceurDeRobots(_Entrees.ToList());
            lDeplaceur.DeplacerTousLesRobots(20000, true);

            return string.Empty;
        }


        protected override IEnumerable<Robot> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Regex lRegex = new Regex(@"p=(?<XRobot>[-0-9]{1,}),(?<YRobot>[-0-9]{1,}) v=(?<XDeplacement>[-0-9]{1,}),(?<YDeplacement>[-0-9]{1,})");

            foreach (string lEntree in pEntrees)
            {
                var lMatch = lRegex.Match(lEntree);

                yield return new Robot(new Position2D(int.Parse(lMatch.Groups["XRobot"].Value), int.Parse(lMatch.Groups["YRobot"].Value)),
                                       new Position2D(int.Parse(lMatch.Groups["XDeplacement"].Value), int.Parse(lMatch.Groups["YDeplacement"].Value)));
            }
        }
    }
}
