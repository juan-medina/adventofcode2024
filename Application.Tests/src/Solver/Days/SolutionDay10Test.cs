using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay10Test : SolutionDay10
{
    private const string Input = """
                                 89010123
                                 78121874
                                 87430965
                                 96549874
                                 45678903
                                 32019012
                                 01329801
                                 10456732
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay10>(1, Input, 36);
    
    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay10>(1, 811);
    
    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay10>(2, Input, 81);
    
    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay10>(2, 1794);
}