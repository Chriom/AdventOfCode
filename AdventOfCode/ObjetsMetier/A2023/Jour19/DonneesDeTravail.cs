using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Utilitaires;

namespace AdventOfCode.ObjetsMetier.A2023.Jour19
{
    public class DonneesDeTravail
    {
        private List<FluxDeTravail> _Flux;

        private List<Element> _Elements;


        public DonneesDeTravail(List<FluxDeTravail> pFlux, List<Element> pElements)
        {
            _Flux = pFlux;
            _Elements = pElements;
        }


        public const string FLUX_DEBUT = "in";
        public const string FLUX_POUBELLE = "R";
        public const string FLUX_ACCEPTE = "A";

        public decimal ExecuterFluxDeTravail()
        {
            decimal lResultat = 0;

            _ReduireFluxDeTravail();

            Dictionary<string, FluxDeTravail> lDicoFlux = _Flux.ToDictionary(o => o.NomFlux, o => o);


            
            foreach(Element lElement in _Elements)
            {
                FluxDeTravail lFluxTest = lDicoFlux[FLUX_DEBUT];
                do
                {
                    string lNouveauFlux = lFluxTest.DonneProchainFlux(lElement);

                    if (lNouveauFlux == FLUX_ACCEPTE)
                    {
                        lResultat += lElement.SommeTotal;
                        lFluxTest = null;
                    }
                    else if(lNouveauFlux == FLUX_POUBELLE)
                    {
                        lFluxTest = null;
                    }
                    else
                    {
                        lFluxTest = lDicoFlux[lNouveauFlux];
                    }

                } while (lFluxTest != null);
            }



            return lResultat;
        }

        public decimal DonneToutesLesCombinaisonsPossible()
        {
            _ReduireFluxDeTravail();

            Dictionary<string, FluxDeTravail> lDicoFlux = _Flux.ToDictionary(o => o.NomFlux, o => o);


            List<NoeudTest> lNoeudComplet = new List<NoeudTest>();

            NoeudTest lNoeudDebut = _DonneNoeudDepart();
            lNoeudComplet.Add(lNoeudDebut);


            Queue<NoeudTest> lQueue = new Queue<NoeudTest>();

            lQueue.Enqueue(lNoeudDebut);

            NoeudTest lNoeud = lQueue.Dequeue();
            do
            {
                if(lNoeud.EstTerminé == false)
                {
                    //Si le noeud est fini pas besoin de chercher la suite
                    FluxDeTravail lFluxTest = lDicoFlux[lNoeud.FluxSuivant];

                    //Création du premier enfant qui aura ensuite sa plage coupé
                    NoeudTest lEnfant = _CreerNoeudEnfant(lNoeud);

                    foreach(Instruction lInstruction in lFluxTest.Instructions)
                    {
                        //Parcours de toutes les instructions (forcément pas unique)
                        //si < ou > Split de la plage sur les bonne bornes
                        //Création d'un noeud enfant sur la valeur testé
                        //Passage de l'instruction suivante sur le non testé

                        
                        if(lInstruction.SensComparaison != Instruction.Comparaison.Aucune)
                        {
                            PlageValeur<int> lPlageTest = lInstruction.PartieElementTest switch
                            {
                                'x' => lEnfant.Plage_ExtremementBeauARegarder,
                                'm' => lEnfant.Plage_Musical,
                                'a' => lEnfant.Plage_Aerodynamique,
                                's' => lEnfant.Plage_Brillant,
                                _ => throw new Exception("On doit toujours pouvoir tester"),
                            };

                            //Détermine si on doit couper
                            //Si pas => pas besoin de tester les instruction suivante

                            if(lInstruction.SensComparaison == Instruction.Comparaison.Inferieur)
                            {
                                if (lInstruction.NombreComparaison <= lPlageTest.BorneInferieur)
                                {
                                    //< Nombre <= Plage début
                                    //Rien dedans => on passe au suivant
                                    continue;
                                }
                                else if(lPlageTest.BorneSuperieur < lInstruction.NombreComparaison)
                                {
                                    //Plage fin <= Nombre
                                    //Tous dedans => pas besoin de coupé
                                    lEnfant.FluxSuivant = lInstruction.NomFluxSiReussi;
                                }
                                else
                                {
                                    //On coupe
                                    List<PlageValeur<int>> lPlagesCoupées = lPlageTest.DecouperPlage(lInstruction.NombreComparaison - 1).ToList();

                                    //Le premier élément passe et le deuxième est sur le nouvelle enfant
                                    lEnfant.AffecterPlage(lInstruction.PartieElementTest, lPlagesCoupées[0]);
                                    lEnfant.FluxSuivant = lInstruction.NomFluxSiReussi;

                                    lNoeudComplet.Add(lEnfant);
                                    lQueue.Enqueue(lEnfant);

                                    lEnfant = _CopierNoeudEnfant(lEnfant);

                                    //Le restant va sur l'instruction suivante
                                    lEnfant.AffecterPlage(lInstruction.PartieElementTest, lPlagesCoupées[1]);
                                }
                            }
                            else if(lInstruction.SensComparaison == Instruction.Comparaison.Superieur)
                            {
                                if (lInstruction.NombreComparaison <= lPlageTest.BorneInferieur)
                                {
                                    //Nombre <= Plage début
                                    //Tous dedans => pas besoin de coupé
                                    lEnfant.FluxSuivant = lInstruction.NomFluxSiReussi;
                                   
                                }
                                else if (lPlageTest.BorneSuperieur < lInstruction.NombreComparaison)
                                {
                                    //Plage fin <= Nombre
                                    //Rien dedans => on passe au suivant
                                    continue;
                                }
                                else
                                {
                                    //On coupe
                                    List<PlageValeur<int>> lPlagesCoupées = lPlageTest.DecouperPlage(lInstruction.NombreComparaison).ToList();

                                    //Le deuxième élément passe et le premier est sur le nouvelle enfant
                                    lEnfant.AffecterPlage(lInstruction.PartieElementTest, lPlagesCoupées[1]);
                                    lEnfant.FluxSuivant = lInstruction.NomFluxSiReussi;
                                    lNoeudComplet.Add(lEnfant);
                                    lQueue.Enqueue(lEnfant);

                                    lEnfant = _CopierNoeudEnfant(lEnfant);

                                    //Le restant va sur l'instruction suivante
                                    lEnfant.AffecterPlage(lInstruction.PartieElementTest, lPlagesCoupées[0]);
                                }
                            }

                        }
                        else
                        {
                            //Si c'est un = le restant est sur un nouveau noeud l'instruction si rebelote
                            lEnfant.FluxSuivant = lInstruction.NomFluxSiReussi;
                            lNoeudComplet.Add(lEnfant);
                            lQueue.Enqueue(lEnfant);
                        }

                    }



                }             

                //Fin
                if(lQueue.Count > 0)
                {
                    lNoeud = lQueue.Dequeue();
                }
                else
                {
                    lNoeud = null;
                }

            } while (lNoeud != null);

            return lNoeudComplet.Where(o => o.AComtabiliser).Sum(o => o.TotalDansPlage);
        }

