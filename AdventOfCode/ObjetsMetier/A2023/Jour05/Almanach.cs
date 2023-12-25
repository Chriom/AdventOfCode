using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Commun.Utilitaires;

namespace AdventOfCode.ObjetsMetier.A2023.Jour05
{
    public class Almanach
    {
        public List<decimal> Graines { get; set; }

        public List<Carte> Cartes { get; set; } = new List<Carte>();

        private const Categorie CATEGORIE_DEPART = Categorie.Graine;
        private const Categorie CATEGORIE_ARRIVEE = Categorie.Lieux;

        public decimal DonneGraineAvecPlusPetitLieux()
        {
            return _DonneGraineAvecPlusPetitLieux(Graines);
        }

        public decimal DonneGraineAvecPlusPetitLieuxPlageValeur()
        {
            List<Task<decimal>> lResultats = new List<Task<decimal>>();

            foreach (List<decimal> lGraines in Graines.SplitEnListe(2))
            {
                PlageValeur<decimal> lPlageGraine = PlageValeur<decimal>.DonnePlageValeurDepuisBorneEtDistance(lGraines[0], lGraines[1]);

                List<decimal> lValeursTest = new List<decimal>();

                for (decimal lIndex = lPlageGraine.BorneInferieur; lIndex <= lPlageGraine.BorneSuperieur; lIndex++)
                {
                    lValeursTest.Add(lIndex);
                }

                lResultats.Add(Task<decimal>.Run(() => 
                {
                    decimal lRetour = _DonneGraineAvecPlusPetitLieux(lValeursTest);

                    if (EntreesHelper.EstEnmodeTest == false)
                    {
                        Debug.WriteLine("Fin de la tache");
                    }

                    return lRetour;
                }));

            }



            var lResultatsTraitement = Task.WhenAll(lResultats.ToArray());

            return lResultatsTraitement.Result.Min();

        }

        private decimal _DonneGraineAvecPlusPetitLieux(List<decimal> pGraines)
        {
            decimal lValeurMinimal = decimal.MaxValue;

            



            foreach (decimal lGraine in pGraines)
            {
                Categorie lProchaineCategorie = CATEGORIE_DEPART;

                decimal lNombreGraine = lGraine;

                do
                {
                    Carte lCarte = _DonneCarte(lProchaineCategorie);

                    foreach (PlagePossible lPlage in lCarte.PlagesPossible)
                    {
                        if (lPlage.Source.EstDansPlage(lNombreGraine))
                        {
                            lNombreGraine = lPlage.Destination.BorneInferieur + lPlage.Source.DistanceDepuisBorneInferieur(lNombreGraine);
                            break;
                        }
                    }

                    lProchaineCategorie = lCarte.CategorieArrivé;
                } while (lProchaineCategorie != CATEGORIE_ARRIVEE);

                if (lValeurMinimal > lNombreGraine)
                {
                    lValeurMinimal = lNombreGraine;
                }
            }


            return lValeurMinimal;
        }

        private Carte _DonneCarte(Categorie pCategorie)
        {
            return Cartes.First(o => o.CategorieDepart == pCategorie);
        }
    }
}
