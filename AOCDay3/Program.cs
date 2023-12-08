using System.Text.RegularExpressions;

namespace AdventOfCode.Day3;

internal class Program
{
    private static void Main(string[] args)
    {
        var allLines = GameDataReader.Read("data.txt");
        Console.WriteLine(allLines.FindResultPart1());
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
                    Console.WriteLine(match.Value);
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
}

public static class CharExtensions
{
    public static bool IsNum(this char value) => value >= '0' && value <= '9';
    public static bool IsEmpty(this char value) => value == '.';
    public static bool IsSpecial(this char value) => !value.IsNum() && !value.IsEmpty();
}
