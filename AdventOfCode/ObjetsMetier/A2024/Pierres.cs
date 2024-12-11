using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024
{
    public class Pierres
    {
        private List<decimal> _Pierres;
        public Pierres(List<decimal> pPierres)
        {
            _Pierres = pPierres;
        }

        private Dictionary<string, decimal> _CacheClignotement = new Dictionary<string, decimal>();

        public decimal DonneNombreDePierresApresClignotement(int pNombreClignotement)
        {
            decimal lTotal = 0;

            foreach(int lPierre in _Pierres)
            {
                lTotal += _Clignoter(lPierre, pNombreClignotement);
            }

            return lTotal;
        }

        private decimal _Clignoter(decimal pValeurPierre, int pNombreRestant)
        {
            string lCle = $"{pValeurPierre}-{pNombreRestant}";

            if(pNombreRestant == 0)
            {
                return 1;
            }

            if (_CacheClignotement.ContainsKey(lCle))
            {
                return _CacheClignotement[lCle];
            }

            decimal lNombrePierres = 0;

            if (pValeurPierre == 0)
            {
                lNombrePierres = _Clignoter(1, pNombreRestant - 1);
            }
            else if (pValeurPierre.ToString().Length % 2 == 0)
            {
                string lNombre = pValeurPierre.ToString();
                
                decimal lPierre1 = decimal.Parse(lNombre.Substring(0, lNombre.Length / 2));
                decimal lPierre2 = decimal.Parse(lNombre.Substring(lNombre.Length / 2));

                lNombrePierres = _Clignoter(lPierre1, pNombreRestant - 1);
                lNombrePierres += _Clignoter(lPierre2, pNombreRestant - 1);
            }
            else
            {
                lNombrePierres = _Clignoter(pValeurPierre * 2024, pNombreRestant - 1);
            }

            _CacheClignotement.Add(lCle, lNombrePierres);
            return lNombrePierres;
        }
    }
}
