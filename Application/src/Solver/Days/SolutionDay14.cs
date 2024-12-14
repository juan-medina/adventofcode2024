using System.Text.RegularExpressions;

namespace Application.Solver.Days;

public partial class SolutionDay14() : DaySolver(14)
{
    public override ulong Resolve(int part, string input, bool test)
    {
        var width = test ? 11 : 101;
        var height = test ? 7 : 103;
        var robots = Parse(input);

        return part == 1
            ? (ulong)Move(robots, 100, width, height)
                .Where(r => r.x != width / 2 && r.y != height / 2) // not in the cardinals
                .GroupBy(r => (r.x > width / 2 ? 1 : -1, r.y > height / 2 ? 1 : -1)) // group by quadrant
                .Select(g => g.Count()) // how many per quadrant
                .Aggregate((a, b) => a * b) // multiply
            : (ulong)Enumerable.Range(1, 10000) // from 1 to 10000 seconds
                .Select(i => new { Index = i, Robots = Move(robots, i, width, height) }) // move the robots
                .First(x => x.Robots.Distinct().Count() == x.Robots.Count).Index; // they do not overlap
    }

    private static List<(int x, int y)> Move(List<((int x, int y) p, (int x, int y) v)> bots,
        int seconds, int width, int height) => bots
        .Select(robot => ((robot.p.x + robot.v.x * seconds) % width, (robot.p.y + robot.v.y * seconds) % height))
        .Select(pos => (pos.Item1 < 0 ? pos.Item1 + width : pos.Item1, pos.Item2 < 0 ? pos.Item2 + height : pos.Item2))
        .ToList();

    private static List<( (int x, int y) p, (int x, int y) v)> Parse(string input)
    {
        var matches = ParseRegex().Matches(input);
        return matches.Select(match => (
            (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)),
            (int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value))
        )).ToList();
    }

    [GeneratedRegex(@"p=(\d+),(\d+) v=([+-]?\d+),([+-]?\d+)")]
    private static partial Regex ParseRegex();
}