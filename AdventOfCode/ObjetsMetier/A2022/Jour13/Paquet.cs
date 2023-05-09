using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AdventOfCode.ObjetsMetier.A2022.Jour13
{
    [DebuggerDisplay("{PaquetSource}")]
    public class Paquet : IComparable<Paquet>
    {
        private string _Paquet;

        public string PaquetSource => _Paquet;

        public JArray Json { get; private set; }

        public Paquet(string pPaquet)
        {
            _Paquet = pPaquet;

            Json = (JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(_Paquet);
        }

        public int CompareTo(Paquet pAutre)
        {
            PairePaquets lPaire = new PairePaquets(0, this, pAutre);

            if (lPaire.EstDansLeBonOrdre)
            {
                return -1;
            }

            return 1;
        }
    }
}
