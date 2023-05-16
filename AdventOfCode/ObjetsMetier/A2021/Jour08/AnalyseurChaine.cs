using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour08
{
    public static class AnalyseurChaine
    {
       public static List<int> AnalyserChaine(string pChaine, Dictionary<TypeSegment, char> pDicoSegmentTrouve)
       {
            List<int> lDigitsPossible = new List<int>();

            if (pChaine.Length == 2)
            {
                lDigitsPossible.Add(1);
            }
            else if (pChaine.Length == 3)
            {
                lDigitsPossible.Add(7);
            }
            else if (pChaine.Length == 4)
            {
                lDigitsPossible.Add(4);
            }
            else if (pChaine.Length == 5)
            {
                //Possible : 2, 3, 5
                lDigitsPossible.Add(5);
                lDigitsPossible.Add(2);
                lDigitsPossible.Add(3);
                if (pDicoSegmentTrouve.ContainsKey(TypeSegment.HautGauche) && pChaine.Contains(pDicoSegmentTrouve[TypeSegment.HautGauche]))
                {
                    lDigitsPossible.Remove(2);
                    lDigitsPossible.Remove(3);
                }
                else if (pDicoSegmentTrouve.ContainsKey(TypeSegment.BasGauche) && pChaine.Contains(pDicoSegmentTrouve[TypeSegment.BasGauche]))
                {
                    lDigitsPossible.Remove(5);
                    lDigitsPossible.Remove(3);
                }
                else if (pDicoSegmentTrouve.ContainsKey(TypeSegment.HautDroite) && pDicoSegmentTrouve.ContainsKey(TypeSegment.BasGauche) && 
                         pChaine.Contains(pDicoSegmentTrouve[TypeSegment.HautDroite]) && pChaine.Contains(pDicoSegmentTrouve[TypeSegment.BasGauche]) == false)
                {
                    lDigitsPossible.Remove(2);
                    lDigitsPossible.Remove(5);
                }
            }
            else if (pChaine.Length == 6)
            {
                //Possible : 0, 6, 9
                lDigitsPossible.Add(0);
                lDigitsPossible.Add(6);
                lDigitsPossible.Add(9);
                if (pDicoSegmentTrouve.ContainsKey(TypeSegment.Centre) && pChaine.Contains(pDicoSegmentTrouve[TypeSegment.Centre]) == false)
                {
                    lDigitsPossible.Remove(6);
                    lDigitsPossible.Remove(9);
                }
                else if (pDicoSegmentTrouve.ContainsKey(TypeSegment.HautDroite) && pChaine.Contains(pDicoSegmentTrouve[TypeSegment.HautDroite]) == false)
                {
                    lDigitsPossible.Remove(0);
                    lDigitsPossible.Remove(9);
                }
                else if (pDicoSegmentTrouve.ContainsKey(TypeSegment.BasGauche) && pChaine.Contains(pDicoSegmentTrouve[TypeSegment.BasGauche]) == false)
                {
                    lDigitsPossible.Remove(0);
                    lDigitsPossible.Remove(6);
                }
            }
            else if (pChaine.Length == 7)
            {
                lDigitsPossible.Add(8);
            }


            return lDigitsPossible;


        }
    }
}
