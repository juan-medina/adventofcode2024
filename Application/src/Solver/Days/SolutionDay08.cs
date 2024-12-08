using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay08() : DaySolver(8)
{
    public override ulong Resolve(int part, string input)
    {
        var map = StringHelpers.GetListFromStringWithBounds(input);
        _bounds = map.bounds;
        map.list.SelectMany((rb, y) => rb.Select((f, x) => (x, y, f))).Where(t => t.f != '.')
            .Select(t => (t.y, t.x, t.f))
            .GroupBy(a => a.f).SelectMany(g => g.SelectMany(a1 => g.Where(a2 => a1 != a2), (a1, a2) => (a1, a2)))
            .ToList().ForEach(pair =>
                {
                    (int y, int x) d = (pair.a1.y - pair.a2.y, pair.a1.x - pair.a2.x);
                    var i = 2 - part; // part 2 antinodes will be where the antenna are, because is the complete line
                    while (true)
                    {
                        (int y, int x) l = (d.y * i, d.x * i); // distance from the antenna [1-2] in this iteration
                        var from1 = CheckAntinode(pair.a1, (l.y, l.x));
                        var from2 = CheckAntinode(pair.a2, (-l.y, -l.x));
                        if (part == 1 || !(from1 || from2)) break; // if we are OoB in both antinodes, or if part 1
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
        if (pos.x < 0 || pos.x > _bounds.h - 1 || pos.y < 0 || pos.y > _bounds.w - 1) return false; // stop OoB
        _antinodes.Add(pos);
        return true; // regardless if the antinode was there or not we need to continue for part 2
    }
}