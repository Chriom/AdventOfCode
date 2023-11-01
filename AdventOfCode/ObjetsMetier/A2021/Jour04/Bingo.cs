using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour04
{
    public class Bingo
    {
        public List<int> Numeros { get; set; }

        public List<Grille> Grilles { get; set; } = new List<Grille>();

        public int DonneScoreGrilleGagnante()
        {
            foreach(int lNumero in Numeros)
            {
                foreach(Grille lGrille in Grilles)
                {
                    lGrille.JouerNumero(lNumero);

                    if (lGrille.EstGagnante)
                    {
                        return lNumero * lGrille.Score;
                    }
                }
            }

            throw new Exception("Impossible de déterminer une grille gagnante");
        }

        public int DonneScoreDerniereGrilleGagnante()
        {
            int lNombreGagnant = 0;
            foreach (int lNumero in Numeros)
            {
                foreach (Grille lGrille in Grilles)
                {
                    if(lGrille.EstGagnante == false)
                    {

                        lGrille.JouerNumero(lNumero);

                        if (lGrille.EstGagnante)
                        {
                            lNombreGagnant++;

                            if(lNombreGagnant == Grilles.Count)
                            {
                                //Dernier gagnant
                                return lGrille.Score * lNumero;
                            }
                        }
                    }
                }
            }

            throw new Exception("Impossible de déterminer la dernière grille gagnante");
        }

    }
}
