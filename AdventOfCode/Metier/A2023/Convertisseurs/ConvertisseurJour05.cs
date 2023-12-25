using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Commun.Utilitaires;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour05;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    internal class ConvertisseurJour05 : IConvertisseurEntree<Almanach>
    {
        public IEnumerable<Almanach> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            Almanach lAlmanach = new Almanach();

            lAlmanach.Graines = pEntrees.First()
                                      .Replace("seeds:", string.Empty)
                                      .Trim()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                      .Select(o => decimal.Parse(o))
                                      .ToList();

            Carte lCarte = null;

            foreach(string lEntree in pEntrees.Skip(2))
            {
                if(lCarte == null)
                {
                    //Premiere ligne
                    lCarte = new Carte();

                    string lEntreeCoupe = lEntree.Replace(" map:", string.Empty);

                    string[] lEntreeSplit = lEntreeCoupe.Split("-to-");

                    lCarte.CategorieDepart = EnumHelper.DonneValeurDepuisDescription<Categorie>(lEntreeSplit[0]);
                    lCarte.CategorieArrivé = EnumHelper.DonneValeurDepuisDescription<Categorie>(lEntreeSplit[1]);

                }
                else if(string.IsNullOrEmpty(lEntree) == false)
                {
                    //List de nombre
                    decimal[] lNombresSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                     .Select(o => decimal.Parse(o))
                                                     .ToArray();

                    lCarte.PlagesPossible.Add(new PlagePossible()
                    {
                        Source = PlageValeur<decimal>.DonnePlageValeurDepuisBorneEtDistance(lNombresSplit[1], lNombresSplit[2]),
                        Destination = PlageValeur<decimal>.DonnePlageValeurDepuisBorneEtDistance(lNombresSplit[0], lNombresSplit[2]),
                        Longueur = lNombresSplit[2],
                    });
                }
                else
                {
                    //Ligne vide
                    lAlmanach.Cartes.Add(lCarte);
                    lCarte = null;
                }
            }

            if(lCarte != null)
            {
                lAlmanach.Cartes.Add(lCarte);
            }



            yield return lAlmanach;
        }
    }
}
