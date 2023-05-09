using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour08;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour08 : AJour<Foret>
    {
        public override int NumeroJour => 8;
        public override int Annee => 2022;

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
