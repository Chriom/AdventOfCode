using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.ObjetsMetier.Jour20
{
    [DebuggerDisplay("{_Debug}")]
    public class ListeCirculaire
    {
        private List<Donnees> _Donnees;


        public string _Debug
        {
            get
            {
                StringBuilder lSb = new StringBuilder();

                Donnees lDonnee = _Donnees.First(o => o.Valeur == 0);
                do
                {
                    lSb.Append($"{lDonnee.Valeur}, ");

                    lDonnee = lDonnee.Suivant;
                } while (lDonnee.Valeur != 0);

                return lSb.ToString();
            }
        }
        public ListeCirculaire(List<Donnees> pDonnees)
        {
            _Donnees = pDonnees;
        }

        public const decimal NOMBRE_MAGIQUE = 811589153;

        public void PermutterListe()
        {
            foreach (Donnees lDonnees in _Donnees)
            {
                if (lDonnees.Valeur == 0)
                {
                    lDonnees.EstTraitee = true;
                    continue;
                }

                //Sortie de la liste
                lDonnees.Precedent.Suivant = lDonnees.Suivant;
                lDonnees.Suivant.Precedent = lDonnees.Precedent;

                //Parcours pour mettre au bon endroit
                decimal lNombre = lDonnees.Valeur;

                if (Math.Abs(lNombre) > _Donnees.Count)
                {
                    // -1 élément dans la liste !!!
                    lNombre = lNombre % (_Donnees.Count -1);
                }

                if (lNombre < 0)
                {
                    Donnees lDonneePrecedente = lDonnees;

                    while (lNombre < 0)
                    {
                        lDonneePrecedente = lDonneePrecedente.Precedent;
                        lNombre++;
                    }

                    lDonnees.Suivant = lDonneePrecedente;
                    lDonnees.Precedent = lDonneePrecedente.Precedent;

                    lDonnees.Precedent.Suivant = lDonnees;
                    lDonneePrecedente.Precedent = lDonnees;
                }
                else if (lNombre > 0)
                {
                    Donnees lDonneeSuivante = lDonnees;

                    while (lNombre > 0)
                    {
                        lDonneeSuivante = lDonneeSuivante.Suivant;
                        lNombre--;
                    }

                    lDonnees.Precedent = lDonneeSuivante;
                    lDonnees.Suivant = lDonneeSuivante.Suivant;

                    lDonnees.Suivant.Precedent = lDonnees;
                    lDonneeSuivante.Suivant = lDonnees;                  
                }



                lDonnees.EstTraitee = true;
            }
        }

        public decimal DonneSommeDeTerme(int pDebut, int pFin, int pNombreTerme)
        {
            decimal lResultat = 0;

            //On commence à celle à 0
            Donnees lDonnee = _Donnees.First(o => o.Valeur == 0);

            for(int lIndex = pDebut; lIndex <= pFin; lIndex++)
            {
                if (lIndex % pNombreTerme == 0)
                {
                    lResultat += lDonnee.Valeur;
                }

                lDonnee = lDonnee.Suivant;
            }


            return lResultat;
        }

        public void AppliquerNombreMagique()
        {
            foreach(Donnees lDonnee in _Donnees)
            {
                lDonnee.Valeur = lDonnee.Valeur * NOMBRE_MAGIQUE;
            }
        }
    }
}
