using System.Collections.Generic;
using Application.Solver;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver;

[TestClass]
public class DaySolverTest() : DaySolver(0)
{
    public override int Resolve(int part, string input)
    {
        return 0;
    }

    private const string TestInput = """
                                     ABC
                                     DEF
                                     """;

    private static readonly List<string> ExpectedList =
    [
        "ABC",
        "DEF",
    ];

    private static readonly char[][] ExpectedArray =
    [
        ['A', 'B', 'C'],
        ['D', 'E', 'F'],
    ];

    [TestMethod]
    public void GetListFromStringTest()
    {
        var result = GetListFromString(TestInput);
        result.Should().BeEquivalentTo(ExpectedList);
    }

    [TestMethod]
    public void Get2DArrayFromStringTest()
    {
        var result = Get2DArrayFromString(TestInput);
        result.Should().BeEquivalentTo(ExpectedArray);
    }
}