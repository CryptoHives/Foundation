// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
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
        HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "Alloc Ratio", "Gen0", "Gen1", "Gen2", "Method");

        AddColumn(new DescriptionColumn());
        AddExporter(ShortExporter);
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name like "Set · AsyncAutoResetEvent · Pooled".
    /// </summary>
    /// <remarks>
    /// Derives the description from <c>[BenchmarkCategory]</c> attributes on the method and class:
    /// <list type="bullet">
    /// <item><description>Method categories[0] → Operation (e.g. "Set", "WaitThenSet", "LockAsync")</description></item>
    /// <item><description>Method categories[1] → Implementation variant (e.g. "Pooled", "Nito.AsyncEx")</description></item>
    /// <item><description>Method categories[2] → Type override (optional, e.g. "AutoResetEvent" for sync baseline)</description></item>
    /// <item><description>Class-level category → Default type when categories[2] is absent</description></item>
    /// </list>
    /// Uses middle dot (·) separator instead of pipe (|) to avoid breaking markdown tables.
    /// </remarks>
    private sealed class DescriptionColumn : IColumn
    {
        public string Id => "Description";
        public string ColumnName => "Description";
        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Job;
        public int PriorityInCategory => -10;
        public bool IsNumeric => false;
        public UnitType UnitType => UnitType.Dimensionless;
        public string Legend => "Benchmark description: Operation · Primitive · Implementation";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            // Read method-level categories directly via reflection to avoid
            // BDN's Descriptor.Categories which may merge class+method categories.
            var methodCategories = benchmarkCase.Descriptor.WorkloadMethod
                .GetCustomAttributes(typeof(BenchmarkDotNet.Attributes.BenchmarkCategoryAttribute), false)
                .OfType<BenchmarkDotNet.Attributes.BenchmarkCategoryAttribute>()
                .SelectMany(a => a.Categories)
                .ToArray();

            var classCategories = benchmarkCase.Descriptor.Type
                .GetCustomAttributes(typeof(BenchmarkDotNet.Attributes.BenchmarkCategoryAttribute), true)
                .OfType<BenchmarkDotNet.Attributes.BenchmarkCategoryAttribute>()
                .SelectMany(a => a.Categories)
                .ToArray();

            string operation = methodCategories.Length > 0 ? methodCategories[0] : benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            string implementation = methodCategories.Length > 1 ? methodCategories[1] : "";

            // Use explicit type override (categories[2]) if present, otherwise fall back to class-level category.
            // This allows sync baseline methods (e.g. AutoResetEvent) to show their actual type
            // instead of the async class name (e.g. AsyncAutoResetEvent).
            string typeName = methodCategories.Length > 2
                ? methodCategories[2]
                : classCategories.Length > 0 ? FormatPrimitive(classCategories[0]) : "";

            if (!string.IsNullOrEmpty(typeName) && !string.IsNullOrEmpty(implementation))
            {
                return $"{operation} · {typeName} · {implementation}";
            }

            if (!string.IsNullOrEmpty(typeName))
            {
                return $"{operation} · {typeName}";
            }

            return operation;
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        public bool IsAvailable(Summary summary) => true;

        private static string FormatPrimitive(string name) => name switch
        {
            "AsyncAutoResetEvent" => "AsyncAutoReset",
            "AsyncManualResetEvent" => "AsyncManualReset",
            "AsyncLock" => "AsyncLock",
            "AsyncSemaphore" => "AsyncSemaphore",
            "AsyncReaderWriterLock" => "AsyncRWLock",
            "AsyncBarrier" => "AsyncBarrier",
            "AsyncCountdownEvent" => "AsyncCountdownEv",
            _ => name,
        };
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
