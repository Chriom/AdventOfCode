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

        public PlageValeur<T> DonneValeurEnCommun(PlageValeur<T> pPlage)
        {
            return PlageValeur<T>.DonnePlageValeurDepuisBornes(T.Max(this.BorneInferieur, pPlage.BorneInferieur), T.Min(this.BorneSuperieur, pPlage.BorneSuperieur));
        }
    }
}
