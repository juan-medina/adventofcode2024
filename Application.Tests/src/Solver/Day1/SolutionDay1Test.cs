using System.Collections.Generic;
using Application.Solver.Day1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Day1;

[TestClass]
public class SolutionDay1Test
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
    public void SplitInLeftRightListsTest()
    {
        var expected = (new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 });
        var actual = SolutionDay1.SplitInLeftRightLists(Part1Input);
        CollectionAssert.AreEqual(expected.Item1, actual.Item1, "left list");
        CollectionAssert.AreEqual(expected.Item2, actual.Item2, "right list");
    }

    [TestMethod]
    public void ResolvePart1Test() => Assert.AreEqual(Part1Expected, new SolutionDay1().Resolve(1, Part1Input));

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
    public void ResolvePart2Test() => Assert.AreEqual(Part2Expected, new SolutionDay1().Resolve(2, Part2Input));
}
