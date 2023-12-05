using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;

namespace AdventOfCode.ObjetsMetier.A2021.Jour09
{
    public class CarteHauteur
    {
        public int Hauteur { get; set; }
        public int Largeur { get; set; }
        public Localisation[][] Carte { get; set; }

        public List<Bassin> Bassins = new List<Bassin>();
        public void DeterminerPointsLesPlusBas()
        {
            for(int lHauteur = 0; lHauteur < Hauteur; lHauteur++)
            {
                for(int lLargeur = 0; lLargeur < Largeur; lLargeur++)
                {
                    int lHauteurPoint = Carte[lHauteur][lLargeur].Hauteur;

                    if ((lHauteur > 0 && Carte[lHauteur - 1][lLargeur].Hauteur <= lHauteurPoint ) ||
                        (lHauteur < Hauteur - 1 && Carte[lHauteur + 1][lLargeur].Hauteur <= lHauteurPoint) ||
                        (lLargeur > 0 && Carte[lHauteur][lLargeur - 1].Hauteur <= lHauteurPoint) ||
                        (lLargeur < Largeur -1 && Carte[lHauteur][lLargeur + 1].Hauteur <= lHauteurPoint))
                    {
                        Carte[lHauteur][lLargeur].EstLePointLePlusBas = false;
                    }
                    else
                    {
                        Carte[lHauteur][lLargeur].EstLePointLePlusBas = true;
                    }

                    Carte[lHauteur][lLargeur].EstTraite = true;
                }
            }
        }

        public int DonneNiveauDeRisque()
        {
            return Carte.Select(o => o)
                        .SelectMany(o => o)
                        .Sum(o => o.NiveauDeRisque);
        }

        public void DeterminerBassinVersant()
        {
            int lNumeroBassin = 1;
            Bassin lBassinCourant = new Bassin()
            {
                NumeroBassin = lNumeroBassin,
            };

            Bassins.Add(lBassinCourant);

            for (int lHauteur = 0; lHauteur < Hauteur; lHauteur++)
            {
                for (int lLargeur = 0; lLargeur < Largeur; lLargeur++)
                {
                    Localisation lPosition = Carte[lHauteur][lLargeur];

                    if(lPosition.BassinVersant == null && lPosition.Hauteur < 9)
                    {
                        _DeterminerBassinAPartirDePosition(lPosition, lBassinCourant);


                        //Nouveau Bassin
                        lBassinCourant = new Bassin()
                        {
                            NumeroBassin = ++lNumeroBassin,
                        };
                        Bassins.Add(lBassinCourant);
                    }
                }
            }
        }

        private void _DeterminerBassinAPartirDePosition(Localisation pPosition, Bassin pBassin)
        {
            Queue<Localisation> lQueue = new Queue<Localisation>();

            
            Localisation lPosition = pPosition;

            do
            {
                //Haut
                if (lPosition.Y > 0 && Carte[lPosition.Y - 1][lPosition.X].BassinVersant == null && Carte[lPosition.Y - 1][lPosition.X].Hauteur < 9)
                {
                    lQueue.Enqueue(Carte[lPosition.Y - 1][lPosition.X]);
                }

                //Bas
                if (lPosition.Y < Hauteur - 1 && Carte[lPosition.Y + 1][lPosition.X].BassinVersant == null && Carte[lPosition.Y + 1][lPosition.X].Hauteur < 9)
                {
                    lQueue.Enqueue(Carte[lPosition.Y + 1][lPosition.X]);
                }

                //Gauche
                if (lPosition.X > 0 && Carte[lPosition.Y][lPosition.X - 1].BassinVersant == null && Carte[lPosition.Y][lPosition.X - 1].Hauteur < 9)
                {
                    lQueue.Enqueue(Carte[lPosition.Y][lPosition.X - 1]);
                }

                //Droite
                if (lPosition.X < Largeur - 1 && Carte[lPosition.Y][lPosition.X + 1].BassinVersant == null && Carte[lPosition.Y][lPosition.X + 1].Hauteur < 9)
                {
                    lQueue.Enqueue(Carte[lPosition.Y][lPosition.X + 1]);
                }

                if(lPosition.BassinVersant == null)
                {

                    lPosition.BassinVersant = pBassin;
                    pBassin.Localisations.Add(lPosition);
                }

                if (lQueue.Count > 0)
                {
                    lPosition = lQueue.Dequeue();
                }
                else
                {
                    lPosition = null;
                }

            } while (lPosition != null);

        }

        public int DonneTailleDesPlusGrandBassins()
        {
            return Bassins.OrderByDescending(o => o.Taille)
                          .Take(3)
                          .Produit(o => o.Taille);                          
        }
    }
}
