using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour03
{
    public class Instruction
    {
        private static readonly Regex _RegexMul = new Regex(@"mul\((?<NombreUn>[0-9]{1,}),(?<NombreDeux>[0-9]{1,})\)");
        private string _Chaine;

        public Instruction(string pChaine)
        {
            _Chaine = pChaine;
        }

        public int ExtraireInstructionsMul()
        {
            return _ExtraireInstructionsMul(_Chaine);
        }

        private int _ExtraireInstructionsMul(string pChaine)
        {
            int lSomme = 0;

            foreach (Match lMatch in _RegexMul.Matches(pChaine))
            {
                int lNombreUn = int.Parse(lMatch.Groups["NombreUn"].Value);
                int lNombreDeux = int.Parse(lMatch.Groups["NombreDeux"].Value);

                lSomme += lNombreUn * lNombreDeux;
            }

            return lSomme;
        }

        public int ExtraireEnTenantCompteDesStops()
        {
            const string DO = "do()";
            const string DONT = "don't()";

            int lSomme = 0;

            string lChaine = _Chaine;

            bool lEnCours = true;

            do
            {
                if (lEnCours)
                {
                    int lIndexDont = lChaine.IndexOf(DONT);

                    if(lIndexDont >= 0)
                    {
                        string lChaineTest = lChaine.Substring(0, lIndexDont);
                        lSomme += _ExtraireInstructionsMul(lChaineTest);

                        lChaine = lChaine.Substring(lIndexDont);
                    }
                    else
                    {
                        //Plus de dont => tous le reste
                        lSomme += _ExtraireInstructionsMul(lChaine);
                        lChaine = string.Empty;
                    }

                    lEnCours = false;
                }
                else
                {
                    int lIndexDo = lChaine.IndexOf(DO);
                    if(lIndexDo >= 0)
                    {
                        lChaine = lChaine.Substring(lIndexDo);
                    }
                    else
                    {
                        //Plus de do => fin
                        lChaine = string.Empty;
                    }

                    lEnCours = true;
                }

            }while(string.IsNullOrEmpty(lChaine) == false);

            return lSomme;
        }

    }
}
