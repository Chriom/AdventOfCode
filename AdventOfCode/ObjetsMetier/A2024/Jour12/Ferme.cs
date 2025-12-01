using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour12
{
    public class Ferme
    {
        private Parcelle[,] _Ferme;

        private int _Hauteur;
        private int _Largeur;

        private List<Region> _Regions;

        public Ferme(List<string> pCarte)
        {
            _ConvertirCarte(pCarte);
        }

        private void _ConvertirCarte(List<string> pCarte)
        {
            _Hauteur = pCarte.Count;
            _Largeur = pCarte[0].Length;

            _Ferme = new Parcelle[_Hauteur, _Largeur];

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    _Ferme[lIndexLigne, lIndexColonne] = new Parcelle() { X = lIndexColonne, Y = lIndexLigne, Valeur = pCarte[lIndexLigne][lIndexColonne] };
                }
            }
        }

        public int DonnePrixBarrieres()
        {
            _DeterminerRegions();

            return  _Regions.Sum(o => o.ValeurBarriere);
        }

        public int DonnePrixBarrieresAvecReduction()
        {
            _DeterminerRegions();

            return _Regions.Sum(o => o.ValeurBarriereReduite);
        }

        private void _DeterminerRegions()
        {
            _Regions = new List<Region>();

            for (int lIndexLigne = 0; lIndexLigne < _Hauteur; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _Largeur; lIndexColonne++)
                {
                    if (_Ferme[lIndexLigne, lIndexColonne].EstTraitee == false)
                    {
                        Region lRegion = new Region(_Ferme[lIndexLigne, lIndexColonne].Valeur);
                        _Regions.Add(lRegion);

                        _CompleterRegion(lRegion, _Ferme[lIndexLigne, lIndexColonne]);
                    }
                }
            }
        }

        private void _CompleterRegion(Region pRegion, Parcelle pParcelleDebut)
        {
            
            
            Queue<Parcelle> lParcellesATraiter = new Queue<Parcelle>();
            
            Parcelle lParcelleCourante = pParcelleDebut;
            do
            {
                //Regard des quatre côtés
                if(lParcelleCourante.EstTraitee == false)
                {
                    pRegion.Parcelles.Add(lParcelleCourante);
                    lParcelleCourante.RegionAffectee = pRegion;


                    if (lParcelleCourante.X > 0 && _Ferme[lParcelleCourante.Y, lParcelleCourante.X - 1].Valeur == pRegion.Valeur)
                    {
                        lParcellesATraiter.Enqueue(_Ferme[lParcelleCourante.Y, lParcelleCourante.X - 1]);
                    }
                    else
                    {
                        lParcelleCourante.NombreAdjacentRegionDifferente++;
                    }

                    if (lParcelleCourante.X < _Largeur - 1 && _Ferme[lParcelleCourante.Y, lParcelleCourante.X + 1].Valeur == pRegion.Valeur)
                    {
                        lParcellesATraiter.Enqueue(_Ferme[lParcelleCourante.Y, lParcelleCourante.X + 1]);
                    }
                    else
                    {
                        lParcelleCourante.NombreAdjacentRegionDifferente++;
                    }

                    if (lParcelleCourante.Y > 0 && _Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X].Valeur == pRegion.Valeur)
                    {
                        lParcellesATraiter.Enqueue(_Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X]);
                    }
                    else
                    {
                        lParcelleCourante.NombreAdjacentRegionDifferente++;
                    }

                    if (lParcelleCourante.Y < _Hauteur - 1 && _Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X].Valeur == pRegion.Valeur)
                    {
                        lParcellesATraiter.Enqueue(_Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X]);
                    }
                    else
                    {
                        lParcelleCourante.NombreAdjacentRegionDifferente++;
                    }



                    //Comptage des coins

                    //Gauche et haut
                    if ((lParcelleCourante.X == 0 || _Ferme[lParcelleCourante.Y, lParcelleCourante.X - 1] .Valeur != pRegion.Valeur) &&
                        (lParcelleCourante.Y == 0 || _Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }
                    else if ((lParcelleCourante.X > 0 && _Ferme[lParcelleCourante.Y, lParcelleCourante.X - 1].Valeur == pRegion.Valeur) && 
                            (lParcelleCourante.Y > 0 && _Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X].Valeur == pRegion.Valeur) &&
                            (_Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X - 1].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }

                    //Haut et droit
                    if ((lParcelleCourante.X == _Largeur - 1 || _Ferme[lParcelleCourante.Y, lParcelleCourante.X + 1].Valeur != pRegion.Valeur) &&
                        (lParcelleCourante.Y == 0 || _Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }
                    else if ((lParcelleCourante.X < _Largeur - 1 && _Ferme[lParcelleCourante.Y, lParcelleCourante.X + 1].Valeur == pRegion.Valeur) &&
                            (lParcelleCourante.Y > 0 && _Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X].Valeur == pRegion.Valeur) &&
                            (_Ferme[lParcelleCourante.Y - 1, lParcelleCourante.X + 1].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }

                    //Droit et bas
                    if ((lParcelleCourante.X == _Largeur - 1 || _Ferme[lParcelleCourante.Y, lParcelleCourante.X + 1].Valeur != pRegion.Valeur) &&
                        (lParcelleCourante.Y == _Hauteur - 1 || _Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }
                    else if ((lParcelleCourante.X < _Largeur - 1 && _Ferme[lParcelleCourante.Y, lParcelleCourante.X + 1].Valeur == pRegion.Valeur) &&
                            (lParcelleCourante.Y < _Hauteur - 1 && _Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X].Valeur == pRegion.Valeur) &&
                            (_Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X + 1].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }

                    //Bas et Gauche
                    if ((lParcelleCourante.X == 0 || _Ferme[lParcelleCourante.Y, lParcelleCourante.X - 1].Valeur != pRegion.Valeur) &&
                        (lParcelleCourante.Y == _Hauteur - 1 || _Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }
                    else if ((lParcelleCourante.X > 0 && _Ferme[lParcelleCourante.Y, lParcelleCourante.X - 1].Valeur == pRegion.Valeur) &&
                            (lParcelleCourante.Y < _Hauteur - 1 && _Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X].Valeur == pRegion.Valeur) &&
                            (_Ferme[lParcelleCourante.Y + 1, lParcelleCourante.X - 1].Valeur != pRegion.Valeur))
                    {
                        lParcelleCourante.NombreCoin++;
                    }
                }
                

                lParcelleCourante.EstTraitee = true;

                if(lParcellesATraiter.Count > 0)
                {
                    lParcelleCourante = lParcellesATraiter.Dequeue();
                }
                else
                {
                    lParcelleCourante = null;
                }

            } while (lParcelleCourante != null);

        }
    }
}
