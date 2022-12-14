using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour13
{
    public class TrieurPaquets
    {
        IEnumerable<PairePaquets> _Source;

        public TrieurPaquets(IEnumerable<PairePaquets> pPaires)
        {
            _Source = pPaires;
        }

        public List<Paquet> ExtrairePaquetsEtTrier()
        {
            List<Paquet> lPaquets = _Extraire();
            lPaquets.Sort();

            return lPaquets;

        }

        private List<Paquet> _Extraire()
        {
            List<Paquet> lPaquets = new List<Paquet>();

            foreach (PairePaquets lPaire in _Source)
            {
                lPaquets.Add(lPaire.Paquet1);
                lPaquets.Add(lPaire.Paquet2);
            }

            return lPaquets;
        }
    }
}
