using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour14
{
    public class CoordonneesRocher
    {
        private string _Instructions;

        public CoordonneesRocher(string pInstruction)
        {
            _Instructions = pInstruction;
        }

        public List<Coordonnees> DonneCoordonnees()
        {
            List<Coordonnees> lCoordonnees = new List<Coordonnees>();
            string[] lInstructionsSplit = _Instructions.Split("->", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (string lInstruction in lInstructionsSplit)
            {
                string[] lSplit = lInstruction.Split(",", StringSplitOptions.RemoveEmptyEntries);

                lCoordonnees.Add(new Coordonnees()
                {
                    Horizontale = int.Parse(lSplit[0]),
                    Verticale = int.Parse(lSplit[1]),
                });
            }

            return lCoordonnees;
        }
    }
}
