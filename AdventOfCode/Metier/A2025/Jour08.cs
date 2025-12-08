using AdventOfCode.Commun.Helpers;
using AdventOfCode.ObjetsMetier.A2025.Jour08;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Metier.A2025
{
    public class Jour08 : AJour<BoiteDerivation>
    {
        public override int NumeroJour => 8;

        public override int Annee => 2025;
        public override string DonneResultatUn()
        {
            ConnecteurBoites lConnecteur = new ConnecteurBoites(_Entrees.ToList());

            return lConnecteur.ProduitDes3PlusGrandCircuitsApresNConnections(EntreesHelper.EstEnmodeTest ? 10 : 1000).ToString();
        }

        public override string DonneResultatDeux()
        {
            ConnecteurBoites lConnecteur = new ConnecteurBoites(_Entrees.ToList());

            return lConnecteur.ProduitDesXDesDeuxBoitesQuiFormentUnCircuitUnique().ToString();
        }


        protected override IEnumerable<BoiteDerivation> _ConvertirEntrees(IEnumerable<string> pEntrees)
        {
            foreach(string lEntree in pEntrees)
            {
                string[] lSplit = lEntree.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                yield return new BoiteDerivation()
                {
                    Position = new Commun.ObjetsUtilitaire.Position3D(int.Parse(lSplit[0]), int.Parse(lSplit[1]), int.Parse(lSplit[2]))                    
                };
            }

        }
    }
}
