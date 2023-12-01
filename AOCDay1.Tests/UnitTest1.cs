using Shouldly;

namespace AOCDay1.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("zlmlk1", 11)]
    [InlineData("vqjvxtc79mvdnktdsxcqc1sevenone", 71)]
    [InlineData("vsskdclbtmjmvrseven6", 66)]
    [InlineData("8jkfncbeight7seven8", 88)]
    public void Test1(string line, int expected)
    {
        Calibration.GetValue(line).ShouldBe(expected);
    }
}