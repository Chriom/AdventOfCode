using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour04
{
    public class Tache
    {
        private PlageSection _SectionsElf1;

        private PlageSection _SectionsElf2;

        public Tache(string pEntree)
        {
            _DecouperEntree(pEntree);
        }

        private void _DecouperEntree(string pEntree)
        {
            string[] lSplit = pEntree.Split(',');

            string[] lElf1 = lSplit[0].Split('-');
            _SectionsElf1 = new PlageSection(int.Parse(lElf1[0]), int.Parse(lElf1[1]));

            string[] lElf2 = lSplit[1].Split('-');
            _SectionsElf2 = new PlageSection(int.Parse(lElf2[0]), int.Parse(lElf2[1]));
        }

        public bool UnDesElfsEstTotalementDansLaPlageDeLAutre => _SectionsElf1.EstInclueTotalementDansPlage(_SectionsElf2) || _SectionsElf2.EstInclueTotalementDansPlage(_SectionsElf1);

        public bool AAuMoinsUneSectionEnCommun => _SectionsElf1.AAuMoinsUneSectionInclueDansPlage(_SectionsElf2) || _SectionsElf2.AAuMoinsUneSectionInclueDansPlage(_SectionsElf1);

    }
}
