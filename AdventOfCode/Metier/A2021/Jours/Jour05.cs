using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour05;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour05 : AJour<Ligne>
    {
        public override int NumeroJour => 5;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            Plateau lPlateau = new Plateau(_Entrees.ToList());


            return lPlateau.DonneNombreCasesHorizontaleOuVerticalSeChevauchant().ToString();
        }

        public override string DonneResultatDeux()
        {
            Plateau lPlateau = new Plateau(_Entrees.ToList());


            return lPlateau.DonneNombreCasesSeChevauchant().ToString();
        }
    }
}
