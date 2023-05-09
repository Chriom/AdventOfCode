using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour12
{
    [DebuggerDisplay("{Position} - {ViensDe}")]
    public class Chemin
    {
        public Chemin CheminPrecedent { get; init; }

        public int Niveau { get; init; }

        public List<Chemin> CheminsSuivant { get; init; } = new List<Chemin>();

        public Position Position { get; init; }

        public char Hauteur { get; init; }

        public Mouvement ViensDe { get; init; }

        public bool EstBloque { get; set; }
        public bool EstALarrive { get; set; }

        public bool AUnEnfantALarrive => CheminsSuivant.Any(o => o.EstALarrive || o.AUnEnfantALarrive);
        public bool EstParcourue => EstBloque || EstALarrive || AUnEnfantALarrive;

        public Chemin DonneSuivantNonParcourue()
        {
            return CheminsSuivant.FirstOrDefault(o => o.EstParcourue == false);
        }

        public int DonneNiveauPlusBasALarrive()
        {
            if (EstALarrive)
            {
                return Niveau;
            }

            int lNiveauPlusBas = int.MaxValue;

            foreach (Chemin lEnfant in CheminsSuivant)
            {
                int lNiveau = lEnfant.DonneNiveauPlusBasALarrive();

                if (lNiveau < lNiveauPlusBas)
                {
                    lNiveauPlusBas = lNiveau;
                }
            }


            return lNiveauPlusBas;
        }

    }
}
