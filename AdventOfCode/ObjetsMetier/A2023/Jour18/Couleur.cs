using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour18
{
    public class Couleur
    {
        public string RGB { get; set; }

        public int Rouge => Convert.ToInt32(RGB.Substring(1,2), 16);
        public int Vert => Convert.ToInt32(RGB.Substring(3, 2), 16);
        public int Bleu => Convert.ToInt32(RGB.Substring(5, 2), 16);

        public Couleur(string pRGB)
        {
            RGB = pRGB;
        }

        public Sens Sens => (Sens)int.Parse(RGB.Substring(6, 1));
        
        public int Mouvement => Convert.ToInt32(RGB.Substring(1, 5), 16);
    }
}
