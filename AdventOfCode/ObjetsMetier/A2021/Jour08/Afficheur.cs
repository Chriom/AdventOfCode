using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour08
{
    public class Afficheur
    {
        private string _Chaine;

        public Afficheur(string pChaine)
        {
            _Chaine = pChaine;
        }
        
        public int? Digit { get; set; }

        public void AnalyserChaine(Dictionary<TypeSegment, char> pDicoSegmentTrouve) 
        {
            List<int> lDigitsPossible = AnalyseurChaine.AnalyserChaine(_Chaine, pDicoSegmentTrouve);

            if(lDigitsPossible.Count == 1)
            {
                Digit = lDigitsPossible.First();
            }
        }


    }
}
