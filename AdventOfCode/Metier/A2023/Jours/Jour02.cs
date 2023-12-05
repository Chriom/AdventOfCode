using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2023.Jour02;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour02 : AJour<Jeu>
    {
        public override int NumeroJour => 2;
        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            return _Entrees.Where(o => o.JeuEstPossible(12, 13, 14))
                           .Sum(o => o.Numero)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Sum(o => o.DonneNombreMinimumDeCubeNecessaire()
                                      .Produit(o => o.Value))
                           .ToString();
        }

    }
}
