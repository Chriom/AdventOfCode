using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AdventOfCode.ObjetsMetier.A2022.Jour16
{
    internal class ExplorateurCave
    {
        public const int MINUTES_TOTAL = 30;

        private Dictionary<string, Valve> _Valves { get; set; }

        public ExplorateurCave(IEnumerable<Valve> pValves)
        {
            _Valves = pValves.ToDictionary(o => o.Cle, o => o);
        }

        private const string _CLE_VALVE_DEBUT = "AA";

        private decimal _NombreParcours = 0;

        public int DonnePressionMaximaleLiberee()
        {
            Valve lDebut = _Valves[_CLE_VALVE_DEBUT];


            Route lRoute = new Route()
            {
                Minutes = 0,
                Action = ActionFaite.Deplacement,
                Valve = lDebut,
            };

            _Explorer(lRoute);

            return lRoute.TotalePressionLibere;
        }

        private void _Explorer(Route pParent)
        {
            if (pParent.Minutes >= MINUTES_TOTAL)
            {
                return;
            }

            if (pParent.ValvesFermes.Contains(pParent.Valve.Cle) == false && pParent.Valve.PeutEtreFermee)
            {
                //Fermeture de la valve
                HashSet<string> lValvesFermees = new HashSet<string>(pParent.ValvesFermes);
                lValvesFermees.Add(pParent.Valve.Cle);

                pParent.Suivant.Add(new Route()
                {
                    Action = ActionFaite.FermetureValve,
                    Minutes = pParent.Minutes + 1,
                    Precedent = pParent,
                    Valve = pParent.Valve,
                    ValvesFermes = lValvesFermees
                });
            }
            else
            {
                //Parcours des destinations restante
                foreach (string lCleValve in pParent.Valve.DistanceAutreValves.Keys)
                {
                    if (pParent.ValvesFermes.Contains(lCleValve))
                    {
                        continue;
                    }

                    int lDistance = pParent.Valve.DistanceAutreValves[lCleValve];

                    if (pParent.Minutes + lDistance >= MINUTES_TOTAL)
                    {
                        continue;
                    }

                    Valve lValve = _Valves[lCleValve];

                    pParent.Suivant.Add(new Route()
                    {
                        Action = ActionFaite.Deplacement,
                        Minutes = pParent.Minutes + lDistance,
                        Precedent = pParent,
                        Valve = lValve,
                        ValvesFermes = new HashSet<string>(pParent.ValvesFermes),
                    });
                }

            }

            //Parcours
            int lMaxEnfant = 1;

            List<Route> lASupprimer = new List<Route>();
            foreach (Route lRoute in pParent.Suivant)
            {
                _Explorer(lRoute);

                int lPressionLibere = lRoute.TotalePressionLibere;

                if (lPressionLibere < lMaxEnfant)
                {
                    lASupprimer.Add(lRoute);
                }
                else
                {
                    lMaxEnfant = lPressionLibere;
                }
            }

            foreach (Route lRouteASupprime in lASupprimer)
            {
                pParent.Suivant.Remove(lRouteASupprime);
            }

            _NombreParcours++;

            if (_NombreParcours % 1000 == 0)
            {
                Debug.WriteLine(_NombreParcours);
            }
        }


        public int DonnePressionMaximaleLibereeAvecElephant()
        {
            Valve lDebut = _Valves[_CLE_VALVE_DEBUT];


            RouteAvecElephant lRoute = new RouteAvecElephant()
            {
                MinutesPersonnage = 4,
                MinutesElephant = 4,
                ActionPersonnage = ActionFaite.ApprentissagePachiderme,
                ActionElephant = ActionFaite.ApprentissagePachiderme,
                ValvePersonnage = lDebut,
                ValveElephant = lDebut,
            };

            _ExplorerAvecElephant(lRoute);

            return lRoute.TotalePressionLibere;
        }

        private int _DonnePointPotentiel(string pCle, int pDistance, int pMinutesParent)
        {
            Valve lValve = _Valves[pCle];

            if (pMinutesParent + pDistance + 1 < MINUTES_TOTAL)
            {
                return (MINUTES_TOTAL - pMinutesParent - pDistance - 1) * lValve.Pression;
            }

            return 0;
        }

        private void _ExplorerAvecElephant(RouteAvecElephant pParent)
        {
            if (pParent.MinutesPersonnage >= MINUTES_TOTAL && pParent.MinutesElephant >= MINUTES_TOTAL)
            {
                return;
            }

            if (pParent.ValvesFermes.Contains(pParent.ValvePersonnage.Cle) == false && pParent.ValvePersonnage.PeutEtreFermee)
            {
                //Fermeture de la valve du personnage
                HashSet<string> lValvesFermees = new HashSet<string>(pParent.ValvesFermes);
                lValvesFermees.Add(pParent.ValvePersonnage.Cle);



                if (pParent.ValvesFermes.Contains(pParent.ValveElephant.Cle) == false && pParent.ValveElephant.PeutEtreFermee && pParent.MinutesElephant < MINUTES_TOTAL)
                {
                    lValvesFermees.Add(pParent.ValveElephant.Cle);

                    RouteAvecElephant lRoute = new RouteAvecElephant()
                    {
                        Precedent = pParent,

                        ActionPersonnage = ActionFaite.FermetureValve,
                        MinutesPersonnage = pParent.MinutesPersonnage + 1,
                        ValvePersonnage = pParent.ValvePersonnage,

                        ActionElephant = ActionFaite.FermetureValve,
                        MinutesElephant = pParent.MinutesElephant + 1,
                        ValveElephant = pParent.ValveElephant,

                        ValvesFermes = lValvesFermees,
                    };

                    lock (pParent.Suivant)
                    {
                        pParent.Suivant.Add(lRoute);
                    }
                }
                else
                {
                    //Ajout des detination de l'éléphant
                    foreach (var lKVValve in pParent.ValveElephant.DistanceAutreValves.OrderByDescending(o => _DonnePointPotentiel(o.Key, o.Value, pParent.MinutesElephant)))
                    {
                        if (pParent.ValvesFermes.Contains(lKVValve.Key) || pParent.ValvePersonnage.Cle == lKVValve.Key)
                        {
                            continue;
                        }

                        int lDistance = pParent.ValveElephant.DistanceAutreValves[lKVValve.Key];

                        if (pParent.MinutesElephant + lDistance >= MINUTES_TOTAL)
                        {
                            continue;
                        }

                        Valve lValve = _Valves[lKVValve.Key];

                        RouteAvecElephant lRoute = new RouteAvecElephant()
                        {
                            Precedent = pParent,

                            ActionPersonnage = ActionFaite.FermetureValve,
                            MinutesPersonnage = pParent.MinutesPersonnage + 1,
                            ValvePersonnage = pParent.ValvePersonnage,

                            ActionElephant = ActionFaite.Deplacement,
                            MinutesElephant = pParent.MinutesElephant + lDistance,
                            ValveElephant = lValve,

                            ValvesFermes = new HashSet<string>(lValvesFermees),
                        };

                        lock (pParent.Suivant)
                        {
                            pParent.Suivant.Add(lRoute);
                        }
                    }

                    if (pParent.Suivant.Count == 0)
                    {
                        //L'éléphant n'a plus d'action, il attend sagement
                        RouteAvecElephant lRoute = new RouteAvecElephant()
                        {
                            Precedent = pParent,

                            ActionPersonnage = ActionFaite.FermetureValve,
                            MinutesPersonnage = pParent.MinutesPersonnage + 1,
                            ValvePersonnage = pParent.ValvePersonnage,

                            ActionElephant = ActionFaite.Attente,
                            MinutesElephant = pParent.MinutesElephant + 1,
                            ValveElephant = pParent.ValveElephant,

                            ValvesFermes = new HashSet<string>(lValvesFermees),
                        };

                        lock (pParent.Suivant)
                        {
                            pParent.Suivant.Add(lRoute);
                        }
                    }
                }
            }
            else
            {
                //Parcours des destinations restante
                foreach (var lKVValvePersonnage in pParent.ValvePersonnage.DistanceAutreValves.OrderByDescending(o => _DonnePointPotentiel(o.Key, o.Value, pParent.MinutesPersonnage)))
                {
                    if (pParent.ValvesFermes.Contains(lKVValvePersonnage.Key) || pParent.ValvePersonnage.Cle == lKVValvePersonnage.Key)
                    {
                        continue;
                    }

                    int lDistancePersonnage = lKVValvePersonnage.Value;

                    if (pParent.MinutesPersonnage + lDistancePersonnage >= MINUTES_TOTAL)
                    {
                        continue;
                    }

                    Valve lValvePersonnage = _Valves[lKVValvePersonnage.Key];

                    if (pParent.ValvesFermes.Contains(pParent.ValveElephant.Cle) == false && pParent.ValveElephant.PeutEtreFermee && pParent.MinutesElephant < MINUTES_TOTAL)
                    {
                        //L'éléphant ferme sa valve
                        HashSet<string> lValvesFermees = new HashSet<string>(pParent.ValvesFermes);
                        lValvesFermees.Add(pParent.ValveElephant.Cle);


                        RouteAvecElephant lRoute = new RouteAvecElephant()
                        {
                            Precedent = pParent,

                            ActionPersonnage = ActionFaite.Deplacement,
                            MinutesPersonnage = pParent.MinutesPersonnage + lDistancePersonnage,
                            ValvePersonnage = lValvePersonnage,

                            ActionElephant = ActionFaite.FermetureValve,
                            MinutesElephant = pParent.MinutesElephant + 1,
                            ValveElephant = pParent.ValveElephant,

                            ValvesFermes = lValvesFermees,
                        };

                        lock (pParent.Suivant)
                        {
                            pParent.Suivant.Add(lRoute);
                        }
                    }
                    else
                    {
                        //L'éléphant se déplace
                        foreach (var lKVValveElephant in pParent.ValveElephant.DistanceAutreValves.OrderByDescending(o => _DonnePointPotentiel(o.Key, o.Value, pParent.MinutesElephant)))
                        {
                            if (pParent.ValvesFermes.Contains(lKVValveElephant.Key) || pParent.ValvePersonnage.Cle == lKVValveElephant.Key || lKVValvePersonnage.Key == lKVValveElephant.Key)
                            {
                                continue;
                            }

                            int lDistanceElephant = lKVValveElephant.Value;

                            if (pParent.MinutesPersonnage + lDistanceElephant >= MINUTES_TOTAL)
                            {
                                continue;
                            }

                            Valve lValveElephant = _Valves[lKVValveElephant.Key];
                            HashSet<string> lValvesFermees = new HashSet<string>(pParent.ValvesFermes);

                            RouteAvecElephant lRoute = new RouteAvecElephant()
                            {
                                Precedent = pParent,

                                ActionPersonnage = ActionFaite.Deplacement,
                                MinutesPersonnage = pParent.MinutesPersonnage + lDistancePersonnage,
                                ValvePersonnage = lValvePersonnage,

                                ActionElephant = ActionFaite.Deplacement,
                                MinutesElephant = pParent.MinutesElephant + lDistanceElephant,
                                ValveElephant = lValveElephant,

                                ValvesFermes = new HashSet<string>(lValvesFermees),
                            };

                            lock (pParent.Suivant)
                            {
                                pParent.Suivant.Add(lRoute);
                            }

                        }


                        if (pParent.Suivant.Count == 0)
                        {
                            //l'éléphant n'a plus d'action, il attend s'agement
                            HashSet<string> lValvesFermees = new HashSet<string>(pParent.ValvesFermes);

                            RouteAvecElephant lRoute = new RouteAvecElephant()
                            {
                                Precedent = pParent,

                                ActionPersonnage = ActionFaite.Deplacement,
                                MinutesPersonnage = pParent.MinutesPersonnage + lDistancePersonnage,
                                ValvePersonnage = lValvePersonnage,

                                ActionElephant = ActionFaite.Attente,
                                MinutesElephant = pParent.MinutesElephant + 1,
                                ValveElephant = pParent.ValveElephant,

                                ValvesFermes = new HashSet<string>(lValvesFermees),
                            };

                            lock (pParent.Suivant)
                            {
                                pParent.Suivant.Add(lRoute);
                            }

                        }

                    }
                }

            }

            //Parcours
            if (pParent.ActionElephant == ActionFaite.ApprentissagePachiderme)
            {
                //int lNombreFini = 0;
                int lTotal = pParent.Suivant.Count;

                var lResultat = Parallel.ForEach(pParent.Suivant, o =>
                {
                    _ExplorerAvecElephant(o);
                    //Console.WriteLine($"fini {++lNombreFini} / {lTotal}");
                });

            }
            else
            {
                foreach (RouteAvecElephant lRoute in pParent.Suivant)
                {
                    _ExplorerAvecElephant(lRoute);
                }
            }


            if (pParent.Suivant.Count > 1)
            {
                lock (pParent.Suivant)
                {
                    pParent.Suivant = pParent.Suivant.OrderByDescending(o => o.TotalePressionLibere)
                                                     .Take(1)
                                                     .ToList();
                }

            }


            _NombreParcours++;

            if (_NombreParcours % 10000000 == 0)
            {
                //Console.WriteLine(_NombreParcours);

                //RouteAvecElephant lRoute = pParent;
                //while(lRoute.Precedent != null)
                //{
                //    lRoute = lRoute.Precedent;
                //}

                //Console.WriteLine($"Max actuel : {lRoute.TotalePressionLibere}");
            }
        }


    }
}
