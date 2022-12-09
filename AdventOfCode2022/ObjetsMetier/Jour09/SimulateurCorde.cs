using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour09
{
    internal class SimulateurCorde
    {
        public static List<ResultatEtapeSimulation> SimulerToutesLesInstructions(IEnumerable<Instruction> pInstructions, int pNombreNoeuds)
        {
            List<ResultatEtapeSimulation> lResultats = new List<ResultatEtapeSimulation>();

            //Init les positions initiales
            SortedDictionary<int, PositionCorde> lPositions = new SortedDictionary<int, PositionCorde>();

            for(int lIndex = 1; lIndex <= pNombreNoeuds; lIndex++)
            {
                lPositions.Add(lIndex, new PositionCorde());
            }


            foreach (Instruction lInstruction in pInstructions)
            {
                lResultats.AddRange(_SimulerInstruction(lInstruction, lPositions));

                ResultatEtapeSimulation lResultat = lResultats.Last();

                lPositions = lResultat.NoeudsCorde;
            }

            return lResultats;
        }

        private static List<ResultatEtapeSimulation> _SimulerInstruction(Instruction pInstruction, SortedDictionary<int, PositionCorde> pPositions)
        {
            List<ResultatEtapeSimulation> lResultats = new List<ResultatEtapeSimulation>();

            SortedDictionary<int, PositionCorde> lPositionsPrecedente = pPositions;
            

            for (int lEtape = 1; lEtape <= pInstruction.NombreEtape; lEtape++)
            {
                SortedDictionary<int, PositionCorde> lPositions = new SortedDictionary<int, PositionCorde>();
                PositionCorde lNoeud = lPositionsPrecedente[1];

                //Déplacement de la tête             
                lNoeud = pInstruction.DirectionDeplacement switch
                {
                    Direction.Haut => new PositionCorde() { Horizontale = lNoeud.Horizontale, Verticale = lNoeud.Verticale - 1 },
                    Direction.Bas => new PositionCorde() { Horizontale = lNoeud.Horizontale, Verticale = lNoeud.Verticale + 1 },
                    Direction.Gauche => new PositionCorde() { Horizontale = lNoeud.Horizontale - 1, Verticale = lNoeud.Verticale },
                    Direction.Droite => new PositionCorde() { Horizontale = lNoeud.Horizontale + 1, Verticale = lNoeud.Verticale },
                    _ => throw new NotImplementedException(),
                };

                lPositions.Add(1, lNoeud); 

                for (int lIndex = 2; lIndex <= pPositions.Count; lIndex++)
                {
                    //Déplacement du reste
                    lNoeud = lPositions[lIndex - 1];
                    PositionCorde lNoeudSuivant = lPositionsPrecedente[lIndex];

                   

                    if(Math.Abs(lNoeudSuivant.Horizontale - lNoeud.Horizontale) == 2 && Math.Abs(lNoeudSuivant.Verticale - lNoeud.Verticale) == 0)
                    {
                        //Déplacement horizontale
                        int lDirection = lNoeudSuivant.Horizontale - lNoeud.Horizontale < 0 ? 1 : -1;
                        lNoeudSuivant = new PositionCorde() { Horizontale = lNoeudSuivant.Horizontale + lDirection, Verticale = lNoeudSuivant.Verticale };
                    }
                    else if (Math.Abs(lNoeudSuivant.Horizontale - lNoeud.Horizontale) == 0 && Math.Abs(lNoeudSuivant.Verticale - lNoeud.Verticale) == 2)
                    {
                        //Déplacement verticale
                        int lDirection = lNoeudSuivant.Verticale - lNoeud.Verticale < 0 ? 1 : -1;
                        lNoeudSuivant = new PositionCorde() { Horizontale = lNoeudSuivant.Horizontale , Verticale = lNoeudSuivant.Verticale + lDirection };
                    }
                    else if ((Math.Abs(lNoeudSuivant.Horizontale - lNoeud.Horizontale) > 1 && Math.Abs(lNoeudSuivant.Verticale - lNoeud.Verticale) >= 1) ||
                             (Math.Abs(lNoeudSuivant.Horizontale - lNoeud.Horizontale) >= 1 && Math.Abs(lNoeudSuivant.Verticale - lNoeud.Verticale) > 1))
                    {
                        //Diagonale
                        int lDirectionHorizontale = lNoeudSuivant.Horizontale - lNoeud.Horizontale < 0 ? 1 : -1;
                        int lDirectionVerticale = lNoeudSuivant.Verticale - lNoeud.Verticale < 0 ? 1 : -1;

                        lNoeudSuivant = new PositionCorde() { Horizontale = lNoeudSuivant.Horizontale + lDirectionHorizontale, Verticale = lNoeudSuivant.Verticale + lDirectionVerticale };
                    }

                    lPositions.Add(lIndex, lNoeudSuivant);

                }

               
                lResultats.Add(new ResultatEtapeSimulation()
                {
                    Instruction = pInstruction,
                    Etape = lEtape,
                    NoeudsCorde = lPositions,
                }) ;


                //On incrémente la position de la tête
                lPositionsPrecedente = lPositions;
            }



            return lResultats;
        }
    }
}
