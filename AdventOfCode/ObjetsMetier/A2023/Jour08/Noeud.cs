using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour08
{
    [DebuggerDisplay("{NomNoeud}")]
    public class Noeud
    {
        public string NomNoeud { get; set; }

        public string NoeudGauche { get; set; }

        public Noeud Gauche { get; set; }

        public Noeud Droite { get; set; }

        public string NoeudDroite { get; set; }

        public Noeud(string pLigne) 
        {
            string[] lLigneSplit = pLigne.Split("=", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            NomNoeud = lLigneSplit[0];

            string lNoeudEnfants = lLigneSplit[1].Replace("(", string.Empty).Replace(")", string.Empty);

            string[] lEnfantsSplit = lNoeudEnfants.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            NoeudGauche = lEnfantsSplit[0];
            NoeudDroite = lEnfantsSplit[1];
        }

        private const string _NOEUD_DEBUT = "AAA";
        private const string _NOEUD_FIN = "ZZZ";

        public bool EstAuDebut => NomNoeud == _NOEUD_DEBUT;

        public bool EstALaFin => NomNoeud == _NOEUD_FIN;

        private const char _NOEUD_DEBUT_FAMTOME = 'A';
        private const char _NOEUD_FIN_FAMTOME = 'Z';

        public bool EstAuDebutPourUnFamtome => NomNoeud.EndsWith(_NOEUD_DEBUT_FAMTOME);
        public bool EstALaFinPourUnFamtome => NomNoeud.EndsWith(_NOEUD_FIN_FAMTOME);


    }
}
