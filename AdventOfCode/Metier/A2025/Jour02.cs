using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2025.Jour01;
using AdventOfCode.ObjetsMetier.A2025.Jour02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2025
{
    public class Jour02 : AJour<PlageReferences>
    {
        public override int NumeroJour => 2;

        public override int Annee => 2025;

        public override string DonneResultatUn()
        {
            return _Entrees.SelectMany(o => o.ReferencesInvalide)
                           .Sum()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.SelectMany(o => o.ReferencesInvalideRepetition)
                           .Sum()
                           .ToString();
        }

        protected override IEnumerable<PlageReferences> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees.First().Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                yield return new PlageReferences(lEntree);
            }
        }
    }
}
