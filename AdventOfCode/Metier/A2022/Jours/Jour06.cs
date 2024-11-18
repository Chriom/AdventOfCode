using AdventOfCode.ObjetsMetier.A2022.Jour06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour06 : AJour<MessageEncode>
    {
        public override int NumeroJour => 6;
        public override int Annee => 2022;

        protected override IEnumerable<MessageEncode> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new MessageEncode(o));
        }
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
