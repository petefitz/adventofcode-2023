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
            int value = Calibration.GetValue(item);
            sum += value;

            Console.WriteLine($"{item} {value} {sum}");
        }

        Console.WriteLine(sum);
        Console.WriteLine("Hello, World!");
    }
}

public static class Calibration
{
    public static int GetValue(string item)
    {
        var matches = Regex.Matches(item, "(\\d)|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)");

        var first = Mappings[matches.First().Value];
        var last = Mappings[matches.Last().Value];

        return int.Parse($"{first}{last}");
    }

    private static Dictionary<string, string> Mappings = new Dictionary<string, string>
    {
        ["one"]="1",
        ["two"]="2",
        ["three"]="3",
        ["four"]="4",
        ["five"]="5",
        ["six"]="6",
        ["seven"]="7",
        ["eight"]="8",
        ["nine"]="9",
        ["1"]="1",
        ["2"]="2",
        ["3"]="3",
        ["4"]="4",
        ["5"]="5",
        ["6"]="6",
        ["7"]="7",
        ["8"]="8",
        ["9"]="9"
    };
}
