﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2022.Jour03;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour03 : AJour<ContenuSac>
    {
        public override int NumeroJour => 3;
        public override int Annee => 2022;

        protected override IEnumerable<ContenuSac> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new ContenuSac(o));
        }

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
