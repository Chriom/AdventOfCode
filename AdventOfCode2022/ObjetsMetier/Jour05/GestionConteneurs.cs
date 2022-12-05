using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour05
{
    public class GestionConteneurs
    {

        private PlanConteneurs _Plan;

        private List<Instruction> _Instructions;

        public GestionConteneurs(PlanConteneurs pPlan, List<Instruction> pInstructions)
        {
            _Plan = pPlan;
            _Instructions = pInstructions;
        }


        public void ExecuterInstructionsPourGrue9000()
        {
            foreach(Instruction lInstruction in _Instructions)
            {
                _Plan.DeplacerContaineurPourGrue9000(lInstruction);
            }
        }

        public void ExecuterInstructionsPourGrue9001()
        {
            foreach (Instruction lInstruction in _Instructions)
            {
                _Plan.DeplacerContaineurPourGrue9001(lInstruction);
            }
        }

        public string DonneConteneursDuHautDeLaPile()
        {
            return _Plan.DonneConteneursDuHaut();
        }
    }
}
