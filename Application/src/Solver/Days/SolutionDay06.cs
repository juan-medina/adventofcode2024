namespace Application.Solver.Days;

public class SolutionDay06() : DaySolver(6)
{
    public override int Resolve(int part, string input)
    {
        var map = Get2DArrayFromString(input);
        var blocks = map.SelectMany((rb, y) => rb.Select((cb, x) => (x, y, cb)))
            .Where(t => t.cb == '#')
            .Select(t => (t.y, t.x))
            .ToHashSet();
        var (col, row, c) = map.SelectMany((row, y) => row.Select((c, x) => (x, y, c)))
            .Where(t => t.c != '.' && t.c != '#')
            .First(t => map[t.y][t.x] == t.c)
            .ToTuple();
        var visited = GetVisited(blocks, map[0].Length, map.Length, row, col, c);
        return part == 1
            ? visited.Count
            : visited.Select(visit => GetVisited(visited, map[0].Length, map.Length, row, col, c, visit))
                .Count(visitWithExtra => visitWithExtra.Count == 0);
    }
    private static HashSet<(int, int)> GetVisited(HashSet<(int, int)> blocks, int width, int height, int row, int col,
        char c, (int, int) extraBlock = default)
    {
        var dir = Directions[c];
        var visited = new HashSet<(int, int)>();
        var blocksAlreadyStopUs = new HashSet<(int, int, char)>();
        while (row >= 0 && row < height && col >= 0 && col < width)
        {
            if (blocks.Contains((row, col)) || extraBlock == (row, col))
            {
                if (!blocksAlreadyStopUs.Add((row, col, dir.Item3)))
                    return []; // block already stop us going in them same direction, we are in a loop
                (row, col, dir) = (row - dir.Item1, col - dir.Item2, Directions[dir.Item3]);
                continue;
            }

            visited.Add((row, col));
            (row, col) = (row + dir.Item1, col + dir.Item2);
        }

        return visited;
    }

    private static readonly Dictionary<char, (int, int, char)> Directions = new()
        { { '^', (-1, 0, '>') }, { '>', (0, 1, 'v') }, { 'v', (1, 0, '<') }, { '<', (0, -1, '^') }, };
}