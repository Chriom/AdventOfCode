using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour15
{
    [DebuggerDisplay("C : {Capteur} - B : {BaliseLaPlusProche}")]
    public class Capteurs
    {
        public Position Capteur { get; init; }
        public Position BaliseLaPlusProche { get; init; }

        public Capteurs(Position pPositionCapteur, Position pPositionPlusProcheBalise)
        {
            Capteur = pPositionCapteur;
            BaliseLaPlusProche = pPositionPlusProcheBalise;
        }

        public PlageValeur DonnePlagePorterDeBalisePourLaLigne(decimal pNumeroLigne)
        {

            decimal lDistance = Capteur.DonneDistanceDeManhattan(BaliseLaPlusProche);

            if (Capteur.Y <= pNumeroLigne && Capteur.Y + lDistance >= pNumeroLigne)
            {
                //Vers le bas
                decimal lDifferenceParRapportAuBord = Capteur.Y + lDistance - pNumeroLigne;
                return new PlageValeur(Capteur.X - lDifferenceParRapportAuBord, Capteur.X + lDifferenceParRapportAuBord);

            }
            else if (Capteur.Y >= pNumeroLigne && Capteur.Y - lDistance <= pNumeroLigne)
            {
                //Vers le haut
                decimal lDifferenceParRapportAuBord = pNumeroLigne + lDistance - Capteur.Y;
                return new PlageValeur(Capteur.X - lDifferenceParRapportAuBord, Capteur.X + lDifferenceParRapportAuBord);
            }

            return null;
        }
    }
}
