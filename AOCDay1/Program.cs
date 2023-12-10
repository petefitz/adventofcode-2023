// See https://aka.ms/new-console-template for more information
namespace AdventOfCode;

using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;
using AdventOfCode.Day4;

internal static class Program
{
    private static void Main(string[] args)
    {
        Day1Runner.Part2();
        Day2Runner.Parts1and2();
        Day3Runner.Parts1and2();
        Day4Runner.Part1();
    }
}
