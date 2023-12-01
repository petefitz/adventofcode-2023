// See https://aka.ms/new-console-template for more information


using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] allLines = File.ReadAllLines("data.txt");

        int sum = 0;
        foreach (var item in allLines)
        {
            sum += Calibration.GetValue(item);
        }

        Console.WriteLine(sum);
        Console.WriteLine("Hello, World!");
    }
}

public static class Calibration
{
    public static int GetValue(string item)
    {
        var matches = Regex.Matches(item, "\\d");

        var first = matches.First().Value;
        var last = matches.Last().Value;

        return int.Parse($"{first}{last}");
    }
}