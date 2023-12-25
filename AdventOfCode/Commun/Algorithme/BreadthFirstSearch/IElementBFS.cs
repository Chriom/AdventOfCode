using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Commun.Algorithme.BreadthFirstSearch
{
    public interface IElementBFS
    {
        /// <summary>
        /// Position X de l'élément sur la carte
        /// </summary>
        int PositionX { get; set; }

        /// <summary>
        /// Position Y de l'élément sur la carte
        /// </summary>
        int PositionY { get; set; }

        /// <summary>
        /// Nombre d'accès de l'élément lors du parcours de la carte
        /// </summary>
        int NombreAcces { get; set; }

        /// <summary>
        /// Profondeur minimal lors du premier accès
        /// </summary>
        int Profondeur { get; set; }

        /// <summary>
        /// Indique si l'élement est le premier
        /// </summary>
        bool EstAuDepart { get; set; }

        /// <summary>
        /// Indique si l'élement est une fin
        /// </summary>
        bool EstALaFin { get; }

        /// <summary>
        /// Indique si la case a déja été visité
        /// </summary>
        bool EstVisitee { get; }
    }

    public interface IElementBFS<T> where T : class, IElementBFS
    {
        IEnumerable<T> DonneElementsAccessible(ParcoursBFS<T> pParcours, int pXPrecedent, int pYPrecedent);
    }
}
