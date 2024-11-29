using Application.Helpers;
using JetBrains.Annotations;

namespace Application.Tests.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
[TestSubject(typeof(StringHelpersTest))]
public class StringHelpersTest
{
    [TestMethod]
    public void GetFirstTokenInStringTest()
    {
        Assert.AreEqual("a", StringHelpers.GetFirstTokenInString("abc", From.Left, ["a", "b", "c"]));
        Assert.AreEqual("c", StringHelpers.GetFirstTokenInString("abc", From.Right, ["a", "b", "c"]));

        Assert.AreEqual("b", StringHelpers.GetFirstTokenInString("abc", From.Left, ["b", "c"]));
        Assert.AreEqual("b", StringHelpers.GetFirstTokenInString("abc", From.Right, ["a", "b"]));

        Assert.AreEqual("cat", StringHelpers.GetFirstTokenInString("acateatadog", From.Left, ["dog", "cat", "mouse"]));
        Assert.AreEqual("dog", StringHelpers.GetFirstTokenInString("acateatadog", From.Right, ["dog", "cat", "mouse"]));

        Assert.AreEqual("", StringHelpers.GetFirstTokenInString("thereisnone", From.Left, ["dog", "cat", "mouse"]));
        Assert.AreEqual("", StringHelpers.GetFirstTokenInString("tereisnone", From.Right, ["dog", "cat", "mouse"]));
    }
}