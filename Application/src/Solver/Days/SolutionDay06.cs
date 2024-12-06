namespace Application.Solver.Days;

public class SolutionDay06() : DaySolver(6)
{
    public override int Resolve(int part, string input)
    {
        var map = Get2DArrayFromString(input);
        var (col, row, c) = map.SelectMany((row, y) => row.Select((c, x) => (x, y, c)))
            .Where(t => t.c != '.' && t.c != '#')
            .First(t => map[t.y][t.x] == t.c)
            .ToTuple();
        return GetVisited(map, row, col, c).Count;
    }

    private HashSet<(int, int)> GetVisited(char[][] map, int row, int col, char c)
    {
        var dir = Directions[c];
        var visited = new HashSet<(int, int)>();

        while (row >= 0 && row < map.Length && col >= 0 && col < map[row].Length)
        {
            if (map[row][col] == '#')
            {
                (row, col, dir) = Rotate(row, col, dir);
                continue;
            }

            visited.Add((row, col));
            (row, col) = Advance(row, col, dir);
        }

        return visited;
    }

    private static (int, int) Advance(int row, int col, (int row, int col, char) direction) =>
        (row + direction.row, col + direction.col);

    private static (int, int, (int, int, char)) Rotate(int row, int col, (int row, int col, char c) direction) =>
        (row - direction.row, col - direction.col, Directions[direction.c]);

    private static readonly Dictionary<char, (int, int, char)> Directions = new()
    {
        { '^', (-1, 0, '>') },
        { '>', (0, 1, 'v') },
        { 'v', (1, 0, '<') },
        { '<', (0, -1, '^') },
    };
}