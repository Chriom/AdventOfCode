using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Interfaces;

namespace AdventOfCode2022.Helpers
{
    public static class EntreesHelper
    {
        public static bool EstEnmodeTest = false;
        public static IEnumerable<T> ChargerEntrees<T>(int pJour)
        {
            IEnumerable<string> lEntrees = _ChargerEntrees(pJour);

            IConvertisseurEntree<T> lConvertisseur = _DonneConvertisseur<T>();

            if(lConvertisseur == null)
            {
                throw new NullReferenceException($"{nameof(lConvertisseur)} Introuvable");
            }

            return lConvertisseur.ConvertirEntrees(lEntrees);
        }

        private static IEnumerable<string> _ChargerEntrees(int pJour)
        {
            string lChemin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..", "Entrees");

            if (EstEnmodeTest)
            {
                lChemin = Path.Combine(lChemin, "Tests");
            }

            lChemin = Path.Combine(lChemin, $"{pJour:D3}{(EstEnmodeTest ? "_Test" : string.Empty)}.txt");

            return System.IO.File.ReadAllLines(lChemin);
        }

        private static IConvertisseurEntree<T> _DonneConvertisseur<T>()
        {
            foreach(Type lType in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach(Type lInterface in lType.GetInterfaces())
                {
                    if(lInterface.IsGenericType && lInterface.GetGenericTypeDefinition() == typeof(IConvertisseurEntree<>))
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
