using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour14
{
    public class DeplaceurDeRobots
    {
        private List<Robot> _Robots;

        private int _Largeur;
        private int _Hauteur;

        private int _NumeroPas = 0;

        public DeplaceurDeRobots(List<Robot> pRobots)
        {
            _Robots = pRobots;

            _Largeur = pRobots.Max(o => o.Position.X) + 1;
            _Hauteur = pRobots.Max(o => o.Position.Y) + 1;

        }

        public void DeplacerTousLesRobots(int pNombreDePas, bool pDessinerCarte = false)
        {
            for (int lPas = 0; lPas < pNombreDePas; lPas++)
            {
                _NumeroPas++;
                foreach (Robot lRobot in _Robots)
                {
                    lRobot.Deplacer(_Largeur, _Hauteur);
                }

                _DessinerCarte();
            }
        }

        public int DonneFacteurDeSecurite()
        {
            int lLargeurCadrant = _Largeur / 2 - 1;
            int lHauteurCadrant = _Hauteur / 2 - 1;

            int lHautGauche = _DonneNombreDeRobotsDansCadrant(0, lLargeurCadrant, 0, lHauteurCadrant);
            int lHautDroit = _DonneNombreDeRobotsDansCadrant(_Largeur - lLargeurCadrant - 1, _Largeur, 0, lHauteurCadrant);

            int lBasGauche = _DonneNombreDeRobotsDansCadrant(0, lLargeurCadrant, _Hauteur - lHauteurCadrant -1 , _Hauteur);
            int lBasDroit = _DonneNombreDeRobotsDansCadrant(_Largeur - lLargeurCadrant - 1, _Largeur, _Hauteur - lHauteurCadrant - 1, _Hauteur);

            return lHautGauche * lHautDroit * lBasGauche * lBasDroit;
        }

        private int _DonneNombreDeRobotsDansCadrant(int pXMin, int pXMax, int pYMin, int pYMax)
        {
            return _Robots.Count(o => o.Position.X >= pXMin && o.Position.X <= pXMax && o.Position.Y >= pYMin && o.Position.Y <= pYMax);
        }


        const string _DOSSIER = @"C:/Temp/Arbre";
        private void _DessinerCarte()
        {
            int[,] lCarte = new int[_Hauteur, _Largeur];

            string lFichier = System.IO.Path.Combine(_DOSSIER, $"Carte_{_NumeroPas}.bmp");

            foreach (Robot lRobot in _Robots)
            {
                lCarte[lRobot.Position.Y, lRobot.Position.X]++;
            }
            
            using(Bitmap lBitmap = new Bitmap(_Largeur, _Hauteur))
            {
                for (int lLigne = 0; lLigne < _Hauteur; lLigne++)
                {
                    for (int lColonne = 0; lColonne < _Largeur; lColonne++)
                    {
                        if(lCarte[lLigne, lColonne] >= 1)
                        {
                            lBitmap.SetPixel(lColonne, lLigne, Color.Black);
                        }
                        else
                        {
                            lBitmap.SetPixel(lColonne, lLigne, Color.White);
                        }
                    }
                }

                lBitmap.Save(lFichier, System.Drawing.Imaging.ImageFormat.Bmp);
            }


        }
    }
}
