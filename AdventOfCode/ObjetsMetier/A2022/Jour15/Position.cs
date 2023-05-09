﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour15
{
    [DebuggerDisplay("X : {X} - Y : {Y}")]
    public class Position
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public decimal DonneDistanceDeManhattan(Position pPosition)
        {
            return Math.Abs(pPosition.X - X) + Math.Abs(pPosition.Y - Y);
        }

        public override bool Equals(object pObjet)
        {
            Position lPosition = pObjet as Position;

            if (lPosition == null)
            {
                return false;
            }

            return X == lPosition.X && Y == lPosition.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
