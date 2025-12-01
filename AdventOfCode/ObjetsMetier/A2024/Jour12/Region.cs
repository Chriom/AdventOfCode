using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour12
{
    [DebuggerDisplay("{Valeur} - Réduit : {ValeurBarriereReduite}")]
    public class Region
    {
        public char Valeur { get; private set; }

        public List<Parcelle> Parcelles { get; set; } = new List<Parcelle>();

        public int Aire => Parcelles.Count;

        public int Perimetre => Parcelles.Sum(o => o.NombreAdjacentRegionDifferente);

        public int ValeurBarriere => Aire * Perimetre;

        public int NombreCoins => Parcelles.Sum(o => o.NombreCoin);

        public int ValeurBarriereReduite => Aire * NombreCoins;

        public Region(char pValeur)
        {
            Valeur = pValeur;
        }
    }
}
