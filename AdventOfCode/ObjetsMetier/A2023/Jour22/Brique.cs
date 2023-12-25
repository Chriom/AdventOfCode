using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour22
{
    [DebuggerDisplay("{Identifiant} | {Debut} | {Fin}")]
    public class Brique
    {
        public int Identifiant { get; set; }
        public Position3D Debut { get; set; }

        public Position3D Fin { get; set; }

        public IEnumerable<Position3D> DonnePositions()
        {
            for(int lIndexX = Debut.X; lIndexX <= Fin.X; lIndexX++)
            {
                for(int lIndexY = Debut.Y; lIndexY <= Fin.Y; lIndexY++)
                {
                    for(int lIndexZ = Debut.Z; lIndexZ <= Fin.Z; lIndexZ++)
                    {
                        yield return new Position3D(lIndexX, lIndexY, lIndexZ);
                    }
                }
            }
        }

        public Orientation Orientation => Debut.Z == Fin.Z ? Orientation.Horizontale : Orientation.Vertical;

        public List<Brique> BriquesDessous { get; set; } = new List<Brique>();

        public List<Brique> BriquesDessus { get; set; } =   new List<Brique>();
    }
}
