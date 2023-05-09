using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Extension
{
    internal static class IEnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> SplitEnListe<T>(this IEnumerable<T> pEnumerable, int pNombreElements)
        {
            if(pNombreElements <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pNombreElements));
            }

            List<T> lListe = new List<T>();

            foreach (T lElement in pEnumerable)
            {
                lListe.Add(lElement);

                if(lListe.Count == pNombreElements)
                {
                    yield return lListe;
                    lListe = new List<T>();
                }
            }
        }

    }
}
