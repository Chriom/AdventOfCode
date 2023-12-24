using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.ObjetsUtilitaire;

namespace AdventOfCode.ObjetsMetier.A2023.Jour23
{
    public class CarteRandonnee
    {
        private TypeCase[][] _Carte;

        private int _Hauteur;
        private int _Largeur;


        private Position2D _Debut;
        private Position2D _Fin;

        public CarteRandonnee(TypeCase[][] pCarte)
        {
            _Carte = pCarte;
            _Hauteur = pCarte.Length;
            _Largeur = pCarte[0].Length;

            _ChercherDebutEtFin();
        }

        private void _ChercherDebutEtFin()
        {
            //Début
            for(int lIndexDebut = 0; lIndexDebut < _Largeur; lIndexDebut++)
            {
                if (_Carte[0][lIndexDebut] == TypeCase.Chemin)
                {
                    _Debut = new Position2D(lIndexDebut, 0);
                    break;
                }
            }

            //Fin
            for (int lIndexDebut = 0; lIndexDebut < _Largeur; lIndexDebut++)
            {
                if (_Carte[_Hauteur - 1][lIndexDebut] == TypeCase.Chemin)
                {
                    _Fin = new Position2D(lIndexDebut, _Hauteur - 1);
                    break;
                }
            }
        }

        public int DonnePlusLongChemin(bool pPentesSontGlissante = true)
        {
            return _DonneDistanceMaxParcoursArrivantALaFin(pPentesSontGlissante);
        }

