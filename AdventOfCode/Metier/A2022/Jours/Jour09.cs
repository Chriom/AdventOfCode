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

        protected override IEnumerable<Instruction> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(' ');
                int lNombreEtape = int.Parse(lSplit[1]);

                yield return lSplit[0] switch
                {
                    "U" => new Instruction(Direction.Haut, lNombreEtape),
                    "D" => new Instruction(Direction.Bas, lNombreEtape),
                    "L" => new Instruction(Direction.Gauche, lNombreEtape),
                    "R" => new Instruction(Direction.Droite, lNombreEtape),
                    _ => throw new Exception("Instruction illisible")
                };
            }
        }

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
