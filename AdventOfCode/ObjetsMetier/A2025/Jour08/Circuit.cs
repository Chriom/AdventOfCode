using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.ObjetsMetier.A2025.Jour08
{
    [DebuggerDisplay("{NombreBoites} - {Id}")]
    public class Circuit
    {
        public Guid Id { get; private set ; }

        public List<BoiteDerivation> BoitesDerivation { get; private set; } = new List<BoiteDerivation>();

        public Circuit()
        {
            Id = Guid.NewGuid();
        }

        public void AjouterBoite(BoiteDerivation pBoite)
        {
            BoitesDerivation.Add(pBoite);

            pBoite.Circuit = this;
        }

        public int NombreBoites => BoitesDerivation.Count;
    }
}
