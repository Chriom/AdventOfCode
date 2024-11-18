using AdventOfCode.ObjetsMetier.A2023.Jour03;
using AdventOfCode.ObjetsMetier.A2023.Jour04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour04 : AJour<Partie>
    {
        public override int NumeroJour => 4;
        public override int Annee => 2023;

        protected override IEnumerable<Partie> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                Partie lPartie = new Partie();
                string[] lPartieSplit = lEntree.Split(':', StringSplitOptions.TrimEntries);

                lPartie.NumeroPartie = int.Parse(lPartieSplit[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[1]);

                string[] lNombresSplit = lPartieSplit[1].Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                lPartie.NumeroCartes = lNombresSplit[0].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                       .Select(o => int.Parse(o))
                                                       .ToList();

                lPartie.NumeroValide = lNombresSplit[1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                       .Select(o => int.Parse(o))
                                                       .ToList();

                yield return lPartie;
            }
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneNombreDeCarteValide() > 0 ? Math.Pow(2, o.DonneNombreDeCarteValide() - 1) : 0)
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
            JoueurDePartie lJoueur = new JoueurDePartie(_Entrees);

            return lJoueur.DonneResultatPartie().ToString();
            
        }

    }
}
