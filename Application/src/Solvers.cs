using Application.Solver;

namespace Application;

internal abstract partial class Program
{
    private static readonly IDaySolver[] Solvers =
    [
        new Solver.Day1.SolutionDay1()
    ];
}