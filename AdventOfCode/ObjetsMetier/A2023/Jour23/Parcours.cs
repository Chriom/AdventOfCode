using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour23
{
    [DebuggerDisplay("{NombreDeCasesParcourus}")]
    public class Parcours
    {
        private int _Hauteur;
        private int _Largeur;

        private bool _PentesSontGlissante;
        public int NombreDeCasesParcourus { get; private set; }

        private TypeCase[][] _Carte;
        private bool[][] _Parcouru;

        public int Position_X { get; private set; }

        public int Position_Y { get; private set; }

        public Position2D PositionFinaleParent { get; private set; }

        public Parcours(TypeCase[][] pCarte, Position2D pDepart, bool pPentesSontGlissante)
        {
            _Carte = pCarte;
            _Hauteur = _Carte.Length;
            _Largeur = _Carte[0].Length;

            Position_X = pDepart.X;
            Position_Y = pDepart.Y;
            PositionFinaleParent = new Position2D(Position_X, Position_Y);

            _PentesSontGlissante = pPentesSontGlissante;

            _Initialiser();
        }

        private Parcours()
        {

        }

        public string ClePosition => $"{Position_X}|{Position_Y}";

        private void _Initialiser()
        {
            _Parcouru = new bool[_Hauteur][];

            for(int lIndex = 0; lIndex< _Hauteur; lIndex++)
            {
                _Parcouru[lIndex] = new bool[_Largeur];
            }

            _Parcouru[Position_Y][Position_X] = true;
        }

        public List<Parcours> ParcourirJusquaEmbranchement()
        {
            List<Position2D> lEmbranchements = new List<Position2D>();

            do
            {
                if(lEmbranchements.Count == 1)
                {
                    //Nouveau tour => on décale la position
                    Position_X = lEmbranchements.First().X;
                    Position_Y = lEmbranchements.First().Y;
                    NombreDeCasesParcourus++;

                    _Parcouru[Position_Y][Position_X] = true;
                }

                lEmbranchements = new List<Position2D>();

                //Test de toutes les positions possible
                //Gauche
                if (Position_X > 0 && _Parcouru[Position_Y][Position_X - 1] == false &&
                    ((_PentesSontGlissante == false && _Carte[Position_Y][Position_X - 1] != TypeCase.Foret) ||
                    (_Carte[Position_Y][Position_X - 1] == TypeCase.Chemin || _Carte[Position_Y][Position_X - 1] == TypeCase.PenteGauche)))
                {
                    lEmbranchements.Add(new Position2D(Position_X - 1, Position_Y));
                }

                //Haut
                if(Position_Y > 0 && _Parcouru[Position_Y - 1][Position_X] == false &&
                    ((_PentesSontGlissante == false && _Carte[Position_Y - 1][Position_X] != TypeCase.Foret) ||
                    (_Carte[Position_Y - 1][Position_X] == TypeCase.Chemin || _Carte[Position_Y - 1][Position_X] == TypeCase.PenteHaut)))
                {
                    lEmbranchements.Add(new Position2D(Position_X, Position_Y - 1));
                }

                //Droite
                if (Position_X + 1 < _Largeur && _Parcouru[Position_Y][Position_X + 1] == false &&
                    ((_PentesSontGlissante == false && _Carte[Position_Y][Position_X + 1] != TypeCase.Foret) ||
                    (_Carte[Position_Y][Position_X + 1] == TypeCase.Chemin || _Carte[Position_Y][Position_X + 1] == TypeCase.PenteDroite)))
                {
                    lEmbranchements.Add(new Position2D(Position_X + 1, Position_Y));
                }

                //Bas
                if (Position_Y + 1 < _Hauteur && _Parcouru[Position_Y + 1][Position_X] == false && 
                    ((_PentesSontGlissante == false && _Carte[Position_Y + 1][Position_X] != TypeCase.Foret) ||
                    (_Carte[Position_Y + 1][Position_X] == TypeCase.Chemin || _Carte[Position_Y + 1][Position_X] == TypeCase.PenteBas)))
                {
                    lEmbranchements.Add(new Position2D(Position_X, Position_Y + 1));
                }

            } while (lEmbranchements.Count == 1);


            //Création des nouveaux parcours
            List<Parcours> lRetour = new List<Parcours>();

            foreach(Position2D lEmbranchement in lEmbranchements)
            {
                Parcours lCopie = _CopierActuel();

                lCopie.Position_X = lEmbranchement.X;
                lCopie.Position_Y = lEmbranchement.Y;

                lCopie._Parcouru[lEmbranchement.Y][lEmbranchement.X] = true;
                lCopie.NombreDeCasesParcourus++;

                lRetour.Add(lCopie);
            }

            if(lEmbranchements.Count == 0)
            {
                //Arrivé dans une impasse : il faut quand même le sortir pour chopper la fin
                Parcours lCopie = _CopierActuel();

                lRetour.Add(lCopie);
            }

            return lRetour;
        }

        private Parcours _CopierActuel()
        {
            return new Parcours()
            {
                _Carte = _Carte,
                _Hauteur = _Hauteur,
                _Largeur = _Largeur,
                _PentesSontGlissante = _PentesSontGlissante,
                _Parcouru = _CopieParcouru(),
                NombreDeCasesParcourus = NombreDeCasesParcourus,
                Position_X = Position_X,
                Position_Y = Position_Y,
                PositionFinaleParent = new Position2D(Position_X, Position_Y),
            };
        }

        private bool[][] _CopieParcouru()
        {
            bool[][] lParcouruCopie = new bool[_Hauteur][];

            for(int lLigne = 0; lLigne < _Hauteur; lLigne++)
            {
                lParcouruCopie[lLigne] = new bool[_Largeur];
                for(int lColonne = 0; lColonne < _Largeur; lColonne++)
                {
                    lParcouruCopie[lLigne][lColonne] = _Parcouru[lLigne][lColonne];
                }
            }

            return lParcouruCopie;
        }
    }
}
