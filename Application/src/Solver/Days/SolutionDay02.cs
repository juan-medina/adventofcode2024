using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay02() : DaySolver(2)
{
    public override ulong Resolve(int part, string input) => (ulong)StringHelpers.GetListFromString(input)
        .Select(report => report.Split(" ").Select(int.Parse).ToList())
        .Count(part == 1 ? IsLevelsValid : IsLevelValidWithDampener);

    private static bool IsLevelsValid(List<int> levels) => (levels.Count < 1) ||
                                                           levels.Zip(levels.Skip(1), (a, b) => a - b).All(diff =>
                                                               (diff > 0) == levels[0] > levels[1] &&
                                                               Math.Abs(diff) is (> 0 and < 4));

    private static bool IsLevelValidWithDampener(List<int> levels) => IsLevelsValid(levels) ||
                                                                      levels.Select((_, i) =>
                                                                          levels.Where((_, index) => index != i)
                                                                              .ToList()).Any(IsLevelsValid);
}