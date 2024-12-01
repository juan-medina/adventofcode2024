﻿using System.Diagnostics.CodeAnalysis;
using CommandLine;

namespace Application;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
// ReSharper disable once ClassNeverInstantiated.Global
internal class Params
{
    [Option('d', "day", Required = true, HelpText = "day to run")]
    public int Day { get; set; }

    [Option('p', "part", Required = true, HelpText = "part to run")]
    public int Part { get; set; }

    [Option('l', "location", Required = false, HelpText = "location of data files", Default = "data")]
    public required string Location { get; set; }
}