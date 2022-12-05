using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour05
{
    [DebuggerDisplay("{NumeroPile}")]
    public class PileConteneur
    {
        public int NumeroPile { get; init; }

        private Stack<char> _Conteneurs = new Stack<char>();

        public PileConteneur(int pNumero)
        {
            NumeroPile = pNumero;
        }

        public void AjouterSurLaPile(char pConteneur)
        {
            _Conteneurs.Push(pConteneur);
        }

        public char RetirerDeLaPile()
        {
            return _Conteneurs.Pop();
        }
    }
}
