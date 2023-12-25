using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour21
{
    public class CarteJardin
    {
        public TypeCase[][] Jardin { get; private set; }

        public int Hauteur { get; private set; }
        public int Largeur { get; private set; }

        public CarteJardin(TypeCase[][] pJardin)
        {
            Jardin = pJardin;
            Hauteur = Jardin.Length;
            Largeur = Jardin.First().Length;
        }

        public CarteJardin CopierSansLesPotagers(bool pDoitGrandir = false)
        {
            int lHauteur = Hauteur;
            int lLargeur = Largeur;

            if (pDoitGrandir)
            {
                lHauteur *= 3;
                lLargeur *= 3;
            }

            TypeCase[][] lJardinCopie = new TypeCase[lHauteur][];

            

            for(int lLigne = 0; lLigne < Hauteur; lLigne++)
            {
                lJardinCopie[lLigne] = new TypeCase[lLargeur];

                if (pDoitGrandir)
                {
                    lJardinCopie[lLigne + Hauteur] = new TypeCase[lLargeur];
                    lJardinCopie[lLigne + Hauteur * 2] = new TypeCase[lLargeur];
                }

                for(int lColonne = 0; lColonne < Largeur; lColonne++)
                {
                    lJardinCopie[lLigne][lColonne] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;

                    if (pDoitGrandir)
                    {
                        lJardinCopie[lLigne + Hauteur][lColonne] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;
                        lJardinCopie[lLigne + Hauteur * 2][lColonne] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;

                        lJardinCopie[lLigne][lColonne + Largeur] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;
                        lJardinCopie[lLigne + Hauteur][lColonne + Largeur] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;
                        lJardinCopie[lLigne + Hauteur * 2][lColonne + Largeur] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;

                        lJardinCopie[lLigne][lColonne + Largeur * 2] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;
                        lJardinCopie[lLigne + Hauteur][lColonne + Largeur * 2] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;
                        lJardinCopie[lLigne + Hauteur * 2][lColonne + Largeur * 2] = Jardin[lLigne][lColonne] == TypeCase.Pierre ? TypeCase.Pierre : TypeCase.Vide;
                    }                    
                }
            }

            return new CarteJardin(lJardinCopie);
        }

        public void Dessiner()
        {
            StringBuilder lSb = new StringBuilder();

            foreach (TypeCase[] lLigne in Jardin)
            {
                foreach(TypeCase lCase in lLigne)
                {
                    string lSymbole = lCase switch
                    {
                        TypeCase.Pierre => "#",
                        TypeCase.Vide => ".",
                        TypeCase.Potager => "O",
                        TypeCase.Depart => "S",
                        _ => throw new Exception("Pas possible")
                    };
                    lSb.Append(lSymbole);
                }

                lSb.Append("\r\n");
            }

            Console.WriteLine(lSb.ToString());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
