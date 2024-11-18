using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour20;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour20 : AJour<Donnees>
    {
        public override int NumeroJour => 20;
        public override int Annee => 2022;

        protected override IEnumerable<Donnees> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<Donnees> lDonnees = pEntrees.Select((o, p) => new Donnees()
            {
                IndexDepart = p,
                Valeur = decimal.Parse(o),
            })
                                              .ToList();

            for (int lIndex = 0; lIndex < lDonnees.Count; lIndex++)
            {
                int lIndexPrecedent = lIndex - 1;
                int lIndexSuivant = lIndex + 1;

                Donnees lDonnee = lDonnees[lIndex];

                if (lIndexPrecedent < 0)
                {
                    lIndexPrecedent = lDonnees.Count - 1;
                }
                if (lIndexSuivant == lDonnees.Count)
                {
                    lIndexSuivant = 0;
                }

                lDonnee.Precedent = lDonnees[lIndexPrecedent];
                lDonnee.Suivant = lDonnees[lIndexSuivant];

                yield return lDonnee;
            }
        }

        public override string DonneResultatUn()
        {
            ListeCirculaire lListe = new ListeCirculaire(_Entrees.ToList());


            lListe.PermutterListe();

            return lListe.DonneSommeDeTerme(0, 3000, 1000).ToString();

        }

        public override string DonneResultatDeux()
        {
            ListeCirculaire lListe = new ListeCirculaire(_Entrees.ToList());

            lListe.AppliquerNombreMagique();


            for (int lIndex = 0; lIndex < 10; lIndex++)
            {
                lListe.PermutterListe();
            }


            return lListe.DonneSommeDeTerme(0, 3000, 1000).ToString();
        }


    }
}
