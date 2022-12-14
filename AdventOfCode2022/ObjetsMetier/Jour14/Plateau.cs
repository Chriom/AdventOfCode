using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour14
{
    internal class Plateau
    {
        private List<CoordonneesRocher> _CoordonneesRochers;

        private Materiel[][] _Plateau;

        private int _Gauche;
        private int _Droite;
        private int _Haut;
        private int _Bas;

        private const int _MARGE = 10;

        public Plateau(List<CoordonneesRocher> pCoordonneesRochers)
        {
            _CoordonneesRochers = pCoordonneesRochers;

            _ExtraireInformations();
        }


        private void _ExtraireInformations()
        {
            //Récupèration des max
            List<Coordonnees> lToutesLesCoordonnees = _CoordonneesRochers.SelectMany(o => o.DonneCoordonnees())
                                                                .ToList();

            _Gauche = lToutesLesCoordonnees.MinBy(o => o.Horizontale).Horizontale;
            _Droite = lToutesLesCoordonnees.MaxBy(o => o.Horizontale).Horizontale;
            _Haut = lToutesLesCoordonnees.MinBy(o => o.Verticale).Verticale;
            _Bas = lToutesLesCoordonnees.MaxBy(o => o.Verticale).Verticale;

            //Création du plateau
            _Plateau = new Materiel[_Bas + _MARGE][];

            for(int lIndex = 0; lIndex < _Bas + _MARGE; lIndex++)
            {
                _Plateau[lIndex] = new Materiel[_Droite + _Droite];
            }


            //Remplissage des rochers
            foreach(CoordonneesRocher lRochers in _CoordonneesRochers)
            {
                List<Coordonnees> lCoordonnees = lRochers.DonneCoordonnees();

                for(int lIndex = 0; lIndex < lCoordonnees.Count - 1; lIndex++)
                {
                    Coordonnees lDepart = lCoordonnees[lIndex];
                    Coordonnees lArrive = lCoordonnees[lIndex + 1];

                    if(lDepart.Horizontale == lArrive.Horizontale)
                    {
                        int lPositionDepart = lDepart.Verticale < lArrive.Verticale ? lDepart.Verticale : lArrive.Verticale;
                        int lPositionArrive = lDepart.Verticale < lArrive.Verticale ? lArrive.Verticale : lDepart.Verticale;

                        for (int lIndexRocher = lPositionDepart; lIndexRocher <= lPositionArrive; lIndexRocher++)
                        {
                            _Plateau[lIndexRocher][lDepart.Horizontale] = Materiel.Rocher;
                        }
                    }
                    else
                    {
                        int lPositionDepart = lDepart.Horizontale < lArrive.Horizontale ? lDepart.Horizontale : lArrive.Horizontale;
                        int lPositionArrive = lDepart.Horizontale < lArrive.Horizontale ? lArrive.Horizontale : lDepart.Horizontale;

                        for (int lIndexRocher = lPositionDepart; lIndexRocher <= lPositionArrive; lIndexRocher++)
                        {
                            _Plateau[lDepart.Verticale][lIndexRocher] = Materiel.Rocher;
                        }
                    }
                }
            }


        }

        private const int _HORIZONTALE_EMETTEUR = 500;
        private const int _VERTICALE_EMETTEUR = 0;

        public int DonneNombreDeGrainsSurLePlateau()
        {
            int lNombreGrain = 1;
            int lHorizontaleSable = _HORIZONTALE_EMETTEUR;
            int lVerticaleSable = _VERTICALE_EMETTEUR;


            do
            {
                //_Dessiner();
                if (_Plateau[lVerticaleSable + 1][lHorizontaleSable] == Materiel.Vide)
                {
                    //Le sable tombe tout droit
                    lVerticaleSable++;
                }
                else if (_Plateau[lVerticaleSable + 1][lHorizontaleSable - 1] == Materiel.Vide)
                {
                    lHorizontaleSable--;
                    lVerticaleSable++;
                }
                else if(_Plateau[lVerticaleSable + 1][lHorizontaleSable + 1] == Materiel.Vide)
                {
                    lHorizontaleSable++;
                    lVerticaleSable++;
                }
                else
                {
                    _Plateau[lVerticaleSable][lHorizontaleSable ] = Materiel.Sable;

                    lNombreGrain++;
                    lHorizontaleSable = _HORIZONTALE_EMETTEUR;
                    lVerticaleSable = _VERTICALE_EMETTEUR;
                }




            } while (_Plateau[_VERTICALE_EMETTEUR][_HORIZONTALE_EMETTEUR] != Materiel.Sable && lVerticaleSable <= _Bas);

            //On décrémente le dernier lancé
            lNombreGrain--;

            return lNombreGrain;
        }

        public void AjouterSol()
        {
            _Bas = _Bas + 2;


            for(int lIndex = 0; lIndex < _Droite + _Droite; lIndex++)
            {
                _Plateau[_Bas][lIndex] = Materiel.Rocher;
            }
        }

        private void _Dessiner()
        {
            List<string> lListe = new List<string>();

            for(int lIndex = 0; lIndex < _Bas + _MARGE; lIndex++)
            {
                lListe.Add(string.Join("", _Plateau[lIndex].Skip(_Gauche)
                                                           .Take(_Droite - _Gauche)
                                                           .Select(o =>
                                                                    {
                                                                        return o switch
                                                                        {
                                                                            Materiel.Rocher => "#",
                                                                            Materiel.Sable => "o",
                                                                            Materiel.Vide => ".",
                                                                            _ => throw new NotImplementedException(),
                                                                        };
                                                                    })));
            }


            Console.Clear();
            Console.Write(string.Join("\r\n", lListe));

            Thread.Sleep(10);
        }
    }
}
