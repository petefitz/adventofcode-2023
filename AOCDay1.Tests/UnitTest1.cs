using Shouldly;

namespace AOCDay1.Tests;

public class UnitTest1
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
    public void Test1(string line, int expected)
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
    public void Test2a(string line, int expected)
    {
        Calibration.GetValue2a(line).ShouldBe(expected);
    }
}