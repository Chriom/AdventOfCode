using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour06
{
    public class CartePatrouille
    {
        TypeCase[,] _Carte;
        bool[,] _CaseParcourus;

        private int _Largeur;
        private int _Hauteur;

        private Direction _Direction = Direction.Nord;
        private int _XGarde;
        private int _YGarde;

        public CartePatrouille(List<string> pLignes)
        {
            _ExtraireCarte(pLignes);
        }

        public CartePatrouille(TypeCase[,] pCarte)
        {
            _Carte = pCarte;
            _Hauteur = pCarte.GetLength(0);
            _Largeur = pCarte.GetLength(1);

            _CaseParcourus = new bool[_Hauteur, _Largeur];

            _TrouverGarde();
        }

        private void _ExtraireCarte(List<string> pLignes)
        {
            _Largeur = pLignes.First().Length;
            _Hauteur = pLignes.Count;

            _Carte = new TypeCase[_Hauteur, _Largeur];
            _CaseParcourus = new bool[_Hauteur, _Largeur];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                string lLigne = pLignes[lIndexLigne];

                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    _Carte[lIndexLigne, lIndexColonne] = lLigne[lIndexColonne] switch
                    {
                        '.' => TypeCase.Vide,
                        '#' => TypeCase.Bloquant,
                        '^' => TypeCase.Garde,
                        _ => throw new NotImplementedException(),
                    };

                    if(lLigne[lIndexColonne] == '^')
                    {
                        _XGarde = lIndexColonne;
                        _YGarde = lIndexLigne;
                    }
                }
            }
        }

        private void _TrouverGarde()
        {
            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    if (_Carte[lIndexLigne, lIndexColonne] == TypeCase.Garde)
                    {
                        _XGarde = lIndexColonne;
                        _YGarde = lIndexLigne;
                        return;
                    }
                }
            }
        }

        public int ParcourirCarteComplete()
        {
            do
            {
                (int lNouveauX, int lNouveauY) = _DonnePositionSuivante();

                if ((lNouveauX >= 0 && lNouveauY >= 0 && lNouveauX < _Largeur && lNouveauY < _Hauteur))
                {
                    if (_Carte[lNouveauY, lNouveauX] == TypeCase.Bloquant)
                    {
                        //Si ça bloque => on tourne
                        _Direction = (Direction)(((int)_Direction + 1) % 4);
                        continue;
                    }
                }

                _CaseParcourus[_YGarde, _XGarde] = true;
                _XGarde = lNouveauX;
                _YGarde = lNouveauY;


            } while (_XGarde >= 0 && _YGarde >= 0 && _XGarde < _Largeur && _YGarde < _Hauteur);


            return _CaseParcourus.Cast<bool>()
                                 .Count(o => o);
        }

        private (int X, int Y) _DonnePositionSuivante()
        {
            return _Direction switch
            {
                Direction.Nord => (_XGarde, _YGarde - 1),
                Direction.Est => (_XGarde + 1, _YGarde),
                Direction.Sud => (_XGarde, _YGarde + 1),
                Direction.Ouest => (_XGarde - 1, _YGarde),
                _ => throw new NotImplementedException(),
            };
        }


        public int DonneNombreDePositionsBloquante()
        {
            //Parcours de la carte
            ParcourirCarteComplete();

            //Création de copie bloquante
            List<Task<bool>> lThreads = new List<Task<bool>>();

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    if (_CaseParcourus[lIndexLigne, lIndexColonne] == true)
                    {
                        TypeCase[,] lCaseNouvelle = _CopierCases();
                        lCaseNouvelle[lIndexLigne, lIndexColonne] = TypeCase.Bloquant;

                        CartePatrouille lCarteNouvelle = new CartePatrouille(lCaseNouvelle);

                        lThreads.Add(Task.Run(() => lCarteNouvelle._DeterminerSiGardeBoucle()));
                    }
                }
            }


            //Attente
            Task.WaitAll(lThreads.ToArray());

            return lThreads.Count(o => o.Result);
        }

        private TypeCase[,] _CopierCases()
        {
            TypeCase[,] lCopie = new TypeCase[_Hauteur, _Largeur];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lCopie[lIndexLigne, lIndexColonne] = _Carte[lIndexLigne, lIndexColonne];
                }
            }

            return lCopie;
        }

        private bool _DeterminerSiGardeBoucle()
        {
            HashSet<string> lParcouru = new HashSet<string>();

            do
            {
                (int lNouveauX, int lNouveauY) = _DonnePositionSuivante();

                if ((lNouveauX >= 0 && lNouveauY >= 0 && lNouveauX < _Largeur && lNouveauY < _Hauteur))
                {
                    if (_Carte[lNouveauY, lNouveauX] == TypeCase.Bloquant)
                    {
                        //Si ça bloque => on tourne
                        _Direction = (Direction)(((int)_Direction + 1) % 4);
                        continue;
                    }
                }

                if(lParcouru.Add($"{_XGarde}-{_YGarde}-{_Direction}") == false)
                {
                    return true;
                }

                _XGarde = lNouveauX;
                _YGarde = lNouveauY;


            } while (_XGarde >= 0 && _YGarde >= 0 && _XGarde < _Largeur && _YGarde < _Hauteur);


            return false;
        }
    }
}
