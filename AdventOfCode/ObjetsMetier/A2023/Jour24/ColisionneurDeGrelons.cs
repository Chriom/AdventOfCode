using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;
using AdventOfCode.ObjetsMetier.A2022.Jour12;
using Microsoft.Z3;

namespace AdventOfCode.ObjetsMetier.A2023.Jour24
{
    public class ColisionneurDeGrelons
    {
        private List<Grelon> _Grelons;


        public ColisionneurDeGrelons(IEnumerable<Grelon> pGrelons)
        {
            _Grelons = pGrelons.ToList();
        }

        public int DonneNombreDeColissionDansLaZone2D(decimal pMin, decimal pMax)
        {

            List<Position2D<decimal>> lPositionsInterception = new List<Position2D<decimal>>();

            for(int lIndex = 0; lIndex < _Grelons.Count - 1; lIndex++)
            {
               for(int lIndexDeux = lIndex + 1; lIndexDeux < _Grelons.Count; lIndexDeux++)
                {
                    Grelon lGrelon1 = _Grelons[lIndex];
                    Grelon lGrelon2 = _Grelons[lIndexDeux];

                    Position2D<decimal> lPosition = lGrelon1.DonnePositionDeColissionSurXetY(lGrelon2);

                    if(lPosition == null)
                    {
                        continue;
                    }

                    if(lPosition.X >= pMin && lPosition.X <= pMax && lPosition.Y >= pMin && lPosition.Y <= pMax)
                    {
                        lPositionsInterception.Add(lPosition);
                    }
                }
            }

            return lPositionsInterception.Count();
        }


