using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour11;

namespace AdventOfCode.Metier.A2022.Convertisseur
{
    internal class ConvertisseurJour11 : IConvertisseurEntree<Singe>
    {
        public IEnumerable<Singe> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            int lNumeroSinge = -1;
            List<int> lPrioriteObjets = null;
            Func<decimal, decimal> lOperation = null;
            int lDivision = -1;
            int lTrue = -1;
            int lFalse = -1;


            foreach (string lLigne in pEntrees)
            {
                if (string.IsNullOrEmpty(lLigne))
                {
                    continue;
                }

                string[] lSplit = lLigne.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch(lSplit[0])
                {
                    case "Monkey":
                        lNumeroSinge = _DonneNumeroSinge(lLigne);
                        break;
                    case "Starting":
                        lPrioriteObjets = _DonnePrioritesObjets(lLigne);
                        break;
                    case "Operation:":
                        lOperation = _DonneOperation(lLigne);
                        break;
                    case "Test:":
                        lDivision = _DonneDivisionEtTest(lLigne);
                        break;
                    case "If":
                        if (lSplit[1] == "true:")
                        {
                            lTrue = _DonneDivisionEtTest(lLigne);
                        }
                        else
                        {
                            lFalse = _DonneDivisionEtTest(lLigne);
                            Singe lSinge = new Singe()
                            {
                                Numero = lNumeroSinge,
                                OperationChangementNiveau = lOperation,
                                TestObjet = new Test()
                                {
                                    DivisiblePar = lDivision,
                                    NumeroSingeSiVrai = lTrue,
                                    NumeroSingeSiFaux = lFalse,
                                }
                            };

                            foreach(int lObjet in lPrioriteObjets)
                            {
                                lSinge.AjouterObjet(lObjet);
                            }

                            yield return lSinge;
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                };
            }
        }

        private int _DonneNumeroSinge(string pChaine)
        {
            return int.Parse(pChaine.Replace("Monkey ", string.Empty).Replace(":", string.Empty));
        }

        private List<int> _DonnePrioritesObjets(string pChaine)
        {
            string[] lSplit = pChaine.Split(':', StringSplitOptions.RemoveEmptyEntries);

            string[] lObjets = lSplit[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

            return lObjets.Select(o => int.Parse(o))
                          .ToList();
        }

        private Func<decimal, decimal> _DonneOperation(string pChaine)
        {
            string[] lSplit = pChaine.Split("=", StringSplitOptions.RemoveEmptyEntries);
            string[] lOperationSplit = lSplit[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string lGauche = lOperationSplit[0];
            string lOperateur = lOperationSplit[1];
            string lDroite = lOperationSplit[2];

            return (o) =>
            {
                decimal lNombreGauche = o;
                decimal lNombreDroite = o;

                if(lGauche != "old")
                {
                    lNombreGauche = decimal.Parse(lGauche);
                }

                if(lDroite != "old")
                {
                    lNombreDroite = decimal.Parse(lDroite);
                }

                return lOperateur switch
                {
                    "+" => lNombreGauche + lNombreDroite,
                    "-" => lNombreGauche - lNombreDroite,
                    "*" => lNombreGauche * lNombreDroite,
                    "/" => lNombreGauche / lNombreDroite,
                    _ => throw new NotImplementedException(),
                };
            };
        }

        private int _DonneDivisionEtTest(string pChaine)
        {
            return int.Parse(pChaine.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
        }
    }
}
