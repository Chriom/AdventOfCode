using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour17
{
    public class QuartierVisite
    {
        public Quartier Quartier { get; set; }
        public SensVenu Sens { get; set; }
        public int Longueur { get; set; }

        public string Cle => $"{Sens}|{Longueur}|{Quartier.PositionX}|{Quartier.PositionY}";

        public int DeperditionDepuisDepart { get; set; } = int.MaxValue;

        public QuartierVisite Precedent { get; set; }

    }
}
