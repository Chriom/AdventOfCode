using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2024.Jour05;

namespace AdventOfCode.Metier.A2024.Jours
{
    public class Jour05 : AJour<RegleEtOrdreDeFabrication>
    {
        public override int NumeroJour => 5;

        public override int Annee => 2024;
        public override string DonneResultatUn()
        {
            RegleEtOrdreDeFabrication lReglesEtOf = _Entrees.First();

            return lReglesEtOf.DonneSommePageCentraleValide()
                              .ToString();
        }

        public override string DonneResultatDeux()
        {
            RegleEtOrdreDeFabrication lReglesEtOf = _Entrees.First();

            return lReglesEtOf.DonneSommePageCentraleAvecReordonnemant()
                              .ToString();
        }

        protected override IEnumerable<RegleEtOrdreDeFabrication> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<Regle> lRegles = new List<Regle>();
            List<OrdreDeFabrication> lOrdres = new List<OrdreDeFabrication>();

            bool lAjoutRegle = true;

            foreach(string lEntree in pEntrees)
            {
                if (string.IsNullOrEmpty(lEntree))
                {
                    lAjoutRegle = false;
                }
                else if (lAjoutRegle)
                {
                    string[] lEntreeSplit = lEntree.Split('|');
                    lRegles.Add(new Regle()
                    {
                        NumeroPageAvant = int.Parse(lEntreeSplit[0]),
                        NumeroPageApres = int.Parse(lEntreeSplit[1]),
                    });
                }
                else
                {
                    string[] lEntreeSplit = lEntree.Split(',');
                    lOrdres.Add(new OrdreDeFabrication()
                    {
                        NumerosPage = lEntreeSplit.Select(o => int.Parse(o))
                                                  .ToList(),
                    });
                }
            }



            yield return new RegleEtOrdreDeFabrication(lRegles, lOrdres);
        }
    }
}
