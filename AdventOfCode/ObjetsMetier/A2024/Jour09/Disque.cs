using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour09
{
    public class Disque
    {
        private string _ChaineCompressee;
        private EmplacementDisque[] _EmplacementDisque;

        public Disque(string pChaineCompressee)
        {
            _ChaineCompressee = pChaineCompressee;

            _Decompresser();
        }

        private void _Decompresser()
        {
            int lTailleTotal = _ChaineCompressee.Sum(o => int.Parse(o.ToString()));

            _EmplacementDisque = new EmplacementDisque[lTailleTotal];

            bool lEstDansUnFichier = true;
            int lIndexGlobal = 0;
            uint lIdentifiantFichier = 0;

            foreach (int lTaille in _ChaineCompressee.Select(o => int.Parse(o.ToString())))
            {
                Fichier lFichier = null;
                if (lEstDansUnFichier)
                {
                    lFichier = new Fichier();
                    lFichier.Taille = (uint)lTaille;
                    lFichier.Identifiant = lIdentifiantFichier++;
                }

                for (int lIndex = 0; lIndex < lTaille; lIndex++)
                {
                    EmplacementDisque lEmplacementDisque = new EmplacementDisque();
                    
                    lEmplacementDisque.Fichier = lFichier;
                    lEmplacementDisque.Block = lIndex;

                    _EmplacementDisque[lIndexGlobal++] = lEmplacementDisque;
                }


                lEstDansUnFichier = !lEstDansUnFichier;
            }
        }

        public decimal DeplacerBlocEtDonneChecksum()
        {
            int lIndexLibre = 0;

            for (int lIndexFin = _EmplacementDisque.Length - 1; lIndexFin >= lIndexLibre; lIndexFin--)
            {
                if (_EmplacementDisque[lIndexFin].Fichier != null)
                {
                    //Prochain espace
                    while (_EmplacementDisque[lIndexLibre].Fichier != null && lIndexFin != lIndexLibre)
                    {
                        lIndexLibre++;
                    }

                    if(lIndexFin == lIndexLibre)
                    {
                        break;
                    }

                    _EmplacementDisque[lIndexLibre].Fichier = _EmplacementDisque[lIndexFin].Fichier;
                    _EmplacementDisque[lIndexLibre].Block = _EmplacementDisque[lIndexFin].Block;

                    _EmplacementDisque[lIndexFin].Fichier = null;
                    _EmplacementDisque[lIndexFin].Block = -1;
                }
            }

            return _DonneChecksum();
        }

        

        public decimal DeplacerFichierSansFragmentationEtDonneChecksum()
        {
            for(int lIndexFin = _EmplacementDisque.Length - 1; lIndexFin >= 0; lIndexFin--)
            {
                Fichier lFichier = _EmplacementDisque[lIndexFin].Fichier;
                if (lFichier != null && _EmplacementDisque[lIndexFin].Block == 0)
                {
                    uint lNombreBlocks = lFichier.Taille;

                    
                    for (int lIndexVide = 0; lIndexVide < _EmplacementDisque.Length; lIndexVide++)
                    {
                        int lNombreVide = 1;
                        if (_EmplacementDisque[lIndexVide].Fichier == null)
                        {
                            int lDebutVide = lIndexVide;
                            //Taille de l'espace
                            while (lNombreVide < lNombreBlocks && lIndexVide < _EmplacementDisque.Length - 1)
                            {
                                lIndexVide++;
                                if (_EmplacementDisque[lIndexVide].Fichier != null)
                                {
                                    break;
                                }
                                else
                                {
                                    lNombreVide++;
                                }
                            }

                            if(lNombreVide == lNombreBlocks && lDebutVide <lIndexFin)
                            {
                                //Déplacement du fichier complet

                                for(int lIndexBloc = 0; lIndexBloc < lNombreBlocks; lIndexBloc++)
                                {
                                    _EmplacementDisque[lDebutVide + lIndexBloc].Fichier = _EmplacementDisque[lIndexFin + lIndexBloc].Fichier;
                                    _EmplacementDisque[lDebutVide + lIndexBloc].Block = _EmplacementDisque[lIndexFin + lIndexBloc].Block;

                                    _EmplacementDisque[lIndexFin + lIndexBloc].Fichier = null;
                                    _EmplacementDisque[lIndexFin + lIndexBloc].Block = -1;
                                }

                                break;
                            }

                        }


                    }

                    
                }
            }

            return _DonneChecksum();
        }

        private decimal _DonneChecksum()
        {
            decimal lCheckSum = 0;

            int lPosition = -1;

            foreach (EmplacementDisque lEmplacementDisque in _EmplacementDisque)
            {
                lPosition++;
                if (lEmplacementDisque.Fichier == null)
                {
                    continue;
                }

                lCheckSum += lEmplacementDisque.Fichier.Identifiant * lPosition;
                
            }

            return lCheckSum;
        }
    }
}
