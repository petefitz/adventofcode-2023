using AdventOfCode.Day3;
using Shouldly;

namespace AOCDay3.Tests;

public class Day3Tests
{
    [Theory]
    [InlineData("........936..672.........", "936", "672")]
    [InlineData(".123.......12.....123....", "123", "12", "123")]
    public void Day3(string gameLine, params string[] expectedNumbers)
    {
        var data = new GameData { Cells = new[] { gameLine } };

        //GameDataBuilder.GetNumbers(data.Cells[0]).ShouldBe(expectedNumbers);
    }

    [Theory]
    [InlineData(0, 0, '.')]
    [InlineData(0, 1, '1')]
    [InlineData(1, 3, '*')]
    [InlineData(1, 14, '4')]
    [InlineData(-1, -1, '.')]
    [InlineData(-1, 0, '.')]
    [InlineData(0, -1, '.')]
    [InlineData(3, 0, '.')]
    [InlineData(3, -1, '.')]
    [InlineData(1, -1, '.')]
    [InlineData(3, 15, '.')]
    [InlineData(2, 15, '.')]
    public void ArrayIndices(int row, int col, char expected)
    {
        var data = new GameData
        {
            Cells = new[] {
            ".196....544....",
            "...*....*...654",
            "...566..20...$." }
        };

        data[row, col].ShouldBe(expected);
    }

    [Fact]
    public void NextToSpecial()
    {
        var data = new GameData
        {
            Cells = new[] {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."}
        };

        data.FindResultPart1().ShouldBe(4361);

    }

    [Fact]
    public void NextToGear()
    {
        var data = new GameData
        {
            Cells = new[] {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."}
        };

        data.FindResultPart2().ShouldBe(467835);

    }
}
