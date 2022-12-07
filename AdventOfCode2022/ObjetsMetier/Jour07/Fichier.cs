using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour07
{
    [DebuggerDisplay("Fichier : {Nom} - {Taille}")]
    public class Fichier : IEmplacementStockage
    {
        public string Nom { get; init; }

        private decimal _Taille;
        public decimal Taille => _Taille;
        public Dossier Parent { get; init; }



        public Fichier(string pNom, Dossier pParent, decimal pTaille)
        {
            Nom = pNom;
            Parent = pParent;
            _Taille = pTaille;
        }
    }
}
