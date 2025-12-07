using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.ObjetsMetier.A2025.Jour07
{
    public class Diagramme
    {
        private Case[,] _Diagramme;

        private int _NombreLignes;
        private int _NombreColonnes;

        //private 
        public Diagramme(List<string> lLignes)
        {
            _ConstruireDiagramme(lLignes);
        }


        private void _ConstruireDiagramme(List<string> pLignes)
        {
            _NombreColonnes = pLignes.First().Length;
            _NombreLignes = pLignes.Count;

            _Diagramme = new Case[_NombreLignes, _NombreColonnes];


            for (int lIndexLigne = 0; lIndexLigne < _NombreLignes; lIndexLigne++)
            {
                string lLigne = pLignes[lIndexLigne];
                for (int lIndexColonnes = 0; lIndexColonnes < _NombreColonnes; lIndexColonnes++)
                {
                    _Diagramme[lIndexLigne, lIndexColonnes] = lLigne[lIndexColonnes] switch
                    {
                        '.' => Case.Vide,
                        'S' => Case.Depart,
                        '^' => Case.Splitter,
                        _ => throw new ArgumentOutOfRangeException(nameof(lLigne)),
                    };
                }
            }
        }

        public int DonneNombreSeparation()
        {
            int lNombreSeparation = 0;

            for(int lIndexLigne = 0; lIndexLigne < _NombreLignes - 1; lIndexLigne++)
            {
                for(int lIndexColonnes = 0; lIndexColonnes < _NombreColonnes; lIndexColonnes++)
                {
                    Case lCaseCourante = _Diagramme[lIndexLigne, lIndexColonnes];

                    if(lCaseCourante == Case.Depart || lCaseCourante == Case.Tachyon)
                    {
                        //Case en dessous
                        Case lEnDessous = _Diagramme[lIndexLigne + 1, lIndexColonnes];

                        if(lEnDessous == Case.Vide)
                        {
                            //le faisceau se propage
                            _Diagramme[lIndexLigne + 1, lIndexColonnes] = Case.Tachyon;
                        }
                        else if(lEnDessous == Case.Splitter)
                        {
                            lNombreSeparation++;

                            if(lIndexColonnes > 0)
                            {
                                _Diagramme[lIndexLigne + 1, lIndexColonnes - 1] = Case.Tachyon;
                            }
                            if(lIndexColonnes < _NombreColonnes - 1)
                            {
                                _Diagramme[lIndexLigne + 1, lIndexColonnes + 1] = Case.Tachyon;
                            }
                        }

                    }
                }
            }


            return lNombreSeparation;
        }

        public decimal DonneNombreTimeline()
        {
            decimal[,] lTimeline = new decimal[_NombreLignes, _NombreColonnes];

            for (int lIndexLigne = 0; lIndexLigne < _NombreLignes - 1; lIndexLigne++)
            {
                for (int lIndexColonne = 0; lIndexColonne < _NombreColonnes; lIndexColonne++)
                {
                    Case lCaseCourante = _Diagramme[lIndexLigne, lIndexColonne];

                    if(lCaseCourante == Case.Depart)
                    {
                        //Départ sur une timeline
                        lTimeline[lIndexLigne, lIndexColonne] = 1;
                    }

                    if (lCaseCourante == Case.Depart || lCaseCourante == Case.Tachyon)
                    {
                        //Case en dessous
                        Case lEnDessous = _Diagramme[lIndexLigne + 1, lIndexColonne];

                        if (lEnDessous == Case.Vide || lEnDessous == Case.Tachyon)
                        {
                            //le faisceau se propage
                            lTimeline[lIndexLigne + 1, lIndexColonne] += lTimeline[lIndexLigne, lIndexColonne];
                            _Diagramme[lIndexLigne + 1, lIndexColonne] = Case.Tachyon;
                        }
                        else if (lEnDessous == Case.Splitter)
                        {
                            if (lIndexColonne > 0)
                            {
                                lTimeline[lIndexLigne + 1, lIndexColonne - 1] += lTimeline[lIndexLigne, lIndexColonne];
                                _Diagramme[lIndexLigne + 1, lIndexColonne - 1] = Case.Tachyon;
                            }
                            if (lIndexColonne < _NombreColonnes - 1)
                            {
                                lTimeline[lIndexLigne + 1, lIndexColonne + 1] += lTimeline[lIndexLigne, lIndexColonne];
                                _Diagramme[lIndexLigne + 1, lIndexColonne + 1] = Case.Tachyon;
                            }
                        }

                    }

                    

                }
            }

            decimal lNombreTimeline = 0;

            for (int lIndexColonne = 0; lIndexColonne < _NombreColonnes; lIndexColonne++)
            {
                lNombreTimeline += lTimeline[_NombreLignes - 1, lIndexColonne];
            }

            return lNombreTimeline;
        }

        public enum Case
        {
            Vide,
            Depart,
            Splitter,
            Tachyon

        }
    }
}
