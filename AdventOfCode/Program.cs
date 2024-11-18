using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2021.Jours;

internal class Program
{
    private static void Main(string[] pArgs)
    {
        Console.WindowHeight = Console.LargestWindowHeight;
        Console.WindowWidth = Console.LargestWindowWidth;


        EntreesHelper.EstEnmodeTest = false;
        //EntreesHelper.Numero = 4;
        IJour lJour = new Jour11();

        string lResultatUn = lJour.DonneResultatUn();
        Console.WriteLine($"Numero 1 : \r\n{lResultatUn}");

        
        lJour = new Jour11();

        string lResultatDeux = lJour.DonneResultatDeux();
        Console.WriteLine($"Numero 2 : \r\n{lResultatDeux}");



        Console.Read();
    }
}