using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour02;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour02 : AJour<Instruction>
    {
        public override int NumeroJour => 2;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            PositionSousMarin lPosition = _DonnePosition(false);

            return (lPosition.Profondeur * lPosition.Horizontale).ToString();
        }

        public override string DonneResultatDeux()
        {
            PositionSousMarin lPosition = _DonnePosition(true);

            return (lPosition.Profondeur * lPosition.Horizontale).ToString();
        }

        private PositionSousMarin _DonnePosition(bool pAvecCiblage)
        {
            PositionSousMarin lPosition = new PositionSousMarin()
            {
                UtiliserCiblage = pAvecCiblage,
            };

            foreach (Instruction lInstruction in _Entrees)
            {
                switch (lInstruction.Mouvement)
                {
                    case Mouvement.Avancer:
                        lPosition.Avancer(lInstruction.Distance);
                        break;
                    case Mouvement.Monter:
                        lPosition.Monter(lInstruction.Distance);
                        break;
                    case Mouvement.Descendre:
                        lPosition.Descendre(lInstruction.Distance);
                        break;
                }
            }

            return lPosition;
        }
    }
}
