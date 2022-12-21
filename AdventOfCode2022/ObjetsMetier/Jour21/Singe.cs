using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour21
{
    public class Singe
    {
        public string Nom { get; set; }

        public string Operation { get; set; }

        private string _NomSinge1;

        public Singe Singe1 { get; set; }

        private string _NomSinge2;

        public Singe Singe2 { get; set; }

        private Calcul _Calcul;



        public Singe(string pChaine)
        {
            string[] lSplit = pChaine.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            Nom = lSplit[0];
            Operation = lSplit[1];

            

            if (decimal.TryParse(Operation, out decimal lResultat))
            {
                _Calcul = Calcul.Nombre;
            }
            else
            {
                string[] lOperationSplit = Operation.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                _NomSinge1 = lOperationSplit[0];
                _NomSinge2 = lOperationSplit[2];

                _Calcul = lOperationSplit[1] switch
                {
                    "+" => Calcul.Addition,
                    "-" => Calcul.Soustraction,
                    "*" => Calcul.Multiplication,
                    "/" => Calcul.Division,
                    _ => throw new NotImplementedException(),
                };

            }
        }

        public void ModifierOperation(decimal pNombre)
        {
            if(Nom != "humn")
            {
                return;
            }

            _Calcul = Calcul.Nombre;

            Operation = pNombre.ToString();

        }

        public void AssocierSinges(Dictionary<string, Singe> pDicoSinges)
        {
            if (string.IsNullOrEmpty(_NomSinge1) == false)
            {
                Singe1 = pDicoSinges[_NomSinge1];
            }

            if(string.IsNullOrEmpty(_NomSinge2) == false)
            {
                Singe2 = pDicoSinges[_NomSinge2];
            }
        }

        public decimal Resultat
        {
            get
            {
                if (_Calcul == Calcul.Nombre)
                {
                    return decimal.Parse(Operation);
                }

                return _Calcul switch
                {
                    Calcul.Addition => Singe1.Resultat + Singe2.Resultat,
                    Calcul.Soustraction => Singe1.Resultat - Singe2.Resultat,
                    Calcul.Multiplication => Singe1.Resultat * Singe2.Resultat,
                    Calcul.Division =>Singe1.Resultat / Singe2.Resultat,
                    _ => throw new NotImplementedException(),
                };
            }
            
        }

        public decimal EffectueOperation()
        {
            if (decimal.TryParse(Operation, out decimal lResultat))
            {
                return lResultat;
            }

            return 0;
        }

    }
}
