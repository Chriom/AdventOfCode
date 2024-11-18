using AdventOfCode.Commun.Extension;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour07;
using AdventOfCode.ObjetsMetier.A2023.Jour12;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour12 : AJour<SourceInconnu>
    {
        public override int NumeroJour => 12;

        public override int Annee => 2023;

        protected override IEnumerable<SourceInconnu> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                List<int> lTailles = lEntreeSplit[1].Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                    .Select(o => int.Parse(o))
                                                    .ToList();

                yield return new SourceInconnu(lEntreeSplit[0], lTailles);
            }
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneNombreValide())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            decimal lTotal = 0;

            foreach(SourceInconnu lSource in _Entrees)
            {
                lSource.Demultiplier();
                lTotal += lSource.DonneNombreValide();
            }

            return lTotal.ToString();
        }




    }
}
