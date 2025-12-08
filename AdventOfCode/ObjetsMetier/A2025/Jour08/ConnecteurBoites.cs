using AdventOfCode.Commun.Extension;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AdventOfCode.ObjetsMetier.A2025.Jour08
{
    public class ConnecteurBoites
    {

        private List<BoiteDerivation> _BoitesDerivation;

        private Dictionary<Guid, Circuit> _Circuits = new Dictionary<Guid, Circuit>();

        private List<Distance> _DistancesEntreBoite = new List<Distance>();

        public ConnecteurBoites(List<BoiteDerivation> pBoitesDerivation)
        {
            _BoitesDerivation = pBoitesDerivation;

            _CalculerDistanceEntreTous();
        }

        public decimal ProduitDes3PlusGrandCircuitsApresNConnections(int pNombreConnection)
        {
            for (int lIndex = 0; lIndex < pNombreConnection; lIndex++)
            {
                Distance lDistance = _DistancesEntreBoite[lIndex];

                if(lDistance.Boite1.Circuit == null && lDistance.Boite2.Circuit == null)
                {
                    //Pas de liaison => nouveau ciruit
                    Circuit lCircuit = new Circuit();

                    lCircuit.AjouterBoite(lDistance.Boite1);
                    lCircuit.AjouterBoite(lDistance.Boite2);

                    _Circuits.Add(lCircuit.Id, lCircuit);
                }
                else if(lDistance.Boite1.Circuit !=null &&  lDistance.Boite2.Circuit == null)
                {
                    //Circuit sur première boite mais pas sur deuxième
                    lDistance.Boite1.Circuit.AjouterBoite(lDistance.Boite2);
                }
                else if (lDistance.Boite1.Circuit == null && lDistance.Boite2.Circuit != null)
                {
                    //Circuit sur deucième boite mais pas sur première
                    lDistance.Boite2.Circuit.AjouterBoite(lDistance.Boite1);
                }
                else if(lDistance.Boite1.Circuit != null && lDistance.Boite2.Circuit != null)
                {
                    //Deux circuits avec Id différent
                    if(lDistance.Boite1.Circuit.Id != lDistance.Boite2.Circuit.Id)
                    {
                        Guid lIdCircuit2 = lDistance.Boite2.Circuit.Id;
                        //Fusion des deux
                        foreach(BoiteDerivation lBoiteDansCircuit2 in lDistance.Boite2.Circuit.BoitesDerivation)
                        {
                            lDistance.Boite1.Circuit.AjouterBoite(lBoiteDansCircuit2);
                        }

                        //Suppression du circuit
                        _Circuits.Remove(lIdCircuit2);
                    }

                }
            }

            return _Circuits.Values
                            .OrderByDescending(o => o.NombreBoites)
                            .Take(3)
                            .Produit(o => o.NombreBoites);
        }

        public decimal ProduitDesXDesDeuxBoitesQuiFormentUnCircuitUnique()
        {
            int lIndex = 0;

            do
            {
                Distance lDistance = _DistancesEntreBoite[lIndex];

                if (lDistance.Boite1.Circuit == null && lDistance.Boite2.Circuit == null)
                {
                    //Pas de liaison => nouveau ciruit
                    Circuit lCircuit = new Circuit();

                    lCircuit.AjouterBoite(lDistance.Boite1);
                    lCircuit.AjouterBoite(lDistance.Boite2);

                    _Circuits.Add(lCircuit.Id, lCircuit);
                }
                else if (lDistance.Boite1.Circuit != null && lDistance.Boite2.Circuit == null)
                {
                    //Circuit sur première boite mais pas sur deuxième
                    lDistance.Boite1.Circuit.AjouterBoite(lDistance.Boite2);
                }
                else if (lDistance.Boite1.Circuit == null && lDistance.Boite2.Circuit != null)
                {
                    //Circuit sur deucième boite mais pas sur première
                    lDistance.Boite2.Circuit.AjouterBoite(lDistance.Boite1);
                }
                else if (lDistance.Boite1.Circuit != null && lDistance.Boite2.Circuit != null)
                {
                    //Deux circuits avec Id différent
                    if (lDistance.Boite1.Circuit.Id != lDistance.Boite2.Circuit.Id)
                    {
                        Guid lIdCircuit2 = lDistance.Boite2.Circuit.Id;
                        //Fusion des deux
                        foreach (BoiteDerivation lBoiteDansCircuit2 in lDistance.Boite2.Circuit.BoitesDerivation)
                        {
                            lDistance.Boite1.Circuit.AjouterBoite(lBoiteDansCircuit2);
                        }

                        //Suppression du circuit
                        _Circuits.Remove(lIdCircuit2);

                        
                    }

                }


                //Toutes les boites sont dans le circuit 1
                if (lDistance.Boite1.Circuit.NombreBoites == _BoitesDerivation.Count)
                {
                    return lDistance.Boite1.Position.X * lDistance.Boite2.Position.X;
                }


                lIndex++;

                if(lIndex >= _DistancesEntreBoite.Count)
                {
                    //Sur le principe c'est pas sensé arriver
                    lIndex = 0;
                }               

            } while (true);
        }

        private void _CalculerDistanceEntreTous()
        {
            for (int lIndexBoite1 = 0; lIndexBoite1 < _BoitesDerivation.Count - 1; lIndexBoite1++)
            {
                BoiteDerivation lBoite1 = _BoitesDerivation[lIndexBoite1];
                for (int lIndexBoite2 = lIndexBoite1 + 1; lIndexBoite2 < _BoitesDerivation.Count; lIndexBoite2++)
                {
                    BoiteDerivation lBoite2 = _BoitesDerivation[lIndexBoite2];

                    _DistancesEntreBoite.Add(new Distance()
                    {
                        Boite1 = lBoite1,
                        Boite2 = lBoite2,
                        DistanceEntreBoite = lBoite1.Position.DistanceDe(lBoite2.Position),
                    });
                }
            }



            _DistancesEntreBoite = _DistancesEntreBoite.OrderBy(o => o.DistanceEntreBoite)
                                                       .ToList();
        }
    }
}
