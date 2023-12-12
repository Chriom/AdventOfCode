using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour12
{
    public class Enregistrement
    {
        private string _Ligne;
        private List<int> _TailleGroupes;




        public Enregistrement(string pLigne, List<int> pTailleGroupes)
        {
            _Ligne = pLigne;
            _TailleGroupes = pTailleGroupes;
        }


        public int DonneNombreCombinaisonPossible()
        {
            LigneSources lSource = new LigneSources(_Ligne);

            List<LigneSources> lPossible = lSource.DonneSourcesPossible();

            int lNombreValide = lPossible.Count(o => o.EstValide(_TailleGroupes));

            Debug.WriteLine($"{_Ligne} - {lNombreValide}");

            return lNombreValide;
        }

        public decimal DonneNombreCombinaisonPossibleEnDupliquant()
        {
            string lLigne = $"{_Ligne}?{_Ligne}?{_Ligne}?{_Ligne}?{_Ligne}";
            List<int> lGroupes = new List<int>();
            lGroupes.AddRange(_TailleGroupes);
            lGroupes.AddRange(_TailleGroupes);
            lGroupes.AddRange(_TailleGroupes);
            lGroupes.AddRange(_TailleGroupes);
            lGroupes.AddRange(_TailleGroupes);

            LigneSources lSourceDuplique = new LigneSources(lLigne);

            List<LigneSources> lPossible = lSourceDuplique.DonneSourcesPossible();

            int lNombreValide = lPossible.Count(o => o.EstValide(lGroupes));

            Debug.WriteLine($"{_Ligne} - {lNombreValide}");


            return 0;
        }



    }
}
