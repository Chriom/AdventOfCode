using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2024.Jour11;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour11 : AJour<Pierres>
    {
        public override int NumeroJour => 11;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .DonneNombreDePierresApresClignotement(25)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonneNombreDePierresApresClignotement(75)
                           .ToString();
        }


        protected override IEnumerable<Pierres> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Pierres(pEntrees.First()
                                             .Split(" ", StringSplitOptionsExtension.RemoveAndTrim)
                                             .Select(decimal.Parse)
                                             .ToList());
        }
    }
}
