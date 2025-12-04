using AdventOfCode.ObjetsMetier.A2025.Jour04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2025
{
    public class Jour04 : AJour<Entrepot>
    {
        public override int NumeroJour => 4;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            Entrepot lEntrepot = _Entrees.First();

            return lEntrepot.DonneNombreRouleauxAccessible().NombreRouleaux.ToString();
        }

        public override string DonneResultatDeux()
        {
            Entrepot lEntrepot = _Entrees.First();

            return lEntrepot.DonneNombreRouleauxEnTravaillant().ToString();
        }


        protected override IEnumerable<Entrepot> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Entrepot(pEntrees);
        }
    }
}
