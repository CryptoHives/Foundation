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
/// BenchmarkDotNet configuration for hash benchmarks.
/// Groups results by category (algorithm) then data size, highlights CryptoHives implementations.
/// </summary>
public class HashConfig : ManualConfig
{
    /// <summary>
    /// Shared instance of the short name markdown exporter.
    /// </summary>
    private static readonly ShortNameMarkdownExporter ShortExporter = new();

    public HashConfig()
    {
        // Disable default exporters
        WithOptions(ConfigOptions.DisableLogFile);

        Orderer = new CategoryThenDataSizeOrderer();
        AddColumn(new DescriptionColumn());
        HideColumns("Method", "TestHashAlgorithm", "TestXofAlgorithm");

        // Export formats: markdown for docfx (custom R script generates grouped charts from it)
        AddExporter(ShortExporter);
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name like "ComputeHash · SHA-256 · BouncyCastle".
    /// Uses middle dot (·) separator instead of pipe (|) to avoid breaking markdown tables.
    /// </summary>
    private class DescriptionColumn : IColumn
    {
        public string Id => "Description";
        public string ColumnName => "Description";
        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Job;
        public int PriorityInCategory => -10; // Show first
        public bool IsNumeric => false;
        public UnitType UnitType => UnitType.Dimensionless;
        public string Legend => "Benchmark description: Method · Category · Implementation";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            var hashAlgorithm = benchmarkCase.Parameters["TestHashAlgorithm"] as HashAlgorithmType;

            if (hashAlgorithm != null)
            {
                var implType = GetImplementationType(hashAlgorithm.Name);
                // Use middle dot (·) as separator to avoid breaking markdown tables
                return $"{method} · {hashAlgorithm.Category} · {implType}";
            }

            var xofAlgorithm = benchmarkCase.Parameters["TestXofAlgorithm"] as XofAlgorithmType;
            if (xofAlgorithm != null)
            {
                var implType = GetImplementationType(xofAlgorithm.Name);
                return $"{method} · {xofAlgorithm.Category} · {implType}";
            }

            return method;
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        public bool IsAvailable(Summary summary) => true;

        private static string GetImplementationType(string name)
        {
            if (name.EndsWith("(OS)", StringComparison.InvariantCultureIgnoreCase) ||
                name.EndsWith("(DotNet)", StringComparison.InvariantCultureIgnoreCase))
                return "OS Native";
            if (name.EndsWith("(Native)", StringComparison.InvariantCultureIgnoreCase))
                return "Native";
            if (name.EndsWith("(AVX2)", StringComparison.InvariantCultureIgnoreCase))
                return "AVX2";
            if (name.EndsWith("(AVX512F)", StringComparison.InvariantCultureIgnoreCase))
                return "AVX512F";
            if (name.EndsWith("(Sse2)", StringComparison.InvariantCultureIgnoreCase))
                return "Sse2";
            if (name.EndsWith("(Ssse3)", StringComparison.InvariantCultureIgnoreCase))
                return "Ssse3";
            if (name.EndsWith("(Managed)", StringComparison.InvariantCultureIgnoreCase) ||
                name.EndsWith("(CryptoHives)", StringComparison.InvariantCultureIgnoreCase))
                return "Managed";
            if (name.EndsWith("(HashifyNET)", StringComparison.InvariantCultureIgnoreCase))
                return "Hashify .NET";
            if (name.EndsWith("(BouncyCastle)", StringComparison.InvariantCultureIgnoreCase))
                return "BouncyCastle";
            if (name.EndsWith("(OpenGost)", StringComparison.InvariantCultureIgnoreCase))
                return "OpenGost";
            return name;
        }
    }

    /// <summary>
    /// Orders benchmarks by category (algorithm), then by data size, with fastest results first within each group.
    /// </summary>
    private class CategoryThenDataSizeOrderer : IOrderer
    {
        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null) =>
            from benchmark in benchmarksCase
            orderby GetCategory(benchmark),
                GetDataSizeBytes(benchmark),
                benchmark.Descriptor.WorkloadMethodDisplayInfo
            select benchmark;

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary) =>
            from benchmark in benchmarksCase
            orderby GetCategory(benchmark),
                GetDataSizeBytes(benchmark),
                summary[benchmark]?.ResultStatistics?.Mean ?? double.MaxValue
            select benchmark;

        public string GetHighlightGroupKey(BenchmarkCase benchmarkCase)
        {
            // Highlight CryptoHives "Managed" implementations
            var hashAlgorithm = benchmarkCase.Parameters["TestHashAlgorithm"] as HashAlgorithmType;
            return hashAlgorithm?.Name.EndsWith("_Managed", StringComparison.Ordinal) == true ? "Managed" : null!;
        }

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
        {
            var dataSize = benchmarkCase.Parameters["TestDataSize"] as DataSize;
            var category = GetCategory(benchmarkCase);
            return $"{category} | {dataSize?.Name ?? "Unknown"}";
        }

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null) =>
            logicalGroups
                .OrderBy(g => {
                    // Order by category first
                    var parts = g.Key.Split('|');
                    return parts.Length > 0 ? parts[0].Trim() : "";
                })
                .ThenBy(g => {
                    // Then by data size bytes
                    var parts = g.Key.Split('|');
                    var sizeName = parts.Length > 1 ? parts[1].Trim() : "";
                    var size = (DataSize?)DataSize.AllSizes.FirstOrDefault(s => s.Name == sizeName)
                        ?? XofDataSize.AllSizes.FirstOrDefault(s => s.Name == sizeName);
                    return size?.Bytes ?? int.MaxValue;
                });

        public bool SeparateLogicalGroups => true;

        private static int GetDataSizeBytes(BenchmarkCase benchmark)
        {
            var dataSize = benchmark.Parameters["TestDataSize"] as DataSize;
            return dataSize?.Bytes ?? int.MaxValue;
        }

        private static string GetCategory(BenchmarkCase benchmark)
        {
            var hashAlgorithm = benchmark.Parameters["TestHashAlgorithm"] as HashAlgorithmType;
            if (hashAlgorithm != null) return hashAlgorithm.Category;
            var xofAlgorithm = benchmark.Parameters["TestXofAlgorithm"] as XofAlgorithmType;
            return xofAlgorithm?.Category ?? "Unknown";
        }
    }

    /// <summary>
    /// Custom markdown exporter that uses short file names (class name only, no namespace).
    /// </summary>
    /// <remarks>
    /// Produces files like "SHA256Benchmark-report.md" instead of
    /// "Cryptography.Tests.Benchmarks.SHA256Benchmark-report-github.md".
    /// </remarks>
    private sealed class ShortNameMarkdownExporter : IExporter
    {
        private readonly IExporter _inner = MarkdownExporter.GitHub;

        public string Name => "ShortMarkdown";

        public IEnumerable<string> ExportToFiles(Summary summary, ILogger consoleLogger)
        {
            // Get short class name (without namespace)
            var typeName = summary.BenchmarksCases.FirstOrDefault()?.Descriptor.Type.Name ?? "Benchmark";

            var fileName = $"{typeName}-report.md";
            var filePath = Path.Combine(summary.ResultsDirectoryPath, fileName);

            // Export using the inner exporter's logic
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



