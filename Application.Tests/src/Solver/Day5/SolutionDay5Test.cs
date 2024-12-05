using System.Collections.Generic;
using Application.Solver.Day5;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Day5;

[TestClass]
public class SolutionDay5Test : SolutionDay5
{
    private const string Part1Input = """
                                      47|53
                                      97|13
                                      97|61
                                      97|47
                                      75|29
                                      61|13
                                      75|53
                                      29|13
                                      97|29
                                      53|29
                                      61|53
                                      97|53
                                      61|29
                                      47|13
                                      75|47
                                      97|75
                                      47|61
                                      75|61
                                      47|29
                                      75|13
                                      53|13

                                      75,47,61,53,29
                                      97,61,53,29,13
                                      75,29,13
                                      75,97,47,61,53
                                      61,13,29
                                      97,13,75,29,47
                                      """;

    private const int Part1Expected = 143;

    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay5().Resolve(1, Part1Input).Should().Be(Part1Expected);

    [TestMethod]
    public void ParseInputTest()
    {
        const string testInput = """
                                 1|23
                                 10|4

                                 10,20,30
                                 60,50
                                 """;

        var expectedRules = new List<(int, int)> { (1, 23), (10, 4) };
        var expectedUpdates = new List<List<int>> { new() { 10, 20, 30 }, new() { 60, 50 } };

        var (rules, updates) = ParseInput(testInput);
        
        rules.Should().BeEquivalentTo(expectedRules);
        updates.Should().BeEquivalentTo(expectedUpdates);
    }
}