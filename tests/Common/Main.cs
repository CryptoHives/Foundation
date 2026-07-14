// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Running;
using System.Linq;

static class Program
{
    // Main Method
    public static void Main(string[] args)
    {
        // Create config without default exporters - benchmarks provide their own via [Config] attribute.
        // JsonExporter.Full is added globally so Bencher CI can consume the JSON output.
        IConfig config = ManualConfig.CreateEmpty()
            // Need this option because of reference to nunit.framework
            .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            .WithOptions(ConfigOptions.DisableLogFile)
            .WithOptions(ConfigOptions.DisableParallelBuild)
            // Add minimal required components
            .AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray())
            .AddLogger(DefaultConfig.Instance.GetLoggers().ToArray())
            .AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray())
            .AddValidator(DefaultConfig.Instance.GetValidators().ToArray())
            .AddExporter(JsonExporter.Full)
        ;
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}
