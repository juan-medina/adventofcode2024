﻿namespace Application.Solver.Day5;

public class SolutionDay5() : DaySolver(5)
{
    public override int Resolve(int part, string input)
    {
        var (rules, updates) = ParseInput(input);
        return updates
            .Where(update => update.Select((_, i) => !update.Select((t2, j) => j > i
                        ? rules.Any(rule => rule.Item1 == update[i] && rule.Item2 == t2)
                        : rules.Any(rule => rule.Item1 == t2 && rule.Item2 == update[i]))
                    .Where((valid, j) => !valid && i != j).Any())
                .All(x => x) == (part == 1))
            .Select(update => update.OrderBy(page1 => page1, new PageComparer(rules)).ToList())
            .ToList().Sum(update => update[update.Count / 2]);
    }

    private class PageComparer(List<(int, int)> rules) : IComparer<int>
    {
        private int GetRuleResult(int page1, int page2) => rules.Any(r => r.Item1 == page1 && r.Item2 == page2) ? 1 : 0;
        public int Compare(int page1, int page2) => GetRuleResult(page1, page2) - GetRuleResult(page2, page1);
    }

    protected static (List<(int, int)>, List<List<int>>) ParseInput(string input)
    {
        var lines = GetListFromString(input);
        var rules = lines
            .Where(line => line.Contains('|'))
            .Select(line => line.Split('|'))
            .Select(tokens => (int.Parse(tokens[0]), int.Parse(tokens[1])))
            .ToList();

        var pages = lines
            .Where(line => line.Contains(','))
            .Select(line => line.Split(',').Select(int.Parse).ToList())
            .ToList();

        return (rules, pages);
    }
}