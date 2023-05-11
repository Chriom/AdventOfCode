using AdventOfCode.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2021.Jours;

internal class Program
{
    private static void Main(string[] pArgs)
    {
        EntreesHelper.EstEnmodeTest = false;
        IJour lJour = new Jour05();

        string lResultatUn = lJour.DonneResultatUn();
        Console.WriteLine($"Numero 1 : \r\n{lResultatUn}");


        lJour = new Jour05();

        string lResultatDeux = lJour.DonneResultatDeux();
        Console.WriteLine($"Numero 2 : \r\n{lResultatDeux}");

        Console.Read();
    }
}