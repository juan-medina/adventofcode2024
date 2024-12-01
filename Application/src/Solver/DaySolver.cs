namespace Application.Solver;

public interface IDaySolver
{
    void Solve(int part, string dataPath);
    int Day { get; }
}

public abstract class DaySolver(int day) : IDaySolver
{
    public int Day { get; } = day;

    public void Solve(int part, string dataPath)
    {
        if (part is < 1 or > 2)
        {
            Console.Error.WriteLine("Part must be 1 or 2");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Solving Day ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(Day);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Part ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(part);
        Console.WriteLine();
        Console.ResetColor();


        var filePath =
            Path.Combine(
                Path.IsPathRooted(dataPath) ? dataPath : Path.Combine(Directory.GetCurrentDirectory(), dataPath),
                $"day{Day}_input.txt");

        if (!File.Exists(filePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"Input file not found: {filePath}");
            Console.ResetColor();
            return;
        }

        var input = File.ReadAllText(filePath);

        var result = Resolve(part, input);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Input: {filePath}");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine(input);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Result:");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine(result);
        Console.ResetColor();
    }

    protected static List<string> GetListFromString(string input) =>
        input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries).ToList();

    public abstract string Resolve(int part, string input);
}

public class DefaultSolver : IDaySolver
{
    public void Solve(int part, string dataPath)
    {
        Console.Error.WriteLine("Solver not found for the given day");
    }

    public int Day => 0;
}