using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2022.Convertisseur
{
    internal class ConvertisseurJour05 : IConvertisseurEntree<GestionConteneurs>
    {
        private List<string> _Entrees;

        public IEnumerable<GestionConteneurs> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            _Entrees = pEntrees.ToList();
            
            List<PileConteneur> lPiles = new List<PileConteneur>();


            //Recharche de la première séparation
            for(int lIndex = 0; lIndex < _Entrees.Count(); lIndex++)
            {
                string lLigne = _Entrees[lIndex];

                if (string.IsNullOrEmpty(lLigne))
                {
                    PlanConteneurs lPlanConteneurs = _AnalyserPlan(lIndex - 1);
                    List<Instruction> lInstructions = _AnalyserInstructions(lIndex + 1);

                    return new List<GestionConteneurs>() { new GestionConteneurs(lPlanConteneurs, lInstructions) };
                }
            }


            return null;
        }

        private const int _TAILLE_TEXTE_PILE = 4;

        private PlanConteneurs _AnalyserPlan(int pIndexFin)
        {
            //Rupture entre le plan et les instructions
            bool lPremiereLigne = true;

            List<PileConteneur> lPiles = new List<PileConteneur>();

            for (int lIndexPlan = pIndexFin; lIndexPlan >= 0; lIndexPlan--)
            {
                string lLigne = _Entrees[lIndexPlan];

                int lTailleMax = lLigne.Length;
                int lNumeroPile = 1;
                do
                {
                    int lDebutCoupe = (lNumeroPile - 1) * _TAILLE_TEXTE_PILE;
                    int lTailleCoupe = _TAILLE_TEXTE_PILE;

                    if(lDebutCoupe + _TAILLE_TEXTE_PILE > lTailleMax)
                    {
                        lTailleCoupe = lTailleMax - lDebutCoupe;
                    }


                    string lTexte = lLigne.Substring(lDebutCoupe, lTailleCoupe).Trim();

                    if (lPremiereLigne)
                    {
                        int lNumeroDeLaPile = int.Parse(lTexte);

                        lPiles.Add(new PileConteneur(lNumeroDeLaPile));
                    }
                    else
                    {
                        PileConteneur lPile = lPiles.First(o => o.NumeroPile == lNumeroPile);
                        lTexte = lTexte.Replace("[", string.Empty).Replace("]", string.Empty).Trim();

                        if(string.IsNullOrEmpty(lTexte) == false)
                        {
                            lPile.AjouterSurLaPile(lTexte.First());
                        }                        
                    }

                    lNumeroPile++;

                } while (((lNumeroPile - 1) * 4) <= lTailleMax);

                lPremiereLigne = false;
            }
            
            return new PlanConteneurs(lPiles);

        }

        private List<Instruction> _AnalyserInstructions(int pIndexDebut)
        {
            int lNumeroInstruction = 1;
            List<Instruction> lInstructions = new List<Instruction>();


            for(int lIndex = pIndexDebut; lIndex < _Entrees.Count; lIndex++)
            {
                string lLigne = _Entrees[lIndex];

                if (string.IsNullOrEmpty(lLigne))
                {
                    continue;
                }

                string[] lSplit = lLigne.Split(' ');

                int lNombre = int.Parse(lSplit[1]);
                int lDepart = int.Parse(lSplit[3]);
                int lArrivee = int.Parse(lSplit[5]);

                lInstructions.Add(new Instruction(lNumeroInstruction++, lNombre, lDepart, lArrivee));
            }


            return lInstructions;
        }
    }
}
