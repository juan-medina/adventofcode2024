using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay15() : DaySolver(15)
{
    public override ulong Resolve(int part, string input, bool test)
    {
        (obstacles, walls, moves, bot) = Parse(input, part);

        Console.WriteLine("Initial state:");
        DrawMap();

        foreach (var d in moves)
        {
            Console.WriteLine($"Move {d}:");
            Move(d);
            DrawMap();
        }

        var total = 0;
        foreach (var o in obstacles)
        {
            total += o.y * 100 + o.x;
        }

        return (ulong)total;
    }

    private void DrawMap()
    {
        var maxX = walls.Max(o => o.x) + 1;
        var maxY = walls.Max(o => o.y) + 1;

        var map = new char[maxY, maxX];

        for (var y = 0; y < maxY; y++)
        for (var x = 0; x < maxX; x++)
            map[y, x] = '.';

        foreach (var wall in walls) map[wall.y, wall.x] = '#';

        foreach (var obstacle in obstacles)
        {
            if (obstacle.len == 1)
                map[obstacle.y, obstacle.x] = 'O';
            else
            {
                map[obstacle.y, obstacle.x] = '[';
                map[obstacle.y, obstacle.x + 1] = ']';
            }
        }

        map[bot.y, bot.x] = '@';

        for (var y = 0; y < maxY; y++)
            Console.WriteLine(string.Join("", Enumerable.Range(0, maxX).Select(x => map[y, x])));

        Console.WriteLine();
    }


    private void Move(char d)
    {
        var dir = Dirs[d];
        (int y, int x) n = (bot.y + dir.y, bot.x + dir.x);
        if (walls.Contains((n.y, n.x))) return;
        var o = obstacles.FirstOrDefault(o => o.x <= n.x && n.x < o.x + o.len && o.y == n.y);
        if (o != default)
        {
            var moved = GetObstaclesToMove(o, dir);
            if (moved.Count == 0) return;
            foreach (var mov in moved)
            {
                obstacles.Remove(mov); // remove the moved obstacles
                obstacles.Add((mov.y + dir.y, mov.x + dir.x, mov.len));
            }
        }

        bot = n;
    }

    private List<(int y, int x, int len)> GetObstaclesToMove((int y, int x, int len) pos, (int y, int x) d)
    {
        var check = new HashSet<(int y, int x, int len)>();
        if (walls.Contains((pos.y, pos.x))) return [];

        foreach (var next in GetNext(pos, d))
        {
            if (walls.Contains((next.y, next.x))) return [];
            var o = obstacles.FirstOrDefault(o => o.y == next.y && o.x == next.x);
            if (o == default) continue;
            var moved = GetObstaclesToMove(o, d);
            if (moved.Count == 0) return [];
            foreach (var mov in moved) check.Add(mov);
        }

        check.Add((pos.y, pos.x, pos.len));
        return check.ToList();
    }

    private static List<(int y, int x, int len)> GetNext((int y, int x, int len) pos, (int y, int x) d)
    {
        if (pos.len == 1)
        {
            return [(pos.y + d.y, pos.x + d.x, pos.len)];
        }

        if (d.y == 0)
        {
            return [(pos.y + d.y, pos.x + d.x * pos.len, pos.len)];
        }

        return
        [
            (pos.y + d.y, pos.x + d.x, pos.len),
            (pos.y + d.y, pos.x + d.x - (pos.len / 2), pos.len),
            (pos.y + d.y, pos.x + d.x + (pos.len / 2), pos.len)
        ];
    }

    private static (List<(int y, int x, int len)> obstacles, List<(int y, int x)> walls, List<char> moves,
        (int y, int x) bot) Parse(string input, int part)
    {
        var list = StringHelpers.GetListFromString(input);
        var l = list.Where(line => line.StartsWith('#')).ToList();
        var map = l.Select(line => line.Select(c => c).ToList()).ToList();

        if (part == 2)
        {
            for (var j = 0; j < map.Count; j++)
            {
                map[j] = string.Concat(map[j].Select(c => c switch
                {
                    'O' => "[]",
                    '@' => "@.",
                    _ => string.Concat(Enumerable.Repeat(c, 2))
                })).Select(c => c).ToList();
            }
        }

        List<(int y, int x)> walls = [];
        List<(int y, int x, int len)> obstacles = [];
        (int y, int x) bot = (0, 0);

        for (var j = 0; j < map.Count; j++)
        {
            for (var i = 0; i < map[j].Count; i++)
            {
                var c = map[j][i];
                switch (c)
                {
                    case '#':
                        walls.Add((j, i));
                        break;
                    case 'O':
                        obstacles.Add((j, i, 1));
                        break;
                    case '[':
                        obstacles.Add((j, i, 2));
                        break;
                    case '@':
                        bot = (j, i);
                        break;
                }
            }
        }

        var moves = list.Where(line => !line.StartsWith('#')).SelectMany(line => line.ToCharArray()).ToList();
        return (obstacles, walls, moves, bot);
    }

    private static readonly Dictionary<char, (int y, int x)> Dirs = new()
    {
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) },
        { '^', (-1, 0) }
    };

    private List<(int y, int x, int len)> obstacles;
    private List<(int y, int x)> walls;
    private List<char> moves;
    private (int y, int x) bot;
}