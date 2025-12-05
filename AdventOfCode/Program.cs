using System.Diagnostics;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2025;

internal class Program
{
    private static void Main(string[] pArgs)
    {
        Console.WindowHeight = Console.LargestWindowHeight;
        Console.WindowWidth = Console.LargestWindowWidth;

        //EntreesHelper.EstEnmodeTest = true;
        //EntreesHelper.Numero = 2;

        var lInit = () => new Jour05();

        Stopwatch lPartie1 = Stopwatch.StartNew();
        IJour lJour = lInit();
        

        string lResultatUn = lJour.DonneResultatUn();

       lPartie1.Stop();

        Console.WriteLine($"Temps écoulé : {lPartie1.Elapsed}");
        Console.WriteLine($"Numero 1 : \r\n{lResultatUn}");


        Stopwatch lPartie2 = Stopwatch.StartNew();
        lJour = lInit();

        string lResultatDeux = lJour.DonneResultatDeux();

        lPartie2.Stop();

        Console.WriteLine($"Temps écoulé : {lPartie2.Elapsed}");
        Console.WriteLine($"Numero 2 : \r\n{lResultatDeux}");

        Console.Read();
    }
}
