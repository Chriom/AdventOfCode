using AdventOfCode.ObjetsMetier.A2025.Jour09;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Metier.A2025
{
    public class Jour09 : AJour<FaiseurDeRectangle>
    {
        public override int NumeroJour => 9;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            FaiseurDeRectangle lFaiseur = _Entrees.First();

            return lFaiseur.DonneAirePlusGrandRectangle().ToString();
        }

        public override string DonneResultatDeux()
        {
            FaiseurDeRectangle lFaiseur = _Entrees.First();

            return lFaiseur.DonneAirePlusGrandRectangleAvecReglesALaCon().ToString();
        }


        protected override IEnumerable<FaiseurDeRectangle> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new FaiseurDeRectangle(pEntrees.Select(o =>
            {
                string[] lSplit = o.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                return new Commun.ObjetsUtilitaire.Position2D(int.Parse(lSplit[0]), int.Parse(lSplit[1]));
            }).ToList());
        }
    }
}
