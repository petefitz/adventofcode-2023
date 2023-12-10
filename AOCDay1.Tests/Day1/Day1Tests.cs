using Shouldly;

namespace AdventOfCode.Day1.Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("zlmlk1", 11)]
    [InlineData("vqjvxtc79mvdnktdsxcqc1sevenone", 71)]
    [InlineData("vsskdclbtmjmvrseven6", 76)]
    [InlineData("8jkfncbeight7seven8", 88)]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("248twofbkfpxtheightwovng", 22)]
    public void Day1(string line, int expected)
    {
        Calibration.GetValue2(line).ShouldBe(expected);
    }

    [Theory]
    [InlineData("zlmlk1", 11)]
    [InlineData("vqjvxtc79mvdnktdsxcqc1sevenone", 71)]
    [InlineData("vsskdclbtmjmvrseven6", 76)]
    [InlineData("8jkfncbeight7seven8", 88)]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("248twofbkfpxtheightwovng", 22)]
    public void Day1Part2(string line, int expected)
    {
        Calibration.GetValue2a(line).ShouldBe(expected);
    }
}