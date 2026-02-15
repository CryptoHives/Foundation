// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

/// <summary>
/// BenchmarkDotNet configuration for symmetric cipher benchmarks.
/// </summary>
/// <remarks>
/// <para>
/// This configuration mirrors <see cref="HashConfig"/> but is tailored for cipher benchmarks.
/// Groups results by category (algorithm) then data size.
/// </para>
/// </remarks>
public class CipherConfig : ManualConfig
{
    /// <summary>
    /// Shared instance of the short name markdown exporter.
    /// </summary>
    private static readonly ShortNameMarkdownExporter ShortExporter = new();

    public CipherConfig()
    {
        // Disable default exporters
        WithOptions(ConfigOptions.DisableLogFile);

        Orderer = new CategoryThenDataSizeOrderer();
        AddColumn(new DescriptionColumn());
        HideColumns("Method", "TestCipherAlgorithm");

        // Export formats: markdown with short file names (class name only, no namespace)
        AddExporter(ShortExporter);
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name.
    /// </summary>
    private class DescriptionColumn : IColumn
    {
        public string Id => "Description";
        public string ColumnName => "Description";
        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Job;
        public int PriorityInCategory => -10;
        public bool IsNumeric => false;
        public UnitType UnitType => UnitType.Dimensionless;
        public string Legend => "Benchmark description: Method · Category · Implementation";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            var category = benchmarkCase.Parameters["TestCipherAlgorithm"]?.ToString() ?? "Unknown";
            return $"{method} · {category}";
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
        public bool IsAvailable(Summary summary) => true;
    }

    /// <summary>
    /// Orders benchmarks by data size, then method (Encrypt/Decrypt), with fastest implementations
    /// first within each group. This produces separate paragraphs for each size+method combination,
    /// making it easy to compare Managed vs OS vs BouncyCastle.
    /// </summary>
    private class CategoryThenDataSizeOrderer : IOrderer
    {
        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase, IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => benchmarksCase;

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary)
            => from b in benchmarksCase
               orderby GetDataSizeBytes(b),
                   b.Descriptor.WorkloadMethodDisplayInfo,
                   summary[b]?.ResultStatistics?.Mean ?? double.MaxValue
               select b;

        public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
        {
            var dataSize = benchmarkCase.Parameters["TestDataSize"] as DataSize;
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            return $"{dataSize?.Name ?? "Unknown"} | {method}";
        }

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(
            IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => logicalGroups
                .OrderBy(g =>
                {
                    var parts = g.Key.Split('|');
                    var sizeName = parts.Length > 0 ? parts[0].Trim() : "";
                    return GetDataSizeBytes(sizeName);
                })
                .ThenBy(g =>
                {
                    var parts = g.Key.Split('|');
                    return parts.Length > 1 ? parts[1].Trim() : "";
                });

        public bool SeparateLogicalGroups => true;

        private static int GetDataSizeBytes(BenchmarkCase benchmarkCase)
        {
            var param = benchmarkCase.Parameters["TestDataSize"];
            if (param is DataSize ds) return ds.Bytes;
            return 0;
        }

        private static int GetDataSizeBytes(string name)
        {
            return name switch {
                "128B" => 128,
                "1KB" => 1024,
                "8KB" => 8192,
                "128KB" => 131072,
                _ => 0
            };
        }
    }

    /// <summary>
    /// Custom markdown exporter that uses short file names (class name only, no namespace).
    /// </summary>
    /// <remarks>
    /// Produces files like "AesGcm256Benchmark-report.md" instead of
    /// "Cryptography.Tests.Benchmarks.AesGcm256Benchmark-report-github.md".
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
