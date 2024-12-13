using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay13Test : SolutionDay13
{
    private const string Input = """
                                 Button A: X+94, Y+34
                                 Button B: X+22, Y+67
                                 Prize: X=8400, Y=5400
                                 
                                 Button A: X+26, Y+66
                                 Button B: X+67, Y+21
                                 Prize: X=12748, Y=12176
                                 
                                 Button A: X+17, Y+86
                                 Button B: X+84, Y+37
                                 Prize: X=7870, Y=6450
                                 
                                 Button A: X+69, Y+23
                                 Button B: X+27, Y+71
                                 Prize: X=18641, Y=10279
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay13>(1, Input, 480);
    
    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay13>(1, 33427);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay13>(2, Input, 875318608908U);
    
    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay13>(2, 91649162972270);
}