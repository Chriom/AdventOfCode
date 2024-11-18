using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Metier.A2022.Convertisseurs;
using AdventOfCode.ObjetsMetier.A2022.Jour11;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour11 : AJour<Singe>
    {
        public override int NumeroJour => 11;
        public override int Annee => 2022;

        protected override IEnumerable<Singe> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            return new ConvertisseurJour11().ConvertirEntrees(pEntrees);
        }

        public override string DonneResultatUn()
        {
            InspecteurDeSinge lInspecteur = new InspecteurDeSinge(_Entrees);

            decimal lResultat = 1;

            IEnumerable<int> lDeuxPlusGrand = lInspecteur.DonneNombreInspectionsApresNTour(20, 3)
                                                         .OrderByDescending(o => o)
                                                         .Take(2);

            foreach (int lNombre in lDeuxPlusGrand)
            {
                lResultat *= lNombre;
            }

            return lResultat.ToString();

        }

        public override string DonneResultatDeux()
        {
            InspecteurDeSinge lInspecteur = new InspecteurDeSinge(_Entrees);

            decimal lResultat = 1;

            IEnumerable<int> lDeuxPlusGrand = lInspecteur.DonneNombreInspectionsApresNTour(10000, 1)
                                                         .OrderByDescending(o => o)
                                                         .Take(2);

            foreach (int lNombre in lDeuxPlusGrand)
            {
                lResultat *= lNombre;
            }

            return lResultat.ToString();
        }


    }
}
