using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour09;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour09 : AJour<Sequence>
    {
        public override int NumeroJour => 9;

        public override int Annee => 2023;

        protected override IEnumerable<Sequence> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                List<decimal> lValeurs = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                .Select(o => decimal.Parse(o))
                                                .ToList();

                yield return new Sequence(lValeurs);
            }
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneProchaineValeur())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Sum(o => o.DonneProchaineValeur(true))
                           .ToString();
        }


    }
}
