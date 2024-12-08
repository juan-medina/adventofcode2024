using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay06() : DaySolver(6)
{
    public override ulong Resolve(int part, string input)
    {
        var map = StringHelpers.GetListFromStringWithBounds(input);
        var blocks = map.list.SelectMany((rb, y) => rb.Select((cb, x) => (x, y, cb)))
            .Where(t => t.cb == '#')
            .Select(t => (t.y, t.x))
            .ToHashSet();
        var (col, row, c) = map.list.SelectMany((row, y) => row.Select((c, x) => (x, y, c)))
            .Where(t => t.c != '.' && t.c != '#')
            .First(t => map.list[t.y][t.x] == t.c)
            .ToTuple();
        var visited = GetVisited(blocks, map.bounds, row, col, c);
        return (ulong)(part == 1
            ? visited.Count
            : visited.Select(visit => GetVisited(blocks, map.bounds, row, col, c, visit))
                .Count(visitWithExtra => visitWithExtra.Count == 0));
    }

    private static HashSet<(int, int)> GetVisited(HashSet<(int, int)> blocks, (int h, int w) bounds, int row, int col,
        char c, (int r, int c) extraBlock = default)
    {
        var dir = Directions[c];
        var visited = new HashSet<(int, int)>();
        var blocksAlreadyStopUs = new HashSet<(int, int, char)>();
        while (row >= 0 && row < bounds.h && col >= 0 && col < bounds.w)
        {
            if (blocks.Contains((row, col)) || extraBlock == (row, col))
            {
                if (!blocksAlreadyStopUs.Add((row, col, dir.r)))
                    return []; // block already stop us going in them same direction, we are in a loop
                (row, col, dir) = (row - dir.y, col - dir.x, Directions[dir.r]);
                continue;
            }

            visited.Add((row, col));
            (row, col) = (row + dir.y, col + dir.x);
        }

        return visited;
    }

    private static readonly Dictionary<char, (int y, int x, char r)> Directions = new()
        { { '^', (-1, 0, '>') }, { '>', (0, 1, 'v') }, { 'v', (1, 0, '<') }, { '<', (0, -1, '^') }, };
}