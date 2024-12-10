using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay10() : DaySolver(10)
{
    public override ulong Resolve(int part, string input)
    {
        var map = StringHelpers.GetListFromStringWithBounds(input);
        _bounds = map.bounds;
        return (ulong)map.list.SelectMany((rb, y) => rb.Select((cb, x) => (x, y, cb))).Where(t => t.cb == '0')
            .Select(t => (t.y, t.x)).ToHashSet().Sum(head => Walk(map.list, head, part));
    }

    private int Walk(List<string> map, (int y, int x) pos, int part)
    {
        var queue = new Queue<((int y, int x) cpos, int searching)>([(pos, 0)]); // where we are, what we search
        var count = 0;
        var visits = part == 1 ? new HashSet<(int y, int x, int searching)>() : null; // dont need visit on part 2
        while (queue.Count > 0)
        {
            var (cpos, searching) = queue.Dequeue();
            if (cpos.x < 0 || cpos.x > _bounds.w - 1 || cpos.y < 0 || cpos.y > _bounds.h - 1) continue; // OoB
            if (int.Parse(map[cpos.y][cpos.x].ToString()) != searching) continue; // not the right number
            if (part == 1)
                if (!visits!.Add((cpos.y, cpos.x, searching))) // already visited (only part 1)
                    continue;
            if (searching != 9)
                foreach (var dir in Directions)
                    queue.Enqueue(((cpos.y + dir.y, cpos.x + dir.x), searching + 1));
            else count++;
        }

        return count;
    }

    private (int h, int w) _bounds;
    private static readonly (int y, int x)[] Directions = [(0, -1), (0, 1), (-1, 0), (1, 0)];
}