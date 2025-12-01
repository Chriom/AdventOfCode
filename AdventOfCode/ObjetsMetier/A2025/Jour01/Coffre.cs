using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2025.Jour01
{
    public class Coffre
    {
        public int Aiguille { get; private set; } = 50;

        public int ArretSurZero { get; private set; } = 0;

        public int PassageSurZero { get; private set; } = 0;

        public void AppliquerRotations(IEnumerable<Rotation> pRotations)
        {
            foreach (Rotation lRotation in pRotations)
            {
                Aiguille += lRotation.Direction switch
                {
                    Rotation.DirectionRotation.Gauche => -lRotation.Pas,
                    Rotation.DirectionRotation.Droite => lRotation.Pas,
                    _ => throw new ArgumentOutOfRangeException(nameof(lRotation.Direction))
                };

                while(Aiguille < 0)
                {
                    Aiguille += 100;
                    PassageSurZero++;
                }

                while (Aiguille > 99)
                {
                    Aiguille -= 100;
                    PassageSurZero++;
                }

                if(Aiguille == 0)
                {
                    ArretSurZero++;
                }
            }
        }
    }
}
