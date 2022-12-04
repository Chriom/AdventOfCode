using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour02;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour02 : AJour<Jeu>
    {
        public override int NumeroJour => 2;

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.Score)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            foreach(Jeu lJeu in _Entrees)
            {
                lJeu.ChangerJeuJoueurPourEtat();
            }

            return _Entrees.Sum(o => o.Score)
                           .ToString();
        }
    }
}
