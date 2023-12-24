using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Algorithme.BreadthFirstSearch;

namespace AdventOfCode.ObjetsMetier.A2023.Jour10
{
    public class CaseLabyrinthe : ElementBFS<CaseLabyrinthe>, IElementBFS
    {
        public TypeTuyau TypeCase { get; set; }

        public override bool EstAuDepart
        {
            get { return TypeCase == TypeTuyau.Depart; }
            set { TypeCase = TypeTuyau.Depart; }
        }
        

        public override bool EstALaFin => false;

        public CaseLabyrinthe(TypeTuyau pTypeCase, int pPositionX, int pPositionY)
        {
            TypeCase = pTypeCase;
            PositionX = pPositionX;
            PositionY = pPositionY;
        }

        public override IEnumerable<CaseLabyrinthe> DonneElementsAccessible(ParcoursBFS<CaseLabyrinthe> pParcours, int pXPrecedent, int pYPrecedent)
        {
            if (TypeCase == TypeTuyau.Depart ||
                TypeCase == TypeTuyau.NordEtSud ||
                TypeCase == TypeTuyau.NordEtEst ||
                TypeCase == TypeTuyau.NordEtOuest)
            {
                //Haut
                CaseLabyrinthe lHaut = _HautPossible(pParcours);

                if(lHaut != null)
                {
                    yield return lHaut;
                }
            }

            if(TypeCase == TypeTuyau.Depart ||
               TypeCase == TypeTuyau.NordEtSud ||
               TypeCase == TypeTuyau.SudEtEst ||
               TypeCase == TypeTuyau.SudEtOuest)
            {
                //Bas
                CaseLabyrinthe lBas = _BasPossible(pParcours);

                if (lBas != null)
                {
                    yield return lBas;
                }
            }

            if (TypeCase == TypeTuyau.Depart ||
                TypeCase == TypeTuyau.EstEtOuest ||
                TypeCase == TypeTuyau.NordEtOuest ||
               TypeCase == TypeTuyau.SudEtOuest)
            {
                //Gauche
                CaseLabyrinthe lGauche = _GauchePossible(pParcours);

                if (lGauche != null)
                {
                    yield return lGauche;
                }
            }

            if (TypeCase == TypeTuyau.Depart ||
                TypeCase == TypeTuyau.EstEtOuest ||
                TypeCase == TypeTuyau.NordEtEst ||
                TypeCase == TypeTuyau.SudEtEst)
            {
                //Droite
                CaseLabyrinthe lDroite = _DroitePossible(pParcours);

                if (lDroite != null)
                {
                    yield return lDroite;
                }
            }
        }

        private CaseLabyrinthe _HautPossible(ParcoursBFS<CaseLabyrinthe> pParcours)
        {
            if (PositionY > 0)
            {
                //Haut
                TypeTuyau lHaut = pParcours.Cases[PositionY - 1][PositionX].TypeCase;
                if (lHaut == TypeTuyau.NordEtSud || lHaut == TypeTuyau.SudEtEst || lHaut == TypeTuyau.SudEtOuest || lHaut == TypeTuyau.Depart)
                {
                    return pParcours.Cases[PositionY - 1][PositionX];
                }
            }

            return null;
        }

        private CaseLabyrinthe _BasPossible(ParcoursBFS<CaseLabyrinthe> pParcours)
        {
            if (PositionY < pParcours.Hauteur - 1)
            {
                //Bas
                TypeTuyau lBas = pParcours.Cases[PositionY + 1][PositionX].TypeCase;
                if (lBas == TypeTuyau.NordEtSud || lBas == TypeTuyau.NordEtEst || lBas == TypeTuyau.NordEtOuest || lBas == TypeTuyau.Depart)
                {
                    return pParcours.Cases[PositionY + 1][PositionX];
                }
            }

            return null;
        }

        private CaseLabyrinthe _GauchePossible(ParcoursBFS<CaseLabyrinthe> pParcours)
        {
            if (PositionX > 0)
            {
                //Gauche
                TypeTuyau lGauche = pParcours.Cases[PositionY][PositionX - 1].TypeCase;
                if (lGauche == TypeTuyau.EstEtOuest || lGauche == TypeTuyau.NordEtEst || lGauche == TypeTuyau.SudEtEst || lGauche == TypeTuyau.Depart)
                {
                    return pParcours.Cases[PositionY][PositionX - 1];
                }
            }

            return null;
        }

        private CaseLabyrinthe _DroitePossible(ParcoursBFS<CaseLabyrinthe> pParcours)
        {
            if (PositionX < pParcours.Largeur - 1)
            {
                //Droite
                TypeTuyau lDroite = pParcours.Cases[PositionY][PositionX + 1].TypeCase;
                if (lDroite == TypeTuyau.EstEtOuest || lDroite == TypeTuyau.NordEtOuest || lDroite == TypeTuyau.SudEtOuest || lDroite == TypeTuyau.Depart)
                {
                    return pParcours.Cases[PositionY][PositionX + 1];
                }
            }

            return null;
        }

        public override string ToString()
        {
            return TypeCase switch
            {
                TypeTuyau.Depart => "S",
                TypeTuyau.NordEtSud => "║",
                TypeTuyau.EstEtOuest => "═",
                TypeTuyau.SudEtEst => "╔",
                TypeTuyau.SudEtOuest => "╗",
                TypeTuyau.NordEtEst => "╚",
                TypeTuyau.NordEtOuest => "╝",
                TypeTuyau.Exterieur => "¤",
                TypeTuyau.Interieur => "■",
                TypeTuyau.Sol => " ",
                _ => throw new Exception("Indéfini")
            }; ;
        }
    }
}
