using System.Collections.Generic;
using Application.Solver.Days;
using Application.Tests.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay01Test : SolutionDay01
{
    private const string Input = """
                                 3   4
                                 4   3
                                 2   5
                                 1   3
                                 3   9
                                 3   3
                                 """;

    [TestMethod]
    public void SplitInLeftRightListsTest() => SplitInLeftRightLists(Input).Should()
        .BeEquivalentTo((new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 }));

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay01>(1, Input, 11);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay01>(1, 2192892);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay01>(2, Input, 31);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay01>(2, 22962826);
}