using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2023.Jour10;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour10 : AJour<Labyrinthe>
    {
        public override int NumeroJour => 10;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            Labyrinthe lLabyrinthe = _Entrees.First();

            return lLabyrinthe.DonneLongeurPlusGrandeBoucle().ToString();
        }

        public override string DonneResultatDeux()
        {
            Labyrinthe lLabyrinthe = _Entrees.First();

            return lLabyrinthe.DonneNombreDeCasesALInterieurDeLaBoucle().ToString();
        }

        
    }
}
