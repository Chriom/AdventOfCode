using System.Diagnostics;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2024.Jours;

internal class Program
{
    private static void Main(string[] pArgs)
    {
        Console.WindowHeight = Console.LargestWindowHeight;
        Console.WindowWidth = Console.LargestWindowWidth;

        EntreesHelper.EstEnmodeTest = false;

        Stopwatch lPartie1 = Stopwatch.StartNew();
        IJour lJour = new Jour12();

        string lResultatUn = lJour.DonneResultatUn();

        lPartie1.Stop();

        Console.WriteLine($"Temps écoulé : {lPartie1.Elapsed}");
        Console.WriteLine($"Numero 1 : \r\n{lResultatUn}");


        Stopwatch lPartie2 = Stopwatch.StartNew();
        lJour = new Jour12();

        string lResultatDeux = lJour.DonneResultatDeux();

        lPartie2.Stop();

        Console.WriteLine($"Temps écoulé : {lPartie2.Elapsed}");
        Console.WriteLine($"Numero 2 : \r\n{lResultatDeux}");

        Console.Read();
    }
}
