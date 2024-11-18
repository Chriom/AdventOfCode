using AdventOfCode.Metier.A2022.Convertisseurs;
using AdventOfCode.ObjetsMetier.A2022.Jour05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour05 : AJour<GestionConteneurs>
    {
        public override int NumeroJour => 5;
        public override int Annee => 2022;

        protected override IEnumerable<GestionConteneurs> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return new ConvertisseurJour05().ConvertirEntrees(pEntrees);
        }

        public override string DonneResultatUn()
        {
            GestionConteneurs lGestion = _Entrees.First();

            lGestion.ExecuterInstructionsPourGrue9000();

            return lGestion.DonneConteneursDuHautDeLaPile();
        }

        public override string DonneResultatDeux()
        {
            GestionConteneurs lGestion = _Entrees.First();

            lGestion.ExecuterInstructionsPourGrue9001();

            return lGestion.DonneConteneursDuHautDeLaPile();
        }


    }
}
