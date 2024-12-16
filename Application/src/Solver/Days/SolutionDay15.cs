using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay15() : DaySolver(15)
{
    public override ulong Resolve(int part, string input, bool test)
    {
        (_boxes, _walls, _moves, _bot) = Parse(input, part); // parse the input
        _moves.ForEach(Move); // do the movements
        return (ulong)_boxes.Where(o => o.t != T.Rb).Sum(o => o.y * 100 + o.x); // GPS of the boxes, skip right sides
    }

    private void Move(char dir)
    {
        var d = Dirs[dir]; // get the direction 
        (int y, int x) n = (_bot.y + d.y, _bot.x + d.x); // get the new position using the direction
        if (!CanBePushed(n, d)) return; // if we can not move return
        MoveBoxes(n, d); // move the obstacles in the new position
        _bot = n; // update the bot position
    }

    private T GetObjectType((int y, int x) pos)
    {
        if (_walls.Contains(pos)) return T.Wall; // check if is on the wall list
        var obstacle = _boxes.FirstOrDefault(o => o.x == pos.x && pos.y == o.y); // find an obstacle in this pos
        return obstacle != default ? obstacle.t : T.Empty; // return the type, or empty if is not an obstacle
    }

    private bool CanBePushed((int y, int x) pos, (int y, int x) d)
    {
        var type = GetObjectType(pos); // get what object type is in this position
        return type switch
        {
            T.Empty => true, // we can push a empty space
            T.Wall => false, // we can not push a wall
            T.Box or T.Lb or T.Rb => CanBePushed((pos.y + d.y, pos.x + d.x), d) && // left part of the box
                                     (type == T.Box || d.y == 0 || // skip if is a single box or going horizontal
                                      CanBePushed((pos.y + d.y, pos.x + d.x + (type == T.Lb ? 1 : -1)), d)), // right p
            _ => false // this shouldn't happen (famous last words)
        };
    }

    private void MoveBoxes((int y, int x) pos, (int y, int x) d)
    {
        var type = GetObjectType(pos); // get what object type is in this position
        switch (type)
        {
            case T.Box:
            case T.Lb:
            case T.Rb:
                MoveBoxes((pos.y + d.y, pos.x + d.x), d); // move other obstacles in left part of the box
                UpdateBox((pos.y, pos.x), d); // update this part of the box
                if (type != T.Box && d.y != 0) // if not a single box or going horizontal
                {
                    var add = type == T.Lb ? 1 : -1; // if left or right part of the box
                    MoveBoxes((pos.y + d.y, pos.x + d.x + add), d); // move other obstacles in right part of the box
                    UpdateBox((pos.y, pos.x + add), d); // update the right part of the box
                }

                break;
            case T.Empty:
            case T.Wall:
            case T.Bot:
            default:
                break; // nothing to do in these objects types
        }
    }

    private void UpdateBox((int y, int x) pos, (int y, int x) d)
    {
        var o = _boxes.First(o => o.x == pos.x && pos.y == o.y); // find the obstacle
        _boxes.Remove(o); // remove it
        _boxes.Add((pos.y + d.y, pos.x + d.x, o.t)); // add it in the new position
    }

    private static readonly Dictionary<char, (int y, int x)> Dirs = new()
    {
        { '>', (0, 1) },
        { 'v', (1, 0) },
        { '<', (0, -1) },
        { '^', (-1, 0) }
    };

    private List<(int y, int x, T t)> _boxes = [];
    private List<(int y, int x)> _walls = [];
    private List<char> _moves = [];
    private (int y, int x) _bot = (0, 0);

    private enum T
    {
        Wall = '#',
        Box = 'O',
        Lb = '[',
        Rb = ']',
        Empty = '.',
        Bot = '@'
    }

    private static (List<(int y, int x, T c)> boxes, List<(int y, int x)> walls, List<char> moves,
        (int y, int x) bot) Parse(string input, int part)
    {
        var list = StringHelpers.GetListFromString(input); // read all input as strings, this skip the empty lines
        var l = list.Where(line => line.StartsWith('#')).ToList(); // the map lines are starting with #
        var map = l.Select(line => line.Select(c => c).ToList()).ToList(); // convert to a list
        if (part == 2) // if part 2 expand it
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
        List<(int y, int x, T t)> boxes = [];
        (int y, int x) bot = (0, 0);

        for (var j = 0; j < map.Count; j++)
        {
            for (var i = 0; i < map[j].Count; i++)
            {
                var t = (T)map[j][i];
                switch (t)
                {
                    case T.Wall:
                        walls.Add((j, i)); // add the wall
                        break;
                    case T.Box:
                    case T.Lb:
                    case T.Rb:
                        boxes.Add((j, i, t)); // add the box, single, left or right
                        break;
                    case T.Bot:
                        bot = (j, i); // save the bot position
                        break;
                    case T.Empty: // we don't need to store empty spaces
                    default:
                        break;
                }
            }
        }

        var moves = list.Where(line => !line.StartsWith('#')).SelectMany(line => line.ToCharArray()).ToList();
        return (boxes, walls, moves, bot);
    }
}