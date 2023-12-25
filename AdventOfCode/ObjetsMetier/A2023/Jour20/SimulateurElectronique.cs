using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    public class SimulateurElectronique
    {
        private List<IModule> _Modules;

        private Dictionary<string, IModule> _DicoModules;

        public SimulateurElectronique(List<IModule> pModules)
        {
            _Modules = pModules;
            _DicoModules = _Modules.ToDictionary(o => o.Cle, o => o);

            _AssocierModules();
        }

        private void _AssocierModules()
        {
            foreach(IModule lModule in _Modules)
            {
                lModule.LierModules(_DicoModules);
            }

            foreach(ModuleBase lModel in _Modules)
            {
                lModel.ApresLiaisonModules();
            }

            //Actualisation avec les nom éventuellement créé
            _Modules = _DicoModules.Select(o => o.Value)
                                   .ToList();
        }

        private const string _MODULE_DEBUT = "broadcaster";

        public decimal DonneNombreImpulsionApresAppuisSurBouton(int pNombreAppui)
        {
            decimal lNombreImpulsionBasse = 0;
            decimal lNombreImpulsionHaute = 0;
            IModule lBroadCast = _DicoModules[_MODULE_DEBUT];

            for(int lNumeroImpulsion = 0; lNumeroImpulsion < pNombreAppui; lNumeroImpulsion++)
            {

                ImpulsionDiffusee lImpulsionATraiter = new ImpulsionDiffusee()
                {
                    Impulsion = TypeImpulsion.Basse,
                    ModuleSource = null,
                    ModuleDestination = lBroadCast,
                };


                Queue<ImpulsionDiffusee> lImpulsionsAttente = new Queue<ImpulsionDiffusee>();

                do
                {
                    if(lImpulsionATraiter.Impulsion == TypeImpulsion.Basse)
                    {
                        lNombreImpulsionBasse++;
                    }
                    else
                    {
                        lNombreImpulsionHaute++;
                    }
                     


                    foreach(ImpulsionDiffusee lImpulsionEnfant in lImpulsionATraiter.ModuleDestination.TraiterImpulsion(lImpulsionATraiter))
                    {
                        lImpulsionsAttente.Enqueue(lImpulsionEnfant);
                    }


                    if(lImpulsionsAttente.Count > 0)
                    {
                        lImpulsionATraiter = lImpulsionsAttente.Dequeue();
                    }
                    else
                    {
                        lImpulsionATraiter = null;
                    }

                } while (lImpulsionATraiter != null);
            }


            return lNombreImpulsionBasse * lNombreImpulsionHaute;
        }


        private const string _MODULE_FIN = "rx";
        public decimal DonneNombreAppuiSurBoutonPourActiverModuleRx()
        {
            //rx < dg <     lk
            //              zv
            //              sp
            //              xt

            //dg : Conjonction => il faut que les 4 précédent soit high en même temps pour impulsion basse dans rx

            IModule lModuleFin = _DicoModules[_MODULE_FIN];
            string lCleAvantFin = string.Empty;
            //On choppe les parents du parent (ceux qui activent dg)
            List<IModule> lParents = lModuleFin.ModulesParent;

            while(lParents.Count == 1)
            {
                lCleAvantFin = lParents.First().Cle;
                lParents = lParents.First().ModulesParent;
            }

            Dictionary<string, decimal> lDicoCycle = lParents.ToDictionary(o => o.Cle, o => (decimal)0);

            int lNombreAppuyeBouton = 0;
            IModule lBroadCast = _DicoModules[_MODULE_DEBUT];

            do
            {
                lNombreAppuyeBouton++;

                ImpulsionDiffusee lImpulsionATraiter = new ImpulsionDiffusee()
                {
                    Impulsion = TypeImpulsion.Basse,
                    ModuleSource = null,
                    ModuleDestination = lBroadCast,
                };


                Queue<ImpulsionDiffusee> lImpulsionsAttente = new Queue<ImpulsionDiffusee>();

                do
                {
                    //Récupération du cycle

                    if (lDicoCycle.ContainsKey(lImpulsionATraiter.ModuleSource?.Cle ?? string.Empty) && lImpulsionATraiter.ModuleDestination.Cle == lCleAvantFin && lImpulsionATraiter.Impulsion == TypeImpulsion.Haute)
                    {
                        lDicoCycle[lImpulsionATraiter.ModuleSource.Cle] = lNombreAppuyeBouton;
                    }

                    foreach (ImpulsionDiffusee lImpulsionEnfant in lImpulsionATraiter.ModuleDestination.TraiterImpulsion(lImpulsionATraiter))
                    {
                        lImpulsionsAttente.Enqueue(lImpulsionEnfant);
                    }


                    if (lImpulsionsAttente.Count > 0)
                    {
                        lImpulsionATraiter = lImpulsionsAttente.Dequeue();
                    }
                    else
                    {
                        lImpulsionATraiter = null;
                    }

                } while (lImpulsionATraiter != null);

                if (lDicoCycle.All(o => o.Value > 0))
                {
                    //On sort quand on a déterminé les cycle de tous le monde en espérant que le cycle ne soit pas erratique et qu'il faillent en garder plusieurs
                    break;
                }

            } while (true);



            //Debug du dico
            Console.WriteLine("Cycle trouvé : ");
            foreach(var lKv in lDicoCycle)
            {
                Console.WriteLine($"{lKv.Key} - {lKv.Value}");
            }
            Console.WriteLine();

            //Logiquement c'est le PPCM des valeurs du dico qui active Rx

            decimal lResultat = lDicoCycle.First().Value;

            foreach (var lKv in lDicoCycle.Skip(1))
            {
                lResultat = MathsHelper.PlusPetitCommunMultiplicateur(lResultat, lKv.Value);
            }

            return lResultat;
        }
    }
}
