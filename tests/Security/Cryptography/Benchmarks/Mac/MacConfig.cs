// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Mac;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

/// <summary>
/// BenchmarkDotNet configuration for MAC benchmarks.
/// </summary>
/// <remarks>
/// Mirrors <c>HashConfig</c> but is tailored for <c>TestMacAlgorithm</c> parameters.
/// Groups results by category (algorithm) then data size.
/// </remarks>
public class MacConfig : ManualConfig
{
    /// <summary>
    /// Shared instance of the short name markdown exporter.
    /// </summary>
    private static readonly ShortNameMarkdownExporter ShortExporter = new();

    public MacConfig()
    {
        WithOptions(ConfigOptions.DisableLogFile);

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            AddDiagnoser(new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(
                maxDepth: 3,
                printSource: true,
                exportGithubMarkdown: true,
                exportCombinedDisassemblyReport: true)));
        }

        Orderer = new CategoryThenDataSizeOrderer();
        AddColumn(new DescriptionColumn());
        HideColumns("Method", "TestMacAlgorithm");

        AddExporter(ShortExporter);
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name like "ComputeMac · HMAC-SHA256 · BouncyCastle".
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
            var macAlgorithm = benchmarkCase.Parameters["TestMacAlgorithm"] as MacAlgorithmType;

            if (macAlgorithm != null)
            {
                return $"{method} · {macAlgorithm.Category} · {GetImplementationType(macAlgorithm.Name)}";
            }

            // Benchmarks without a TestMacAlgorithm parameter (e.g. AesGmacBenchmark, which uses
            // [Benchmark(Description = ...)] directly instead of the registry-driven pattern) fall
            // back to WorkloadMethodDisplayInfo — BenchmarkDotNet wraps that in single quotes when
            // the description contains spaces, which the markdown exporter then HTML-escapes.
            return method.Trim('\'');
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        public bool IsAvailable(Summary summary) => true;

        private static string GetImplementationType(string name)
        {
            if (name.EndsWith("(OS)", System.StringComparison.InvariantCultureIgnoreCase))
                return "OS";
            if (name.EndsWith("(CryptoHives-Scalar)", System.StringComparison.InvariantCultureIgnoreCase))
                return "CryptoHives-Scalar";
            if (name.EndsWith("(BouncyCastle)", System.StringComparison.InvariantCultureIgnoreCase))
                return "BouncyCastle";
            return name;
        }
    }

    /// <summary>
    /// Orders benchmarks by category (algorithm), then by data size.
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

        public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase)
        {
            var macAlgorithm = benchmarkCase.Parameters["TestMacAlgorithm"] as MacAlgorithmType;
            return macAlgorithm?.Name.EndsWith("(CryptoHives-Scalar)", System.StringComparison.Ordinal) == true
                ? "CryptoHives-Scalar"
                : null;
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
                    var parts = g.Key.Split('|');
                    return parts.Length > 0 ? parts[0].Trim() : "";
                })
                .ThenBy(g => {
                    var parts = g.Key.Split('|');
                    var sizeName = parts.Length > 1 ? parts[1].Trim() : "";
                    var size = DataSize.AllSizes.FirstOrDefault(s => s.Name == sizeName);
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
            var macAlgorithm = benchmark.Parameters["TestMacAlgorithm"] as MacAlgorithmType;
            return macAlgorithm?.Category ?? "Unknown";
        }
    }

    /// <summary>
    /// Custom markdown exporter that uses short file names (class name only, no namespace).
    /// </summary>
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
