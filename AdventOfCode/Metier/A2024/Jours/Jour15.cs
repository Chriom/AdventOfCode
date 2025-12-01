using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour15;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour15 : AJour<Entrepot>
    {
        public override int NumeroJour => 15;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            return _Entrees.First()
                           .ExecuterInstructions()
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return new EntrepotDouble(_Entrees.First()).ExecuterInstructions()
                                                       .ToString();
        }


        protected override IEnumerable<Entrepot> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignesCarte = new List<string>();
            List<string> lInstructions = new List<string>();

            bool lCarte = true;

            foreach (string lEntree in pEntrees)
            {
                if (string.IsNullOrEmpty(lEntree))
                {
                    lCarte = false;
                    continue;
                }
                else
                {
                    if (lCarte)
                    {
                        lLignesCarte.Add(lEntree);
                    }
                    else
                    {
                        lInstructions.Add(lEntree);
                    }
                }
            }

            Element[,] lPlanEntrepot = new Element[lLignesCarte.Count, lLignesCarte[0].Length];

            for (int lLigne = 0; lLigne < lLignesCarte.Count; lLigne++)
            {
                for (int lColonne = 0; lColonne < lLignesCarte[lLigne].Length; lColonne++)
                {
                    lPlanEntrepot[lLigne, lColonne] = lLignesCarte[lLigne][lColonne] switch
                    {
                        '.' => Element.Vide,
                        '#' => Element.Mur,
                        'O' => Element.Boite,
                        '@' => Element.Robot,
                        _ => throw new Exception("Caractère inconnu")
                    };
                }
            }

            List<Direction> lDirections = new List<Direction>();

            foreach (string lLigne in lInstructions)
            {
                foreach (char lInstruction in lLigne)
                {
                    Direction lDirection = lInstruction switch
                    {
                        '^' => Direction.Haut,
                        '>' => Direction.Droite,
                        'v' => Direction.Bas,
                        '<' => Direction.Gauche,
                        _ => throw new Exception("Instruction inconnue")
                    };

                    lDirections.Add(lDirection);
                }
            }

            yield return new Entrepot(lPlanEntrepot, lLignesCarte[0].Length, lLignesCarte.Count, lDirections);
        }
    }
}
