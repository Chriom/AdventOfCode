using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.ObjetsMetier.A2023.Jour21
{
    public class SimulateurJardin
    {
        private int _Hauteur;
        private int _Largeur;

        private CarteJardin _Carte;

        public SimulateurJardin(CarteJardin pCarte)
        {
            _Carte = pCarte;

            _Hauteur = _Carte.Hauteur;
            _Largeur = _Carte.Largeur;
        }

        public int DonneNombreDePotagerApresNombreEtape(int pNombreEtape)
        {
            //Dictionary<int, CarteJardin> lDicoEtapes = new Dictionary<int, CarteJardin>();

            CarteJardin lCarte = _Carte;
            bool lCarteSuivanteEtendu = false;
            for(int lNumero = 0; lNumero < pNombreEtape; lNumero++)
            {
                //lDicoEtapes.Add(lNumero, lCarte);

                //Copie pour avoir la version n+1 vide
                CarteJardin lCarteSuivante = lCarte.CopierSansLesPotagers(lCarteSuivanteEtendu);
                lCarteSuivanteEtendu = false;

                //Parcours des cases
                for (int lLigne = 0; lLigne < lCarte.Hauteur; lLigne++)
                {
                    for (int lColonne = 0; lColonne < lCarte.Largeur; lColonne++)
                    {
                        if(lCarte.Jardin[lLigne][lColonne] == TypeCase.Potager || lCarte.Jardin[lLigne][lColonne] == TypeCase.Depart)
                        {
                            int lLigneReelle = lLigne;
                            int lColonneReelle = lColonne;

                            if(lCarte.Largeur != lCarteSuivante.Largeur)
                            {
                                //ça à grandi, il faut taper au milieu
                                lLigneReelle = lLigne + lCarte.Hauteur;
                                lColonneReelle = lColonne + lCarte.Largeur;
                            }


                            //parcours des cellules
                            if (lCarteSuivante.Jardin[lLigneReelle - 1][lColonneReelle] != TypeCase.Pierre)
                            {
                                lCarteSuivante.Jardin[lLigneReelle - 1][lColonneReelle] = TypeCase.Potager;
                            }
                            if(lCarteSuivante.Jardin[lLigneReelle + 1][lColonneReelle] != TypeCase.Pierre)
                            {
                                lCarteSuivante.Jardin[lLigneReelle + 1][lColonneReelle] = TypeCase.Potager;
                            }

                            if(lCarteSuivante.Jardin[lLigneReelle][lColonneReelle - 1] != TypeCase.Pierre)
                            {
                                lCarteSuivante.Jardin[lLigneReelle][lColonneReelle - 1] = TypeCase.Potager;
                            }
                            if (lCarteSuivante.Jardin[lLigneReelle][lColonneReelle + 1] != TypeCase.Pierre)
                            {
                                lCarteSuivante.Jardin[lLigneReelle][lColonneReelle + 1] = TypeCase.Potager;
                            }

                            if(lLigne - 1 == 0 || lLigne - 1 == lCarte.Hauteur || lColonne - 1 == 0 || lColonne + 1 == lCarte.Largeur)
                            {
                                //On touche le bout, il faut étendre la carte
                                lCarteSuivanteEtendu = true;
                            }
                        }                     

                    }
                }



                //Debug des potagers sur la carte
                int lNombreCases = lCarteSuivante.Jardin.SelectMany(o => o).Count(o => o == TypeCase.Depart || o == TypeCase.Potager);
                Console.WriteLine($"Etape numéro : {lNumero} => {lNombreCases}");

                if(pNombreEtape > 1000 && EntreesHelper.EstEnmodeTest == false)
                {
                    System.IO.File.AppendAllText(@"D:\Debug\2023_21.txt", $"{lNumero}\t\t\t{lCarteSuivante.Largeur}\t\t\t{lNombreCases}\n");
                }
                else
                {
                    if(lNombreCases < 10 || lNombreCases % 10 == 0)
                    {
                        lCarteSuivante.Dessiner();
                    }
                    
                }
                 
                
                lCarte = lCarteSuivante;
            }

            return lCarte.Jardin.SelectMany(o => o).Count(o => o == TypeCase.Depart || o == TypeCase.Potager);
        }
    }
}
