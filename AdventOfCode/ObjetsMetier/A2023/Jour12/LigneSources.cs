using AdventOfCode.Commun.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour12
{
    [DebuggerDisplay("{_Ligne}")]
    public class LigneSources
    {
        private string _Ligne;
        private Source[] _Sources;

        public LigneSources(string pLigne) 
        {
            _Ligne = pLigne;
            _Sources = pLigne.Select(o => EnumHelper.DonneValeurDepuisDescription<Source>(o.ToString()))
                             .ToArray();
        }

        public List<LigneSources> DonneSourcesPossible(List<int> pTailleGroupes)
        {
            List<LigneSources> lRetour = new List<LigneSources>();
            if(_Sources.Any(o => o == Source.Inconnu))
            {
                Regex lRegex = new Regex(@"\?");

                LigneSources lOperationnel = new LigneSources(lRegex.Replace(_Ligne, ".", 1));
                LigneSources lEndommage = new LigneSources(lRegex.Replace(_Ligne, "#", 1));

                lRetour.AddRange(lOperationnel.DonneSourcesPossible(pTailleGroupes));
                lRetour.AddRange(lEndommage.DonneSourcesPossible(pTailleGroupes));
            }
            else
            {
                lRetour.Add(this);
            }

            return lRetour;
        }


        public bool EstValideJusquaInconnu(List<int> pTailleGroupe)
        {

        }


        public bool EstValide(List<int> pTailleGroupes)
        {

            string[] lLigneSplit = _Ligne.Split(".", StringSplitOptions.RemoveEmptyEntries);

            if(lLigneSplit.Length != pTailleGroupes.Count)
            {
                return false;
            }

            for(int lIndex = 0; lIndex < lLigneSplit.Length; lIndex++)
            {
                if (lLigneSplit[lIndex].Length != pTailleGroupes[lIndex])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return _Ligne;
        }
    }
}
