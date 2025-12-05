using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Utilitaires
{
    [DebuggerDisplay("{BorneInferieur} --> {BorneSuperieur}")]
    public class PlageValeur<T> where T : INumber<T>
    {
        public T BorneInferieur { get; private set; }
        public T BorneSuperieur { get; private set; }

        public T Distance { get; private set; }

        public T NombreEntiersDansPlage => Distance + T.One + T.One;


        public static PlageValeur<T> DonnePlageValeurDepuisBorneEtDistance(T pBorneInferieur, T pDistance)
        {
            return new PlageValeur<T>()
            {
                BorneInferieur = pBorneInferieur,
                BorneSuperieur = pBorneInferieur + pDistance - T.One,
                Distance = pDistance,
            };
        }

        public static PlageValeur<T> DonnePlageValeurDepuisBornes(T pBorneInferieur, T pBorneSuperieur)
        {
            return new PlageValeur<T>()
            {
                BorneInferieur = pBorneInferieur,
                BorneSuperieur = pBorneSuperieur,
                Distance = pBorneSuperieur - pBorneInferieur - T.One,
            };
        }

        private PlageValeur()
        {
        }

        public T DistanceDepuisBorneInferieur(T pNombre)
        {
            T lDistance = pNombre - BorneInferieur;

            return T.Abs(lDistance);
        }

        public bool EstDansPlage(T pNombre)
        {
            return BorneInferieur <= pNombre && pNombre <= BorneSuperieur;
        }

        public bool PossedeUnBoutDansPlage(PlageValeur<T> pPlage)
        {
            if(this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur < pPlage.BorneInferieur)
            {
                //Avant la plage testé
                return false;
            }

            if(this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneInferieur)
            {
                //Dépasse devant
                return true;
            }

            if(this.BorneInferieur > pPlage.BorneInferieur && this.BorneSuperieur < pPlage.BorneSuperieur)
            {
                //Compris dedans
                return true;
            }

            if(this.BorneInferieur < pPlage.BorneSuperieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //Dépasse derriere
                return true;
            }

            if(this.BorneInferieur > pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //Après la plage testé
                return false;
            }

            if(this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //Englobe la plage testé
                return true;
            }

            
            //On devrait pas tombé dedans
            throw new Exception("Plage - cas pas testé");
        }

        public bool PlageSontDedansOuSeTouche(PlageValeur<T> pPlage)
        {
            if (this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur < pPlage.BorneInferieur)
            {
                //Avant la plage testé
                return false;
            }

            if (this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneInferieur)
            {
                //Dépasse devant
                return true;
            }

            if (this.BorneInferieur > pPlage.BorneInferieur && this.BorneSuperieur < pPlage.BorneSuperieur)
            {
                //Compris dedans
                return true;
            }

            if (this.BorneInferieur < pPlage.BorneSuperieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //Dépasse derriere
                return true;
            }

            if (this.BorneInferieur > pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //Après la plage testé
                return false;
            }

            if (this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //Englobe la plage testé
                return true;
            }

            if (this.BorneInferieur == pPlage.BorneInferieur && this.BorneSuperieur == pPlage.BorneSuperieur)
            {
                //Plage identique
                return true;
            }


            //Début égal
            if (this.BorneInferieur == pPlage.BorneInferieur && this.BorneSuperieur < pPlage.BorneInferieur)
            {
                //touche devant
                return true;
            }

            if (this.BorneInferieur == pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneInferieur)
            {
                //Dépasse devant
                return true;
            }

            if (this.BorneInferieur == pPlage.BorneInferieur && this.BorneSuperieur < pPlage.BorneSuperieur)
            {
                //Compris dedans
                return true;
            }

            if (this.BorneInferieur == pPlage.BorneSuperieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //touche derriere
                return true;
            }

            if (this.BorneInferieur == pPlage.BorneInferieur && this.BorneSuperieur > pPlage.BorneSuperieur)
            {
                //touche après
                return true;
            }



            //fin egal
            if (this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur == pPlage.BorneInferieur)
            {
                //Avant la plage testé
                return true;
            }

            if (this.BorneInferieur < pPlage.BorneInferieur && this.BorneSuperieur == pPlage.BorneInferieur)
            {
                //Dépasse devant
                return true;
            }

            if (this.BorneInferieur > pPlage.BorneInferieur && this.BorneSuperieur == pPlage.BorneSuperieur)
            {
                //Compris dedans
                return true;
            }

            if (this.BorneInferieur < pPlage.BorneSuperieur && this.BorneSuperieur == pPlage.BorneSuperieur)
            {
                //Dépasse derriere
                return true;
            }

            if (this.BorneInferieur > pPlage.BorneInferieur && this.BorneSuperieur == pPlage.BorneSuperieur)
            {
                //Après la plage testé
                return true;
            }

            //On devrait pas tombé dedans
            throw new Exception("Plage - cas pas testé");
        }

        public PlageValeur<T> DonneValeurEnCommun(PlageValeur<T> pPlage)
        {
            return PlageValeur<T>.DonnePlageValeurDepuisBornes(T.Max(this.BorneInferieur, pPlage.BorneInferieur), T.Min(this.BorneSuperieur, pPlage.BorneSuperieur));
        }

        public IEnumerable<PlageValeur<T>> DecouperPlage(T pBorneInferieur)
        {
            if(this.BorneInferieur >= pBorneInferieur || this.BorneSuperieur < pBorneInferieur)
            {
                //Pas dans la plage
                yield return this;
            }

            yield return PlageValeur<T>.DonnePlageValeurDepuisBornes(this.BorneInferieur, pBorneInferieur);
            yield return PlageValeur<T>.DonnePlageValeurDepuisBornes(pBorneInferieur + T.One, this.BorneSuperieur);

        }

        public IEnumerable<PlageValeur<T>> EnglobePlageSiPossible(PlageValeur<T> pPlage)
        {
            if (PlageSontDedansOuSeTouche(pPlage) == false)
            {
                //Les plages ne se coupent pas
                yield return this;
                yield return pPlage;
                yield break;
            }

            yield return DonnePlageValeurDepuisBornes(T.Min(this.BorneInferieur, pPlage.BorneInferieur), T.Max(this.BorneSuperieur, pPlage.BorneSuperieur));
        }


        public PlageValeur<T> Copie()
        {
            return new PlageValeur<T>()
            {
                BorneInferieur = this.BorneInferieur,
                BorneSuperieur = this.BorneSuperieur,
                Distance = this.Distance,
            };
        }
    }
}
