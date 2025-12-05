using AdventOfCode.Commun.Utilitaires;
using AdventOfCode.ObjetsMetier.A2025.Jour05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Metier.A2025
{
    public class Jour05 : AJour<ListeFraicheur>
    {
        public override int NumeroJour => 5;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            ListeFraicheur lListe = _Entrees.First();

            return lListe.DonneNombreIdsFrais().ToString();
        }

        public override string DonneResultatDeux()
        {
            ListeFraicheur lListe = _Entrees.First();

            return lListe.DonneTotalIdsFrais().ToString();
        }


        protected override IEnumerable<ListeFraicheur> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            bool lIdEnCours = false;

            List<PlageValeur<decimal>> lPlages = new List<PlageValeur<decimal>>();
            List<decimal> lIds = new List<decimal>();

            foreach(string lEntree in pEntrees)
            {
                if(lIdEnCours == false && string.IsNullOrEmpty(lEntree))
                {
                    lIdEnCours = true;
                }
                else if(lIdEnCours == false)
                {
                    string[] lPlageSplit = lEntree.Split("-", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    lPlages.Add(PlageValeur<decimal>.DonnePlageValeurDepuisBornes(decimal.Parse(lPlageSplit[0]), decimal.Parse(lPlageSplit[1])));
                }
                else
                {
                    lIds.Add(decimal.Parse(lEntree));
                }
            }

            yield return new ListeFraicheur(lPlages, lIds);
        }
    }
}
