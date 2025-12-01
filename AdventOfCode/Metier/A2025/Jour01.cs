using AdventOfCode.ObjetsMetier.A2025.Jour01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2025
{
    public class Jour01 : AJour<Rotation>
    {
        public override int NumeroJour => 1;

        public override int Annee => 2025;

        public override string DonneResultatUn()
        {
            Coffre lCoffre = new Coffre();

            lCoffre.AppliquerRotations(_Entrees);

            return lCoffre.ArretSurZero.ToString();
        }

        public override string DonneResultatDeux()
        {
            Coffre lCoffre = new Coffre();

            lCoffre.AppliquerRotations(_Entrees);

            return lCoffre.PassageSurZero.ToString();
        }

        protected override IEnumerable<Rotation> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                if (string.IsNullOrEmpty(lEntree))
                {
                    yield break; 
                }

                Rotation lRotation = new Rotation();

                lRotation.Direction = lEntree[0] switch
                {
                    'L' => Rotation.DirectionRotation.Gauche,
                    'R' => Rotation.DirectionRotation.Droite,
                    _ => throw new ArgumentOutOfRangeException(nameof(lRotation.Direction))
                };

                lRotation.Pas = int.Parse(lEntree.Substring(1));

                yield return lRotation;
            }
        }
    }
}
