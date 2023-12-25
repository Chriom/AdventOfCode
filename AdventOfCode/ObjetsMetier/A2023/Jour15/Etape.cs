using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour15
{
    public class Etape
    {
        public Etape(string pSequence)
        {
            Sequence = pSequence;

            string[] lSplit = Sequence.Split(new char[] { '=', '-' }, StringSplitOptions.RemoveEmptyEntries);

            SequenceCoupé = lSplit[0];
            if (lSplit.Length == 1)
            {
                Operation = RETRAIT_LENTILLE;
            }
            else
            {
                Operation = AJOUT_LENTILLE;
                LongueurFocal = int.Parse(lSplit[1]);
            }
        }

        public string Sequence { get; private set; }

        public string SequenceCoupé { get; private set; }

        public const char RETRAIT_LENTILLE = '-';
        public const char AJOUT_LENTILLE = '=';

        public char Operation { get; private set; }
        public int LongueurFocal { get; private set; }

        public int CalculerHashComplet()
        {
            return _CalculerHash(Sequence);
        }

        public int CalculerHashCoupé()
        {
            return _CalculerHash(SequenceCoupé);
        }

        private int _CalculerHash(string pSequence)
        {
            int lValeurCourante = 0;

            foreach (char lChar in pSequence)
            {
                lValeurCourante += (int)lChar;
                lValeurCourante *= 17;
                lValeurCourante = lValeurCourante % 256;
            }

            return lValeurCourante;
        }

        
    }
}
