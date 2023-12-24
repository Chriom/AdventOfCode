using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2023.Jours;

internal class Program
{
    private static void Main(string[] pArgs)
    {
        Console.WindowHeight = Console.LargestWindowHeight;
        Console.WindowWidth = Console.LargestWindowWidth;


        EntreesHelper.EstEnmodeTest = false;
        //EntreesHelper.Numero = 4;
        IJour lJour = new Jour23();

        string lResultatUn = lJour.DonneResultatUn();
        Console.WriteLine($"Numero 1 : \r\n{lResultatUn}");

        
        lJour = new Jour23();

        string lResultatDeux = lJour.DonneResultatDeux();
        Console.WriteLine($"Numero 2 : \r\n{lResultatDeux}");



        Console.Read();
    }
}