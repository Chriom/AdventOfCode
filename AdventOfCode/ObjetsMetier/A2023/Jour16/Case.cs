using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.ObjetsMetier.A2023.Jour16
{
    public class Case : ElementBFS<Case>, IElementBFS
    {
        public TypeDeCase TypeCase { get; set; }

        private bool _Depart = false;

        public override bool EstAuDepart { get => _Depart; set => _Depart = value; }
        public override bool EstALaFin => false;

        public override bool EstVisitee => EnergiseNord && EnergiseSud && EnergiseEst && EnergiseOuest;


        public Case(TypeDeCase pType)
        {
            TypeCase = pType;
        }

        public bool EnergiseNord = false;
        public bool EnergiseEst = false;
        public bool EnergiseSud = false;
        public bool EnergiseOuest = false;

        public override IEnumerable<Case> DonneElementsAccessible(ParcoursBFS<Case> pParcours, int pXPrecedent, int pYPrecedent)
        {
            if ((EstAuDepart && EnergiseOuest) ||  (pXPrecedent >= 0 && pXPrecedent < PositionX))
            {
                //Rayon viens de l'Ouest

                if (EstAuDepart == false && EnergiseOuest)
                {
                    yield break;
                }

                EnergiseOuest = true;

                if (TypeCase == TypeDeCase.Vide || TypeCase == TypeDeCase.DiviseurHorizontal)
                {
                    if (PositionX + 1 < pParcours.Largeur)
                    {
                        yield return pParcours.Cases[PositionY][PositionX + 1];
                    }
                }
                if (TypeCase == TypeDeCase.Miroir || TypeCase == TypeDeCase.DiviseurVertical)
                {
                    if (PositionY - 1 >= 0)
                    {
                        yield return pParcours.Cases[PositionY - 1][PositionX];
                    }
                }
                if (TypeCase == TypeDeCase.AntiMiroir || TypeCase == TypeDeCase.DiviseurVertical)
                {
                    if (PositionY + 1 < pParcours.Hauteur)
                    {
                        yield return pParcours.Cases[PositionY + 1][PositionX];
                    }
                }
            }
            else if ((EstAuDepart && EnergiseEst) || (pXPrecedent >= 0 && pXPrecedent > PositionX))
            {
                //Rayon viens de l'Est
                if (EstAuDepart == false && EnergiseEst)
                {
                    yield break;
                }

                EnergiseEst = true;

                if (TypeCase == TypeDeCase.Vide || TypeCase == TypeDeCase.DiviseurHorizontal)
                {
                    if (PositionX - 1 >= 0)
                    {
                        yield return pParcours.Cases[PositionY][PositionX - 1];
                    }
                }
                if (TypeCase == TypeDeCase.Miroir || TypeCase == TypeDeCase.DiviseurVertical)
                {
                    if (PositionY + 1 < pParcours.Hauteur)
                    {
                        yield return pParcours.Cases[PositionY + 1][PositionX];
                    }
                }
                if (TypeCase == TypeDeCase.AntiMiroir || TypeCase == TypeDeCase.DiviseurVertical)
                {
                    if (PositionY - 1 >= 0)
                    {
                        yield return pParcours.Cases[PositionY - 1][PositionX];
                    }
                }
            }
            else if ((EstAuDepart && EnergiseNord) || (pYPrecedent >= 0 && pYPrecedent < PositionY))
            {
                //Rayon viens du Nord
                if (EstAuDepart == false && EnergiseNord)
                {
                    yield break;
                }

                EnergiseNord = true;

                if (TypeCase == TypeDeCase.Vide || TypeCase == TypeDeCase.DiviseurVertical)
                {
                    if (PositionY + 1 < pParcours.Hauteur)
                    {
                        yield return pParcours.Cases[PositionY + 1][PositionX];
                    }
                }
                if (TypeCase == TypeDeCase.Miroir || TypeCase == TypeDeCase.DiviseurHorizontal)
                {
                    if (PositionX - 1 >= 0)
                    {
                        yield return pParcours.Cases[PositionY][PositionX - 1];
                    }

                }
                if (TypeCase == TypeDeCase.AntiMiroir || TypeCase == TypeDeCase.DiviseurHorizontal)
                {
                    if (PositionX + 1 < pParcours.Largeur)
                    {
                        yield return pParcours.Cases[PositionY][PositionX + 1];
                    }
                }
            }
            else if ((EstAuDepart && EnergiseSud) || (pYPrecedent >= 0 && pYPrecedent > PositionY))
            {
                //Rayon viens du Sud
                if (EstAuDepart == false && EnergiseSud)
                {
                    yield break;
                }

                EnergiseSud = true;

                if (TypeCase == TypeDeCase.Vide || TypeCase == TypeDeCase.DiviseurVertical)
                {
                    if (PositionY - 1 >= 0)
                    {
                        yield return pParcours.Cases[PositionY - 1][PositionX];
                    }
                }
                if (TypeCase == TypeDeCase.Miroir || TypeCase == TypeDeCase.DiviseurHorizontal)
                {
                    if (PositionX + 1 < pParcours.Largeur)
                    {
                        yield return pParcours.Cases[PositionY][PositionX + 1];
                    }

                }
                if (TypeCase == TypeDeCase.AntiMiroir || TypeCase == TypeDeCase.DiviseurHorizontal)
                {
                    if (PositionX - 1 >= 0)
                    {
                        yield return pParcours.Cases[PositionY][PositionX - 1];
                    }

                }
            }
        }

        public override string ToString()
        {
            int lNombre = 0;
            lNombre += EnergiseNord ? 1 : 0;
            lNombre += EnergiseSud ? 1 : 0;
            lNombre += EnergiseEst ? 1 : 0;
            lNombre += EnergiseOuest ? 1 : 0;

            if(lNombre > 0)
            {
                return lNombre.ToString();
            }

            return EnumHelper.DonneDescription(TypeCase);
        }
    }
}
