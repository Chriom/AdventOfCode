using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour14;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour14 : AJour<CoordonneesRocher>
    {
        public override int NumeroJour => 14;
        public override int Annee => 2022;

        protected override IEnumerable<CoordonneesRocher> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return pEntrees.Select(o => new CoordonneesRocher(o));
        }

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
