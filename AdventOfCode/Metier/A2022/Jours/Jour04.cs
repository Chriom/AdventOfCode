using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour04;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour04 : AJour<Tache>
    {
        public override int NumeroJour => 4;
        public override int Annee => 2022;

        protected override IEnumerable<Tache> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new Tache(o));
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Count(o => o.UnDesElfsEstTotalementDansLaPlageDeLAutre)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Count(o => o.AAuMoinsUneSectionEnCommun)
                           .ToString();
        }


    }
}
