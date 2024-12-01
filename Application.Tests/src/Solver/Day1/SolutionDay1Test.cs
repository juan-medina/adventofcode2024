using System.Collections.Generic;
using Application.Solver.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Application.Tests.Solver.Day1;

[TestClass]
public class SolutionDay1Test : SolutionDay1
{
    private const string Part1Input = """
                                      3   4
                                      4   3
                                      2   5
                                      1   3
                                      3   9
                                      3   3
                                      """;

    private const string Part1Expected = "11";

    [TestMethod]
    public void SplitInLeftRightListsTest() => SolutionDay1.SplitInLeftRightLists(Part1Input).Should()
        .BeEquivalentTo((new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 }));

    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay1().Resolve(1, Part1Input).Should().Be(Part1Expected);

    private const string Part2Input = """
                                      3   4
                                      4   3
                                      2   5
                                      1   3
                                      3   9
                                      3   3
                                      """;

    private const string Part2Expected = "31";

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay1().Resolve(2, Part2Input).Should().Be(Part2Expected);
}