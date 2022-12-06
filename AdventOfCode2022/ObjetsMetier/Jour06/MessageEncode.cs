using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour06
{
    public class MessageEncode
    {
        private string _ChaineEncode;

        private const int _NOMBRE_CARACTERES_MARQUEUR_PAQUET = 4;
        private const int _NOMBRE_CARACTERES_MARQUEUR_MESSAGE = 14;

        public MessageEncode(string pChaineEncode)
        {
            _ChaineEncode = pChaineEncode;
        }

        public int DonnePositionPremierMarqueurPaquet()
        {
            return DonnePositionMarqueurSuivant(0, _NOMBRE_CARACTERES_MARQUEUR_PAQUET);
        }

        public int DonnePositionPremierMarqueurMessage()
        {
            return DonnePositionMarqueurSuivant(0, _NOMBRE_CARACTERES_MARQUEUR_MESSAGE);
        }

        private int DonnePositionMarqueurSuivant(int pPositionDebut, int pTailleMarqueur)
        {
            if(pPositionDebut + pTailleMarqueur > _ChaineEncode.Length)
            {
                throw new Exception($"La position initiale est trop importante");
            }

            if(pPositionDebut < 0 || pPositionDebut > (_ChaineEncode.Length - pTailleMarqueur)){
                throw new Exception("Position incorrecte");
            }

            //Pas de quatre
            for(int lIndex = pPositionDebut; lIndex < _ChaineEncode.Length - pTailleMarqueur; lIndex++ )
            {
                HashSet<char> lHash = new HashSet<char>();
                bool lResultat = true;
                
                for(int lPositionCharTest = 0; lPositionCharTest < pTailleMarqueur; lPositionCharTest++)
                {
                    lResultat = lResultat && lHash.Add(_ChaineEncode[lIndex + lPositionCharTest]);
                }
                
                //true si les charactères sont ajoutés
                if (lResultat)
                {
                    //Dernier caractère de la chaîne
                    return lIndex + pTailleMarqueur;
                }

            }

            throw new Exception("Impossible de trouver le marqueur");
        }
    }
}
