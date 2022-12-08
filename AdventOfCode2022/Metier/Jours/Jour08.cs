using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour08;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour08 : AJour<Foret>
    {
        public override int NumeroJour => 8;

        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .NombreArbresVisible()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonneMeilleurScoreScenic()
                           .ToString();
        }


    }
}
