using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour10
{
    internal class Processeur
    {
        private IEnumerable<IInstruction> _Instructions;

        public Processeur(IEnumerable<IInstruction> pInstructions)
        {
            _Instructions = pInstructions;
        }

        public IEnumerable<int> DonnePuissanceRegistreTousLesNCycle(int pNumeroDebutCycle, int pNumeroFinCycle, int pEspacementCycle)
        {
            foreach(ResultatExecutionInstruction lResultat in ExecuterToutesLesInstructions())
            {
                if(lResultat.Cycle > pNumeroFinCycle)
                {
                    break;
                }

                if(lResultat.Cycle == pNumeroDebutCycle || (lResultat.Cycle - pNumeroDebutCycle) % pEspacementCycle == 0)
                {
                    yield return lResultat.Cycle * lResultat.RegistreX;
                }
            }
        }

        public IEnumerable<ResultatExecutionInstruction> ExecuterToutesLesInstructions()
        {
            int lCycle = 1;
            int lRegistreX = 1;

            foreach (IInstruction lInstruction in _Instructions)
            {
                foreach(ResultatExecutionInstruction lResultat in lInstruction.Executer(lCycle, lRegistreX))
                {
                    lCycle = lResultat.Cycle + 1;
                    lRegistreX = lResultat.RegistreXCycleSuivant;

                    yield return lResultat;
                }
            }
        }
    }
}
