using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Commun.Helpers
{
    public static class EntreesHelper
    {
        public static bool EstEnmodeTest = false;

        public static int Numero = 1;

        public static IEnumerable<string> ChargerEntrees(int pAnnee, int pJour)
        {
            string lChemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..", "Entrees", pAnnee.ToString());

            if (EstEnmodeTest)
            {
                lChemin = Path.Combine(lChemin, "Tests");
            }

            lChemin = Path.Combine(lChemin, $"{pJour:D3}{(EstEnmodeTest ? "_Test" : string.Empty)}{(Numero != 1 ? $"_{Numero:D2}" : string.Empty)}.txt");

            return File.ReadAllLines(lChemin);
        }
                
    }
}
