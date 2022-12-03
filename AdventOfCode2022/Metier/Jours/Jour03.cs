using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Extension;
using AdventOfCode2022.ObjetsMetier.Jour03;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour03 : AJour<ContenuSac>
    {
        public override int NumeroJour => 3;

        public Jour03(bool pModeTest) : base(pModeTest)
        { }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.PrioriteCharactereCommun)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.SplitEnListe(3)
                           .Select(o => new GroupeElf(o))
                           .Sum(o => o.PrioriteBadge)
                           .ToString();
        }


    }
}
