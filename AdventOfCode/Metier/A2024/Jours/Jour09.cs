using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour09;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour09 : AJour<Disque>
    {
        public override int NumeroJour => 9;

        public override int Annee => 2024;

        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .DeplacerBlocEtDonneChecksum()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DeplacerFichierSansFragmentationEtDonneChecksum()
                           .ToString();
        }

        protected override IEnumerable<Disque> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Disque(pEntrees.First());
        }
    }
}
