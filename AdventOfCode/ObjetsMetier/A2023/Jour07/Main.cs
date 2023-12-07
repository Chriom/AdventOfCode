using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.ObjetsMetier.A2023.Jour07
{
    [DebuggerDisplay("{_Cartes} - {_CombinaisonDeLaMain}")]
    public class Main : IComparable<Main>
    {
        private string _Cartes;

        public List<CarteChameau> Cartes { get; private set; } = new List<CarteChameau>();

        public int Enchere { get; private set; }
        private Combinaison _CombinaisonDeLaMain;

        public Main(string pCartes, int pEnchere)
        {
            _Cartes = pCartes;
            Enchere = pEnchere;

            Cartes = _Cartes.Select(o => EnumHelper.DonneValeurDepuisDescription<CarteChameau>(o.ToString()))
                            .ToList();
           
        }

        public void ExtraireMain()
        {
            var lGroupes = Cartes.GroupBy(o => o)                        //Par carte identique
                                 .OrderByDescending(o => o.Count());     //Les plus gros groupe devant
                                 

            var lPremierGroupe = lGroupes.First();
            if(lPremierGroupe.Count() == 5)
            {
                _CombinaisonDeLaMain = Combinaison.CinqIdentique;
            }
            else if(lPremierGroupe.Count() == 4)
            {
                _CombinaisonDeLaMain = Combinaison.Carre;
            }
            else if(lPremierGroupe.Count() == 3)
            {
                var lDeuxiemeGroupe = lGroupes.Skip(1).First();

                if(lDeuxiemeGroupe.Count() == 2)
                {
                    _CombinaisonDeLaMain = Combinaison.Full;
                }
                else
                {
                    _CombinaisonDeLaMain = Combinaison.Brelan;
                }
            }
            else if(lPremierGroupe.Count() == 2)
            {
                var lDeuxiemeGroupe = lGroupes.Skip(1).First();

                if(lDeuxiemeGroupe.Count() == 2)
                {
                    _CombinaisonDeLaMain = Combinaison.DeuxPaires;
                }
                else
                {
                    _CombinaisonDeLaMain = Combinaison.Paire;
                }
            }
            else
            {
                _CombinaisonDeLaMain = Combinaison.Carte;
            }

        }

        public void ExtraireMainEnTenantCompteJoker()
        {
            //Remplace les valet par des joker
            Cartes = Cartes.Select(o => o == CarteChameau.Valet ? CarteChameau.Joker : o)
                                               .ToList();

            var lGroupes = Cartes.Where(o => o != CarteChameau.Joker)
                                 .GroupBy(o => o)                        //Par carte identique
                                 .OrderByDescending(o => o.Count());     //Les plus gros groupe devant

            int lNombreJoker = Cartes.Count(o => o == CarteChameau.Joker);

            if(lNombreJoker == 5)
            {
                _CombinaisonDeLaMain = Combinaison.CinqIdentique;
                return;
            }


            var lPremierGroupe = lGroupes.First();
            if (lPremierGroupe.Count() + lNombreJoker == 5)
            {
                _CombinaisonDeLaMain = Combinaison.CinqIdentique;
            }
            else if (lPremierGroupe.Count() + lNombreJoker == 4)
            {
                _CombinaisonDeLaMain = Combinaison.Carre;
            }
            else if (lPremierGroupe.Count() + lNombreJoker == 3)
            {
                var lDeuxiemeGroupe = lGroupes.Skip(1).First();

                if (lDeuxiemeGroupe.Count() == 2)
                {
                    _CombinaisonDeLaMain = Combinaison.Full;
                }
                else
                {
                    _CombinaisonDeLaMain = Combinaison.Brelan;
                }
            }
            else if (lPremierGroupe.Count() + lNombreJoker == 2)
            {
                var lDeuxiemeGroupe = lGroupes.Skip(1).First();

                if (lDeuxiemeGroupe.Count() == 2)
                {
                    _CombinaisonDeLaMain = Combinaison.DeuxPaires;
                }
                else
                {
                    _CombinaisonDeLaMain = Combinaison.Paire;
                }
            }
            else
            {
                _CombinaisonDeLaMain = Combinaison.Carte;
            }
        }

        public int CompareTo(Main pMain)
        {
            if(_CombinaisonDeLaMain == pMain._CombinaisonDeLaMain)
            {
                for(int lIndex = 0; lIndex < Cartes.Count; lIndex++)
                {
                    if (Cartes[lIndex] == pMain.Cartes[lIndex])
                    {
                        continue;
                    }
                    else if ((int)Cartes[lIndex] < (int)pMain.Cartes[lIndex])
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }

                return 0;
            }
            else if((int)_CombinaisonDeLaMain < (int)pMain._CombinaisonDeLaMain)
            {
                return -1;
            }

            return 1;
        }

        public override string ToString()
        {
            return $"{_Cartes} - {_CombinaisonDeLaMain}";
        }

    }
}
