using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour04
{
    internal class PlageSection
    {
        public int SectionBasse { get; init; }

        public int SectionHaute { get; init; }

        public PlageSection(int pSectionBasse, int pSectionHaute)
        {
            SectionBasse = pSectionBasse;
            SectionHaute = pSectionHaute;
        }

        public bool EstInclueTotalementDansPlage(PlageSection pPlageTest)
        {
            return SectionBasse <= pPlageTest.SectionBasse && SectionHaute >= pPlageTest.SectionHaute;
        }

        public bool AAuMoinsUneSectionInclueDansPlage(PlageSection pPlageTest)
        {
            return SectionBasse >= pPlageTest.SectionBasse && SectionHaute <= pPlageTest.SectionHaute ||
                   SectionHaute >= pPlageTest.SectionBasse && SectionHaute <= pPlageTest.SectionHaute;
        }
    }
}
