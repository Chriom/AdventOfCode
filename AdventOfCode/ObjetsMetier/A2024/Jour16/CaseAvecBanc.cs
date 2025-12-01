using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;
using AdventOfCode.ObjetsMetier.A2023.Jour23;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode.ObjetsMetier.A2024.Jour16
{
    public class CaseAvecBanc : ElementBFS<CaseAvecBanc>, IElementBFS
    {
        public TypeCase TypeDeCase { get; set; }

        public Direction Direction { get; set; } 

        public int Score { get; set; }

        public override bool EstAuDepart { get => TypeDeCase == TypeCase.Sortie; set => throw new NotImplementedException(); }

        public override bool EstALaFin => TypeDeCase == TypeCase.Entrée;

        public override IEnumerable<CaseAvecBanc> DonneElementsAccessible(ParcoursBFS<CaseAvecBanc> pParcours, int pXPrecedent, int pYPrecedent)
        {
            int lMaxScore = pParcours.Cases.SelectMany(o => o)
                                           .Where(o => o.TypeDeCase == TypeCase.Sortie)
                                           .Max(o => o.Score);

            CaseAvecBanc lCaseOrigine = pYPrecedent >= 0 && pXPrecedent >= 0 ? pParcours.Cases[pYPrecedent][pXPrecedent] : this;

            //Les inférieur dans les trois directions
            //Les supérieur de max 999 avec direction opposé (pas sur la sortie ni l'entrée)
            if (Direction != Direction.Haut)
            {
                CaseAvecBanc lCaseHaut = pParcours.Cases[PositionY - 1][PositionX];

                if (lCaseHaut.Score < Score)
                {
                    if (lCaseHaut.Direction == Direction.Bas)
                    {
                        yield return lCaseHaut;
                    }
                    else if (lCaseHaut.Score + 1001 <= lMaxScore)
                    {
                        yield return lCaseHaut;
                    }

                }
                else if (lCaseHaut.TypeDeCase != TypeCase.Mur &&
                        lCaseHaut.Score <= Score + 999 &&
                        lCaseHaut.Score <= lMaxScore &&
                        lCaseHaut.Direction != Direction &&
                        lCaseHaut.Score + 2 == lCaseOrigine.Score)
                {
                    yield return lCaseHaut;
                }
            }

            if (Direction != Direction.Bas)
            {
                CaseAvecBanc lCaseBas = pParcours.Cases[PositionY + 1][PositionX];
                if (lCaseBas.Score < Score)
                {
                    if (lCaseBas.Direction == Direction.Haut)
                    {
                        yield return pParcours.Cases[PositionY + 1][PositionX];
                    }
                    else if (lCaseBas.Score + 1001 <= lMaxScore)
                    {
                        yield return lCaseBas;
                    }
                }
                else if (lCaseBas.TypeDeCase != TypeCase.Mur &&
                         lCaseBas.Score <= Score + 999 &&
                         lCaseBas.Score <= lMaxScore &&
                         lCaseBas.Direction != Direction &&
                         lCaseBas.Score + 2 == lCaseOrigine.Score)
                {
                    yield return lCaseBas;
                }
            }

            if (Direction != Direction.Droite)
            {
                CaseAvecBanc lCaseDroite = pParcours.Cases[PositionY][PositionX + 1];
                if (lCaseDroite.Score < Score)
                {
                    if (lCaseDroite.Direction == Direction.Gauche)
                    {
                        yield return lCaseDroite;
                    }
                    else if (lCaseDroite.Score + 1001 <= lMaxScore)
                    {
                        yield return lCaseDroite;
                    }
                }
                else if (lCaseDroite.TypeDeCase != TypeCase.Mur &&
                         lCaseDroite.Score <= Score + 999 &&
                         lCaseDroite.Score <= lMaxScore &&
                         lCaseDroite.Direction != Direction &&
                         lCaseDroite.Score + 2 == lCaseOrigine.Score)
                {
                    yield return lCaseDroite;
                }
            }

            if (Direction != Direction.Gauche)
            {
                CaseAvecBanc lCaseGauche = pParcours.Cases[PositionY][PositionX - 1];
                if (lCaseGauche.Score < Score)
                {
                    if (lCaseGauche.Direction == Direction.Droite)
                    {
                        yield return lCaseGauche;
                    }
                    else if (lCaseGauche.Score + 1001 <= lMaxScore)
                    {
                        yield return lCaseGauche;
                    }
                }
                else if (lCaseGauche.TypeDeCase != TypeCase.Mur &&
                         lCaseGauche.Score <= Score + 999 &&
                         lCaseGauche.Score <= lMaxScore &&
                         lCaseGauche.Direction != Direction &&
                         lCaseGauche.Score + 2 == lCaseOrigine.Score)
                {
                    yield return lCaseGauche;
                }
            }
        }

       
    }
}
