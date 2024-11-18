using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour10;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour10 : AJour<Labyrinthe>
    {
        public override int NumeroJour => 10;

        public override int Annee => 2023;

        protected override IEnumerable<Labyrinthe> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeTuyau[][] lCases = new TypeTuyau[lEntrees.Count][];

            for (int lIndex = 0; lIndex < lEntrees.Count; lIndex++)
            {
                lCases[lIndex] = lEntrees[lIndex].Select(o => EnumHelper.DonneValeurDepuisDescription<TypeTuyau>(o.ToString()))
                                                .ToArray();
            }

            yield return new Labyrinthe(lCases);
        }

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
