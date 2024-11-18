using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2023.Jour07;

namespace AdventOfCode.Metier.A2023.Jours
{
    public class Jour07 : AJour<Main>
    {
        public override int NumeroJour => 7;

        public override int Annee => 2023;
        
        protected override IEnumerable<Main> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach (string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                yield return new Main(lSplit[0], int.Parse(lSplit[1]));
            }
        }

        public override string DonneResultatUn()
        {
            decimal lTotal = 0;
            int lRang = 1;

            List<Main> lMains = new List<Main>();

            foreach(Main lMain in _Entrees)
            {
                lMain.ExtraireMain();
                lMains.Add(lMain);
            }

            foreach(Main lMain in lMains.OrderBy(o => o))
            {
                if(EntreesHelper.EstEnmodeTest == false)
                {
                    Console.WriteLine($"{lRang} - {lMain}");
                }

                lTotal += lRang * (decimal)lMain.Enchere;

                lRang++;
            }

            return lTotal.ToString();        
        }

        public override string DonneResultatDeux()
        {
            decimal lTotal = 0;
            int lRang = 1;

            List<Main> lMains = new List<Main>();

            foreach (Main lMain in _Entrees)
            {
                lMain.ExtraireMainEnTenantCompteJoker();
                lMains.Add(lMain);
            }

            foreach (Main lMain in lMains.OrderBy(o => o))
            {
                if (EntreesHelper.EstEnmodeTest == false)
                {
                    Console.WriteLine($"{lRang} - {lMain}");
                }

                lTotal += lRang * (decimal)lMain.Enchere;

                lRang++;
            }

            return lTotal.ToString();
        }

    
    }
}
