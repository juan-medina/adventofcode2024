namespace Application.Solver.Day4;

public class SolutionDay4() : DaySolver(4)
{
    private const string Part1Search = "XMAS";
    private const string Part2Search = "MAS";

    public override string Resolve(int part, string input)
    {
        var map = GetListFromString(input);
        return map
            .SelectMany((row, y) => row.Select((c, x) => (x, y, c)))
            .Where(t => part == 1 ? t.c == Part1Search[0] : t.c == Part2Search[1])
            .Sum(t => part == 1 ? TimesAt(map, t.x, t.y, Part1Search) : CrossAt(map, t.x, t.y, Part2Search))
            .ToString();
    }

    private static int TimesAt(List<string> map, int x, int y, string search) =>
        Enumerable.Range(-1, 3)
            .SelectMany(dx => Enumerable.Range(-1, 3).Select(dy => (dx, dy)))
            .Sum(pair => CheckAt(map, x, y, pair.dx, pair.dy, search));

    private static int CrossAt(List<string> map, int x, int y, string search) =>
        new[] { (-1, -1), (1, 1), (-1, 1), (1, -1) }.Count(dir =>
            CheckAt(map, x + dir.Item1, y + dir.Item2, -dir.Item1, -dir.Item2, search) == 1) == 2
            ? 1
            : 0;

    private static int CheckAt(List<string> map, int x, int y, int dx, int dy, string search) =>
        search.All(character =>
        {
            if (x < 0 || y < 0 || y > map.Count - 1 || x > map[y].Length - 1)
            {
                return false;
            }

            if (map[y][x] != character)
            {
                return false;
            }

            y += dy;
            x += dx;
            return true;
        })
            ? 1
            : 0;
}