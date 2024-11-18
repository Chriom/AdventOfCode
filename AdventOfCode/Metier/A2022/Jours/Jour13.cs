using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour13;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour13 : AJour<PairePaquets>
    {
        public override int NumeroJour => 13;
        public override int Annee => 2022;

        protected override IEnumerable<PairePaquets> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lEntrees = pEntrees.ToList();
            int lIndexPaire = 1;

            for (int lIndex = 0; lIndex < lEntrees.Count; lIndex += 3)
            {
                yield return new PairePaquets(lIndexPaire++, new Paquet(lEntrees[lIndex]), new Paquet(lEntrees[lIndex + 1]));
            }
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Where(o => o.EstDansLeBonOrdre)
                           .Sum(o => o.Index)
                           .ToString();
        }

        private const string _PAQUET1 = "[[2]]";
        private const string _PAQUET2 = "[[6]]";

        public override string DonneResultatDeux()
        {
            List<PairePaquets> lPaires = _Entrees.ToList();
            lPaires.Add(new PairePaquets(-1, new Paquet(_PAQUET1), new Paquet(_PAQUET2)));

            List<Paquet> lPaquets = new TrieurPaquets(lPaires).ExtrairePaquetsEtTrier();

            int lPosition = 1;

            for (int lIndex = 0; lIndex < lPaquets.Count; lIndex++)
            {
                Paquet lPaquet = lPaquets[lIndex];

                if (lPaquet.PaquetSource == _PAQUET1 || lPaquet.PaquetSource == _PAQUET2)
                {
                    lPosition *= lIndex + 1;
                }
            }

            return lPosition.ToString();
        }
    }
}
