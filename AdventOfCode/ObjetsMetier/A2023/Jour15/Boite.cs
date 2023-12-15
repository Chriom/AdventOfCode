using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour15
{
    public class Boite
    {
        public int Numero { get; set; }

        private List<Lentille> _Lentilles = new List<Lentille>();

        public void RetireLentille(string pEtiquette)
        {
            _Lentilles = _Lentilles.Where(o => o.Etiquette !=  pEtiquette)
                                   .ToList();
        }

        public void AjouterLentille(string pEtiquette, int pLongueurFocal)
        {
            Lentille lLentille = _Lentilles.FirstOrDefault(o => o.Etiquette == pEtiquette);

            if(lLentille != null)
            {
                lLentille.LongeurFocal = pLongueurFocal;
            }
            else
            {
                _Lentilles.Add(new Lentille() { Etiquette = pEtiquette, LongeurFocal = pLongueurFocal });
            }
        }

        public decimal DonneValeurDansBoite()
        {
            decimal lValeur = 0;

            int lEmplacementDansBoite = 1;

            foreach(Lentille lLentille in _Lentilles)
            {
                lValeur += (Numero + 1) * lEmplacementDansBoite * lLentille.LongeurFocal;

                lEmplacementDansBoite++;
            }


            return lValeur;
        }
    }
}
