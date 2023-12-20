using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour20
{
    
    public class ConjonctionModule : ModuleBase
    {

        private List<EtatInterneModule> _EtatParents;
        public ConjonctionModule()
        {
            _EtatParents = new List<EtatInterneModule>();
        }


        public override IEnumerable<ImpulsionDiffusee> TraiterImpulsion(ImpulsionDiffusee pImpulsion)
        {
            EtatInterneModule lEtat = _EtatParents.First(o => o.Cle == pImpulsion.ModuleSource.Cle);
            lEtat.TypeImpulsion = pImpulsion.Impulsion;

            TypeImpulsion lImpulsionEnvoye = TypeImpulsion.Haute;

            if(_EtatParents.All(o => o.TypeImpulsion == TypeImpulsion.Haute))
            {
                lImpulsionEnvoye = TypeImpulsion.Basse;
            }

            foreach(IModule lEnfant in ModulesEnfant)
            {
                yield return new ImpulsionDiffusee()
                {
                    ModuleSource = this,
                    ModuleDestination = lEnfant,
                    Impulsion = lImpulsionEnvoye,
                };
            }


            EtatInterne = string.Join("_", _EtatParents);
        }

        public override void ApresLiaisonModules()
        {
            foreach(IModule lParent in ModulesParent)
            {
                _EtatParents.Add(new EtatInterneModule()
                {
                    Cle = lParent.Cle,
                    TypeImpulsion = TypeImpulsion.Basse,
                });
            }

            EtatInterne = string.Join("_", _EtatParents);
        }

        private class EtatInterneModule
        {
            public string Cle { get; set; }
            public TypeImpulsion TypeImpulsion { get; set; }

            public override string ToString()
            {
                return $"{Cle}|{(int)TypeImpulsion}";
            }
        }
    }
}
