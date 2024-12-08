using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2024.Jour08
{
    public class CarteAntennes
    {
        public CarteAntennes(List<string> pCarte)
        {
            _ExtraireInformations(pCarte);
        }

        private int _Largeur;
        private int _Hauteur;
        private char[,] _Carte;

        private Dictionary<char, List<Position2D>> _PositionAntennes = new Dictionary<char, List<Position2D>>();

        private HashSet<string> _PositionsAntinode = new HashSet<string>();

        private void _ExtraireInformations(List<string> pCarte)
        {
            _Hauteur = pCarte.Count;
            _Largeur = pCarte[0].Length;
            _Carte = new char[_Hauteur, _Largeur];

            for (int lLigne = 0; lLigne < _Hauteur; lLigne++)
            {
                for (int lColonne = 0; lColonne < _Largeur; lColonne++)
                {
                    char lCaractere = pCarte[lLigne][lColonne];
                    _Carte[lLigne, lColonne] = lCaractere;


                    if (lCaractere != '.')
                    {
                        if (_PositionAntennes.ContainsKey(lCaractere) == false)
                        {
                            _PositionAntennes[lCaractere] = new List<Position2D>();
                        }
                        _PositionAntennes[lCaractere].Add(new Position2D(lColonne, lLigne));
                    }
                }
            }
        }


        public int DonneNombreAntinodes()
        {
            foreach (var lAntennes in _PositionAntennes)
            {
                char lFrequence = lAntennes.Key;
                List<Position2D> lPositionsAntennes = lAntennes.Value;

                if (lPositionsAntennes.Count > 1)
                {
                    for (int lIndexAntenne1 = 0; lIndexAntenne1 < lPositionsAntennes.Count - 1; lIndexAntenne1++)
                    {
                        for (int lIndexAntenne2 = lIndexAntenne1 + 1; lIndexAntenne2 < lPositionsAntennes.Count; lIndexAntenne2++)
                        {
                            Position2D lPosition1 = lPositionsAntennes[lIndexAntenne1];
                            Position2D lPosition2 = lPositionsAntennes[lIndexAntenne2];

                            Position2D lDelta = new Position2D(lPosition1.X - lPosition2.X, lPosition1.Y - lPosition2.Y);

                            Position2D lPositionAntinode1 = new Position2D(lPosition1.X + lDelta.X, lPosition1.Y + lDelta.Y);
                            Position2D lPositionAntinode2 = new Position2D(lPosition1.X - lDelta.X, lPosition1.Y - lDelta.Y);

                            Position2D lPositionAntinode3 = new Position2D(lPosition2.X + lDelta.X, lPosition2.Y + lDelta.Y);
                            Position2D lPositionAntinode4 = new Position2D(lPosition2.X - lDelta.X, lPosition2.Y - lDelta.Y);

                            if (lPositionAntinode1.X != lPosition2.X && lPositionAntinode1.Y != lPosition2.Y)
                            {
                                if (lPositionAntinode1.X >= 0 && lPositionAntinode1.X < _Largeur && lPositionAntinode1.Y >= 0 && lPositionAntinode1.Y < _Hauteur)
                                {
                                    _PositionsAntinode.Add($"{lPositionAntinode1.X}_{lPositionAntinode1.Y}");
                                }
                            }
                            if (lPositionAntinode2.X != lPosition2.X && lPositionAntinode2.Y != lPosition2.Y)
                            {
                                if (lPositionAntinode2.X >= 0 && lPositionAntinode2.X < _Largeur && lPositionAntinode2.Y >= 0 && lPositionAntinode2.Y < _Hauteur)
                                {
                                    _PositionsAntinode.Add($"{lPositionAntinode2.X}_{lPositionAntinode2.Y}");
                                }
                            }

                            if (lPositionAntinode3.X != lPosition1.X && lPositionAntinode3.Y != lPosition1.Y)
                            {
                                if (lPositionAntinode3.X >= 0 && lPositionAntinode3.X < _Largeur && lPositionAntinode3.Y >= 0 && lPositionAntinode3.Y < _Hauteur)
                                {
                                    _PositionsAntinode.Add($"{lPositionAntinode3.X}_{lPositionAntinode3.Y}");
                                }
                            }
                            if (lPositionAntinode4.X != lPosition1.X && lPositionAntinode4.Y != lPosition1.Y)
                            {
                                if (lPositionAntinode4.X >= 0 && lPositionAntinode4.X < _Largeur && lPositionAntinode4.Y >= 0 && lPositionAntinode4.Y < _Hauteur)
                                {
                                    _PositionsAntinode.Add($"{lPositionAntinode4.X}_{lPositionAntinode4.Y}");
                                }
                            }
                        }
                    }
                }
            }


            return _PositionsAntinode.Count;
        }

        public int DonneNombreAntinodesAvecRepetition()
        {
            foreach (var lAntennes in _PositionAntennes)
            {
                char lFrequence = lAntennes.Key;
                List<Position2D> lPositionsAntennes = lAntennes.Value;

                if (lPositionsAntennes.Count > 1)
                {
                    for (int lIndexAntenne1 = 0; lIndexAntenne1 < lPositionsAntennes.Count - 1; lIndexAntenne1++)
                    {
                        for (int lIndexAntenne2 = lIndexAntenne1 + 1; lIndexAntenne2 < lPositionsAntennes.Count; lIndexAntenne2++)
                        {
                            Position2D lPosition1 = lPositionsAntennes[lIndexAntenne1];
                            Position2D lPosition2 = lPositionsAntennes[lIndexAntenne2];

                            Position2D lDelta = new Position2D(lPosition1.X - lPosition2.X, lPosition1.Y - lPosition2.Y);

                            
                            _AjouterAntinodesAvecRepetition(lPosition1, lDelta, lPosition2);
                            _AjouterAntinodesAvecRepetition(lPosition1, new Position2D(-lDelta.X, -lDelta.Y), lPosition2);
                            _AjouterAntinodesAvecRepetition(lPosition2, lDelta, lPosition1);
                            _AjouterAntinodesAvecRepetition(lPosition2, new Position2D(-lDelta.X, -lDelta.Y), lPosition1);
                        }
                    }

                    //Ajout des antennes qui ne sont pas unique
                    foreach(Position2D lPositionAntenne in lPositionsAntennes)
                    {
                        _PositionsAntinode.Add($"{lPositionAntenne.X}_{lPositionAntenne.Y}");
                    }
                }
            }
           
            return _PositionsAntinode.Count;
        }

        private void _AjouterAntinodesAvecRepetition(Position2D pPositionInitiale, Position2D pDelta, Position2D pPositionAutre)
        {
            Position2D lPositionAntinode = new Position2D(pPositionInitiale.X + pDelta.X, pPositionInitiale.Y + pDelta.Y);
            while (lPositionAntinode.X >= 0 && lPositionAntinode.X < _Largeur && lPositionAntinode.Y >= 0 && lPositionAntinode.Y < _Hauteur)
            {
                if (lPositionAntinode.X != pPositionAutre.X || lPositionAntinode.Y != pPositionAutre.Y)
                {
                    _PositionsAntinode.Add($"{lPositionAntinode.X}_{lPositionAntinode.Y}");
                }
                lPositionAntinode = new Position2D(lPositionAntinode.X + pDelta.X, lPositionAntinode.Y + pDelta.Y);
            }
        }
    }
}
