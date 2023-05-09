using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour16;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour16 : AJour<Valve>
    {
        public override int NumeroJour => 16;
        public override int Annee => 2022;

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
