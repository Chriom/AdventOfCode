using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2024.Jour13
{
    public class MachineAPince
    {
        private Position2D _BoutonA;
        private Position2D _BoutonB;
        private Position2D _Prix;

        public MachineAPince(Position2D pBoutonA, Position2D pBoutonB, Position2D pPrix)
        {
            _BoutonA = pBoutonA;
            _BoutonB = pBoutonB;
            _Prix = pPrix;
        }

        public decimal DonneNombreDeToken()
        {
            using (Microsoft.Z3.Context lContext = new Microsoft.Z3.Context())
            {
                //Résoudre pour X
                //NombreBoutonA * _BoutonA.X + NombreBoutonB * _BoutonB.X = _Prix.X
                //Et pour Y
                //NombreBoutonA * _BoutonA.Y + NombreBoutonB * _BoutonB.Y = _Prix.Y
                //Avec NombreBoutonA + NombreBoutonB <= 100

                Microsoft.Z3.ArithExpr lNombreBoutonA = lContext.MkIntConst("NombreBoutonA");
                Microsoft.Z3.ArithExpr lNombreBoutonB = lContext.MkIntConst("NombreBoutonB");

                Microsoft.Z3.ArithExpr lEquationX = lContext.MkAdd(lContext.MkMul(lNombreBoutonA, lContext.MkInt(_BoutonA.X)), lContext.MkMul(lNombreBoutonB, lContext.MkInt(_BoutonB.X)));
                Microsoft.Z3.ArithExpr lEquationY = lContext.MkAdd(lContext.MkMul(lNombreBoutonA, lContext.MkInt(_BoutonA.Y)), lContext.MkMul(lNombreBoutonB, lContext.MkInt(_BoutonB.Y)));

                Microsoft.Z3.BoolExpr lContrainteA = lContext.MkLe(lNombreBoutonA, lContext.MkInt(100));
                Microsoft.Z3.BoolExpr lContrainteB = lContext.MkLe(lNombreBoutonB, lContext.MkInt(100));

                Microsoft.Z3.Solver lSolver = lContext.MkSolver();

                lSolver.Assert(lContext.MkEq(lEquationX, lContext.MkInt(_Prix.X)));
                lSolver.Assert(lContext.MkEq(lEquationY, lContext.MkInt(_Prix.Y)));

                lSolver.Assert(lContrainteA);
                lSolver.Assert(lContrainteB);

                if (lSolver.Check() == Microsoft.Z3.Status.SATISFIABLE)
                {
                    Microsoft.Z3.Model lModel = lSolver.Model;

                    return 3 * decimal.Parse(lModel.Eval(lNombreBoutonA, true).ToString()) + decimal.Parse(lModel.Eval(lNombreBoutonB, true).ToString());
                }

                return 0;
            }
        }

        private const decimal _PRIXAJUSTE = 10000000000000;

        public decimal DonneNombreDeTokenAvecAjustementPrix()
        {

            using (Microsoft.Z3.Context lContext = new Microsoft.Z3.Context())
            {
                //Résoudre pour X
                //NombreBoutonA * _BoutonA.X + NombreBoutonB * _BoutonB.X = _Prix.X
                //Et pour Y
                //NombreBoutonA * _BoutonA.Y + NombreBoutonB * _BoutonB.Y = _Prix.Y
                //Avec NombreBoutonA + NombreBoutonB <= 100

                Microsoft.Z3.ArithExpr lNombreBoutonA = lContext.MkIntConst("NombreBoutonA");
                Microsoft.Z3.ArithExpr lNombreBoutonB = lContext.MkIntConst("NombreBoutonB");

                Microsoft.Z3.ArithExpr lEquationX = lContext.MkAdd(lContext.MkMul(lNombreBoutonA, lContext.MkInt(_BoutonA.X)), lContext.MkMul(lNombreBoutonB, lContext.MkInt(_BoutonB.X)));
                Microsoft.Z3.ArithExpr lEquationY = lContext.MkAdd(lContext.MkMul(lNombreBoutonA, lContext.MkInt(_BoutonA.Y)), lContext.MkMul(lNombreBoutonB, lContext.MkInt(_BoutonB.Y)));

                Microsoft.Z3.Solver lSolver = lContext.MkSolver();

                lSolver.Assert(lContext.MkEq(lEquationX, lContext.MkInt((_Prix.X + _PRIXAJUSTE).ToString())));
                lSolver.Assert(lContext.MkEq(lEquationY, lContext.MkInt((_Prix.Y + _PRIXAJUSTE).ToString())));


                if (lSolver.Check() == Microsoft.Z3.Status.SATISFIABLE)
                {
                    Microsoft.Z3.Model lModel = lSolver.Model;

                    return 3 * decimal.Parse(lModel.Eval(lNombreBoutonA, true).ToString()) + decimal.Parse(lModel.Eval(lNombreBoutonB, true).ToString());
                }

                return 0;
            }
        }
    }
}
