using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour08 : IConvertisseurEntree<Carte>
    {
        public IEnumerable<Carte> ConvertirEntrees(IEnumerable<string> pEntrees)
        { 
            string lDirection = pEntrees.First();

            List<Mouvement> lMouvements = lDirection.Select(o => EnumHelper.DonneValeurDepuisDescription<Mouvement>(o.ToString()))
                                                    .ToList();

            List<Noeud> lNoeuds = new List<Noeud>();
            Dictionary<string, Noeud> lDicoNoeuds = new Dictionary<string, Noeud>();

            foreach(string lEntree in pEntrees.Skip(2))
            {
                Noeud lNoeud = new Noeud(lEntree);

                lNoeuds.Add(lNoeud);
                lDicoNoeuds.Add(lNoeud.NomNoeud, lNoeud);
            }


            //Association des noeuf
            foreach(Noeud lNoeud in lNoeuds)
            {
                lNoeud.Gauche = lDicoNoeuds[lNoeud.NoeudGauche];
                lNoeud.Droite = lDicoNoeuds[lNoeud.NoeudDroite];
            }

            yield return new Carte(lMouvements, lNoeuds);
        }
    }
}

