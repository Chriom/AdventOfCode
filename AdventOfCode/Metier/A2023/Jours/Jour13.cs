using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2023.Jour13;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour13 : AJour<IleDeLave>
    {
        public override int NumeroJour => 13;

        public override int Annee => 2023;
        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneResume())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
             return _Entrees.Sum(o => o.DonneResumeAvecReparation())
                            .ToString();
        }


    }
}
