using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour01
{
    public class Instruction
    {
        private string _LigneInstruction;

        private string _LigneInstructionConverti;

        public Instruction(string pEntree)
        {
            _LigneInstruction = pEntree;
            _LigneInstructionConverti = _LigneInstruction;
        }


        public int DonneCode() => _DonnePremiereDigit * 10 + _DonneDerniereDigit;

        public void Convertir()
        {
            Dictionary<string, string> lDicoRemplacement = new Dictionary<string, string>()
            {
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3",
                ["four"] = "4",
                ["five"] = "5",
                ["six"] = "6",
                ["seven"] = "7",
                ["eight"] = "8",
                ["nine"] = "9",
            };

            int lIndexDebut = int.MaxValue;
            string lCleDebut = string.Empty;

            int lIndexFin = -1;
            string lCleFin = string.Empty;


            foreach(string lCle in lDicoRemplacement.Keys)
            {
                int lIndexPremier = _LigneInstruction.IndexOf(lCle);

                if(lIndexPremier >= 0 && lIndexPremier < lIndexDebut)
                {
                    lIndexDebut = lIndexPremier;
                    lCleDebut = lCle;
                }

                int lIndexDernier = _LigneInstruction.LastIndexOf(lCle);

                if(lIndexDernier >= 0 && lIndexDernier > lIndexFin)
                {
                    lIndexFin = lIndexDernier;
                    lCleFin = lCle;
                }
            }
            int lIndexPremiereDigit = _LigneInstruction.IndexOf(_LigneInstruction.First(o => char.IsDigit(o)));
            int lIndexDerniereDigit = _LigneInstruction.LastIndexOf(_LigneInstruction.Last(o => char.IsDigit(o)));
            
            if (lIndexFin >= 0 && (lIndexFin + lDicoRemplacement[lCleFin].Length) > lIndexDerniereDigit)
            {
                Regex lRegex = new Regex(lCleFin);
                _LigneInstructionConverti = _LigneInstructionConverti.Substring(0, lIndexFin) + lRegex.Replace(_LigneInstructionConverti.Substring(lIndexFin), lDicoRemplacement[lCleFin], 1);
            }

            if (lIndexDebut != int.MaxValue && lIndexDebut < lIndexPremiereDigit)
            {
                Regex lRegex = new Regex(lCleDebut);
                _LigneInstructionConverti = lRegex.Replace(_LigneInstructionConverti, lDicoRemplacement[lCleDebut], 1);
            }

        }

        private int _DonnePremiereDigit => int.Parse(_LigneInstructionConverti.First(o => char.IsDigit(o)).ToString());
        private int _DonneDerniereDigit => int.Parse(_LigneInstructionConverti.Last(o => char.IsDigit(o)).ToString());


    }
}
