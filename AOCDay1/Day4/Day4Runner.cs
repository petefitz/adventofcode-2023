using System.Text.RegularExpressions;

namespace AdventOfCode.Day4;

public static class Day4Runner
{
    public static void Part1()
    {
        var allLines = GameDataReader.Read("data/day4/data.txt");

        Console.WriteLine("Part 1");
        Console.WriteLine(allLines.FindResultPart1());
    }
}

public static class GameDataReader
{
    public static GameData Read(string filename)
    {
        string[] allLines = File.ReadAllLines(filename);

        return new GameData { Lines = allLines };
    }
}

public class GameData
{
    public string[] Lines { get; set; } = Array.Empty<string>();

    public int FindResultPart1()
    {
        var games = Lines
            .Select(l => l.Split(separator:new char[] {':', '|'}))
            .Select(l1 => new {WinningNumbers = l1[1].Split(' ', StringSplitOptions.RemoveEmptyEntries), Entry = l1[2].Split(' ', StringSplitOptions.RemoveEmptyEntries)})
            .ToList();

        var winningLines = games.Select(g => g.Entry.Intersect(g.WinningNumbers).Count()).Where(gg => gg > 0).ToList();

        int result = 0;
        foreach (var item in winningLines)
        {
            result += int.Parse(Math.Pow(2, item-1).ToString());
        }

        return result;
    }
}
