using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2023.Jour19
{
    public class Instruction
    {
        public char PartieElementTest { get; set; }
        public Comparaison SensComparaison { get; set; }

        public int NombreComparaison { get; set; }
        public string NomFluxSiReussi { get; set; }


        public bool PasseLeTest(Element pElement)
        {
            if(SensComparaison == Comparaison.Aucune)
            {
                return true;
            }

            int lNombreTest = PartieElementTest switch
            {
                'x' => pElement.ExtremementBeauARegarder,
                'm' => pElement.Musical,
                'a' => pElement.Aerodynamique,
                's' => pElement.Brillant,
                _ => throw new ArgumentOutOfRangeException("Impossible")
            };

            return SensComparaison switch
            {
                Comparaison.Inferieur => lNombreTest < NombreComparaison,
                Comparaison.Superieur => lNombreTest > NombreComparaison,
                _ => throw new ArgumentOutOfRangeException("On ne devrait pas être la")
            };
        }

        public enum Comparaison
        {
            Aucune,
            Inferieur,
            Superieur
        }
    }
}
