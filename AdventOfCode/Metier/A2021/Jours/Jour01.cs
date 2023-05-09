using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour01;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour01 : AJour<Profondeur>
    {
        public override int NumeroJour => 1;

        public override int Annee => 2021;

        public override string DonneResultatUn()
        {
            int lMesurePrecedente = int.MaxValue;

            int lTotalAugmentation = 0;
            foreach(Profondeur lProfondeur in _Entrees)
            {
                if(lProfondeur.Mesure  > lMesurePrecedente)
                {
                    lTotalAugmentation++;
                }

                lMesurePrecedente = lProfondeur.Mesure;
            }

            return lTotalAugmentation.ToString();
        }

        public override string DonneResultatDeux()
        {
            List<Profondeur> lProfondeurs = _Entrees.ToList();

            int lSommeProfondeursPrecedente = int.MaxValue;
            int lTotalAugmentation = 0;

            for (int lIndex = 2; lIndex < lProfondeurs.Count; lIndex++)
            {
                int lSommeProfondeurs = lProfondeurs[lIndex - 2].Mesure + lProfondeurs[lIndex - 1].Mesure + lProfondeurs[lIndex].Mesure;

                if(lSommeProfondeurs > lSommeProfondeursPrecedente)
                {
                    lTotalAugmentation++;
                }

                lSommeProfondeursPrecedente = lSommeProfondeurs;
            }

            return lTotalAugmentation.ToString();
        }


    }
}
