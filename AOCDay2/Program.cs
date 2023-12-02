internal class Program
{
    private static void Main(string[] args)
    {
        var allGames = GameDataReader.Read("data.txt");

        int sum = 0;
        foreach (var game in allGames)
        {
            if (GameDataBuilder.IsValid(game))
            {
                Console.WriteLine(game.GameNumber);
                sum += game.GameNumber;
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine("Hello, World!");
    }
}

public static class GameDataReader
{
    public static GameData[] Read(string filename)
    {
        string[] allLines = File.ReadAllLines(filename);

        return allLines.Select(l => GameDataBuilder.Read(l)).ToArray();
    }
}

public static class GameDataBuilder
{
    public static GameData Read(string line)
    {
        var items = line.Split(new char[] { ':', ';' });
        var gameNumber = int.Parse(items[0][5..]);
        var colours = items[1..].Select(i => new ColourData(i));
        return new GameData() { GameNumber = gameNumber, Colours = colours.ToArray() };
    }

    public static bool IsValid(GameData gameData)
    {
        return gameData.Colours.All(c => c.red <= 12 && c.green <= 13 && c.blue <= 14);
    }
}

public class GameData
{
    public int GameNumber { get; set; }
    public ColourData[] Colours { get; set; }
}

public class ColourData
{
    private Dictionary<string, int> Colours = new Dictionary<string, int>
    {
        ["red"] = 0,
        ["green"] = 0,
        ["blue"] = 0
    };
    public ColourData(string values)
    {
        var colours = values.Split(',');
        foreach (var item in colours)
        {
            var colourNumber = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Colours[colourNumber[1]] = int.Parse(colourNumber[0]);
        }
    }

    public int red => Colours["red"];
    public int green => Colours["green"];
    public int blue => Colours["blue"];
}