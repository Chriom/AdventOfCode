using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour08 : AJour<Carte>
    {
        public override int NumeroJour => 8;

        public override int Annee => 2023;

        protected override  IEnumerable<Carte> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            string lDirection = pEntrees.First();

            List<Mouvement> lMouvements = lDirection.Select(o => EnumHelper.DonneValeurDepuisDescription<Mouvement>(o.ToString()))
                                                    .ToList();

            List<Noeud> lNoeuds = new List<Noeud>();
            Dictionary<string, Noeud> lDicoNoeuds = new Dictionary<string, Noeud>();

            foreach (string lEntree in pEntrees.Skip(2))
            {
                Noeud lNoeud = new Noeud(lEntree);

                lNoeuds.Add(lNoeud);
                lDicoNoeuds.Add(lNoeud.NomNoeud, lNoeud);
            }


            //Association des noeuf
            foreach (Noeud lNoeud in lNoeuds)
            {
                lNoeud.Gauche = lDicoNoeuds[lNoeud.NoeudGauche];
                lNoeud.Droite = lDicoNoeuds[lNoeud.NoeudDroite];
            }

            yield return new Carte(lMouvements, lNoeuds);
        }

        public override string DonneResultatUn()
        {
            Carte lCarte = _Entrees.First();


            return lCarte.DonneNombreEtapePourParcourirJusquaLaFin().ToString();
        }

        public override string DonneResultatDeux()
        {
            Carte lCarte = _Entrees.First();


            return lCarte.DonneNombreEtapePourParcourirJusquaLaFinPourUnFamtome().ToString();
        }


    }
}
