using AdventOfCode.ObjetsMetier.A2023.Jour15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour15 : AJour<Procedure>
    {
        public override int NumeroJour => 15;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            Procedure lProcedure = _Entrees.First();


            return lProcedure.DonneSommeDesHash()
                             .ToString();
        }

        public override string DonneResultatDeux()
        {
            Procedure lProcedure = _Entrees.First();

            return lProcedure.TrierBoites()
                             .ToString();


        }


    }
}
