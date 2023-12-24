using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour23
{
    public class Intersection
    {
        public Position2D Position { get; set; }

        public List<Intersection> IntersectionLies { get; set; } = new List<Intersection>();

        public string Cle => Position.Cle;
    }
}