        public decimal DonneSommeCoordonneeGrelonInterception()
        {
            Grelon lGrelon = _DonneGrelonInterception();

            Console.WriteLine($"Grelon X : {lGrelon.PositionInitiale.X:N0} - Y : {lGrelon.PositionInitiale.Y:N0} - Z : {lGrelon.PositionInitiale.Z:N0}");
            Console.WriteLine($"Vélocité X : {lGrelon.Mouvement.X:N0} - Y : {lGrelon.Mouvement.Y:N0} - Z : {lGrelon.Mouvement.Z:N0}");

            return lGrelon.PositionInitiale.X + lGrelon.PositionInitiale.Y + lGrelon.PositionInitiale.Z;
        }
        private Grelon _DonneGrelonInterception()
        {
            Microsoft.Z3.Context lContextZ3 = new Microsoft.Z3.Context();
            Microsoft.Z3.Solver lSolver = lContextZ3.MkSolver();

            const string X_RECHERCHE = "X_Recherche";
            const string Y_RECHERCHE = "Y_Recherche";
            const string Z_RECHERCHE = "Z_Recherche";

            const string X_VELOCITE_RECHERCHE = "VX_Recherche";
            const string Y_VELOCITE_RECHERCHE = "VY_Recherche";
            const string Z_VELOCITE_RECHERCHE = "VZ_Recherche";


            //Sur le principe il faut qu'on arrive à taper quelque grelon dans la liste en partant du même début et même vélocité
            //Position(X, Y, Z) + Vélocité(X, Y, Z) + Pas de temps * nombre de grelon
            //Donc au moins 6 + nt inconnues

            //Les coordonnées recherchées
            var lXCherche = lContextZ3.MkIntConst(X_RECHERCHE);
            var lYCherche = lContextZ3.MkIntConst(Y_RECHERCHE);
            var lZCherche = lContextZ3.MkIntConst(Z_RECHERCHE);

            //La vélocité recherché

            var lVXCherche = lContextZ3.MkIntConst(X_VELOCITE_RECHERCHE);
            var lVYCherche = lContextZ3.MkIntConst(Y_VELOCITE_RECHERCHE);
            var lVZCherche = lContextZ3.MkIntConst(Z_VELOCITE_RECHERCHE);


            //Boucle sur les premier grelons pour faire les égalitées
            //Choix totalement arbitraire
            for(int lIndex = 0; lIndex < 5 ; lIndex++)
            {
                Grelon lGrelon = _Grelons[lIndex];

                //Chaque delta peut être différent au moment de l'impact
                var lDelta = lContextZ3.MkIntConst($"t_Grelon_[{lIndex}]");

                //Position
                //X_Grelon = X_Initiale + t_Grelon_[] * X_Mouvement
                //Y_Grelon = Y_Initiale + t_Grelon_[] * Y_Mouvement
                //Z_Grelon = Z_Intiiale + t_Grelon_[] * Z_Mouvement

                //Doit respectivement être égale
                //X_Recherche + t_Grelon_[] * VX_Recherche 
                //Y_Recherche + t_Grelon_[] * VY_Recherche
                //Z_Recherche + t_Grelon_[] * VZ_Recherche


                //************************************
                //Equation du grelon

                //Vélocité
                var lXMouvement = lContextZ3.MkInt((Int64)lGrelon.Mouvement.X);
                var lYMouvement = lContextZ3.MkInt((Int64)lGrelon.Mouvement.Y);
                var lZMouvement = lContextZ3.MkInt((Int64)lGrelon.Mouvement.Z);

                //Multiplication
                var lMuliplicationVelociteX = lContextZ3.MkMul(lDelta, lXMouvement);
                var lMuliplicationVelociteY = lContextZ3.MkMul(lDelta, lYMouvement);
                var lMuliplicationVelociteZ = lContextZ3.MkMul(lDelta, lZMouvement);

                //Positions
                var lXInitiale = lContextZ3.MkInt((Int64)lGrelon.PositionInitiale.X);
                var lYInitiale = lContextZ3.MkInt((Int64)lGrelon.PositionInitiale.Y);
                var lZInitiale = lContextZ3.MkInt((Int64)lGrelon.PositionInitiale.Z);

                //Addition

                var lEquationX = lContextZ3.MkAdd(lXInitiale, lMuliplicationVelociteX);
                var lEquationY = lContextZ3.MkAdd(lYInitiale, lMuliplicationVelociteY);
                var lEquationZ = lContextZ3.MkAdd(lZInitiale, lMuliplicationVelociteZ);



                //*******************************************
                //Equation de la recherche
                var lMuliplicationRechercheVelociteX = lContextZ3.MkMul(lDelta, lVXCherche);
                var lMuliplicationRechercheVelociteY = lContextZ3.MkMul(lDelta, lVYCherche);
                var lMuliplicationRechercheVelociteZ = lContextZ3.MkMul(lDelta, lVZCherche);

                //Addition
                var lEquationRechercheX = lContextZ3.MkAdd(lXCherche, lMuliplicationRechercheVelociteX);
                var lEquationRechercheY = lContextZ3.MkAdd(lYCherche, lMuliplicationRechercheVelociteY);
                var lEquationRechercheZ = lContextZ3.MkAdd(lZCherche, lMuliplicationRechercheVelociteZ);


                //***********************************************
                //Egalité
                var lEgaliteX = lContextZ3.MkEq(lEquationX, lEquationRechercheX);
                var lEgaliteY = lContextZ3.MkEq(lEquationY, lEquationRechercheY);
                var lEgaliteZ = lContextZ3.MkEq(lEquationZ, lEquationRechercheZ);


                lSolver.Add(lEgaliteX);
                lSolver.Add(lEgaliteY);
                lSolver.Add(lEgaliteZ);
            }

            Status lStatus = lSolver.Check();

            if(lStatus != Status.SATISFIABLE)
            {
                throw new Exception("ça suffit pas t'a fait de la merde");
            }

            var lModel = lSolver.Model;


            var lX = lModel.Eval(lXCherche);
            var lY = lModel.Eval(lYCherche);
            var lZ = lModel.Eval(lZCherche);

            var lX_Velocite = lModel.Eval(lVXCherche);
            var lY_Velocite = lModel.Eval(lVYCherche);
            var lZ_Velocite = lModel.Eval(lVZCherche);


            decimal lPositionX = decimal.Parse(lX.ToString());
            decimal lPositionY = decimal.Parse(lY.ToString());
            decimal lPositionZ = decimal.Parse(lZ.ToString());

            decimal lVelociteX = decimal.Parse(lX_Velocite.ToString());
            decimal lVelociteY = decimal.Parse(lY_Velocite.ToString());
            decimal lVelociteZ = decimal.Parse(lZ_Velocite.ToString());

            Position3D<decimal> lPosition = new Position3D<decimal>(lPositionX, lPositionY, lPositionZ);
            Vecteur3D<decimal> lVelocite = new Vecteur3D<decimal>(lVelociteX, lVelociteY, lVelociteZ);

            return new Grelon(lPosition, lVelocite);

        }
    }
}
