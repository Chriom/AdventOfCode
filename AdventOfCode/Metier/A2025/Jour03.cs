using AdventOfCode.ObjetsMetier.A2025.Jour03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2025
{
    public class Jour03 : AJour<BlocBatterie>
    {
        public override int NumeroJour => 3;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.JoltageMaximal()).ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Sum(o => o.JoltageMaximalDouzeBatteries()).ToString();
        }


        protected override IEnumerable<BlocBatterie> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                yield return new BlocBatterie(lEntree);
            }
        }
    }
}
