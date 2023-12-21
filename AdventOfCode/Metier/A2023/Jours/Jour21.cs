using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour21;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour21 : AJour<CarteJardin>
    {
        public override int NumeroJour => 21;

        public override int Annee => 2023;

        public override string DonneResultatUn()
        {
            CarteJardin lCarte = _Entrees.First();

            int lNombre = EntreesHelper.EstEnmodeTest ? 6 : 64;

            SimulateurJardin lSimulateur = new SimulateurJardin(lCarte);
            return lSimulateur.DonneNombreDePotagerApresNombreEtape(lNombre)
                              .ToString();
        }


        public int NombreEtapes { get; set; } = 26501365;

        public override string DonneResultatDeux()
        {
            const int NOMBRE_PAS = 26501365;
            int lNombreEtape = (NOMBRE_PAS - 65) / 131;


            decimal lTotal = 95175; //Total de l'étape 326 soit index 1 (quand on change de carte)
            int lNombreAugmentation = 30362; //Ajout sur ce qu'on ajoute à chaque étape
            decimal lNombreAjout = 60844; //Départ sur le 2

            int lEtape = 325;
            int lPasEtape = 131;

            //On part de l'index 2 comme on cherche les suivant
            //Donc nombre étape - 2
            lNombreEtape -= 2;

            for(int lIndex = 2; lIndex <= lNombreEtape +10000; lIndex++)
            {
                lNombreAjout += lNombreAugmentation;

                lTotal += lNombreAjout;
                lEtape += lPasEtape;
                if(lEtape >= NOMBRE_PAS - 132)
                {
                    Console.WriteLine($"{lIndex} --- {lTotal}");
                    Console.WriteLine($"{lEtape} --- {lTotal}");
                }
            }

            return lTotal.ToString();

            /*
            CarteJardin lCarte = _Entrees.First();

            SimulateurJardin lSimulateur = new SimulateurJardin(lCarte);
            return lSimulateur.DonneNombreDePotagerApresNombreEtape(NombreEtapes)
                              .ToString();
            */
        }


    }
}
