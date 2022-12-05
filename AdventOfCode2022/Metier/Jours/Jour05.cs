using AdventOfCode2022.ObjetsMetier.Jour05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour05 : AJour<GestionConteneurs>
    {
        public override int NumeroJour => 5;

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
