using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour12
{
    public class SourceInconnu
    {
        private string _Ligne;
        private List<int> _Groupes;

        private Dictionary<string, decimal> _Cache = new Dictionary<string, decimal>();

        private const char _INCONNU = '?';
        private const char _OPERATIONNEL = '.';
        private const char _CASSE = '#';

        public SourceInconnu(string pLigne,  List<int> pGroupes)
        {
            _Ligne = pLigne;
            _Groupes = pGroupes;
        }

        public void Demultiplier()
        {
            _Ligne = $"{_Ligne}?{_Ligne}?{_Ligne}?{_Ligne}?{_Ligne}";
            _Groupes = Enumerable.Repeat(_Groupes, 5)
                                 .SelectMany(o => o)
                                 .ToList();
        }

        public decimal DonneNombreValide(int pIndexDebut = 0, int pIndexGroupe = 0)
        {
            string lCle = $"{pIndexDebut}||{pIndexGroupe}";

            if(_Cache.TryGetValue(lCle, out decimal lResultat))
            {
                return lResultat;
            }

            decimal lTotal = 0;
            int lIndex = pIndexDebut;

            while (lIndex <= _Ligne.Length - _Groupes[pIndexGroupe]) //Il faut pas qu'on sorte de la chaine avant la taille max de la boucle
            {
                //Récupération du nombre de caractère du prochain groupe
                string lTest = _Ligne.Substring(lIndex, _Groupes[pIndexGroupe]);

                if (lTest.Contains(_OPERATIONNEL) == false  && lTest.Length == _Groupes[pIndexGroupe])
                {
                    //Que des # ou des ?
                    //La chaine fait la taille attendu (cas de la fin)

                    int lIndexApresGroupe = lIndex + _Groupes[pIndexGroupe];
                    

                    if (pIndexGroupe == _Groupes.Count - 1)
                    {
                        //on test le dernier groupe
                        string lChaineApres = _Ligne.Substring(lIndexApresGroupe);

                        if (_Ligne.Length == lIndexApresGroupe || lChaineApres.Contains(_CASSE) == false)
                        {
                            //Arrivé à la fin de chaine => valide
                            //Pas de # dans le restant => valide
                            lTotal++;
                        }
                    }
                    else
                    {
                        if (lIndexApresGroupe < _Ligne.Length)
                        {
                            //Toujours dans la chaine

                            if (_Ligne[lIndexApresGroupe] == _OPERATIONNEL || _Ligne[lIndexApresGroupe] == _INCONNU)
                            {
                                //Test sur le prochain groupe
                                //Si c'est cassé après, notre groupe d'avant est pourri
                                //Calcul du groupe suivant
                                lTotal += DonneNombreValide(lIndexApresGroupe + 1, pIndexGroupe + 1);
                            }
                        }
                    }
                }

                if (_Ligne[lIndex] == _OPERATIONNEL || _Ligne[lIndex] == _INCONNU)
                {
                    //Test sur le suivante
                    lIndex++;
                }
                else
                {
                    //C'est un cassé et on à déja testé le tout
                    break;
                }
              

            } 


            _Cache.Add(lCle, lTotal);

            if(pIndexDebut == 0 && pIndexGroupe == 0)
            {
                Console.WriteLine($"{lTotal} - {_Ligne}");
            }
            return lTotal;
        }
    }
}
