using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour08;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour08 : AJour<Signal>
    {
        public override int NumeroJour => 8;

        public override int Annee => 2021;

        protected override IEnumerable<Signal> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split('|', StringSplitOptions.TrimEntries);

                IEnumerable<string> lEntrees = lSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);
                IEnumerable<string> lSorties = lSplit[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);

                yield return new Signal(lEntrees, lSorties);
            }
        }

        public override string DonneResultatUn()
        {
            int lNombreAnalyseSimple = 0;

            foreach(Signal lSignal in _Entrees)
            {
                lSignal.AnalyserSorties();

                lNombreAnalyseSimple += lSignal.Afficheurs.Count(o => o.Digit >= 0);
            }

            return lNombreAnalyseSimple.ToString();
        }

        public override string DonneResultatDeux()
        {
            int lNombreAnalyseComplete = 0;

            foreach (Signal lSignal in _Entrees)
            {
                lSignal.AnalyserEntrees();
                lSignal.AnalyserSorties();

                lNombreAnalyseComplete += lSignal.NombreAffiche;
            }

            return lNombreAnalyseComplete.ToString();
        }
    }
}
