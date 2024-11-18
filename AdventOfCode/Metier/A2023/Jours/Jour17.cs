using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour17;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour17 : AJour<PiscineDelave>
    {
        public override int NumeroJour => 17;

        public override int Annee => 2023;

        protected override IEnumerable<PiscineDelave> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            int[][] lBassin = new int[lEntrees.Count][];


            int lIndex = 0;
            foreach (string lEntree in lEntrees)
            {
                lBassin[lIndex] = lEntree.Select(o => int.Parse(o.ToString()))
                                         .ToArray();
                lIndex++;
            }

            yield return new PiscineDelave(lBassin);
        }

        public override string DonneResultatUn()
        {
            PiscineDelave lPiscine = _Entrees.First();

            return lPiscine.DonneDeperditionDeChaleurMinimal()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            PiscineDelave lPiscine = _Entrees.First();

            return lPiscine.DonneDeperditionDeChaleurMinimalUltraCrucible()
                           .ToString();
        }


    }
}
