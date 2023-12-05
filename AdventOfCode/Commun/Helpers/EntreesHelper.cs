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

        public static IEnumerable<T> ChargerEntrees<T>(int pAnnee, int pJour)
        {
            IEnumerable<string> lEntrees = _ChargerEntrees(pAnnee, pJour);

            IConvertisseurEntree<T> lConvertisseur = _DonneConvertisseur<T>();

            if (lConvertisseur == null)
            {
                throw new NullReferenceException($"{nameof(lConvertisseur)} Introuvable");
            }

            return lConvertisseur.ConvertirEntrees(lEntrees);
        }

        private static IEnumerable<string> _ChargerEntrees(int pAnnee, int pJour)
        {
            string lChemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..", "Entrees", pAnnee.ToString());

            if (EstEnmodeTest)
            {
                lChemin = Path.Combine(lChemin, "Tests");
            }

            lChemin = Path.Combine(lChemin, $"{pJour:D3}{(EstEnmodeTest ? "_Test" : string.Empty)}{(Numero != 1 ? $"_{Numero:D2}" : string.Empty)}.txt");

            return File.ReadAllLines(lChemin);
        }

        private static IConvertisseurEntree<T> _DonneConvertisseur<T>()
        {
            foreach (Type lType in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach (Type lInterface in lType.GetInterfaces())
                {
                    if (lInterface.IsGenericType && lInterface.GetGenericTypeDefinition() == typeof(IConvertisseurEntree<>))
                    {
                        if (lInterface.GenericTypeArguments.Any(o => o == typeof(T)))
                        {
                            return (IConvertisseurEntree<T>)Activator.CreateInstance(lType);
                        }
                    }
                }
            }

            return null;
        }
    }
}
