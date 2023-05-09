using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour20;

namespace AdventOfCode.Metier.A2022.Convertisseur
{
    internal class ConvertisseurJour20 : IConvertisseurEntree<Donnees>
    {
        public IEnumerable<Donnees> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<Donnees> lDonnees = pEntrees.Select((o, p) => new Donnees()
                                                    {
                                                        IndexDepart = p,
                                                        Valeur = decimal.Parse(o),
                                                    })
                                              .ToList();

            for(int lIndex = 0; lIndex < lDonnees.Count; lIndex++)
            {
                int lIndexPrecedent = lIndex - 1;
                int lIndexSuivant = lIndex + 1;

                Donnees lDonnee = lDonnees[lIndex];

                if(lIndexPrecedent < 0)
                {
                    lIndexPrecedent = lDonnees.Count - 1;
                }
                if(lIndexSuivant == lDonnees.Count)
                {
                    lIndexSuivant = 0;
                }

                lDonnee.Precedent = lDonnees[lIndexPrecedent];
                lDonnee.Suivant = lDonnees[lIndexSuivant];

                yield return lDonnee;
            }
        }
    }
}
