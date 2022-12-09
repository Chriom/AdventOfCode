using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour09
{
    [DebuggerDisplay("H : {Horizontale} - V : {Verticale}")]
    internal class PositionCorde
    {
        public int Horizontale { get; set; }
        public int Verticale { get; set; }

        public override bool Equals(object pObjet)
        {
            PositionCorde lPosition =  pObjet as PositionCorde;

            if(lPosition == null)
            {
                return false;
            }

            return this.Horizontale == lPosition.Horizontale && this.Verticale == lPosition.Verticale;
        }

        public override int GetHashCode()
        {
            return this.Horizontale.GetHashCode() ^ this.Verticale.GetHashCode();
        }
    }
}
