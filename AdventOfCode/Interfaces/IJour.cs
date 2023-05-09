using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Interfaces
{
    public interface IJour
    {
        int NumeroJour { get; }

        string DonneResultatUn();

        string DonneResultatDeux();
    }
}
