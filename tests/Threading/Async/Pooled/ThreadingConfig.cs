// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// BenchmarkDotNet configuration for threading benchmarks.
/// Consolidates common settings (memory diagnoser, orderer, hidden columns, short-name exporter)
/// so that individual benchmark classes only need <c>[Config(typeof(ThreadingConfig))]</c>.
/// </summary>
public class ThreadingConfig : ManualConfig
{
    /// <summary>
    /// Shared instance of the short name markdown exporter.
    /// </summary>
    private static readonly ShortNameMarkdownExporter ShortExporter = new();

    public ThreadingConfig()
    {
        WithOptions(ConfigOptions.DisableLogFile);

        AddDiagnoser(MemoryDiagnoser.Default);
        Orderer = new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared);
        HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "Alloc Ratio", "Gen0", "Gen1", "Gen2");

        AddExporter(ShortExporter);
    }

    /// <summary>
    /// Custom markdown exporter that uses short file names (class name only, no namespace).
    /// </summary>
    /// <remarks>
    /// Produces files like "AsyncLockSingleBenchmark-report.md" instead of
    /// "Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark-report-github.md".
    /// </remarks>
    private sealed class ShortNameMarkdownExporter : IExporter
    {
        private readonly IExporter _inner = MarkdownExporter.GitHub;

        public string Name => "ShortMarkdown";

        public IEnumerable<string> ExportToFiles(Summary summary, ILogger consoleLogger)
        {
            var typeName = summary.BenchmarksCases.FirstOrDefault()?.Descriptor.Type.Name ?? "Benchmark";

            var fileName = $"{typeName}-report.md";
            var filePath = Path.Combine(summary.ResultsDirectoryPath, fileName);

            using var writer = new StreamWriter(filePath);
            using var logger = new StreamLogger(writer);
            _inner.ExportToLog(summary, logger);

            consoleLogger.WriteLine($"  // * Results exported to: {filePath}");
            return [filePath];
        }

        public void ExportToLog(Summary summary, ILogger logger)
        {
            _inner.ExportToLog(summary, logger);
        }
    }
}
