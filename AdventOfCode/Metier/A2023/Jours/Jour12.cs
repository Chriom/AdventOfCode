using AdventOfCode.ObjetsMetier.A2023.Jour12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour12 : AJour<Enregistrement>
    {
        public override int NumeroJour => 12;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneNombreCombinaisonPossible())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            throw new NotImplementedException();
        }

        
    }
}
