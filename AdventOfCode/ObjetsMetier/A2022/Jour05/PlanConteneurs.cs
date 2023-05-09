using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour05
{
    public class PlanConteneurs
    {
        private Dictionary<int, PileConteneur> _PileConteneurs;

        public int NombrePiles => _PileConteneurs.Count;

        public PlanConteneurs(List<PileConteneur> pPilesDeConteneurs)
        {
            _PileConteneurs = pPilesDeConteneurs.ToDictionary(o => o.NumeroPile, o => o);
        }

        public void DeplacerContaineurPourGrue9000(Instruction pInstruction)
        {
            PileConteneur lDepart = _PileConteneurs[pInstruction.PileDepart];
            PileConteneur lFin = _PileConteneurs[pInstruction.PileArrivee];

            for (int lIndex = 0; lIndex < pInstruction.NombreConteneurs; lIndex++)
            {
                char lConteneur = lDepart.RetirerDeLaPile();
                lFin.AjouterSurLaPile(lConteneur);
            }
        }

        public void DeplacerContaineurPourGrue9001(Instruction pInstruction)
        {
            PileConteneur lDepart = _PileConteneurs[pInstruction.PileDepart];
            PileConteneur lFin = _PileConteneurs[pInstruction.PileArrivee];

            Stack<char> lPile = new Stack<char>();

            for (int lIndex = 0; lIndex < pInstruction.NombreConteneurs; lIndex++)
            {
                lPile.Push(lDepart.RetirerDeLaPile());

            }

            for (int lIndex = 0; lIndex < pInstruction.NombreConteneurs; lIndex++)
            {
                lFin.AjouterSurLaPile(lPile.Pop());
            }

        }

        public string DonneConteneursDuHaut()
        {
            StringBuilder lSb = new StringBuilder();
            for (int lIndex = 1; lIndex <= NombrePiles; lIndex++)
            {
                PileConteneur lPile = _PileConteneurs[lIndex];
                lSb.Append(lPile.RetirerDeLaPile());
            }

            return lSb.ToString();
        }
    }
}
