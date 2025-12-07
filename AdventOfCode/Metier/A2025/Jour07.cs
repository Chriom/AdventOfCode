using AdventOfCode.ObjetsMetier.A2025.Jour07;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Metier.A2025
{
    public class Jour07 : AJour<Diagramme>
    {
        public override int NumeroJour => 7;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            Diagramme lDiagramme = _Entrees.First();

            return lDiagramme.DonneNombreSeparation().ToString();
        }

        public override string DonneResultatDeux()
        {
            Diagramme lDiagramme = _Entrees.First();

            return lDiagramme.DonneNombreTimeline().ToString();
        }


        protected override IEnumerable<Diagramme> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new Diagramme(pEntrees.ToList());
        }
    }
}
