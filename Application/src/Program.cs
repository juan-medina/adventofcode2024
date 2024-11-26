using System.Reflection;
using Application;
using Application.Solver;
using CommandLine;

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();

var solvers = types
    .Where(type => type is { IsInterface: false, IsAbstract: false } && typeof(IDaySolver).IsAssignableFrom(type))
    .Select(type => Activator.CreateInstance(type) as IDaySolver)
    .ToArray();

Parser.Default.ParseArguments<Params>(args).WithParsed(param =>
    (solvers.FirstOrDefault(solver => solver?.Day == param.Day) ??
     new DefaultSolver()).Solve(param.Part, param.Location));