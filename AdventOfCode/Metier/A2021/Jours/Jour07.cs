using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour07;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour07 : AJour<int>
    {
        public override int NumeroJour => 7;

        public override int Annee => 2021;

        protected override IEnumerable<int> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.First()
                           .Split(',')
                           .Select(o => int.Parse(o));
        }

        public override string DonneResultatUn()
        {
            DeplaceurDeCrabe lDeplaceur = new DeplaceurDeCrabe(_Entrees.ToList());

            return lDeplaceur.DonneCoutFuelPourDeplacerCrabes().ToString();
        }

        public override string DonneResultatDeux()
        {
            DeplaceurDeCrabe lDeplaceur = new DeplaceurDeCrabe(_Entrees.ToList());

            return lDeplaceur.DonneCoutFuelIncrementalPourDeplacerCrabes().ToString();
        }
    }
}
