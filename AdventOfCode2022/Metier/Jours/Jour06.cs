using AdventOfCode2022.ObjetsMetier.Jour06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour06 : AJour<MessageEncode>
    {
        public override int NumeroJour => 6;

        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .DonnePositionPremierMarqueurPaquet()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonnePositionPremierMarqueurMessage()
                           .ToString();
        }


    }
}