        private void _ReduireFluxDeTravail()
        {
            bool lReduction = false;
            do
            {
                lReduction = false;

                //Réduction des instructions similaire
                foreach (FluxDeTravail lFlux in _Flux)
                {
                    if(lFlux.Instructions.Count > 1 && lFlux.Instructions.Select(o => o.NomFluxSiReussi).Distinct().Count() == 1)
                    {
                        //Tous pareil, on prend la dernière
                        lFlux.Instructions = new List<Instruction>() { lFlux.Instructions.Last() };
                        lReduction = true;
                    }
                }

                foreach(FluxDeTravail lFluxASupprimer in _Flux.Where(o => o.Instructions.Count == 1))
                {
                    //Plus qu'une instruction, on remplace partout le workflow par la fin
                    string lNomFluxRecherche = lFluxASupprimer.NomFlux;
                    string lNomFluxRemplace = lFluxASupprimer.Instructions.Last().NomFluxSiReussi;

                    foreach(FluxDeTravail lFlux in _Flux)
                    {
                        foreach(Instruction lInstruction in lFlux.Instructions)
                        {
                            if(lInstruction.NomFluxSiReussi == lNomFluxRecherche)
                            {
                                lInstruction.NomFluxSiReussi = lNomFluxRemplace;
                                lReduction = true;
                            }
                        }
                    }
                }


                if (lReduction)
                {
                    _Flux = _Flux.Where(o => o.Instructions.Count > 1)
                                 .ToList();
                }

            } while (lReduction);
        }

        private NoeudTest _DonneNoeudDepart()
        {
            NoeudTest lNoeud = new NoeudTest()
            {
                FluxSuivant = FLUX_DEBUT,
                Plage_ExtremementBeauARegarder = PlageValeur<int>.DonnePlageValeurDepuisBornes(1,4000),
                Plage_Musical = PlageValeur<int>.DonnePlageValeurDepuisBornes(1, 4000),
                Plage_Aerodynamique = PlageValeur<int>.DonnePlageValeurDepuisBornes(1, 4000),
                Plage_Brillant = PlageValeur<int>.DonnePlageValeurDepuisBornes(1, 4000),
            };

            return lNoeud;
        }

        private NoeudTest _CreerNoeudEnfant(NoeudTest pParent)
        {
            NoeudTest lEnfant = new NoeudTest()
            {
                Parent = pParent,
                FluxTesté = pParent.FluxSuivant,
                Plage_ExtremementBeauARegarder = pParent.Plage_ExtremementBeauARegarder.Copie(),
                Plage_Musical = pParent.Plage_Musical.Copie(),
                Plage_Aerodynamique = pParent.Plage_Aerodynamique.Copie(),
                Plage_Brillant = pParent.Plage_Brillant.Copie(),
            };

            pParent.Enfant.Add(lEnfant);

            return lEnfant;
        }

        private NoeudTest _CopierNoeudEnfant(NoeudTest pEnfantACopier)
        {
            NoeudTest lEnfantCopie = new NoeudTest()
            {
                Parent = pEnfantACopier.Parent,
                FluxTesté = pEnfantACopier.FluxTesté,
                Plage_ExtremementBeauARegarder = pEnfantACopier.Plage_ExtremementBeauARegarder.Copie(),
                Plage_Musical = pEnfantACopier.Plage_Musical.Copie(),
                Plage_Aerodynamique = pEnfantACopier.Plage_Aerodynamique.Copie(),
                Plage_Brillant = pEnfantACopier.Plage_Brillant.Copie(),
            };

            pEnfantACopier.Parent.Enfant.Add(lEnfantCopie);

            return lEnfantCopie;
        }
    }
}
