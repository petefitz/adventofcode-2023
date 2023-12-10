using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

public static class Day3Runner
{
    public static void Parts1and2()
    {
        var allLines = GameDataReader.Read("data/day3/data.txt");

        Console.WriteLine("Part 1");
        Console.WriteLine(allLines.FindResultPart1());
        Console.WriteLine("Part 2");
        Console.WriteLine(allLines.FindResultPart2());
    }
}

public static class GameDataReader
{
    public static GameData Read(string filename)
    {
        string[] allLines = File.ReadAllLines(filename);

        return new GameData { Cells = allLines };
    }
}

public class GameData
{
    public string[] Cells { get; set; } = Array.Empty<string>();

    public char this[int row, int col]
    {
        get
        {
            return row == -1 || col == -1 || row >= Cells.Length || col >= Cells[0].Length
            ? '.'
            : Cells[row][col];
        }
    }

    public int FindResultPart1()
    {
        int result = 0;
        for (int row = 0; row < Cells.Length; row++)
        {
            MatchCollection matches = Regex.Matches(Cells[row], @"\d+");
            foreach (var match in matches.Select(m => m))
            {
                if (isSurroundedBySpecialChar(row, match.Index, match.Length))
                {
                    //Console.WriteLine(match.Value);
                    result += int.Parse(match.Value);
                }
            }
        }
        return result;
    }

    private bool isSurroundedBySpecialChar(int row, int startingCol, int length)
    {
        //Current Line
        if (this[row, startingCol - 1].IsSpecial() || this[row, startingCol + length].IsSpecial())
            return true;

        for (int col = startingCol - 1; col <= startingCol + length; col++)
        {
            //Previous Line
            if (this[row - 1, col].IsSpecial())
                return true;
            //Next Line
            if (this[row + 1, col].IsSpecial())
                return true;
        }

        return false;
    }

    public int FindResultPart2()
    {
        var gearRatios = new List<GearRatios>();

        for (int row = 0; row < Cells.Length; row++)
        {
            MatchCollection matches = Regex.Matches(Cells[row], @"\d+");
            foreach (var match in matches.Select(m => m))
            {
                (bool isGear, int gearRow, int GearCol) = IsGearRatio(row, match.Index, match.Length);
                if (isGear)
                {
                    var gearRatio = gearRatios.SingleOrDefault(g => g.row == gearRow && g.col == GearCol);
                    if (gearRatio == null)
                    {
                        gearRatio = new GearRatios { row = gearRow, col = GearCol };
                        gearRatios.Add(gearRatio);
                    }
                    gearRatio.parts.Add(int.Parse(match.Value));
                    Console.WriteLine(match.Value);
                }
            }
        }

        var parts = gearRatios.Where(g => g.parts.Count == 2);
        foreach (var item in parts)
        {
            Console.WriteLine($"{item.parts[0]},{item.parts[1]} = {item.parts[0] * item.parts[1]}");
        }

        return parts.Select(gg => gg.parts[0] * gg.parts[1]).Sum();
    }

    private (bool, int, int) IsGearRatio(int row, int startingCol, int length)
    {
        //Current Line
        if (this[row, startingCol - 1].IsGearRatio())
            return (true, row, startingCol - 1);
        if (this[row, startingCol + length].IsGearRatio())
            return (true, row, startingCol + length);

        for (int col = startingCol - 1; col <= startingCol + length; col++)
        {
            //Previous Line
            if (this[row - 1, col].IsGearRatio())
                return (true, row - 1, col);
            //Next Line
            if (this[row + 1, col].IsGearRatio())
                return (true, row + 1, col);
        }

        return (false, 0, 0);
    }
}

public class GearRatios
{
    public int row { get; set; }
    public int col { get; set; }
    public List<int> parts { get; set; } = new List<int>();
}

public static class CharExtensions
{
    public static bool IsNum(this char value) => value >= '0' && value <= '9';
    public static bool IsEmpty(this char value) => value == '.';
    public static bool IsSpecial(this char value) => !value.IsNum() && !value.IsEmpty();

    public static bool IsGearRatio(this char value) => value == '*';
}
