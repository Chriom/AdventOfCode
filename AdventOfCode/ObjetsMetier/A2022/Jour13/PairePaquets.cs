using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AdventOfCode.ObjetsMetier.A2022.Jour13
{
    public class PairePaquets
    {
        public int Index { get; init; }

        public Paquet Paquet1 { get; init; }

        public Paquet Paquet2 { get; init; }

        public PairePaquets(int pIndex, Paquet pPaquet1, Paquet pPaquet2)
        {
            Index = pIndex;
            Paquet1 = pPaquet1;
            Paquet2 = pPaquet2;
        }

        public bool EstDansLeBonOrdre => _EstDansLeBonOrdre(Paquet1.Json, Paquet2.Json).Value;

        private bool? _EstDansLeBonOrdre(JArray pPaquet1, JArray pPaquet2)
        {
            if (pPaquet1.Count == 0 && pPaquet2.Count > 0)
            {
                return true;
            }


            for (int lIndex = 0; lIndex < pPaquet1.Count; lIndex++)
            {
                if (pPaquet2.Count <= lIndex)
                {
                    //== Pair 5 ==
                    //== Pair 7 ==
                    //- Right side ran out of items, so inputs are not in the right order
                    return false;
                }

                JToken lToken1 = pPaquet1[lIndex];
                JToken lToken2 = pPaquet2[lIndex];


                if (lToken1.Type == JTokenType.Integer && lToken2.Type == JTokenType.Integer)
                {
                    if ((int)lToken1 < (int)lToken2)
                    {
                        //== Pair 1 ==
                        //== Pair 2 ==
                        //Left side is smaller, so inputs are in the right order
                        return true;
                    }

                    if ((int)lToken2 < (int)lToken1)
                    {
                        //== Pair 3 ==
                        //== Pair 8 ==
                        //Right side is smaller, so inputs are not in the right order
                        return false;
                    }
                }
                else
                {
                    if (lToken1.Type == JTokenType.Integer)
                    {
                        lToken1 = new JArray((int)lToken1);
                    }
                    if (lToken2.Type == JTokenType.Integer)
                    {
                        lToken2 = new JArray((int)lToken2);
                    }

                    bool? lEstDansLOrdre = _EstDansLeBonOrdre((JArray)lToken1, (JArray)lToken2);

                    if (lEstDansLOrdre.HasValue)
                    {
                        return lEstDansLOrdre.Value;
                    }
                }

            }

            if (pPaquet1.Count == pPaquet2.Count)
            {
                //Indéfini, il faut passer à la suite
                return null;
            }


            //== Pair 4 ==
            //== Pair 6 ==
            //Left side ran out of items, so inputs are in the right order

            return true;
        }


    }
}
