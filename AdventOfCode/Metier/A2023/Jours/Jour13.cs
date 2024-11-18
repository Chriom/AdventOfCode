using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Extension;
using AdventOfCode.ObjetsMetier.A2023.Jour13;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour13 : AJour<IleDeLave>
    {
        public override int NumeroJour => 13;

        public override int Annee => 2023;

        protected override IEnumerable<IleDeLave> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignesIle = new List<string>();

            foreach (string lEntree in pEntrees)
            {
                if (lEntree == string.Empty)
                {
                    yield return _ConstruireIle(lLignesIle);
                    lLignesIle = new List<string>();
                }
                else
                {
                    lLignesIle.Add(lEntree);
                }
            }

            if (lLignesIle.Count > 0)
            {
                yield return _ConstruireIle(lLignesIle);
            }
        }

        private IleDeLave _ConstruireIle(List<string> pLignes)
        {
            char[][] lIle = new char[pLignes.Count][];

            for (int lIndex = 0; lIndex < pLignes.Count; lIndex++)
            {
                lIle[lIndex] = pLignes[lIndex].ToCharArray();
            }

            return new IleDeLave(lIle);
        }

        public override string DonneResultatUn()
        {
            return _Entrees.Sum(o => o.DonneResume())
                           .ToString();
        }

        public override string DonneResultatDeux()
        {
             return _Entrees.Sum(o => o.DonneResumeAvecReparation())
                            .ToString();
        }


    }
}
