using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour04;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour04 : AJour<Tache>
    {
        public Jour04(bool pModeTest) : base(pModeTest)
        { }

        public override int NumeroJour => 4;

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
