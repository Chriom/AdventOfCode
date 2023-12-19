using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour19
{
    public class FluxDeTravail
    {
        public string NomFlux { get; set; }

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        public string DonneProchainFlux(Element pElement)
        {
            foreach(Instruction lInstruction in Instructions)
            {
                if (lInstruction.PasseLeTest(pElement))
                {
                    return lInstruction.NomFluxSiReussi;
                }
            }

            throw new Exception("Plus d'instruction à tester");
        }
    }
}
