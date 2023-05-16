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
