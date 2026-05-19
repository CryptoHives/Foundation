// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Custom markdown exporter that uses short file names (class name only, no namespace).
/// </summary>
public sealed class ShortNameMarkdownExporter : IExporter
{
    public static readonly ShortNameMarkdownExporter Default = new();

    private readonly IExporter _inner = MarkdownExporter.GitHub;

    public string Name => "ShortMarkdown";

    public async ValueTask ExportAsync(Summary summary, ILogger consoleLogger, CancellationToken cancellationToken)
    {
        var typeName = summary.BenchmarksCases.FirstOrDefault()?.Descriptor.Type.Name ?? "Benchmark";

        var fileName = $"{typeName}-report.md";
        var filePath = Path.IsPathRooted(fileName)
            ? fileName
            : Path.Combine(summary.ResultsDirectoryPath, fileName);

        using var logger = new StreamLogger(filePath);

        consoleLogger.WriteLine($"  // * Results exported to: {filePath}");

        // Export using the async method and wait for completion
        await _inner.ExportAsync(summary, logger, cancellationToken).ConfigureAwait(false);
    }
}

static class Program
{
    // Main Method
    public static void Main(string[] args)
    {
        // Create config without default exporters - benchmarks provide their own via [Config] attribute
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
        ;
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
    }
}
