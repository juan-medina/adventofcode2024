using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay12() : DaySolver(12)
{
    public override ulong Resolve(int part, string input, bool _)
    {
        var map = StringHelpers.GetListFromStringWithBounds(input);
        _bounds = map.bounds;

        return (ulong)map.list.SelectMany((rb, y) => rb.Select((c, x) => (x, y, c))).Select(t => (t.y, t.x, t.c))
            .ToHashSet().Sum(t => PriceStartingAt(map.list, (t.y, t.x), t.c, part));
    }

    private int PriceStartingAt(List<string> map, (int y, int x) start, char type, int part)
    {
        if (_checked.Contains(start)) return 0;
        var state = new Queue<(int y, int x)>([start]);
        var region = new HashSet<(int y, int x)>([start]);
        var walls = new HashSet<((int y, int x)pos, (int y, int x) dir)>();

        var perimeter = 0;
        while (state.Count > 0)
        {
            var current = state.Dequeue();
            foreach (var dir in Dirs)
            {
                (int y, int x) pos = (current.y + dir.y, current.x + dir.x);
                if (pos.y < 0 || pos.y > _bounds.h - 1 || pos.x < 0 || pos.x > _bounds.w - 1 ||
                    map[pos.y][pos.x] != type)
                {
                    perimeter++;
                    walls.Add((pos, dir));
                }
                else
                {
                    if (region.Contains(pos)) continue;
                    state.Enqueue(pos);
                    region.Add(pos);
                }
            }
        }
        _checked.UnionWith(region);
        return region.Count * (part == 1 ? perimeter : CountWalls(walls));
    }

    private static int CountWalls(HashSet<((int y, int x) pos, (int y, int x) dir)> walls)
    {
        var wh = new Dictionary<((int y, int x) dir, int axis), List<int>>(); // all the walls in a direction in an axis
        foreach (var wall in walls)
        {
            var v = wall.dir.x == 0 ? wall.pos.x : wall.pos.y; // if we're doing horizontal, value is x, if not y
            var a = wall.dir.x == 0 ? wall.pos.y : wall.pos.x; // if we're doing horizontal, the axis is y, if not x

            if (!wh.TryGetValue((wall.dir, a), out var items)) wh[(wall.dir, a)] = [v]; // no wall in the axis, add it
            else items.Add(v); // append to existing list of walls
        }

        return wh.Values.Select(v => v.OrderBy(x => x).Zip(v.OrderBy(x => x).Skip(1), // sorting and zip in pairs
                (a, b) => a + 1 != b ? 1 : 0).Sum() + 1 // counting when not consecutive [1,2,4,6,7] = 3 walls 
        ).Sum();
    }

    private (int h, int w) _bounds;
    private readonly HashSet<(int y, int x)> _checked = [];
    private static readonly (int y, int x)[] Dirs = [(0, 1), (1, 0), (0, -1), (-1, 0)];
}