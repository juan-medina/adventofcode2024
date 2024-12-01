﻿using System.Collections.Generic;
using Application.Solver.Day1;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Day1;

[TestClass]
[TestSubject(typeof(SolutionDay1))]
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
    public void SplitInLeftRightListTest()
    {
        var expected = (new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 });
        var actual = SolutionDay1.SplitInLeftRightList(Part1Input);
        CollectionAssert.AreEqual(expected.Item1, actual.Item1, "left list");
        CollectionAssert.AreEqual(expected.Item2, actual.Item2, "right list");
    }
    
    [TestMethod]
    public void RemoveSmallerTest()
    {
        var original = new List<int> { 3, 4, 2, 1, 3, 3 };
        var expected = (1, new List<int> { 3, 4, 2, 3, 3 });
        var (smallest, remaining) =  SolutionDay1.RemoveSmallest(original);
        Assert.AreEqual(expected.Item1, smallest, "first smallest");
        CollectionAssert.AreEqual(expected.Item2, remaining, "first remaining list");
        
        original = [3, 4, 2, 7, 3, 3, 2];
        expected = (2, [3, 4, 7, 3, 3, 2]);
        (smallest, remaining) =  SolutionDay1.RemoveSmallest(original);
        Assert.AreEqual(expected.Item1, smallest, "second smallest");
        CollectionAssert.AreEqual(expected.Item2, remaining, "second remaining list");
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