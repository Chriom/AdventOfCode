using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Extension;
using AdventOfCode.ObjetsMetier.A2022.Jour03;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour03 : AJour<ContenuSac>
    {
        public override int NumeroJour => 3;
        public override int Annee => 2022;

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
