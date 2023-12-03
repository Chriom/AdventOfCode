using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour03
{
    public class Plan
    { 
        private char[][] _Plan;

        private int _HauteurPlan;
        private int _LargeurPlan;

        private List<Instruction> _Instructions = new List<Instruction>();

        public Plan(List<string> pLignes)
        {
            _ExtrairePlan(pLignes);
            _ExtraireInformations();
        }

        private void _ExtrairePlan(List<string> pLignes)
        {
            _HauteurPlan = pLignes.Count;
            _LargeurPlan = pLignes.First().Length;

            _Plan = new char[_HauteurPlan][]; 

            for(int lIndex = 0; lIndex < _HauteurPlan; lIndex++)
            {
                string lLigne = pLignes[lIndex];

                _Plan[lIndex] = lLigne.ToCharArray();
            }
        }

        private void _ExtraireInformations()
        {
            string lNombreEnCours = string.Empty;
            int lXDebut = -1;
            int lYDebut = -1;

            for(int lIndexLigne = 0; lIndexLigne < _HauteurPlan; lIndexLigne++)
            {
                for(int lIndexColonne = 0; lIndexColonne < _LargeurPlan; lIndexColonne++)
                {
                    char lCaractere = _Plan[lIndexLigne][lIndexColonne];

                    if (char.IsDigit(lCaractere))
                    {
                        if(lXDebut == -1)
                        {
                            lXDebut = lIndexColonne;
                            lYDebut = lIndexLigne;
                        }

                        lNombreEnCours += lCaractere;
                    }
                    
                    if((string.IsNullOrEmpty(lNombreEnCours) == false && char.IsDigit(lCaractere) == false) || 
                       (char.IsDigit(lCaractere) && lIndexColonne == _LargeurPlan -1))
                    {
                        Instruction lInstruction = new Instruction()
                        {
                            Nombre = int.Parse(lNombreEnCours),
                            XDebut = lXDebut,
                            YDebut = lYDebut,
                            XFin = lIndexColonne -1,
                        };

                        _ChercherCaractereAutour(lInstruction);

                        _Instructions.Add(lInstruction);

                        //Réinit
                        lNombreEnCours = string.Empty;
                        lXDebut = -1;
                        lYDebut = -1;
                    }
                }


            }
        }

        private void _ChercherCaractereAutour(Instruction pInstruction)
        {
            int lIndexColonneDebut = pInstruction.XDebut - 1;
            int lIndexColonneFin = pInstruction.XFin + 1;

            if(lIndexColonneDebut < 0)
            {
                lIndexColonneDebut = 0;
            }
            if(lIndexColonneDebut >= _LargeurPlan)
            {
                lIndexColonneFin--;
            }

            //Ligne en haut
            if(pInstruction.YDebut > 0)
            {
                for(int lIndex = lIndexColonneDebut; lIndex <= lIndexColonneFin; lIndex++)
                {
                    if(_ExtraireCaractere(lIndex, pInstruction.YDebut -1, pInstruction))
                    {
                        return;
                    }
                }
            }

            //Même ligne que le nombre
            if(pInstruction.XDebut > 0)
            {
                if (_ExtraireCaractere(pInstruction.XDebut - 1, pInstruction.YDebut, pInstruction))
                {
                    return;
                }
            }
            if (pInstruction.XFin < _LargeurPlan - 1)
            {
                if (_ExtraireCaractere(pInstruction.XFin + 1, pInstruction.YDebut, pInstruction))
                {
                    return;
                }
            }

            //Ligne en bas
            if (pInstruction.YDebut < _HauteurPlan - 1)
            {
                for (int lIndex = lIndexColonneDebut; lIndex <= lIndexColonneFin; lIndex++)
                {
                    if (_ExtraireCaractere(lIndex, pInstruction.YDebut + 1, pInstruction))
                    {
                        return;
                    }
                }
            }
        }

        private bool _ExtraireCaractere(int pX, int pY, Instruction pInstruction)
        {
            char lCaractere = _Plan[pY][pX];

            if (lCaractere != '.' && char.IsDigit(lCaractere) == false)
            {
                pInstruction.CaractereAdjacent = lCaractere;
                pInstruction.XCaractere = pX;
                pInstruction.YCaractere = pY;

                return true;
            }

            return false;
        }

        public IEnumerable<Instruction> InstructionAvecNumeroPiece => _Instructions.Where(o => o.PossedeUnCaractereAdjacent);

        private const char _ENGRENAGE = '*';

        public IEnumerable<Engrenage> DonneEngrenage()
        {
            return (from lInstruction in _Instructions
                    where lInstruction.CaractereAdjacent == _ENGRENAGE
                    group lInstruction by new { lInstruction.XCaractere, lInstruction.YCaractere }
                    into lEngrenages
                    where lEngrenages.Count() == 2
                    select new Engrenage() 
                    {
                        Instruction1 = lEngrenages.First(),
                        Instruction2 = lEngrenages.Last()
                    });
        }
    }
}
