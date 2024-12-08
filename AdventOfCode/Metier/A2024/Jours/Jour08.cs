using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour08;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour08 : AJour<CarteAntennes>
    {
        public override int NumeroJour => 8;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .DonneNombreAntinodes()
                           .ToString(); 
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonneNombreAntinodesAvecRepetition()
                           .ToString();
        }


        protected override IEnumerable<CarteAntennes> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new CarteAntennes(pEntrees.ToList());
        }
    }
}
