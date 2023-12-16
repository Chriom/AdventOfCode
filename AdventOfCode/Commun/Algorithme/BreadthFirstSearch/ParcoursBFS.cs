using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Algorithme.BreadthFirstSearch
{
    public class ParcoursBFS<T> where T : IElementBFS
    {
        public T[][] Cases { get; set; }
        public int Hauteur { get; set; }
        public int Largeur { get; set; }

        public int DonneNombreDeCasesVisitees()
        {
            return Cases.SelectMany(o => o)
                        .Count(o => o.EstVisitee);
        }
    }
}
