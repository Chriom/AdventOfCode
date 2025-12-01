using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2024.Jour07;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour07 : AJour<Pont>
    {
        public override int NumeroJour => 7;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.Where(o => new TesteurPont(o).EstPossible(new List<Operateur>() { Operateur.Addition, Operateur.Multiplication}))
                           .Sum(o => o.ValeurNecessaire)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Where(o => new TesteurPont(o).EstPossible(new List<Operateur>() { Operateur.Addition, Operateur.Multiplication, Operateur.Concatenation }))
                           .Sum(o => o.ValeurNecessaire)
                           .ToString();
        }


        protected override IEnumerable<Pont> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split(':', StringSplitOptionsExtension.RemoveAndTrim);

                yield return new Pont
                {
                    ValeurNecessaire = decimal.Parse(lEntreeSplit[0]),
                    Nombres = lEntreeSplit[1].Split(' ').Select(decimal.Parse).ToList()
                };
            }
        }
    }
}
