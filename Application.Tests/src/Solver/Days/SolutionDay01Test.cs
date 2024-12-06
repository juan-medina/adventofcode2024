using System.Collections.Generic;
using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay01Test : SolutionDay01
{
    private const string Part1Input = """
                                      3   4
                                      4   3
                                      2   5
                                      1   3
                                      3   9
                                      3   3
                                      """;

    private const int Part1Expected = 11;

    [TestMethod]
    public void SplitInLeftRightListsTest() => SolutionDay01.SplitInLeftRightLists(Part1Input).Should()
        .BeEquivalentTo((new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 }));

    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay01().Resolve(1, Part1Input).Should().Be(Part1Expected);

    private const string Part2Input = """
                                      3   4
                                      4   3
                                      2   5
                                      1   3
                                      3   9
                                      3   3
                                      """;

    private const int Part2Expected = 31;

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay01().Resolve(2, Part2Input).Should().Be(Part2Expected);
}