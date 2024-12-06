using System.Text.RegularExpressions;

namespace Application.Solver.Days;

public partial class SolutionDay03() : DaySolver(3)
{
    private bool _doIt = true;

    public override int Resolve(int part, string input) => OpcodesPattern().Matches(input).Select(match =>
    {
        switch (match.Value)
        {
            case "do()":
                _doIt = true;
                break;
            case "don't()":
                _doIt = false;
                break;
            default:
            {
                if (part == 1 || _doIt)
                {
                    return (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
                }

                break;
            }
        }

        return (0, 0);
    }).Sum(value => value.Item1 * value.Item2);

    [GeneratedRegex(@"mul\((\d{0,3}),(\d{0,3})\)|(do\(\))|(don\'t\(\))", RegexOptions.Multiline)]
    private static partial Regex OpcodesPattern();
}