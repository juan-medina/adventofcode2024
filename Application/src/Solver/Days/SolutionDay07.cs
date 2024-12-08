using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay07() : DaySolver(7)
{
    public override ulong Resolve(int part, string input) => (from line in StringHelpers.GetListFromString(input)
        select line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray()
        into items
        let target = items[0]
        let result = Calc(items.Skip(1).ToArray(), target, part == 1 ? Part1Operators : Part2Operators)
        where result == target
        select result).Aggregate(0ul, (current, result) => current + result);

    private static ulong Calc(ulong[] items, ulong target, List<Operator> operators, int index = 0, ulong current = 0)
    {
        if (current >= target || index == items.Length) return current;
        foreach (var operation in operators)
        {
            if (Calc(items, target, operators, index + 1, operation(current, items[index])) == target)
            {
                return target;
            }
        }

        return current;
    }

    private delegate ulong Operator(ulong param1, ulong param2);

    private static readonly List<Operator> Part1Operators = [(a, b) => a + b, (a, b) => a * b];
    private static readonly List<Operator> Part2Operators = [..Part1Operators, (a, b) => ulong.Parse(a + b.ToString())];
}