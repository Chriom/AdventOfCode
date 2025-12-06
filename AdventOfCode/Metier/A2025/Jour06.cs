using AdventOfCode.ObjetsMetier.A2025.Jour06;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Metier.A2025
{
    public class Jour06 : AJour<CahierExercice>
    {
        public override int NumeroJour => 6;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            CahierExercice lCahier = _Entrees.First();

            return lCahier.SommeOperation().ToString();
        }

        public override string DonneResultatDeux()
        {
            CahierExercice lCahier = _Entrees.First();

            return lCahier.SommeOperationCorrecte().ToString();
        }


        protected override IEnumerable<CahierExercice> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            CahierExercice.Exercice[] lExercices = null;
            List<CahierExercice.Exercice> lExercicesCorrecte = new List<CahierExercice.Exercice>();

            List<string> lEntrees = pEntrees.ToList();

            foreach (string lEntree in lEntrees)
            {
                string[] lSplit = lEntree.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if(lExercices == null)
                {
                    lExercices = new CahierExercice.Exercice[lSplit.Length];
                }

                for (int lIndex = 0; lIndex < lSplit.Length; lIndex++)
                {
                    if (lExercices[lIndex] == null)
                    {
                        lExercices[lIndex] = new CahierExercice.Exercice();
                    }

                    if (decimal.TryParse(lSplit[lIndex], out decimal lNombre))
                    {
                        lExercices[lIndex].Nombres.Add(lNombre);
                    }
                    else
                    {
                        lExercices[lIndex].OperationNombres = _DonneOperation(lSplit[lIndex]);
                    }
                }
            }

            //Parsage à la méthode cephalopods
            
            int lNombreLignesNombre = lEntrees.Count - 1;

            string lLigneOperation = lEntrees.Last();

            CahierExercice.Exercice.Operation lOperationEnCours = _DonneOperation(lLigneOperation[0].ToString());
            int lIndexDebut = 0;

            for (int lIndex = 1; lIndex < lLigneOperation.Length; lIndex++)
            {
                CahierExercice.Exercice.Operation lOperationTest = _DonneOperation(lLigneOperation[lIndex].ToString());

                if (lOperationTest != CahierExercice.Exercice.Operation.Indefini || lIndex == lLigneOperation.Length -1)
                {
                    CahierExercice.Exercice lExercice = new CahierExercice.Exercice()
                    {
                        OperationNombres = lOperationEnCours,
                    };

                    //Décalage parce que plus de symbole à la fin
                    int lIndexFin = lOperationTest != CahierExercice.Exercice.Operation.Indefini ? lIndex - 2 : lIndex;

                    //Faut lire à l'envers
                    for (int lIndexNombre = lIndexFin; lIndexNombre >= lIndexDebut; lIndexNombre--)
                    {
                        string lNombre = string.Empty;

                        for (int lIndexLigneNombre = 0; lIndexLigneNombre < lNombreLignesNombre; lIndexLigneNombre++)
                        {
                            string lLigneNombre = lEntrees[lIndexLigneNombre];
                            
                            char lChar = lLigneNombre[lIndexNombre];

                            if (lChar != ' ')
                            {
                                lNombre += lChar;
                            }
                        }

                        lExercice.Nombres.Add(decimal.Parse(lNombre));
                    }

                    lExercicesCorrecte.Add(lExercice);

                    lOperationEnCours = lOperationTest;
                    lIndexDebut = lIndex;
                }
            }


            yield return new CahierExercice(lExercices, lExercicesCorrecte);
        }

        private CahierExercice.Exercice.Operation _DonneOperation(string pCaractere)
        {
            return pCaractere switch
            {
                "+" => CahierExercice.Exercice.Operation.Addition,
                "*" => CahierExercice.Exercice.Operation.Multiplication,
                " " => CahierExercice.Exercice.Operation.Indefini,
                _ => throw new ArgumentOutOfRangeException(nameof(pCaractere))
            };
        }
    }
}
