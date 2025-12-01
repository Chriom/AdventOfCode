using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2024.Jour16
{
    public class LabyrintheHistorique
    {

        public bool[,] Parcouru { get; set; }

        private int _Hauteur;
        private int _Largeur;

        public Position2D PositionCourante { get; set; }

        public Direction DirectionCourante { get; set; }

        public int ScoreCourant { get; set; }

        public string CleCreation { get; set; }

        public LabyrintheHistorique(int pHauteur, int pLargeur)
        {
            _Hauteur = pHauteur;
            _Largeur = pLargeur;

            Parcouru = new bool[_Hauteur, _Largeur];
        }

        public LabyrintheHistorique CopieInstance()
        {
            LabyrintheHistorique lInstance = new LabyrintheHistorique(_Hauteur, _Largeur);
            lInstance.PositionCourante = new Position2D(PositionCourante.X, PositionCourante.Y);
            lInstance.DirectionCourante = DirectionCourante;
            lInstance.ScoreCourant = ScoreCourant;

            for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lInstance.Parcouru[lIndexLigne, lIndexColonne] = Parcouru[lIndexLigne, lIndexColonne];
                }
            }

            return lInstance;
        }
    }
}
