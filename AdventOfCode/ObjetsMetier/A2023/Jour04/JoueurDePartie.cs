using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour04
{
    public class JoueurDePartie
    {
        private List<Partie> _Parties;
        private Dictionary<int, int> _DicoPartieResultat = new Dictionary<int, int>();
        private Dictionary<int, Partie> _DicoParties = new Dictionary<int, Partie>();

        private Queue<Partie> _Traitement = new Queue<Partie>();

        public JoueurDePartie(IEnumerable<Partie> pParties)
        {
            _Parties = pParties.ToList();
        }


        public int DonneResultatPartie()
        {
            _Preparer();

            _SimulerPartie();

            return _DicoPartieResultat.Sum(o => o.Value);
        }

        private void _Preparer()
        {
            foreach(Partie lPartie in _Parties) 
            {
                _DicoPartieResultat.Add(lPartie.NumeroPartie, 1);
                _DicoParties.Add(lPartie.NumeroPartie, lPartie);

                _Traitement.Enqueue(lPartie);
            }
        }

        private void _SimulerPartie()
        {
            Partie lPartieSimule = _Traitement.Dequeue();

            do
            {
                int lNombre = lPartieSimule.DonneNombreDeCarteValide();

                int lDebut = lPartieSimule.NumeroPartie + 1;
                int lFin = lDebut + lNombre;

                for(int lIndex = lDebut; lIndex < lFin; lIndex++)
                {
                    //Ajout dans les résultats
                    _DicoPartieResultat[lIndex]++;

                    //partie en plus à traiter
                    _Traitement.Enqueue(_DicoParties[lIndex]);
                }

                if(_Traitement.Count > 0)
                {
                    lPartieSimule = _Traitement.Dequeue();
                }
                else
                {
                    lPartieSimule = null;
                }
                

            } while (lPartieSimule != null);
        }
    }
}
