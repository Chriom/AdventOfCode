using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour21;

namespace AdventOfCode2022.Metier.Jours
{
    public class Jour21 : AJour<Singe>
    {
        public override int NumeroJour => 21;

        public override string DonneResultatUn()
        {
            List<Singe> lSinges = _Entrees.ToList();


            Singe lRoot = lSinges.FirstOrDefault(o => o.Nom == "root");

            return lRoot.Resultat.ToString();
        }

        public override string DonneResultatDeux()
        {
            List<Singe> lSinges = _Entrees.ToList();


            Singe lRoot = lSinges.FirstOrDefault(o => o.Nom == "root");

            Singe lSinge1 = lRoot.Singe1;
            Singe lSinge2 = lRoot.Singe2;

            Singe lHumain = lSinges.FirstOrDefault(o => o.Nom == "humn");

            decimal lNombreHumain = decimal.Parse(lHumain.Operation);

            decimal lResultatBaseSinge1 = lSinge1.Resultat;
            decimal lResultatBaseSinge2 = lSinge2.Resultat;

            lHumain.ModifierOperation(++lNombreHumain);

            while (lSinge1.Resultat != lSinge2.Resultat)
            {
                if(lSinge1.Resultat != lResultatBaseSinge1)
                {
                    decimal lDifference = lSinge1.Resultat - lResultatBaseSinge1;

                    decimal lDifferenceSinge2 = lResultatBaseSinge2 - lResultatBaseSinge1;

                    decimal lDelta = Math.Round(lDifferenceSinge2 / lDifference);

                    lNombreHumain += lDelta - 1;
                }

                if(lSinge2.Resultat != lResultatBaseSinge2)
                {
                    decimal lDifference = lSinge2.Resultat - lResultatBaseSinge2;

                    decimal lDifferenceSinge1 = lResultatBaseSinge1 - lResultatBaseSinge2;

                    decimal lDelta = Math.Round(lDifferenceSinge1 / lDifference);

                    lNombreHumain += lDelta - 1;
                }


                lHumain.ModifierOperation(lNombreHumain);

            }

            return lHumain.Operation;
        }

        
    }
}
