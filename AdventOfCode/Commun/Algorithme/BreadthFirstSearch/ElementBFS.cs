using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Algorithme.BreadthFirstSearch
{
    public abstract class ElementBFS<T> : IElementBFS<T> where T : class, IElementBFS
    {
        private int _Profondeur = -1;
        public int Profondeur
        {
            get
            {
                return _Profondeur;
            }
            set
            {
                if (_Profondeur < 0)
                {
                    _Profondeur = value;
                }
            }
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int NombreAcces { get; set; }
        public bool EstVisitee => Profondeur >= 0;

        public abstract bool EstAuDepart { get; }

        public abstract bool EstALaFin { get; }

        public abstract IEnumerable<T> DonneElementsAccessible(ParcoursBFS<T> pParcours);
    }
}