        private int _DonneDistanceMaxParcoursArrivantALaFin(bool pPentesSontGlissante)
        {
            List<Parcours> lParcoursFin = new List<Parcours>();


            Parcours lParcours = new Parcours(_Carte, _Debut, pPentesSontGlissante);


            Queue<Parcours> lAParcourir = new Queue<Parcours>();


            //Recherche de toutes les intersections
            Dictionary<string, Intersection> lDicoIntersections = new Dictionary<string, Intersection>();

            Dictionary<string, int> lDicoDistance = new Dictionary<string, int>();
            HashSet<string> lEmbranchementsTraite = new HashSet<string>();

            //Ajout du point de départ
            Intersection lIntersectionDepart = new Intersection()
            {
                Position = new Position2D(_Debut.X, _Debut.Y)
            };

            lDicoIntersections.Add(lIntersectionDepart.Cle, lIntersectionDepart);

            do
            {
                int lNombreparcouruAvantTraitement = lParcours.NombreDeCasesParcourus;
                Position2D lPositionDebut = new Position2D(lParcours.PositionFinaleParent.X, lParcours.PositionFinaleParent.Y);

                Intersection lParent = lDicoIntersections[lParcours.PositionFinaleParent.Cle];

                
                List<Parcours> lEmbranchements = lParcours.ParcourirJusquaEmbranchement();


                //Ajout des embranchement à traiter
                foreach(Parcours lEmbranchement in lEmbranchements)
                {
                    Position2D lPositionIntersection = lEmbranchement.PositionFinaleParent; //Position final avant d'avoir les deux direction

                    if (lDicoIntersections.ContainsKey(lPositionIntersection.Cle))
                    {
                        //Déja on ajoute l'enfant si pas dans la liste
                        Intersection lIntersection = lDicoIntersections[lPositionIntersection.Cle];

                        if(lParent.IntersectionLies.Any(o => o.Cle == lIntersection.Cle) == false)
                        {
                            //Dans le dico des distance
                            int lDistance = Math.Abs(lNombreparcouruAvantTraitement - lEmbranchement.NombreDeCasesParcourus - 1);
                            string lCle1 = $"{lPositionDebut.Cle}__{lPositionIntersection.Cle}";
                            string lCle2 = $"{lPositionIntersection.Cle}__{lPositionDebut.Cle}";

                            lDicoDistance.TryAdd($"{lPositionDebut.Cle}__{lPositionIntersection.Cle}", lDistance);
                            lDicoDistance.TryAdd($"{lPositionIntersection.Cle}__{lPositionDebut.Cle}", lDistance);

                            lParent.IntersectionLies.Add(lIntersection);

                        }

                        if(lEmbranchementsTraite.Add(lEmbranchement.ClePosition) == true)
                        {
                            lAParcourir.Enqueue(lEmbranchement);
                        }
                        
                    }
                    else
                    {
                        //Pas encore
                        Intersection lIntersection = new Intersection()
                        {
                            Position = new Position2D(lEmbranchement.PositionFinaleParent.X, lEmbranchement.PositionFinaleParent.Y),
                        };

                        lDicoIntersections.Add(lPositionIntersection.Cle, lIntersection);

                        //Dans le dico des distance
                        int lDistance = Math.Abs(lNombreparcouruAvantTraitement - lEmbranchement.NombreDeCasesParcourus - 1);
                        lDicoDistance.TryAdd($"{lPositionDebut.Cle}__{lPositionIntersection.Cle}", lDistance);
                        lDicoDistance.TryAdd($"{lPositionIntersection.Cle}__{lPositionDebut.Cle}", lDistance);

                        lParent.IntersectionLies.Add(lIntersection);

                        if (lEmbranchementsTraite.Add(lEmbranchement.ClePosition) == true)
                        {
                            lAParcourir.Enqueue(lEmbranchement);
                        }
                    }

                    
                }

                //Vérif si le parcours courant est à la fin
                if (lParcours.Position_X == _Fin.X && lParcours.Position_Y == _Fin.Y)
                {
                    lParcoursFin.Add(lParcours);
                }

                if(lAParcourir.Count > 0)
                {
                    lParcours = lAParcourir.Dequeue();
                }
                else
                {
                    lParcours = null;
                }


            } while (lParcours != null);


            //Parcour du graphe pour chopper toutes les distances

            List<ParcoursIntersection> lALaFin = new List<ParcoursIntersection>();
            ParcoursIntersection lIntersectionParcours = new ParcoursIntersection()
            {
                IntersectionCourante = lIntersectionDepart,
            };

            lIntersectionParcours.IntersectionParcouru.Add(lIntersectionDepart.Cle);

            Queue<ParcoursIntersection> lQueue = new Queue<ParcoursIntersection>();


            decimal lVisite = 0;
            decimal lALaFinTeste = 0;
            do
            {

                List<ParcoursIntersection> lEnfants = lIntersectionParcours.DonneParcoursEnfant(lDicoDistance);


                foreach(ParcoursIntersection lParcoursEnfant in lEnfants)
                {
                    if(lParcoursEnfant.IntersectionCourante.Position.X == _Fin.X && lParcoursEnfant.IntersectionCourante.Position.Y == _Fin.Y)
                    {
                        //A lA fin => on la sort
                        lALaFin.Add(lParcoursEnfant);
                    }
                    else
                    {
                        //Pas encore => on continu
                        lQueue.Enqueue(lParcoursEnfant);
                    }
                }

                if(lQueue.Count > 0)
                {
                    lIntersectionParcours = lQueue.Dequeue();
                }
                else
                {
                    lIntersectionParcours = null;
                }

                lVisite++;

                if(lALaFin.Count > 5000)
                {
                    ParcoursIntersection lIntersectionMax = lALaFin.OrderByDescending(o => o.DistanceTotale).First();
                    lALaFinTeste += lALaFin.Count;

                    lALaFin.Clear();
                    lALaFin.Add(lIntersectionMax);

                    Console.WriteLine($"{DateTime.Now:HH:mm:ss}\t- Fini : {lALaFinTeste:N0}\t- Visité :{lVisite:N0}\t- Max {lIntersectionMax.DistanceTotale:N0}");

                }

            } while (lIntersectionParcours != null);





            return lALaFin.Max(o => o.DistanceTotale);
        }
    }
}
