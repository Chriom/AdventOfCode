using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour16;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour16 : AJour<Machine>
    {
        public override int NumeroJour => 16;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            Machine lMachine = _Entrees.First();

            return lMachine.DonneNombreDeCasesEnergisees()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            Machine lMachine = _Entrees.First();

            return lMachine.DonneNombreMaximumDeCasesEnergise()
                           .ToString();
        }


    }
}
