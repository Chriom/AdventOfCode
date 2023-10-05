using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour10
{
    public class Ligne
    {
        private static readonly Dictionary<char, int> _Points = new Dictionary<char, int>()
        {
            [')'] = 3,
            [']'] = 57,
            ['}'] = 1197,
            ['>'] = 25137,
        };

        private static readonly Dictionary<char, int> _PointsCompletion = new Dictionary<char, int>()
        {
            ['('] = 1,
            ['['] = 2,
            ['{'] = 3,
            ['<'] = 4,
        };

        private static readonly Dictionary<char, char> _CaractereOuvrant = new Dictionary<char, char>()
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{',
            ['>'] = '<',
        };

        private string _Ligne;

        public Ligne(string pLigne)
        {
            _Ligne = pLigne;    
        }

        public int DonnePointDeLaLigne()
        {
            Stack<char> lOuverts = new Stack<char>();

            for(int lIndex = 0; lIndex < _Ligne.Length; lIndex++)
            {
                char lCaractere = _Ligne[lIndex];

                if(_CaractereOuvrant.TryGetValue(lCaractere, out char lCaractereOuvrant))
                {
                    //Fermant
                    char lEnHaut = lOuverts.Peek();

                    if(lEnHaut == lCaractereOuvrant)
                    {
                        lOuverts.Pop();
                    }
                    else
                    {
                        return _Points[lCaractere];
                    }
                }
                else
                {
                    //Ouvert
                    lOuverts.Push(lCaractere);
                }
            }

            return 0;
        }

        public decimal DonnePointEnCompletantLaligne()
        {
            Stack<char> lOuverts = new Stack<char>();

            for (int lIndex = 0; lIndex < _Ligne.Length; lIndex++)
            {
                char lCaractere = _Ligne[lIndex];

                if (_CaractereOuvrant.TryGetValue(lCaractere, out char lCaractereOuvrant))
                {
                    //Fermant
                    char lEnHaut = lOuverts.Peek();

                    if (lEnHaut == lCaractereOuvrant)
                    {
                        lOuverts.Pop();
                    }
                }
                else
                {
                    //Ouvert
                    lOuverts.Push(lCaractere);
                }
            }

            //Parcours pour calcul des scores

            decimal lScore = 0;
            
            do
            {
                char lCaractere = lOuverts.Pop();

                lScore = (lScore * 5) + _PointsCompletion[lCaractere];

            } while (lOuverts.Count > 0);

            return lScore;
        }


    }
}
