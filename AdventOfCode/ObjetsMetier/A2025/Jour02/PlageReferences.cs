using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2025.Jour02
{
    public class PlageReferences
    {
        private string _Chaine;

        private Int64 _Minimal;
        private Int64 _Maximal;
        public PlageReferences(string pChaine) 
        { 
            _Chaine = pChaine;

            string[] lChaineSplit = pChaine.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            _Minimal = Int64.Parse(lChaineSplit[0]);
            _Maximal = Int64.Parse(lChaineSplit[1]); 
        }

        public IEnumerable<Int64> ReferencesInvalide
        {
            get
            {
                for (Int64 lNumeroReference = _Minimal; lNumeroReference <= _Maximal; lNumeroReference++)
                {
                    string lReference = lNumeroReference.ToString();

                    if(lReference.Length % 2 != 0)
                    {
                        continue;
                    }

                    int lMilieu = lReference.Length / 2;

                    string lDebut = lReference.Substring(0, lMilieu);
                    string lFin = lReference.Substring(lMilieu, lMilieu);

                    if(lDebut== lFin)
                    {
                        yield return lNumeroReference;
                    }
                }
            }
        }

        public IEnumerable<Int64> ReferencesInvalideRepetition
        {
            get
            {
                for (Int64 lNumeroReference = _Minimal; lNumeroReference <= _Maximal; lNumeroReference++)
                {
                    if(lNumeroReference < 10)
                    {
                        continue;
                    }

                    string lReference = lNumeroReference.ToString();

                    int lNombreCaracteres = (int)Math.Floor((decimal)(lReference.Length / 2));

                    if(lReference.Length % lNombreCaracteres != 0)
                    {
                        do
                        {
                            lNombreCaracteres -= 1;
                        } while (lNombreCaracteres > 0 && lReference.Length % lNombreCaracteres != 0);
                    }

                    if(lNombreCaracteres <= 0)
                    {
                        continue;
                    }

                    do
                    {
                        bool lEstValide = true;
                        string lMorceau = lReference.Substring(0, lNombreCaracteres);

                        for (int lIndex = lNombreCaracteres; lIndex < lReference.Length; lIndex += lNombreCaracteres)
                        {
                            string lTest = lReference.Substring(lIndex, lNombreCaracteres);

                            if(lMorceau != lTest)
                            {
                                lEstValide = false;
                                break;
                            }
                        }

                        if (lEstValide)
                        {
                            yield return lNumeroReference;
                            break;
                        }

                        do
                        {
                            lNombreCaracteres -= 1;
                        } while (lNombreCaracteres > 0 && lReference.Length % lNombreCaracteres != 0);

                    } while (lNombreCaracteres > 0);
                                        
                }
            }
        }
    }
}
