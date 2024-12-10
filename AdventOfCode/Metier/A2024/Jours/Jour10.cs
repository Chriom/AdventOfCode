using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour10;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour10 : AJour<CarteTopographique>
    {
        public override int NumeroJour => 10;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .DonneNombreDeParcoursPossible()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.First()
                           .DonneNombreDeParcoursDifferentPossible()
                           .ToString();
        }


        protected override IEnumerable<CarteTopographique> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            int[][] lCarte = new int[lEntrees.Count][];

            for(int lIndexLigne = 0; lIndexLigne < lEntrees.Count; lIndexLigne++)
            {
                lCarte[lIndexLigne] = lEntrees[lIndexLigne].Select(o => int.Parse(o.ToString())).ToArray();
            }

            yield return new CarteTopographique(lCarte);
        }
    }
}
