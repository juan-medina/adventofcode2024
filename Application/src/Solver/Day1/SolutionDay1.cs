using Application.Helpers;

namespace Application.Solver.Day1;

public class SolutionDay1() : DaySolver(1)
{
    private static readonly Dictionary<string, int> DigitOnlyLookup = new()
    {
        { "1", 1 },
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 }
    };

    private static readonly Dictionary<string, int> DigitsAndStringsLookup = new(DigitOnlyLookup)
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    private static int GetNumber(string input, From direction, Dictionary<string, int> lookup) =>
        lookup.GetValueOrDefault(StringHelpers.GetFirstTokenInString(input, direction, lookup.Keys.ToArray()), 0);

    public override string Resolve(int part, string input) =>
        (from line in GetListFromString(input)
            let lookup = part == 1 ? DigitOnlyLookup : DigitsAndStringsLookup
            let left = GetNumber(line, From.Left, lookup)
            let right = GetNumber(line, From.Right, lookup)
            select int.Parse(left + "" + right)).Sum().ToString();
}