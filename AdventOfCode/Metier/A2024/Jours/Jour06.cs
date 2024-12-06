using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour06;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour06 : AJour<CartePatrouille>
    {
        public override int NumeroJour => 6;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .ParcourirCarteComplete()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonneNombreDePositionsBloquante()
                           .ToString();
        }


        protected override IEnumerable<CartePatrouille> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new CartePatrouille(pEntrees.ToList());
        }
    }
}
