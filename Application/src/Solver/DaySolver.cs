using System.Diagnostics;

namespace Application.Solver;

public interface IDaySolver
{
    void Solve(int part, string dataPath, bool test);
    int Day { get; }
}

public abstract class DaySolver(int day) : IDaySolver
{
    public int Day { get; } = day;

    public void Solve(int part, string dataPath, bool test)
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
                $"day_{Day:D2}_input.txt");

        if (!File.Exists(filePath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"Input file not found: {filePath}");
            Console.ResetColor();
            return;
        }

        var input = File.ReadAllText(filePath);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Input:");
        Console.ResetColor();
        Console.WriteLine(filePath);

        // get timer before
        var timer = Stopwatch.StartNew();
        var result = Resolve(part, input, test);
        timer.Stop();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Result:");
        Console.ResetColor();
        Console.WriteLine(result);
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Time:");
        Console.ResetColor();
        Console.WriteLine($"{timer.ElapsedMilliseconds} ms");
    }

    public abstract ulong Resolve(int part, string input, bool test);
}

public class DefaultSolver : IDaySolver
{
    public void Solve(int part, string dataPath, bool _)
    {
        Console.Error.WriteLine("Solver not found for the given day");
    }

    public int Day => 0;
}