using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay08() : DaySolver(8)
{
    public override ulong Resolve(int part, string input)
    {
        var map = StringHelpers.GetListFromString(input);
        _bounds = (map.Count, map[0].Length);
        map.SelectMany((rb, y) => rb.Select((f, x) => (x, y, f))).Where(t => t.f != '.').Select(t => (t.y, t.x, t.f))
            .GroupBy(a => a.f).SelectMany(g => g.SelectMany(a1 => g.Where(a2 => a1 != a2), (a1, a2) => (a1, a2)))
            .ToList().ForEach(pair =>
                {
                    (int y, int x) d = (pair.a1.y - pair.a2.y, pair.a1.x - pair.a2.x);
                    var i = 2 - part;
                    while (true)
                    {
                        (int y, int x) l = (d.y * i, d.x * i);
                        var from1 = CheckAntinode(pair.a1, (l.y, l.x));
                        var from2 = CheckAntinode(pair.a2, (-l.y, -l.x));
                        if (part == 1 || !(from2 || from1)) break;
                        i++;
                    }
                }
            );
        return (ulong)_antinodes.Count;
    }

    private readonly HashSet<(int y, int x)> _antinodes = [];
    private (int h, int w) _bounds;

    private bool CheckAntinode((int y, int x, char f) antenna, (int y, int x) diff)
    {
        (int y, int x) pos = (antenna.y + diff.y, antenna.x + diff.x);
        if (pos.x < 0 || pos.x > _bounds.h - 1 || pos.y < 0 || pos.y > _bounds.w - 1) return false;
        _antinodes.Add(pos);
        return true;
    }
}