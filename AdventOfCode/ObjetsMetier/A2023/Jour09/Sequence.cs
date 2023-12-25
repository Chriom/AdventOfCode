using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour09
{
    public class Sequence
    {
        private List<decimal> _Releves;

        public Sequence(List<decimal> pValeurs)
        {
            _Releves = pValeurs;
        }

        public decimal DonneProchaineValeur(bool pInverse = false)
        {
            List<List<decimal>> lChaineSequence = new List<List<decimal>>();

            lChaineSequence.Add(_Releves);

            List<decimal> lLigneEnCours = _Releves;
            List<decimal> lDerniereLigne;

            //Calcul du différentiel pour la ligne suivante
            do
            {
                lDerniereLigne = new List<decimal>();
                //Parcour de 2 en 2
                for(int lIndex = 0; lIndex < lLigneEnCours.Count - 1; lIndex++)
                {
                    decimal lValeur1 = lLigneEnCours[lIndex];
                    decimal lValeur2 = lLigneEnCours[lIndex + 1];

                    
                    lDerniereLigne.Add(lValeur2 - lValeur1);
                    
                }

                lChaineSequence.Add(lDerniereLigne);
                lLigneEnCours = lDerniereLigne;
            } while (lDerniereLigne.Any(o => o != 0));

            //Repart de la fin
            decimal lProchaineValeur = 0;

            for(int lIndex = lChaineSequence.Count - 2; lIndex >= 0; lIndex--)
            {
                

                if(pInverse == false)
                {
                    decimal lDernierListe = lChaineSequence[lIndex].Last();
                    lProchaineValeur += lDernierListe;
                }
                else
                {
                    decimal lPremierListe = lChaineSequence[lIndex].First();
                    lProchaineValeur = lPremierListe - lProchaineValeur;
                }
                
            }

            return lProchaineValeur;
        }
    }
}
