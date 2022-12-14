using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour14;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour14 : AJour<CoordonneesRocher>
    {
        public override int NumeroJour => 14;

        public override string DonneResultatUn()
        {
            Plateau lPlateau = new Plateau(_Entrees.ToList());

            return lPlateau.DonneNombreDeGrainsSurLePlateau()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            Plateau lPlateau = new Plateau(_Entrees.ToList());

            lPlateau.AjouterSol();

            return lPlateau.DonneNombreDeGrainsSurLePlateau()
                           .ToString();
        }        
    }
}
