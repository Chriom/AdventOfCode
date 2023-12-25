using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Utilitaires;

namespace AdventOfCode.ObjetsMetier.A2023.Jour19
{
    [DebuggerDisplay("{FluxTesté} -> {FluxSuivant} : {TotalDansPlage}")]
    public class NoeudTest
    {
        public NoeudTest Parent { get; set; }

        public string FluxTesté { get; set; }

        public string FluxSuivant { get; set; }

        public PlageValeur<int> Plage_ExtremementBeauARegarder { get; set; }
        public PlageValeur<int> Plage_Musical { get; set; }
        public PlageValeur<int> Plage_Aerodynamique { get; set; }
        public PlageValeur<int> Plage_Brillant { get; set; }
        
        public List<NoeudTest> Enfant { get; set; } = new List<NoeudTest>();

        public bool EstAuDebut => FluxSuivant == DonneesDeTravail.FLUX_DEBUT;

        public bool EstTerminé => FluxSuivant == DonneesDeTravail.FLUX_ACCEPTE || FluxSuivant == DonneesDeTravail.FLUX_POUBELLE;

        public bool AComtabiliser => FluxSuivant == DonneesDeTravail.FLUX_ACCEPTE;

        public decimal TotalDansPlage => (decimal)((decimal)(Plage_ExtremementBeauARegarder.Distance + 2) * (decimal)(Plage_Musical.Distance + 2) * (decimal)(Plage_Aerodynamique.Distance + 2) * (decimal)(Plage_Brillant.Distance + 2));

        public void AffecterPlage(char pEmplacement, PlageValeur<int> pPlage)
        {
            switch (pEmplacement)
            {
                case 'x':
                    Plage_ExtremementBeauARegarder = pPlage;
                    break;
                case 'm':
                    Plage_Musical = pPlage;
                    break;
                case 'a':
                    Plage_Aerodynamique = pPlage;
                    break;
                case 's':
                    Plage_Brillant = pPlage;
                    break;
            }
        }
    }
}
