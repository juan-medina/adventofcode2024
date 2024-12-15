using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay15() : DaySolver(15)
{
    public override ulong Resolve(int part, string input, bool test)
    {
        var (map, moves) = Parse(input);
        var (y, x, _) = map.SelectMany((row, y) => row.Select((c, x) => (y, x, c))).First(t => t.c == '@'); // find bot
        foreach (var r in moves.SelectMany(l => l)) (y, x) = Move((y, x), map, Dirs[r]); // do the movement
        return (ulong)map.SelectMany((row, oy) => row.Select((c, ox) => (oy, ox, c))).Where(t => t.c == 'O').ToList()
            .Sum(f => f.oy * 100 + f.ox); // sum the obstacles GPS
    }

    private static (int y, int x) Move((int y, int x) pos, List<List<char>> map, (int y, int x) d)
    {
        (int y, int x) n = (pos.y + d.y, pos.x + d.x); // new post with dir
        switch (map[n.y][n.x]) // check what is in the new pos
        {
            case '.': break; // space, we can move there
            case 'O': // obstacle
            {
                (int y, int x) end = (n.y + d.y, n.x + d.x); // end of the obstacles along the dir
                while (map[end.y][end.x] == 'O') end = (end.y + d.y, end.x + d.x); // find the end
                if (map[end.y][end.x] != '.') return pos; // if was not a space, we can't move
                for (var i = end; i != n; i = (i.y - d.y, i.x - d.x)) map[i.y][i.x] = map[i.y - d.y][i.x - d.x]; // move
                break;
            }
            default: return pos; // wall, we dont move
        }

        map[n.y][n.x] = map[pos.y][pos.x]; // move the bot
        map[pos.y][pos.x] = '.'; // empty the old bot position
        return n; // return new position for the bot
    }

    private static (List<List<char>> map, List<string> moves) Parse(string input)
    {
        var list = StringHelpers.GetListFromString(input);
        var l = list.Where(line => line.StartsWith('#')).ToList();
        var map = l.Select(line => line.Select(c => c).ToList()).ToList();

        var moves = list.Where(line => !line.StartsWith('#')).ToList();
        return (map, moves);
    }

    private static readonly Dictionary<char, (int y, int x)> Dirs = new()
    {
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) },
        { '^', (-1, 0) }
    };
}