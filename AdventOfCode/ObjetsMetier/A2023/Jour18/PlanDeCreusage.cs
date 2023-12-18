using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public class PlanDeCreusage
    {
        private List<Sequence> _SequenceCreusage;

        public PlanDeCreusage(IEnumerable<Sequence> pSequenceCreusage)
        {
            _SequenceCreusage = pSequenceCreusage.ToList();
        }


        public decimal DonneNombreDeCasesCreusees()
        {
            _CreuserTrou();
            _CreuserLeVide();

            return _DonneNombreDeCasesCreusees();
        }

        public decimal DonneNombreDeCasesCreuseesDepuisCouleur()
        {
            _MajSequence();
            _CreuserTrou();
            _CreuserLeVide();

            return _DonneNombreDeCasesCreusees();
        }

        private int _Hauteur;
        private int _Largeur;
        private Case[][] _Trou;


        private void _CreuserTrou()
        {
            _CreerTrou();

            int lPositionX = _Largeur / 2;
            int lPositionY = _Hauteur / 2;

            _Trou[lPositionY][lPositionX].EstCreuse = true;

            foreach(Sequence lSequence in _SequenceCreusage)
            {
                switch (lSequence.Sens)
                {
                    case Sens.Haut:
                        for(int lIndex = 1; lIndex <= lSequence.NombreCases; lIndex++)
                        {
                            lPositionY--;
                            _Trou[lPositionY][lPositionX].EstCreuse = true;

                            AppliquerCouleur(lPositionX, lPositionY, lSequence.Couleur);
                        }
                        break;
                    case Sens.Bas:
                        for (int lIndex = 1; lIndex <= lSequence.NombreCases; lIndex++)
                        {
                            lPositionY++;
                            _Trou[lPositionY][lPositionX].EstCreuse = true;

                            AppliquerCouleur(lPositionX, lPositionY, lSequence.Couleur);
                        }
                        break;
                    case Sens.Gauche:
                        for (int lIndex = 1; lIndex <= lSequence.NombreCases; lIndex++)
                        {
                            lPositionX--;
                            _Trou[lPositionY][lPositionX].EstCreuse = true;

                            AppliquerCouleur(lPositionX, lPositionY, lSequence.Couleur);
                        }
                        break;
                    case Sens.Droite:
                        for (int lIndex = 1; lIndex <= lSequence.NombreCases; lIndex++)
                        {
                            lPositionX++;
                            _Trou[lPositionY][lPositionX].EstCreuse = true;

                            AppliquerCouleur(lPositionX, lPositionY, lSequence.Couleur);
                        }
                        break;
                }
            }

            _DessinerTrou();
        }



        private void _CreerTrou()
        {
            _Largeur = _SequenceCreusage.Where(o => o.Sens == Sens.Droite)
                                               .Sum(o => o.NombreCases);
            _Hauteur = _SequenceCreusage.Where(o => o.Sens == Sens.Bas)
                                               .Sum(o => o.NombreCases);
            _Largeur += 2;
            _Largeur *= 2;
            _Hauteur += 2;  
            _Hauteur *= 2;

            _Trou = new Case[_Hauteur][];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                _Trou[lIndexLigne] = new Case[_Largeur];

                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    _Trou[lIndexLigne][lIndexColonne] = new Case();
                }
            }
        }

        private void AppliquerCouleur(int pX, int pY, Couleur pCouleur)
        {
            if (pX - 1 > 0)
            {
                _Trou[pY][pX - 1].Droite = pCouleur;
            }
            if (pX + 1 < _Largeur)
            {
                _Trou[pY][pX + 1].Gauche = pCouleur;
            }
            if (pY - 1 > 0)
            {
                _Trou[pY - 1][pX].Haut = pCouleur;
            }
            if (pY + 1 < _Hauteur)
            {
                _Trou[pY + 1][pX].Bas = pCouleur;
            }
        }

        private void _CreuserLeVide()
        {
            bool lTermine = false;
            for(int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                if (lTermine)
                {
                    break;   
                }

                for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    if (_Trou[lIndexLigne][lIndexColonne].EstCreuse)
                    {
                        //Creuse à partir de la diagonale bas
                        _Creuser(lIndexColonne + 1, lIndexLigne + 1);
                        lTermine = true;
                        break;
                    }                    
                    
                }
            }

            _DessinerTrou();
        }

        private void _Creuser(int pPositionX, int pPositionY)
        {
            HashSet<string> lPositionEnCours = new HashSet<string>();
            Queue<Position> lQueue = new Queue<Position>();

            lQueue.Enqueue(new Position(pPositionX, pPositionY));

            Position lPosition = lQueue.Dequeue();
            do
            {
                _Trou[lPosition.Y][lPosition.X].EstCreuse = true;

                if(lPosition.X > 0 && _Trou[lPosition.Y][lPosition.X - 1].EstCreuse == false)
                {
                    if (lPositionEnCours.Add($"{lPosition.X - 1}|{lPosition.Y}"))
                    {
                        lQueue.Enqueue(new Position(lPosition.X - 1, lPosition.Y));
                    }
                }
                if(lPosition.X + 1 < _Largeur && _Trou[lPosition.Y][lPosition.X + 1].EstCreuse == false)
                {
                    if (lPositionEnCours.Add($"{lPosition.X + 1}|{lPosition.Y}"))
                    {
                        lQueue.Enqueue(new Position(lPosition.X + 1, lPosition.Y));
                    }
                }
                if(lPosition.Y > 0 && _Trou[lPosition.Y - 1][lPosition.X].EstCreuse == false)
                {
                    if (lPositionEnCours.Add($"{lPosition.X}|{lPosition.Y - 1}"))
                    {
                        lQueue.Enqueue(new Position(lPosition.X, lPosition.Y - 1));
                    }
                }
                if(lPosition.Y + 1 < _Hauteur && _Trou[lPosition.Y + 1][lPosition.X].EstCreuse == false)
                {
                    if (lPositionEnCours.Add($"{lPosition.X}|{lPosition.Y + 1}"))
                    {
                        lQueue.Enqueue(new Position(lPosition.X, lPosition.Y + 1));
                    }
                }

                if(lQueue.Count > 0)
                {
                    lPosition = lQueue.Dequeue();
                }
                else
                {
                    lPosition = null;
                }

            } while (lPosition != null);
        }

        private decimal _DonneNombreDeCasesCreusees()
        {
            return _Trou.SelectMany(o => o)
                        .Count(o => o.EstCreuse);
        }

        private void _MajSequence()
        {
            foreach(Sequence lSequence in _SequenceCreusage)
            {
                lSequence.Sens = lSequence.Couleur.Sens;
                lSequence.NombreCases = lSequence.Couleur.Mouvement;
            }
        }

        private void _DessinerTrou()
        {
            return;
            List<string> lLignes = new List<string>();

            for(int lIndexLigne = 0; lIndexLigne< _Hauteur; lIndexLigne++)
            {
                StringBuilder lSB = new StringBuilder();
                for(int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    lSB.Append(_Trou[lIndexLigne][lIndexColonne].EstCreuse ? "·" : "■");
                }

                lLignes.Add(lSB.ToString());
            }

            if(EntreesHelper.EstEnmodeTest == false)
            {
                System.IO.File.WriteAllLines(@$"C:\Temp\test_{DateTime.Now.Millisecond}.txt", lLignes);
            }
            Console.WriteLine(string.Join("\r\n", lLignes));
        }
    }
}
