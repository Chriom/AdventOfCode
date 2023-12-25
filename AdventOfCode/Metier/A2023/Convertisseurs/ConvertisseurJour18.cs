using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour18 : IConvertisseurEntree<Sequence>
    {
        public IEnumerable<Sequence> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                Sens lSens = EnumHelper.DonneValeurDepuisDescription<Sens>(lEntreeSplit[0]);
                int lNombreCase = int.Parse(lEntreeSplit[1]);

                Couleur lCouleur = new Couleur(lEntreeSplit[2].Replace("(", string.Empty).Replace(")", string.Empty));

                yield return new Sequence(lSens, lNombreCase, lCouleur);
            }
        }
    }
}
