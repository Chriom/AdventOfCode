using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;

namespace AdventOfCode.ObjetsMetier.A2024.Jour10
{
    public class CaseCarte : ElementBFS<CaseCarte>, IElementBFS
    {
        public int HauteurCase;

        public override bool EstAuDepart
        {
            get { return HauteurCase == 0; }
            set { return; }
        }

        public override bool EstALaFin => HauteurCase == 9;

        public override IEnumerable<CaseCarte> DonneElementsAccessible(ParcoursBFS<CaseCarte> pParcours, int pXPrecedent, int pYPrecedent)
        {
            int lHauteurSuivant = HauteurCase + 1;
            if (PositionX > 0 && pParcours.Cases[PositionY][PositionX - 1].HauteurCase == lHauteurSuivant)
            {
                yield return pParcours.Cases[PositionY][PositionX - 1];
            }

            if(PositionX < pParcours.Largeur - 1 && pParcours.Cases[PositionY][PositionX + 1].HauteurCase == lHauteurSuivant)
            {
                yield return pParcours.Cases[PositionY][PositionX + 1];
            }

            if(PositionY > 0 && pParcours.Cases[PositionY - 1][PositionX].HauteurCase == lHauteurSuivant)
            {
                yield return pParcours.Cases[PositionY - 1][PositionX];
            }

            if(PositionY <  pParcours.Hauteur - 1 && pParcours.Cases[PositionY + 1][PositionX].HauteurCase == lHauteurSuivant)
            {
                yield return pParcours.Cases[PositionY + 1][PositionX];
            }
        }

        public override bool EstVisitee => HauteurCase == 9; //Seul la fin
    }
}
