using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2023.Jour13;

namespace AdventOfCode.Metier.A2023.Convertisseurs
{
    public class ConvertisseurJour13 : IConvertisseurEntree<IleDeLave>
    {
        public IEnumerable<IleDeLave> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            List<string> lLignesIle = new List<string>();

            foreach(string lEntree in pEntrees) 
            {
                if(lEntree == string.Empty)
                {
                    yield return _ConstruireIle(lLignesIle);
                    lLignesIle = new List<string>();
                }
                else
                {
                    lLignesIle.Add(lEntree);
                }
            }

            if(lLignesIle.Count > 0)
            {
                yield return _ConstruireIle(lLignesIle);
            }
        }

        private IleDeLave _ConstruireIle(List<string> pLignes)
        {
            char[][] lIle = new char[pLignes.Count][];

            for(int lIndex = 0; lIndex < pLignes.Count; lIndex++) 
            {
                lIle[lIndex] = pLignes[lIndex].ToCharArray();
            }

            return new IleDeLave(lIle);
        }
    }
}
