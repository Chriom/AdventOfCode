using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.ObjetsMetier.A2024.Jour13;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour13 : AJour<MachineAPince>
    {
        public override int NumeroJour => 13;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneNombreDeToken())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Sum(o => o.DonneNombreDeTokenAvecAjustementPrix())
                           .ToString();
        }

        protected override IEnumerable<MachineAPince> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Regex lRegex = new Regex(@".*[+=](?<X>[0-9]{1,}),\s.[+=](?<Y>[0-9]{1,})");

            foreach(List<string> lLignes in pEntrees.SplitEnListe(4))
            {
                Position2D lBoutonA = new Position2D(int.Parse(lRegex.Match(lLignes[0]).Groups["X"].Value), int.Parse(lRegex.Match(lLignes[0]).Groups["Y"].Value));
                Position2D lBoutonB = new Position2D(int.Parse(lRegex.Match(lLignes[1]).Groups["X"].Value), int.Parse(lRegex.Match(lLignes[1]).Groups["Y"].Value));
                Position2D lPrix = new Position2D(int.Parse(lRegex.Match(lLignes[2]).Groups["X"].Value), int.Parse(lRegex.Match(lLignes[2]).Groups["Y"].Value));

                yield return new MachineAPince(lBoutonA, lBoutonB, lPrix);
            }
        }
    }
}
