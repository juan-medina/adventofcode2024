namespace Application.Solver.Day1;

public class SolutionDay1() : DaySolver(1)
{
    private static readonly Dictionary<string, int> DigitOnlyDictionary = new()
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

    private static readonly Dictionary<string, int> DigitsAndStringsDictionary = new(DigitOnlyDictionary)
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

    private static int GetNumber(string text, int index, Dictionary<string, int> map) => (from key in map.Keys
        where index + key.Length <= text.Length
        where text.Substring(index, key.Length) == key
        select map[key]).FirstOrDefault();

    private enum From
    {
        Left,
        Right
    }

    private static int GetNumberInText(string text, From position, Dictionary<string, int> map) => text
        .Select((_, i) => position == From.Left ? i : text.Length - 1 - i)
        .Select(at => GetNumber(text, at, map))
        .FirstOrDefault(result => result != 0);

    public override string Resolve(int part, string input) =>
        (from line in GetListFromString(input)
            let dictionary = part == 1 ? DigitOnlyDictionary : DigitsAndStringsDictionary
            let left = GetNumberInText(line, From.Left, dictionary)
            let right = GetNumberInText(line, From.Right, dictionary)
            select int.Parse(left + "" + right)).Sum().ToString();
}