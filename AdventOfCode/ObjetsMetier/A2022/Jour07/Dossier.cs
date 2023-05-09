using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour07
{
    [DebuggerDisplay("Dossier : {Nom} - {Taille}")]
    public class Dossier : IEmplacementStockage
    {
        public string Nom { get; init; }
        public decimal Taille => Enfants.Sum(o => o.Taille);
        public Dossier Parent { get; init; }
        public List<IEmplacementStockage> Enfants { get; set; } = new List<IEmplacementStockage>();

        public Dossier(string pNom, Dossier pParent)
        {
            Nom = pNom;
            Parent = pParent;
        }
    }
}
