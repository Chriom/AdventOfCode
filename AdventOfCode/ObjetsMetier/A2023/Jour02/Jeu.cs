using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour02
{
    public class Jeu
    {
        public int Numero { get; set; }

        public List<Tirage> Tirages { get; set; } = new List<Tirage>();

        public bool JeuEstPossible(int pNombreRouge, int pNombreVert, int pNombreBleu)
        {
            foreach(Tirage lTirage in Tirages)
            {
                if(pNombreRouge > 0 && lTirage.BoulesTiré.ContainsKey(Boule.Rouge) && lTirage.BoulesTiré[Boule.Rouge] > pNombreRouge)
                {
                    return false;
                }

                if (pNombreVert > 0 && lTirage.BoulesTiré.ContainsKey(Boule.Vert) && lTirage.BoulesTiré[Boule.Vert] > pNombreVert)
                {
                    return false;
                }

                if (pNombreBleu > 0 && lTirage.BoulesTiré.ContainsKey(Boule.Bleu) && lTirage.BoulesTiré[Boule.Bleu] > pNombreBleu)
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<Boule, int> DonneNombreMinimumDeCubeNecessaire()
        {
            Dictionary<Boule, int> lNombreMinimum = new Dictionary<Boule, int>()
            {
                [Boule.Rouge] = 0,
                [Boule.Vert] = 0,
                [Boule.Bleu] = 0,
            };

            foreach(Tirage lTirage in Tirages)
            {
                foreach(Boule lBoule in lTirage.BoulesTiré.Keys)
                {
                    if (lNombreMinimum[lBoule] < lTirage.BoulesTiré[lBoule])
                    {
                        lNombreMinimum[lBoule] = lTirage.BoulesTiré[lBoule];
                    }
                }
            }

            return lNombreMinimum;
        }

    }
}
