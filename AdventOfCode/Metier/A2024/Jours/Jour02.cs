using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour02;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour02 : AJour<SuiteNombre>
    {
        public override int NumeroJour => 2;

        public override int Annee => 2024;

        public override string DonneResultatUn()
        {
            return _Entrees.Count(o => o.EstSur())
                           .ToString();
        }
        public override string DonneResultatDeux()
        {
            return _Entrees.Count(o => o.EstSurAvecTotelerance())
                           .ToString();
        }


        protected override IEnumerable<SuiteNombre> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                yield return new SuiteNombre()
                {
                    Nombres = lSplit.Select(o => int.Parse(o))
                                    .ToList(),
                };
            }
        }
    }
}
