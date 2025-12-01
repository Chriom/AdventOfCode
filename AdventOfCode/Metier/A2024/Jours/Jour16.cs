using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour16;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour16 : AJour<Labyrinthe>
    {
        public override int NumeroJour => 16;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            Labyrinthe lLabyrinthe = _Entrees.First();

            return lLabyrinthe.DonneValeurMeilleurChemin()
                              .ToString();
        }

        public override string DonneResultatDeux()
        {
            Labyrinthe lLabyrinthe = _Entrees.First();

            return lLabyrinthe.DonneNombreDeMeilleurBanc()
                              .ToString();
        }


        protected override IEnumerable<Labyrinthe> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();

            TypeCase[][] lCarte = new TypeCase[lEntrees.Count][];

            for (int lIndexLigne = 0; lIndexLigne < lEntrees.Count; lIndexLigne++)
            {
                string lLigne = lEntrees[lIndexLigne];

                lCarte[lIndexLigne] = new TypeCase[lLigne.Length];

                for (int lIndexColonne = 0; lIndexColonne < lLigne.Length; lIndexColonne++)
                {
                    lCarte[lIndexLigne][lIndexColonne] = lLigne[lIndexColonne] switch
                    {
                        '#' => TypeCase.Mur,
                        '.' => TypeCase.Vide,
                        'S' => TypeCase.Entrée,
                        'E' => TypeCase.Sortie,
                        _ => throw new InvalidOperationException()
                    };

                }
            }

            yield return new Labyrinthe(lCarte);
        }
    }
}
