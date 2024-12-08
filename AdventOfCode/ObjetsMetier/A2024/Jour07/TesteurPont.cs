using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.ObjetsMetier.A2024.Jour07
{
    public class TesteurPont
    {
        private Pont _Pont;
        public TesteurPont(Pont pPont)
        {
            _Pont = pPont;
            _Pont.Initialiser();
        }



        public bool EstPossible(List<Operateur> pOperateurs)
        {
            Queue<OperateurEtPont> lPontsATester = new Queue<OperateurEtPont>();

            foreach(Operateur lOperateur in pOperateurs)
            {
                lPontsATester.Enqueue(new OperateurEtPont
                {
                    Operateur = lOperateur,
                    Pont = new Pont()
                    {
                        ValeurNecessaire = _Pont.ValeurNecessaire,
                        ValeurCourante = _Pont.ValeurCourante,
                        Nombres = new List<decimal>(_Pont.Nombres)
                    }
                });
            }

            OperateurEtPont lPontCourant = lPontsATester.Dequeue();
            do
            {
                lPontCourant.Pont.AppliquerOperation(lPontCourant.Operateur);

                if (lPontCourant.Pont.EstALaFin && lPontCourant.Pont.EstValide)
                {
                    return true;
                }
                else
                {
                    if (lPontCourant.Pont.EstEncorePossible)
                    {
                        foreach (Operateur lOperateur in pOperateurs)
                        {
                            lPontsATester.Enqueue(new OperateurEtPont
                            {
                                Operateur = lOperateur,
                                Pont = new Pont()
                                {
                                    ValeurNecessaire = lPontCourant.Pont.ValeurNecessaire,
                                    ValeurCourante = lPontCourant.Pont.ValeurCourante,
                                    Nombres = new List<decimal>(lPontCourant.Pont.Nombres)
                                }
                            });
                        }
                    }
                }

                if (lPontsATester.Count > 0)
                {
                    lPontCourant = lPontsATester.Dequeue();
                }
                else
                {
                    lPontCourant = null;
                }

            } while (lPontCourant != null);

            return false;
        }
    }
}
