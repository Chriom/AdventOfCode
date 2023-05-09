using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2022.Jour10;

namespace AdventOfCode.Metier.A2022.Jours
{
    public class Jour10 : AJour<IInstruction>
    {
        public override int NumeroJour => 10;
        public override int Annee => 2022;

        public override string DonneResultatUn()
        {
            Processeur lProcesseur = new Processeur(_Entrees);


            return lProcesseur.DonnePuissanceRegistreTousLesNCycle(20, 220, 40)
                              .Sum()
                              .ToString();
        }

        public override string DonneResultatDeux()
        {
            Processeur lProcesseur = new Processeur(_Entrees);


            Ecran lEcran = new Ecran();

            foreach (ResultatExecutionInstruction lInstruction in lProcesseur.ExecuterToutesLesInstructions())
            {
                lEcran.ActualiserEcran(lInstruction);
            }

            return string.Join("\r\n", lEcran.DonneAffichageEcran());
        }


    }
}
