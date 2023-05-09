using AdventOfCode.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2022.Jours;

internal class Program
{
    private static void Main(string[] pArgs)
    {
        EntreesHelper.EstEnmodeTest = false;
        IJour lJour = new Jour20();

        string lResultatUn = lJour.DonneResultatUn();
        Console.WriteLine($"Numero 1 : \r\n{lResultatUn}");


        lJour = new Jour20();

        string lResultatDeux = lJour.DonneResultatDeux();
        Console.WriteLine($"Numero 2 : \r\n{lResultatDeux}");

        Console.Read();
    }
}