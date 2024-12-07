using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay07() : DaySolver(7)
{
    public override ulong Resolve(int part, string input)
    {
        var total = 0ul;
        foreach (var line in StringHelpers.GetListFromString(input))
        {
            var items = line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray();
            var target = items[0];
            var result = Calc(items.Skip(1).ToArray(), 0, 0, target);
            if (result == target)
            {
                total += result;
            }
        }
        
        return total;
    }

    private static ulong Calc(ulong[] items, ulong index, ulong current, ulong target)
    {
        if (current>=target)
        {
            return current;
        }
        if (index != (ulong)items.Length)
            return Calc(items, index + 1, current + items[index], target) == target
                ? target
                : Calc(items, index + 1, current * items[index], target);
        return current;
    }
}