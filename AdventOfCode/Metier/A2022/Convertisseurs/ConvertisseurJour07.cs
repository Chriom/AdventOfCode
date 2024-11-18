using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Interfaces;
using AdventOfCode.ObjetsMetier.A2022.Jour07;

namespace AdventOfCode.Metier.A2022.Convertisseurs
{
    internal class ConvertisseurJour07
    {
        private Dossier _DossierCourant = null;

        public IEnumerable<IEmplacementStockage> ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                if (lEntree.StartsWith("$"))
                {
                    _TraitementCommande(lEntree);
                }
                else
                {
                    _TraitementLs(lEntree);
                }
            }

            _RetournerALaRacine();

            return new List<IEmplacementStockage>() { _DossierCourant };
        }

        private void _TraitementCommande(string pCommande)
        {
            string[] lSplit = pCommande.Split(' ');
            string lCommande = lSplit[1];

            switch (lCommande)
            {
                case "cd":
                    string lNomDossier = lSplit[2];

                    if (lNomDossier != "..")
                    {
                        Dossier lDossier = new Dossier(lNomDossier, _DossierCourant);

                        if (_DossierCourant != null)
                        {
                            _DossierCourant.Enfants.Add(lDossier);
                        }

                        _DossierCourant = lDossier;
                    }
                    else
                    {
                        if (_DossierCourant != null)
                        {
                            _DossierCourant = _DossierCourant.Parent;
                        }
                    }
                    break;
                case "ls":
                    //Rien : on part du principe que c'est la seule autre commande
                    break;
                default:
                    throw new Exception("Commande non supporté");
            }
        }

        private void _TraitementLs(string pEntree)
        {
            string[] lSplit = pEntree.Split(' ');

            //Les dir ne sont pas traité vu que ajouté sur le cd
            if (lSplit[0] != "dir")
            {
                decimal lTaille = decimal.Parse(lSplit[0]);
                string lNom = lSplit[1];

                _DossierCourant.Enfants.Add(new Fichier(lNom, _DossierCourant, lTaille));
            }
        }

        private void _RetournerALaRacine()
        {
            while(_DossierCourant.Parent != null)
            {
                _DossierCourant = _DossierCourant.Parent;
            }
        }
    }
}
