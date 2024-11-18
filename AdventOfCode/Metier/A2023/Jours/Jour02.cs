using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour02;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour02 : AJour<Jeu>
    {
        public override int NumeroJour => 2;
        public override int Annee => 2023;

        protected override IEnumerable<Jeu> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                Jeu lJeu = new Jeu();

                string[] lSplit = lEntree.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                lJeu.Numero = int.Parse(lSplit[0].Replace("Game ", string.Empty));

                foreach (string lTirageInfo in lSplit[1].Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                {
                    Tirage lTirage = new Tirage();
                    lJeu.Tirages.Add(lTirage);

                    foreach (string lNombreCouleur in lTirageInfo.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                    {
                        string[] lInfoSplit = lNombreCouleur.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                        Boule lBoule = lInfoSplit[1] switch
                        {
                            "blue" => Boule.Bleu,
                            "red" => Boule.Rouge,
                            "green" => Boule.Vert,
                            _ => throw new ArgumentOutOfRangeException(nameof(lInfoSplit))
                        };

                        lTirage.BoulesTiré.Add(lBoule, int.Parse(lInfoSplit[0]));
                    }
                }


                yield return lJeu;
            }
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Where(o => o.JeuEstPossible(12, 13, 14))
                           .Sum(o => o.Numero)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            return _Entrees.Sum(o => o.DonneNombreMinimumDeCubeNecessaire()
                                      .Produit(o => o.Value))
                           .ToString();
        }

    }
}
