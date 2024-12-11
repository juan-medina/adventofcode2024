using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay11Test : SolutionDay11
{
    private const string Input = "125 17";

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay11>(1, Input, 55312);
    
    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay11>(1, 213625);
    
    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay11>(2, Input, 65601038650482UL);
    
    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay11>(2, 252442982856820);
}