using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour08
{
    [DebuggerDisplay("{DigitTrouve}")]
    public class Digit
    {
        private string _Chaine;
        public List<char> Characteres { get; private set; }

        public List<int> DigitsPossible { get; set; } = new List<int>();

        public bool EstTrouve => DigitsPossible.Count == 1;

        public int DigitTrouve => EstTrouve ? DigitsPossible.First() : -1;

        public Digit(string pChaine) 
        {
            _Chaine = pChaine;
            Characteres = _Chaine.ToList();
        }

        public void AnalyserDigit(Dictionary<TypeSegment, char> pDicoSegmentTrouve)
        {
            DigitsPossible = AnalyseurChaine.AnalyserChaine(_Chaine, pDicoSegmentTrouve);
        }

        public void SupprimerTrouverDesPossible(List<int> pTrouves)
        {
            DigitsPossible = DigitsPossible.Except(pTrouves)
                                           .ToList();
        }
    }
}
