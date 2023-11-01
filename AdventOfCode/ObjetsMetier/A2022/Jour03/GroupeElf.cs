using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour03
{
    internal class GroupeElf
    {
        private IEnumerable<ContenuSac> _Sacs;

        public GroupeElf(IEnumerable<ContenuSac> pContenu)
        {
            _Sacs = pContenu;
        }

        public int PrioriteBadge => ContenuSac.DonnePriorite(_DonneBadge());

        private char _DonneBadge()
        {
            List<char> lIntersect = new List<char>();

            foreach (ContenuSac lSac in _Sacs)
            {
                if (lIntersect.Count == 0)
                {
                    lIntersect.AddRange(lSac.Contenu.Select(o => o));
                }
                else
                {
                    lIntersect = lIntersect.Intersect(lSac.Contenu.Select(o => o))
                                           .ToList();
                }

                if (lIntersect.Count == 1)
                {
                    return lIntersect.First();
                }
            }

            throw new Exception("Impossible de trouver le badge");
        }
    }
}
