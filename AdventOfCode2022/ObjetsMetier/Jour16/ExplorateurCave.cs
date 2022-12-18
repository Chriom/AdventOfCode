using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.ObjetsMetier.Jour12;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2022.ObjetsMetier.Jour16
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
            if(pParent.Minutes >= MINUTES_TOTAL)
            {
                return;
            }

            if(pParent.ValvesFermes.Contains(pParent.Valve.Cle) == false && pParent.Valve.PeutEtreFermee)
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



                if(pParent.ValvesFermes.Contains(pParent.ValveElephant.Cle) == false && pParent.ValveElephant.PeutEtreFermee && pParent.MinutesElephant < MINUTES_TOTAL)
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

                    pParent.Suivant.Add(lRoute);
                }
                else
                {
                    //Ajout des detination de l'éléphant
                    foreach (string lCleValve in pParent.ValveElephant.DistanceAutreValves.Keys)
                    {
                        if (pParent.ValvesFermes.Contains(lCleValve) || pParent.ValvePersonnage.Cle == lCleValve)
                        {
                            continue;
                        }

                        int lDistance = pParent.ValveElephant.DistanceAutreValves[lCleValve];

                        if (pParent.MinutesElephant + lDistance >= MINUTES_TOTAL)
                        {
                            continue;
                        }

                        Valve lValve = _Valves[lCleValve];

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

                        pParent.Suivant.Add(lRoute);
                    }

                    if(pParent.Suivant.Count == 0)
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

                        pParent.Suivant.Add(lRoute);
                    }
                }               
            }
            else
            {
                //Parcours des destinations restante
                foreach (string lCleValvePersonnage in pParent.ValvePersonnage.DistanceAutreValves.Keys)
                {
                    if (pParent.ValvesFermes.Contains(lCleValvePersonnage) || pParent.ValvePersonnage.Cle == lCleValvePersonnage)
                    {
                        continue;
                    }

                    int lDistancePersonnage = pParent.ValvePersonnage.DistanceAutreValves[lCleValvePersonnage];

                    if (pParent.MinutesPersonnage + lDistancePersonnage >= MINUTES_TOTAL)
                    {
                        continue;
                    }

                    Valve lValvePersonnage = _Valves[lCleValvePersonnage];

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

                        pParent.Suivant.Add(lRoute);
                    }
                    else
                    {
                        //L'éléphant se déplace
                        foreach (string lCleValveElephant in pParent.ValveElephant.DistanceAutreValves.Keys)
                        {
                            if (pParent.ValvesFermes.Contains(lCleValveElephant) || pParent.ValvePersonnage.Cle == lCleValveElephant || lCleValvePersonnage == lCleValveElephant)
                            {
                                continue;
                            }

                            int lDistanceElephant = pParent.ValveElephant.DistanceAutreValves[lCleValveElephant];

                            if (pParent.MinutesPersonnage + lDistanceElephant >= MINUTES_TOTAL)
                            {
                                continue;
                            }

                            Valve lValveElephant = _Valves[lCleValveElephant];
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

                            pParent.Suivant.Add(lRoute);

                        }


                        if(pParent.Suivant.Count == 0)
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

                            pParent.Suivant.Add(lRoute);
                        }

                    }
                }

            }

            //Parcours
            int lMaxEnfant = 1;

            List<RouteAvecElephant> lASupprimer = new List<RouteAvecElephant>();

            if(pParent.ActionElephant == ActionFaite.ApprentissagePachiderme)
            {
                var lResultat = Parallel.ForEach(pParent.Suivant, o => _ExplorerAvecElephant(o));

                if(lResultat.IsCompleted)
                {
                    foreach(RouteAvecElephant lRoute in pParent.Suivant)
                    {
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
                }
            }
            else
            {
                foreach (RouteAvecElephant lRoute in pParent.Suivant)
                {
                    _ExplorerAvecElephant(lRoute);

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
            }
            foreach (RouteAvecElephant lRoute in pParent.Suivant)
            {

                
                List<Task> lTasks = new List<Task>();

                _ExplorerAvecElephant(lRoute);

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

            foreach (RouteAvecElephant lRouteASupprime in lASupprimer)
            {
                pParent.Suivant.Remove(lRouteASupprime);
            }

            _NombreParcours++;

            if (_NombreParcours % 10000 == 0)
            {
                Debug.WriteLine(_NombreParcours);

                RouteAvecElephant lRoute = pParent;
                while(lRoute.Precedent != null)
                {
                    lRoute = lRoute.Precedent;
                }

                Debug.WriteLine($"Max actuel : {lRoute.TotalePressionLibere}");
            }
        }


    }
}
