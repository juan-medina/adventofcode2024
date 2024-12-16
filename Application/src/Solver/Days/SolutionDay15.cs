using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay15() : DaySolver(15)
{
    public override ulong Resolve(int part, string input, bool test)
    {
        (_obstacles, _walls, _moves, _bot) = Parse(input, part);

        DrawMap("Initial state:");

        foreach (var d in _moves)
        {
            Move(d);
            DrawMap($"Move {d}:");
        }

        var total = 0;
        foreach (var o in _obstacles)
        {
            if (o.c == ']') continue;
            total += o.y * 100 + o.x;
        }

        return (ulong)total;
    }

    private void Move(char dir)
    {
        var d = Dirs[dir];
        (int y, int x) n = (_bot.y + d.y, _bot.x + d.x);
        if (CanBePushed(n, d))
        {
            MoveObstacles(n, d);
            _bot = n;
        }
    }

    enum ObjectType
    {
        Wall,
        Goods,
        LeftGoods,
        RightGoods,
        Empty,
    }

    private ObjectType GetObjectType((int y, int x) pos)
    {
        if (_walls.Contains(pos)) return ObjectType.Wall;
        var obstacle = _obstacles.FirstOrDefault(o => o.x == pos.x && pos.y == o.y);
        return obstacle == default
            ? ObjectType.Empty
            : obstacle.c switch
            {
                'O' => ObjectType.Goods,
                '[' => ObjectType.LeftGoods,
                ']' => ObjectType.RightGoods,
                _ => ObjectType.Empty
            };
    }

    private bool CanBePushed((int y, int x) pos, (int y, int x) d)
    {
        return GetObjectType(pos) switch
        {
            ObjectType.Empty => true,
            ObjectType.Wall => false,
            ObjectType.Goods => CanBePushed((pos.y + d.y, pos.x + d.x), d),
            ObjectType.LeftGoods => CanBePushed((pos.y + d.y, pos.x + d.x), d) &&
                                    (d.y == 0 || CanBePushed((pos.y + d.y, pos.x + d.x + 1), d)),
            ObjectType.RightGoods => CanBePushed((pos.y + d.y, pos.x + d.x), d) &&
                                     (d.y == 0 || CanBePushed((pos.y + d.y, pos.x + d.x - 1), d)),
            _ => false
        };
    }

    private void MoveObstacles((int y, int x) pos, (int y, int x) d)
    {
        switch (GetObjectType(pos))
        {
            case ObjectType.Empty: break;
            case ObjectType.Wall: throw new InvalidOperationException();
            case ObjectType.Goods:
                MoveObstacles((pos.y + d.y, pos.x + d.x), d);
                ReposObstacle((pos.y, pos.x), d);
                break;
            case ObjectType.LeftGoods:
                MoveObstacles((pos.y + d.y, pos.x + d.x), d);
                ReposObstacle((pos.y, pos.x), d);
                if (d.y != 0)
                {
                    MoveObstacles((pos.y + d.y, pos.x + d.x + 1), d);
                    ReposObstacle((pos.y, pos.x + 1), d);
                }

                break;
            case ObjectType.RightGoods:
                MoveObstacles((pos.y + d.y, pos.x + d.x), d);
                ReposObstacle((pos.y, pos.x), d);
                if (d.y != 0)
                {
                    MoveObstacles((pos.y + d.y, pos.x + d.x - 1), d);
                    ReposObstacle((pos.y, pos.x - 1), d);
                }

                break;
            default:
                throw new InvalidOperationException();
        }
    }

    private void ReposObstacle((int y, int x) pos, (int y, int x) d)
    {
        var obstacle = _obstacles.FirstOrDefault(o => o.x == pos.x && pos.y == o.y);
        if (obstacle == default) throw new InvalidOperationException();
        _obstacles.Remove(obstacle);
        _obstacles.Add((pos.y + d.y, pos.x + d.x, obstacle.c));
    }

    private static readonly Dictionary<char, (int y, int x)> Dirs = new()
    {
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) },
        { '^', (-1, 0) }
    };

    private List<(int y, int x, char c)> _obstacles = [];
    private List<(int y, int x)> _walls = [];
    private List<char> _moves = [];
    private (int y, int x) _bot = (0, 0);

    private static (List<(int y, int x, char c)> obstacles, List<(int y, int x)> walls, List<char> moves,
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
        List<(int y, int x, char c)> obstacles = [];
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
                    case '[':
                    case ']':
                        obstacles.Add((j, i, c));
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


    private void DrawMap(string title)
    {
        Console.WriteLine(title);
        var maxX = _walls.Max(o => o.x) + 1;
        var maxY = _walls.Max(o => o.y) + 1;

        var map = new char[maxY, maxX];

        for (var y = 0; y < maxY; y++)
        for (var x = 0; x < maxX; x++)
            map[y, x] = '.';

        foreach (var wall in _walls) map[wall.y, wall.x] = '#';

        foreach (var obstacle in _obstacles)
        {
            map[obstacle.y, obstacle.x] = obstacle.c;
        }

        map[_bot.y, _bot.x] = '@';

        for (var y = 0; y < maxY; y++)
            Console.WriteLine(string.Join("", Enumerable.Range(0, maxX).Select(x => map[y, x])));

        Console.WriteLine();
    }
}