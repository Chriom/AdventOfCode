using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Helpers;

namespace AdventOfCode2022.ObjetsMetier.Jour11
{
    internal class InspecteurDeSinge
    {
        private List<Singe> _Singes;

        private decimal _Diviseur = 1;

        public InspecteurDeSinge(IEnumerable<Singe> pSinges)
        {
            _Singes = pSinges.ToList();

            foreach(Singe lSinge in _Singes)
            {
                _Diviseur *= lSinge.TestObjet.DivisiblePar;
            }

        }


        public IEnumerable<int> DonneNombreInspectionsApresNTour(int pNombreTours, int pDivisionNiveauInquietude)
        {
            _InspecterTousLesSinges(pNombreTours, pDivisionNiveauInquietude);

            return _Singes.Select(o => o.NombreInspections);
        }


        private void _InspecterTousLesSinges(int pNombreTours, int pDivisionNiveauInquietude)
        {
            Dictionary<int, Singe> lDicoSinges = _Singes.ToDictionary(o => o.Numero, o => o);


            for(int lTour = 0; lTour < pNombreTours; lTour++)
            {

                foreach(Singe lSinge in _Singes)
                {
                    ResultatInspection lResultat = null;

                    do
                    {
                        lResultat = lSinge.InspecterObjetSuivant(pDivisionNiveauInquietude);

                        if(lResultat != null)
                        {
                            lDicoSinges[lResultat.NumeroSinge].AjouterObjet(lResultat.PrioriteObjet);
                        }
                    } while (lResultat != null);
                }

                foreach (Singe lSinge in _Singes)
                {
                    lSinge.MiseALEchelleObjet(_Diviseur);
                }



            }
        }


    }
}
