using System.Collections.Generic;
using Application.Helpers;

namespace Application.Tests.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

[TestClass]
public class StringHelpersTest
{
    [TestMethod]
    public void GetFirstTokenInStringTest()
    {
        StringHelpers.GetFirstTokenInString("abc", From.Left, ["a", "b", "c"]).Should().Be("a");
        StringHelpers.GetFirstTokenInString("abc", From.Right, ["a", "b", "c"]).Should().Be("c");

        StringHelpers.GetFirstTokenInString("abc", From.Left, ["b", "c"]).Should().Be("b");
        StringHelpers.GetFirstTokenInString("abc", From.Right, ["a", "b"]).Should().Be("b");

        StringHelpers.GetFirstTokenInString("acateatadog", From.Left, ["dog", "cat", "mouse"]).Should().Be("cat");
        StringHelpers.GetFirstTokenInString("acateatadog", From.Right, ["dog", "cat", "mouse"]).Should().Be("dog");

        StringHelpers.GetFirstTokenInString("thereisnone", From.Left, ["dog", "cat", "mouse"]).Should().BeEmpty();
        StringHelpers.GetFirstTokenInString("tereisnone", From.Right, ["dog", "cat", "mouse"]).Should().BeEmpty();
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
        var result = StringHelpers.GetListFromString(TestInput);
        result.Should().BeEquivalentTo(ExpectedList);
    }

    [TestMethod]
    public void Get2DArrayFromStringTest()
    {
        var result = StringHelpers.Get2DArrayFromString(TestInput);
        result.Should().BeEquivalentTo(ExpectedArray);
    }
}