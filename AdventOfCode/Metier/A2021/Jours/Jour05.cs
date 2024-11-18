using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.ObjetsMetier.A2021.Jour05;

namespace AdventOfCode.Metier.A2021.Jours
{
    public class Jour05 : AJour<Ligne>
    {
        public override int NumeroJour => 5;

        public override int Annee => 2021;

        protected override IEnumerable<Ligne> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {

            foreach (string lEntree in pEntrees)
            {
                string[] lCoordonnees = lEntree.Split("->", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                int[] lDepart = lCoordonnees[0].Split(',').Select(o => int.Parse(o)).ToArray();
                int[] lArrive = lCoordonnees[1].Split(',').Select(o => int.Parse(o)).ToArray();

                yield return new Ligne(lDepart[0], lDepart[1], lArrive[0], lArrive[1]);
            }
        }

        public override string DonneResultatUn()
        {
            Plateau lPlateau = new Plateau(_Entrees.ToList());


            return lPlateau.DonneNombreCasesHorizontaleOuVerticalSeChevauchant().ToString();
        }

        public override string DonneResultatDeux()
        {
            Plateau lPlateau = new Plateau(_Entrees.ToList());


            return lPlateau.DonneNombreCasesSeChevauchant().ToString();
        }
    }
}
