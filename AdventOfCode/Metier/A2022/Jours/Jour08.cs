using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour08;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour08 : AJour<Foret>
    {
        public override int NumeroJour => 8;
        public override int Annee => 2022;

        protected override IEnumerable<Foret> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Foret lForet = new Foret(pEntrees.Count(), pEntrees.First().Length);

            int lIndexLigne = 0;
            foreach (string lEntree in pEntrees)
            {
                int[] lRangee = lEntree.Select(o => int.Parse(o.ToString()))
                                       .ToArray();

                lForet.AjouterRangeeArbre(lIndexLigne, lRangee);
                lIndexLigne++;
            }


            yield return lForet;
        }
        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .NombreArbresVisible()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonneMeilleurScoreScenic()
                           .ToString();
        }


    }
}
