using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour06;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour06 : AJour<int>
    {
        public override int NumeroJour => 6;

        public override int Annee => 2021;

        protected override IEnumerable<int> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.First()
                           .Split(',')
                           .Select(o => int.Parse(o));
        }

        public override string DonneResultatUn()
        {
            Aquarium lAquarium = new Aquarium(_Entrees.ToList(), 6, 8);

            return lAquarium.DonneNombrePoissonsApresNombreJour(80).ToString();
        }

        public override string DonneResultatDeux()
        {
            Aquarium lAquarium = new Aquarium(_Entrees.ToList(), 6, 8);

            return lAquarium.DonneNombrePoissonsApresNombreJour(256).ToString();
        }
    }
}
