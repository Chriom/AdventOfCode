using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour02;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour02 : AJour<Jeu>
    {
        public override int NumeroJour => 2;
        public override int Annee => 2022;

        private static readonly Dictionary<string, Forme> _DicoConversion = new Dictionary<string, Forme>()
        {
            ["A"] = Forme.Pierre,
            ["B"] = Forme.Papier,
            ["C"] = Forme.Ciseau,
            ["X"] = Forme.Pierre,
            ["Y"] = Forme.Papier,
            ["Z"] = Forme.Ciseau,
        };

        private static readonly Dictionary<string, EtatPartie> _DicoConversionEtat = new Dictionary<string, EtatPartie>()
        {
            ["X"] = EtatPartie.Perdue,
            ["Y"] = EtatPartie.Egalite,
            ["Z"] = EtatPartie.Victoire,
        };

        protected override IEnumerable<Jeu> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<Jeu> lJeux = new List<Jeu>();

            foreach (string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Forme lOpposant = _DicoConversion[lSplit[0]];
                Forme lJoueur = _DicoConversion[lSplit[1]];

                EtatPartie lEtat = _DicoConversionEtat[lSplit[1]];

                lJeux.Add(new Jeu(lOpposant, lJoueur, lEtat));
            }

            return lJeux;
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.Score)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            foreach (Jeu lJeu in _Entrees)
            {
                lJeu.ChangerJeuJoueurPourEtat();
            }

            return _Entrees.Sum(o => o.Score)
                           .ToString();
        }
    }
}
