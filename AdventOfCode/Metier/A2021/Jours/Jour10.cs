using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour10;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour10 : AJour<Ligne>
    {
        public override int NumeroJour => 10;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonnePointDeLaLigne())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            List<decimal> lPoints = _Entrees.Where(o => o.DonnePointDeLaLigne() == 0)
                                            .Select(o => o.DonnePointEnCompletantLaligne())
                                            .OrderBy(o => o)
                                            .ToList();

            int lMilieu = (int)Math.Floor(lPoints.Count / (decimal)2);

            return lPoints[lMilieu].ToString();

        }


    }
}
