using System.Diagnostics.CodeAnalysis;
using Application.Solver;
using CommandLine;


namespace Application;

internal abstract partial class Program
{
    // ReSharper disable once ClassNeverInstantiated.Local
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    private class Options
    {
        [Option('d', "day", Required = true, HelpText = "day to run")]
        public int Day { get; set; }

        [Option('p', "part", Required = true, HelpText = "part to run")]
        public int Part { get; set; }

        [Option('l', "location", Required = false, HelpText = "location of data files", Default = "data")]
        public required string Location { get; set; }
    }

    private static void Main(string[] args) => Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
        (Solvers.FirstOrDefault(s => s.Day == o.Day) ?? new DefaultSolver()).Solve(o.Part, o.Location));
}