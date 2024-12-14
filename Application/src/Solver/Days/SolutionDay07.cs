using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay07() : DaySolver(7)
{
    public override ulong Resolve(int part, string input, bool _) => (from line in StringHelpers.GetListFromString(input)
        select line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray()
        into items
        let target = items[0]
        let result = Calc(items.Skip(1).ToArray(), target, part == 1 ? Part1Operators : Part2Operators)
        where result == target
        select result).Aggregate(0ul, (current, result) => current + result);

    private static ulong Calc(ulong[] items, ulong target, List<Operator> operators)
    {
        var stack = new Stack<(int index, ulong current)>();
        stack.Push((0, 0));
        while (stack.Count > 0)
        {
            var (index, current) = stack.Pop();

            if (current == target) return current;
            if (current > target || index == items.Length) continue;

            foreach (var op in operators)
            {
                var result = op(current, items[index]);
                stack.Push((index + 1, result));
            }
        }

        return 0;
    }

    private delegate ulong Operator(ulong param1, ulong param2);

    private static readonly List<Operator> Part1Operators = [(a, b) => a + b, (a, b) => a * b];
    private static readonly List<Operator> Part2Operators = [..Part1Operators, (a, b) => ulong.Parse(a + b.ToString())];
}