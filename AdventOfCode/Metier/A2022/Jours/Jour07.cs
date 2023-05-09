using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour07;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour07 : AJour<IEmplacementStockage>
    {
        public override int NumeroJour => 7;
        public override int Annee => 2022;

        public override string DonneResultatUn()
        {


            return _DonneDossierDeTailleInferieur(_DonneDossierRacine(), 100000).Sum(o => o.Taille)
                                                                                .ToString();
        }

        private const decimal _TAILLE_TOTALE = 70000000;
        private const decimal _TAILLE_NECESSAIRE = 30000000;

        public override string DonneResultatDeux()
        {
            Dossier lRacine = _DonneDossierRacine();

            decimal lEspaceLibre = _TAILLE_TOTALE - lRacine.Taille;
            decimal lEspaceManquant = _TAILLE_NECESSAIRE - lEspaceLibre;

            Dossier lDossierASupprime = _DonneDossierDeTailleSuperieur(lRacine, lEspaceManquant).OrderBy(o => o.Taille)
                                                                                                .First();


            return lDossierASupprime.Taille.ToString();
        }

        private Dossier _DonneDossierRacine()
        {
            Dossier lDossierRacine = _Entrees.OfType<Dossier>()
                                             .First();

            return lDossierRacine;
        }

        private IEnumerable<Dossier> _DonneDossierDeTailleInferieur(Dossier pDossierCourant, decimal pTailleMax)
        {
            List<Dossier> lDossiers = new List<Dossier>();

            if (pDossierCourant.Taille <= pTailleMax)
            {
                lDossiers.Add(pDossierCourant);
            }

            foreach (Dossier lEnfant in pDossierCourant.Enfants.OfType<Dossier>())
            {
                lDossiers.AddRange(_DonneDossierDeTailleInferieur(lEnfant, pTailleMax));
            }

            return lDossiers;
        }

        private IEnumerable<Dossier> _DonneDossierDeTailleSuperieur(Dossier pDossierCourant, decimal pTailleMin)
        {
            List<Dossier> lDossiers = new List<Dossier>();

            if (pDossierCourant.Taille >= pTailleMin)
            {
                lDossiers.Add(pDossierCourant);

                foreach (Dossier lEnfant in pDossierCourant.Enfants.OfType<Dossier>())
                {
                    lDossiers.AddRange(_DonneDossierDeTailleSuperieur(lEnfant, pTailleMin));
                }
            }

            return lDossiers;
        }
    }
}
