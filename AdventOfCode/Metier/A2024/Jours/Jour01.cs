using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour01;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour01 : AJour<ListeCoteACote>
    {
        public override int NumeroJour => 1;

        public override int Annee => 2024;

        protected override IEnumerable<ListeCoteACote> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            ListeCoteACote lListe = new ListeCoteACote();
            foreach (string lEntree in pEntrees)
            {
                string[] lEntreeSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                lListe.Liste1.Add(int.Parse(lEntreeSplit[0]));
                lListe.Liste2.Add(int.Parse(lEntreeSplit[1]));
            }

            yield return lListe;
        }
        public override string DonneResultatUn()
        {
            ListeCoteACote lListes = _Entrees.First();

            decimal lResultat = 0;

            List<int> lListe1 = lListes.Liste1.OrderBy(o => o).ToList();
            List<int> lListe2 = lListes.Liste2.OrderBy(o => o).ToList();


            for (int lIndex = 0; lIndex < lListes.Liste1.Count; lIndex++)
            {
                lResultat += Math.Abs(lListe2[lIndex] - lListe1[lIndex]);
            }

            return lResultat.ToString();
        }

        public override string DonneResultatDeux()
        {
            ListeCoteACote lListes = _Entrees.First();

            decimal lResultat = 0;

            List<int> lListe1 = lListes.Liste1.OrderBy(o => o).ToList();
            Dictionary<int, int> lDicoApparition = lListes.Liste2.GroupBy(o => o)
                                                                .ToDictionary(o => o.Key, o => o.Count());


            foreach (int lPosition in lListes.Liste1)
            {
                if (lDicoApparition.ContainsKey(lPosition))
                {
                    lResultat += lDicoApparition[lPosition] * lPosition;
                }
            }


            return lResultat.ToString();
        }

    }
}
