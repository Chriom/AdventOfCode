using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour12;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour12 : AJour<Ferme>
    {
        public override int NumeroJour => 12;

        public override int Annee => 2024;

        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .DonnePrixBarrieres()
                           .ToString();        
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonnePrixBarrieresAvecReduction()
                           .ToString();
        }


        protected override IEnumerable<Ferme> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Ferme(pEntrees.ToList());
        }
    }
}
