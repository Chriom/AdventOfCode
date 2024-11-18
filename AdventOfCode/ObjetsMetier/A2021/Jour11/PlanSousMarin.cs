using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2021.Jour11
{
    public class PlanSousMarin
    {
        private int _Hauteur;
        private int _Largeur;        

        private Octopus[][] _Plan;

        public PlanSousMarin(Octopus[][] pPlan, int pHauteur, int pLargeur)
        {
            _Plan = pPlan;

            _Hauteur = pHauteur;
            _Largeur = pLargeur;
        }

        public int SimulerEtapes(int pNombreEtapes)
        {
            int lNombresTotalFlash = 0;

            for(int lEtape = 0; lEtape < pNombreEtapes;  lEtape++)
            {
                lNombresTotalFlash += _SimulerEtape();
            }

            return lNombresTotalFlash;
        }

        public int DonneNumeroEtapeOuTousLeMondeFlash()
        {
            int lNumeroEtape = 1;
            do
            {
                int lNombreDeFlash = _SimulerEtape();


                if(lNombreDeFlash == _Largeur * _Hauteur)
                {
                    return lNumeroEtape;
                }

                lNumeroEtape++;
            } while (true);
        }

        private int _SimulerEtape()
        {
            bool lAuMoinsUnFlash = false;

            _AugmenterEnergieDeTousLesPoulpes();

            do
            {
                lAuMoinsUnFlash = false;

                //Flashage des poulpes dans le besoin
                for (int lIndexHauteur = 0; lIndexHauteur < _Hauteur; lIndexHauteur++)
                {
                    for (int lIndexLargeur = 0; lIndexLargeur < _Largeur; lIndexLargeur++)
                    {
                        Octopus lPoulpe = _Plan[lIndexHauteur][lIndexLargeur];

                        if (lPoulpe.DoitFlasher)
                        {
                            lPoulpe.FaireFlasher();
                            _AugmenterNiveauEnergiePoulpesAutourDePosition(lIndexHauteur, lIndexLargeur);
                            lAuMoinsUnFlash = true;
                            //Voir pour remettre dans le coin haut gauche
                        }
                    }
                }


            } while (lAuMoinsUnFlash);

            return _ReinitialiserStatusDeTousLesPoulpes();
        }

        private void _AugmenterEnergieDeTousLesPoulpes()
        {
            for(int lIndexHauteur = 0; lIndexHauteur < _Hauteur; lIndexHauteur++)
            {
                for(int lIndexLargeur = 0; lIndexLargeur < _Largeur; lIndexLargeur++)
                {
                    _Plan[lIndexHauteur][lIndexLargeur].AugmenterNiveauEnergie();
                }
            }
        }

        private void _AugmenterNiveauEnergiePoulpesAutourDePosition(int pHauteur, int pLargeur)
        {
            _AugmenterNiveauEnergiePosition(pHauteur - 1, pLargeur - 1);
            _AugmenterNiveauEnergiePosition(pHauteur - 1, pLargeur);
            _AugmenterNiveauEnergiePosition(pHauteur - 1, pLargeur + 1);

            _AugmenterNiveauEnergiePosition(pHauteur, pLargeur - 1);
            _AugmenterNiveauEnergiePosition(pHauteur, pLargeur + 1);

            _AugmenterNiveauEnergiePosition(pHauteur + 1, pLargeur - 1);
            _AugmenterNiveauEnergiePosition(pHauteur + 1, pLargeur);
            _AugmenterNiveauEnergiePosition(pHauteur + 1, pLargeur + 1);
        }

        private void _AugmenterNiveauEnergiePosition(int pHauteur, int pLargeur)
        {
            if(pHauteur >= 0 && pHauteur < _Hauteur && pLargeur >= 0 && pLargeur < _Largeur)
            {
                _Plan[pHauteur][pLargeur].AugmenterNiveauEnergie();
            }
        }


        private int _ReinitialiserStatusDeTousLesPoulpes()
        {
            int lNombreFlash = 0;

            for (int lIndexHauteur = 0; lIndexHauteur < _Hauteur; lIndexHauteur++)
            {
                for (int lIndexLargeur = 0; lIndexLargeur < _Largeur; lIndexLargeur++)
                {
                    Octopus lPoulpe = _Plan[lIndexHauteur][lIndexLargeur];

                    if (lPoulpe.AFlasher)
                    {
                        lNombreFlash++;
                        lPoulpe.ReinitialiserEtatFlash();
                    }
                }
            }

            return lNombreFlash;
        }
    }
}
