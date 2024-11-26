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
        Console.Write($"Solving Day ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(Day);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" Part ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(part);
        Console.WriteLine();

        var input = File.ReadAllText($"{dataPath}/day{Day}_input.txt");
        var result = Resolve(part, input);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Input:");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine(input);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Result:");
        Console.WriteLine();
        Console.ResetColor();
        Console.WriteLine(result);
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