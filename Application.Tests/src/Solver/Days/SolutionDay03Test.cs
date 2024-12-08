using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay03Test : SolutionDay03
{
    private const string Part1Input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay03>(1, Part1Input, 161);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay03>(1, 173419328);

    private const string Part2Input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay03>(2, Part2Input, 48);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay03>(2, 90669332);
}