using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour24
{
    public class Grelon
    {
        public Position3D<decimal> PositionInitiale { get; private set; }

        public Vecteur3D<decimal> Mouvement { get; private set; }

        public Grelon(Position3D<decimal> pPositionInitiale, Vecteur3D<decimal> pMouvement)
        {
            PositionInitiale = pPositionInitiale;
            Mouvement = pMouvement;
        }

        public EquationLigne EquationDeLaLigne => EquationLigne.EquationDepuisDeuxPositions(new Position2D<decimal>(PositionInitiale.X, PositionInitiale.Y), new Position2D<decimal>(PositionInitiale.X + Mouvement.X, PositionInitiale.Y + Mouvement.Y));

        public Position2D<decimal> DonnePositionDeColissionSurXetY(Grelon pGrelonTest)
        {
            Position2D<decimal> lIntersection = this.EquationDeLaLigne.DonnePointIntersection(pGrelonTest.EquationDeLaLigne);


            if(lIntersection == null)
            {
                return null;
            }


            //Vérif que l'intersection n'est pas avant
            if(Mouvement.X > 0 && lIntersection.X < PositionInitiale.X || Mouvement.X < 0 && lIntersection.X > PositionInitiale.X ||
               Mouvement.Y > 0 && lIntersection.Y < PositionInitiale.Y || Mouvement.Y < 0 && lIntersection.Y > PositionInitiale.Y)
            {
                return null;
            }

            if (pGrelonTest.Mouvement.X > 0 && lIntersection.X < pGrelonTest.PositionInitiale.X || pGrelonTest.Mouvement.X < 0 && lIntersection.X > pGrelonTest.PositionInitiale.X ||
                pGrelonTest.Mouvement.Y > 0 && lIntersection.Y < pGrelonTest.PositionInitiale.Y || pGrelonTest.Mouvement.Y < 0 && lIntersection.Y > pGrelonTest.PositionInitiale.Y)
            {
                return null;
            }

            return lIntersection;
        }
    }
}
