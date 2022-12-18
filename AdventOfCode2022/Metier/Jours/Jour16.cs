using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour16;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour16 : AJour<Valve>
    {
        public override int NumeroJour => 16;

        public override string DonneResultatUn()
        {
            ExplorateurCave lExplorateur = new ExplorateurCave(_Entrees);

            return lExplorateur.DonnePressionMaximaleLiberee()
                               .ToString();
        }

        public override string DonneResultatDeux()
        {
            ExplorateurCave lExplorateur = new ExplorateurCave(_Entrees);

            return lExplorateur.DonnePressionMaximaleLibereeAvecElephant()
                               .ToString();
        }


    }
}
