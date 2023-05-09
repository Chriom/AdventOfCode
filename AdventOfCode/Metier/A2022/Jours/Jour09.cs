using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour09;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour09 : AJour<Instruction>
    {
        public override int NumeroJour => 9;
        public override int Annee => 2022;

        public override string DonneResultatUn()
        {
            List<ResultatEtapeSimulation> lSimulation = SimulateurCorde.SimulerToutesLesInstructions(_Entrees, 2);

            return lSimulation.Select(o => o.Queue)
                              .Distinct()
                              .Count()
                              .ToString();

        }

        public override string DonneResultatDeux()
        {
            List<ResultatEtapeSimulation> lSimulation = SimulateurCorde.SimulerToutesLesInstructions(_Entrees, 10);

            return lSimulation.Select(o => o.Queue)
                              .Distinct()
                              .Count()
                              .ToString();
        }


    }
}
