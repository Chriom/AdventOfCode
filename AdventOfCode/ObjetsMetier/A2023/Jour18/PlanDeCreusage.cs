using AdventOfCode.Commun.Algorithme.ShoeLace;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public class PlanDeCreusage
    {
        private List<Sequence> _SequenceCreusage;

        public PlanDeCreusage(IEnumerable<Sequence> pSequenceCreusage)
        {
            _SequenceCreusage = pSequenceCreusage.ToList();
        }


        public decimal DonneNombreDeCasesCreusees()
        {
            return _CalculerAireDeLaZone();
        }

        public decimal DonneNombreDeCasesCreuseesDepuisCouleur()
        {
            _MajSequence();
            return _CalculerAireDeLaZone();
        }


        private decimal _CalculerAireDeLaZone()
        {
            List<Point> lPoints = new List<Point>();

            decimal lPositionX = 0;
            decimal lPositionY = 0;

            //Position initiale
            lPoints.Add(new Point(lPositionX, lPositionY));

            foreach (Sequence lSequence in _SequenceCreusage)
            {
                Point lPoint = lSequence.Sens switch
                {
                    Sens.Droite => new Point(lPositionX + lSequence.NombreCases, lPositionY),
                    Sens.Gauche => new Point(lPositionX - lSequence.NombreCases, lPositionY),
                    Sens.Haut => new Point(lPositionX, lPositionY - lSequence.NombreCases),
                    Sens.Bas => new Point(lPositionX, lPositionY + lSequence.NombreCases),
                    _ => throw new NotImplementedException(),
                };

                lPoints.Add(lPoint);

                lPositionX = lPoint.X;
                lPositionY = lPoint.Y;
            }

            decimal lAire = ShoeLace.CalculerAire(lPoints);

            decimal lPerimetre = _SequenceCreusage.Sum(o => (decimal)o.NombreCases);

            //https://fr.wikipedia.org/wiki/Th%C3%A9or%C3%A8me_de_Pick
            //Le +1 est cadeau mais ça à l'air de marcher sur les exemples
            return lAire + lPerimetre / 2 + 1;

        }

        private void _MajSequence()
        {
            foreach (Sequence lSequence in _SequenceCreusage)
            {
                lSequence.Sens = lSequence.Couleur.Sens;
                lSequence.NombreCases = lSequence.Couleur.Mouvement;
            }
        }

    }
}
