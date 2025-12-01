using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour04;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour04 : AJour<RechercheurDeTexte>
    {
        public override int NumeroJour => 4;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            RechercheurDeTexte lTexte = _Entrees.First();

            return lTexte.DonneNombreXmas()
                         .ToString();
        }

        public override string DonneResultatDeux()
        {
            RechercheurDeTexte lTexte = _Entrees.First();

            return lTexte.DonneNombreX_Mas()
                         .ToString();
        }


        protected override IEnumerable<RechercheurDeTexte> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            yield return new RechercheurDeTexte(pEntrees.ToList());
        }
    }
}
