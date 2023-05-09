using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2022.Jour03
{
    public class ContenuSac
    {

        public ContenuSac(string pContenu)
        {
            Contenu = pContenu;
        }

        public string Contenu { get; init; }

        private IEnumerable<char> _PartieGauche => Contenu.Substring(0, Contenu.Length / 2).Select(o => o);

        private IEnumerable<char> _PartieDroite => Contenu.Substring(Contenu.Length / 2).Select(o => o);

        private char _CharactereCommun => _PartieGauche.Intersect(_PartieDroite).First();

        public int PrioriteCharactereCommun => DonnePriorite(_CharactereCommun);

        public static int DonnePriorite(char pCharactere)
        {
            if (char.IsUpper(pCharactere))
            {
                return pCharactere - 'A' + 27;//65 A en Ascii et 27 en priorité
            }
            else if (char.IsLower(pCharactere))
            {
                return pCharactere - 'a' + 1; //96 a en Ascci et 1 en priorité
            }

            throw new ArgumentOutOfRangeException(nameof(pCharactere), $"{pCharactere} n'est pas une lettre");
        }
    }
}
