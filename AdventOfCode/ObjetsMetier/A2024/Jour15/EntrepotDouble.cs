using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2024.Jour15
{
    public class EntrepotDouble
    {
        Element[,] _PlanEntrepot;

        private int _Largeur;
        private int _Hauteur;


        private List<Direction> _Instructions;

        private Position2D _PositionRobot;

        private int _NumeroInstruction = 1;

        public EntrepotDouble(Entrepot pEntrepot)
        {
            _ConvertirEntrepot(pEntrepot);
        }

        private void _ConvertirEntrepot(Entrepot pEntrepot)
        {
            _Instructions = pEntrepot.Instructions;

            _Largeur = pEntrepot.Largeur * 2;
            _Hauteur = pEntrepot.Hauteur;

            _PlanEntrepot = new Element[_Hauteur, _Largeur];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < pEntrepot.Largeur; lIndexColonne++)
                {
                    switch (pEntrepot.PlantEntrepot[lIndexLigne, lIndexColonne])
                    {
                        case Element.Vide:
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2] = Element.Vide;
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2 + 1] = Element.Vide;
                            break;
                        case Element.Mur:
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2] = Element.Mur;
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2 + 1] = Element.Mur;
                            break;
                        case Element.Boite:
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2] = Element.BoiteGauche;
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2 + 1] = Element.BoiteDroite;
                            break;
                        case Element.Robot:
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2] = Element.Robot;
                            _PlanEntrepot[lIndexLigne, lIndexColonne * 2 + 1] = Element.Vide;
                            break;
                    }


                }
            }

        }

        public decimal ExecuterInstructions()
        {
            _ChercherRobot();

            foreach (Direction lDirection in _Instructions)
            {
                
                //_DessinerEntrepot(lDirection);
                               
                _DeplacerRobot(lDirection);

                _NumeroInstruction++;
            }

            _DessinerEntrepot(Direction.Stop);

            return _DonnerSommeCoordonneesGPS();
        }

        private void _ChercherRobot()
        {
            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    if (_PlanEntrepot[lIndexLigne, lIndexColonne] == Element.Robot)
                    {
                        _PositionRobot = new Position2D(lIndexColonne, lIndexLigne);
                        return;
                    }
                }
            }
        }

        private void _DeplacerRobot(Direction pDirection)
        {
            switch (pDirection)
            {
                case Direction.Haut:
                    _DeplacerRobotHaut();
                    break;
                case Direction.Droite:
                    _DeplacerRobotHorizontal(1);
                    break;
                case Direction.Bas:
                    _DeplacerRobotBas();
                    break;
                case Direction.Gauche:
                    _DeplacerRobotHorizontal(-1);
                    break;
            }
        }


        private void _DeplacerRobotHaut()
        {
            if (_PlanEntrepot[_PositionRobot.Y - 1, _PositionRobot.X] == Element.BoiteGauche)
            {
                _DeplacerBoiteVersLeHaut(new Position2D(_PositionRobot.X, _PositionRobot.Y - 1));
            }
            else if(_PlanEntrepot[_PositionRobot.Y - 1, _PositionRobot.X] == Element.BoiteDroite)
            {
                _DeplacerBoiteVersLeHaut(new Position2D(_PositionRobot.X - 1, _PositionRobot.Y - 1));
            }


            //C'est déplacé : si c'est vide, le robot bouge
            if(_PlanEntrepot[_PositionRobot.Y - 1, _PositionRobot.X] == Element.Vide)
            {
                _PlanEntrepot[_PositionRobot.Y - 1, _PositionRobot.X] = Element.Robot;
                _PlanEntrepot[_PositionRobot.Y, _PositionRobot.X] = Element.Vide;
                _PositionRobot.Y--;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPositionBoite">Position du côté gauche de la boite</param>
        private void _DeplacerBoiteVersLeHaut(Position2D pPositionBoite)
        {
            //Vérification du haut

            if (pPositionBoite.Y > 0)
            {
                if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.Mur || _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.Mur)
                {
                    //Un mur bloque
                    return;
                }

                if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.BoiteGauche)
                {
                    //Les deux boites sont alignées => Déplacement de la boite du haut
                    _DeplacerBoiteVersLeHaut(new Position2D(pPositionBoite.X, pPositionBoite.Y - 1));
                }
                else if(_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.BoiteDroite)
                {
                    Position2D lPosition1 = new Position2D(pPositionBoite.X - 1, pPositionBoite.Y - 1);
                    Position2D lPosition2 = null;

                    //Vérification si pas de boite sur la droite
                    if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                    {
                        //Aussi une boite à gauche
                        lPosition2 = new Position2D(pPositionBoite.X + 1, pPositionBoite.Y - 1);
                    }

                    bool lPeutBouger = true;

                    if(_BoitePeutBougerVersLeHaut(lPosition1) == false)
                    {
                        lPeutBouger = false;
                    }

                    if(lPosition2 != null && _BoitePeutBougerVersLeHaut(lPosition2) == false)
                    {
                        lPeutBouger = false;
                    }
                    else if (lPosition2 == null && _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] != Element.Vide)
                    {
                        lPeutBouger = false;
                    }

                    if (lPeutBouger)
                    {
                        _DeplacerBoiteVersLeHaut(lPosition1);

                        if(lPosition2 != null)
                        {
                            _DeplacerBoiteVersLeHaut(lPosition2);
                        }
                    }
                }
                else if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                {
                    //Dessus vide et à droite boite gauche
                    _DeplacerBoiteVersLeHaut(new Position2D(pPositionBoite.X + 1, pPositionBoite.Y - 1));
                }
            }

            //Vérification du haut
            if (pPositionBoite.Y > 0)
            {
                if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.Vide)
                {
                    //Rien ne bloque après déplacement
                    _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] = Element.BoiteGauche;
                    _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] = Element.BoiteDroite;

                    _PlanEntrepot[pPositionBoite.Y, pPositionBoite.X] = Element.Vide;
                    _PlanEntrepot[pPositionBoite.Y, pPositionBoite.X + 1] = Element.Vide;
                }

            }
        }

        private bool _BoitePeutBougerVersLeHaut(Position2D pPositionBoite)
        {
            if (pPositionBoite.Y > 0)
            {
                if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.Mur || _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.Mur)
                {
                    //Un mur bloque
                    return false;
                }

                if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.BoiteGauche)
                {
                    //Les deux boites sont alignées => Déplacement de la boite du haut
                    return _BoitePeutBougerVersLeHaut(new Position2D(pPositionBoite.X, pPositionBoite.Y - 1));
                }
                else if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.BoiteDroite)
                {
                    Position2D lPosition1 = new Position2D(pPositionBoite.X - 1, pPositionBoite.Y - 1);
                    Position2D lPosition2 = null;

                    //Vérification si pas de boite sur la droite
                    if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                    {
                        //Aussi une boite à gauche
                        lPosition2 = new Position2D(pPositionBoite.X + 1, pPositionBoite.Y - 1);
                    }

                    bool lPeutBouger = true;

                    if (_BoitePeutBougerVersLeHaut(lPosition1) == false)
                    {
                        lPeutBouger = false;
                    }

                    if (lPosition2 != null && _BoitePeutBougerVersLeHaut(lPosition2) == false)
                    {
                        lPeutBouger = false;
                    }
                    else if (lPosition2 == null && _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] != Element.Vide)
                    {
                        lPeutBouger = false;
                    }

                    return lPeutBouger;
                }
                else if (_PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                {
                    return _BoitePeutBougerVersLeHaut(new Position2D(pPositionBoite.X + 1, pPositionBoite.Y - 1));
                }
            }

            return _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y - 1, pPositionBoite.X + 1] == Element.Vide;
        }

        private void _DeplacerRobotBas()
        {
            if (_PlanEntrepot[_PositionRobot.Y + 1, _PositionRobot.X] == Element.BoiteGauche)
            {
                _DeplacerBoiteVersLeBas(new Position2D(_PositionRobot.X, _PositionRobot.Y + 1));
            }
            else if (_PlanEntrepot[_PositionRobot.Y + 1, _PositionRobot.X] == Element.BoiteDroite)
            {
                _DeplacerBoiteVersLeBas(new Position2D(_PositionRobot.X - 1, _PositionRobot.Y + 1));
            }


            //C'est déplacé : si c'est vide, le robot bouge
            if (_PlanEntrepot[_PositionRobot.Y + 1, _PositionRobot.X] == Element.Vide)
            {
                _PlanEntrepot[_PositionRobot.Y + 1, _PositionRobot.X] = Element.Robot;
                _PlanEntrepot[_PositionRobot.Y, _PositionRobot.X] = Element.Vide;
                _PositionRobot.Y++;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPositionBoite">Position du côté gauche de la boite</param>
        private void _DeplacerBoiteVersLeBas(Position2D pPositionBoite)
        {
            //Vérification du bas

            if (pPositionBoite.Y < _Hauteur - 1)
            {
                if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.Mur || _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.Mur)
                {
                    //Un mur bloque
                    return;
                }

                if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.BoiteGauche)
                {
                    //Les deux boites sont alignées => Déplacement de la boite du bas
                    _DeplacerBoiteVersLeBas(new Position2D(pPositionBoite.X, pPositionBoite.Y + 1));
                }
                else if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.BoiteDroite)
                {
                    Position2D lPosition1 = new Position2D(pPositionBoite.X - 1, pPositionBoite.Y + 1);
                    Position2D lPosition2 = null;

                    //Vérification si pas de boite sur la droite
                    if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                    {
                        //Aussi une boite à gauche
                        lPosition2 = new Position2D(pPositionBoite.X + 1, pPositionBoite.Y + 1);
                    }

                    bool lPeutBouger = true;

                    if (_BoitePeutBougerVersLeBas(lPosition1) == false)
                    {
                        lPeutBouger = false;
                    }

                    if (lPosition2 != null && _BoitePeutBougerVersLeBas(lPosition2) == false)
                    {
                        lPeutBouger = false;
                    }
                    else if(lPosition2 == null && _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] != Element.Vide)
                    {
                        lPeutBouger = false;
                    }

                    if (lPeutBouger)
                    {
                        _DeplacerBoiteVersLeBas(lPosition1);

                        if (lPosition2 != null)
                        {
                            _DeplacerBoiteVersLeBas(lPosition2);
                        }
                    }
                }
                else if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                {
                    //Dessous  vide et à droite boite gauche
                    _DeplacerBoiteVersLeBas(new Position2D(pPositionBoite.X + 1, pPositionBoite.Y + 1));
                }

            }



            //Si boite Récursif


            //Vérification du bas

            if (pPositionBoite.Y < _Hauteur - 1)
            {
                if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.Vide)
                {
                    //Rien ne bloque après déplacement
                    _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] = Element.BoiteGauche;
                    _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] = Element.BoiteDroite;

                    _PlanEntrepot[pPositionBoite.Y, pPositionBoite.X] = Element.Vide;
                    _PlanEntrepot[pPositionBoite.Y, pPositionBoite.X + 1] = Element.Vide;
                }

            }
        }


        private bool _BoitePeutBougerVersLeBas(Position2D pPositionBoite)
        {
            if (pPositionBoite.Y > 0)
            {
                if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.Mur || _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.Mur)
                {
                    //Un mur bloque
                    return false;
                }

                if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.BoiteGauche)
                {
                    //Les deux boites sont alignées => Déplacement de la boite du haut
                    return _BoitePeutBougerVersLeBas(new Position2D(pPositionBoite.X, pPositionBoite.Y + 1));
                }
                else if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.BoiteDroite)
                {
                    Position2D lPosition1 = new Position2D(pPositionBoite.X - 1, pPositionBoite.Y + 1);
                    Position2D lPosition2 = null;

                    //Vérification si pas de boite sur la droite
                    if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                    {
                        //Aussi une boite à gauche
                        lPosition2 = new Position2D(pPositionBoite.X + 1, pPositionBoite.Y + 1);
                    }

                    bool lPeutBouger = true;

                    if (_BoitePeutBougerVersLeBas(lPosition1) == false)
                    {
                        lPeutBouger = false;
                    }

                    if (lPosition2 != null && _BoitePeutBougerVersLeBas(lPosition2) == false)
                    {
                        lPeutBouger = false;
                    }
                    else if (lPosition2 == null && _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] != Element.Vide)
                    {
                        lPeutBouger = false;
                    }

                    return lPeutBouger;
                }
                else if (_PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.BoiteGauche)
                {
                    return _BoitePeutBougerVersLeBas(new Position2D(pPositionBoite.X + 1, pPositionBoite.Y + 1));
                }
            }

            return _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X] == Element.Vide && _PlanEntrepot[pPositionBoite.Y + 1, pPositionBoite.X + 1] == Element.Vide;
        }


        private void _DeplacerRobotHorizontal(int pIncrementPosition)
        {
            int lIndexArret = _PositionRobot.X;
            Element lElementPrecedent = Element.Robot;

            while (lIndexArret >= 0 && lIndexArret < _Largeur - 1)
            {
                if (_PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Vide && lElementPrecedent == Element.Vide)
                {
                    //Deux vide : on sort au précédent
                    break;
                }
                else if (_PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Vide &&
                        (lElementPrecedent == Element.BoiteGauche || lElementPrecedent == Element.BoiteDroite || lElementPrecedent == Element.Robot))
                {
                    //Vide avec robot ou boite précédent : ça va pas plus loin
                    lIndexArret += pIncrementPosition;
                    break;
                }
                else if (_PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Vide)
                {
                    lElementPrecedent = Element.Vide;
                    lIndexArret += pIncrementPosition;
                }
                else if (_PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.Mur)
                {
                    //Mur : on sort
                    break;
                }
                else if (_PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.BoiteGauche ||
                         _PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition] == Element.BoiteDroite)
                {
                    lElementPrecedent = _PlanEntrepot[_PositionRobot.Y, lIndexArret + pIncrementPosition];
                    lIndexArret += pIncrementPosition;
                }
            }

            //Déplacer les éléments
            bool lDeplacement = false;

            for (int lIndexDeplacement = lIndexArret; lIndexDeplacement != _PositionRobot.X; lIndexDeplacement -= pIncrementPosition)
            {
                if (_PlanEntrepot[_PositionRobot.Y, lIndexDeplacement] == Element.Vide)
                {
                    lDeplacement = true;
                    _PlanEntrepot[_PositionRobot.Y, lIndexDeplacement] = _PlanEntrepot[_PositionRobot.Y, lIndexDeplacement - pIncrementPosition];
                    _PlanEntrepot[_PositionRobot.Y, lIndexDeplacement - pIncrementPosition] = Element.Vide;
                }
            }

            if (lDeplacement)
            {
                _PositionRobot.X = _PositionRobot.X + pIncrementPosition;
            }
        }

        private decimal _DonnerSommeCoordonneesGPS()
        {
            decimal lTotal = 0;

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    if (_PlanEntrepot[lIndexLigne, lIndexColonne] == Element.BoiteGauche)
                    {
                        lTotal += 100 * lIndexLigne + lIndexColonne;
                    }
                }
            }

            return lTotal;
        }


        private void _DessinerEntrepot(Direction pDirection)
        {
            Console.WindowHeight = _Hauteur + 5;
            Console.WindowWidth = _Largeur + 15;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);


            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    switch (_PlanEntrepot[lIndexLigne, lIndexColonne])
                    {
                        case Element.Vide:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(".");
                            break;
                        case Element.Mur:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("#");
                            break;
                        case Element.BoiteGauche:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[");
                            break;
                        case Element.BoiteDroite:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("]");
                            break;
                        case Element.Robot:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("@");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Instruction : {_NumeroInstruction}");
            Console.WriteLine($"Prochaine Direction : {pDirection}        ");
            Console.WriteLine($"Total Gps : {_DonnerSommeCoordonneesGPS()}");
        }
    }
}
