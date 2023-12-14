using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour14;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour14 : IConvertisseurEntree<Plateforme>
    {
        public IEnumerable<Plateforme> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignes = pEntrees.ToList();

            TypeElement[][] lCarte = new TypeElement[lLignes.Count][];

            for(int lIndex = 0; lIndex < lLignes.Count; lIndex++)
            {
                lCarte[lIndex] = lLignes[lIndex].Select(o => EnumHelper.DonneValeurDepuisDescription<TypeElement>(o.ToString()))
                                                .ToArray();
            }

            yield return new Plateforme(lCarte);
        }
    }
}
