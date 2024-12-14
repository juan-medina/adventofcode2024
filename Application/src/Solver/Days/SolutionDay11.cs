using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay11() : DaySolver(11)
{
    public override ulong Resolve(int part, string input, bool _) =>
        StringHelpers.GetListFromString(input).SelectMany(line => line.Split(' ').Select(ulong.Parse))
            .ToList().Aggregate(0ul, (current, stone) => current + Count(stone, part == 1 ? 25ul : 75ul)); 

    private ulong Count(ulong stone, ulong iterations)
    {
        if (iterations == 0) return 1; // no more iterations this is the last rock
        if (_cache.ContainsKey((stone, iterations))) return _cache[(stone, iterations)]; // already calculated
        if (stone == 0) return Count(1, iterations - 1); // if is 0 return 1

        var split = Split(stone);
        var result = split.Item2 == ulong.MaxValue // is not even digits
            ? Count(split.Item1 * 2024, iterations - 1)  // return number by 2024
            : Count(split.Item1, iterations - 1) + Count(split.Item2, iterations - 1); // split number in two
        _cache[(stone, iterations)] = result; // cache result
        return result;
    }

    private static (ulong, ulong) Split(ulong number)
    {
        var length = (ulong)Math.Floor(Math.Log10(number) + 1);
        if (length % 2 != 0) return (number, ulong.MaxValue);
        var divisor = (ulong)Math.Pow(10, length >> 1);
        return (number / divisor, number % divisor);
    }
    
    private readonly Dictionary<(ulong stone, ulong iterations), ulong> _cache = new();
}