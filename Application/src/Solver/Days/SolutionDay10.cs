using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay10() : DaySolver(10)
{
    public override ulong Resolve(int part, string input)
    {
        var map = StringHelpers.GetListFromStringWithBounds(input);
        _bounds = map.bounds;
        return (ulong)map.list.SelectMany((rb, y) => rb.Select((cb, x) => (x, y, cb))).Where(t => t.cb == '0')
            .Select(t => (t.y, t.x)).ToHashSet().Sum(head => Paths(map.list, head, part));
    }

    private int Paths(List<string> map, (int y, int x) pos, int part)
    {
        var totalPaths = 0;
        var queue = new Queue<((int y, int x) cpos, int search)>([(pos, 0)]); // where we are, what we search
        var visits = part == 1 ? new HashSet<((int y, int x) pos, int search)>() : null; // dont need visit on part 2
        while (queue.Count > 0)
        {
            var (cpos, search) = queue.Dequeue();
            if (cpos.x < 0 || cpos.x > _bounds.w - 1 || cpos.y < 0 || cpos.y > _bounds.h - 1) continue; // OoB
            if (int.Parse(map[cpos.y][cpos.x].ToString()) != search) continue; // not the right number
            if (part == 1) if (!visits!.Add((cpos, search))) continue; // already visited (only part 1)
            if (search == 9) totalPaths++; // is a 9, we reach the end, count one path
            else foreach (var dir in Dirs) queue.Enqueue(((cpos.y + dir.y, cpos.x + dir.x), search + 1)); // q each dir
        }

        return totalPaths;
    }

    private (int h, int w) _bounds;
    private static readonly (int y, int x)[] Dirs = [(0, -1), (0, 1), (-1, 0), (1, 0)];
}