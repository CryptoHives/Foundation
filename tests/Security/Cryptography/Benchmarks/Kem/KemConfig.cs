// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Kem;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
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
using System.Runtime.InteropServices;

/// <summary>
/// BenchmarkDotNet configuration for KEM benchmarks.
/// </summary>
/// <remarks>
/// Mirrors <c>MacConfig</c>, with one structural difference: KEM operations are
/// fixed-size, so there is no data-size axis. Results group by parameter set
/// (ML-KEM-512/768/1024) and then by operation, which puts the four implementations of the
/// same operation next to each other — the comparison the suite exists to make.
/// </remarks>
public class KemConfig : ManualConfig
{
    /// <summary>
    /// Shared instance of the short name markdown exporter.
    /// </summary>
    private static readonly ShortNameMarkdownExporter ShortExporter = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="KemConfig"/> class.
    /// </summary>
    public KemConfig()
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

        Orderer = new CategoryThenOperationOrderer();
        AddColumn(new DescriptionColumn());

        // "Code Size" is hidden here, because it is mostly NA.
        // The disassembly itself is still exported.
        HideColumns("Method", "TestKemAlgorithm", "Code Size");

        // Markdown for docfx, plus full JSON so append_results.py can ingest results without extra flags.
        AddExporter(ShortExporter);
        AddExporter(BenchmarkDotNet.Exporters.Json.JsonExporter.Full);
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name like
    /// "Encapsulate · ML-KEM-768 · BouncyCastle".
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
        public string Legend => "Benchmark description: Method · Parameter set · Implementation";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            var kemAlgorithm = benchmarkCase.Parameters["TestKemAlgorithm"] as KemAlgorithmType;

            if (kemAlgorithm != null)
            {
                return $"{method} · {kemAlgorithm.Category} · {GetImplementationType(kemAlgorithm.Name)}";
            }

            // Benchmarks without a TestKemAlgorithm parameter — the internals suite, which is
            // CryptoHives-only — fall back to the method description. BenchmarkDotNet wraps
            // that in single quotes when it contains spaces, which the markdown exporter then
            // HTML-escapes, so strip them.
            return method.Trim('\'');
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        public bool IsAvailable(Summary summary) => true;

        private static string GetImplementationType(string name)
        {
            if (name.EndsWith("(OS)", StringComparison.InvariantCultureIgnoreCase))
                return "OS";
            if (name.EndsWith("(CryptoHives)", StringComparison.InvariantCultureIgnoreCase))
                return "CryptoHives";
            if (name.EndsWith("(CryptoHives-Stateless)", StringComparison.InvariantCultureIgnoreCase))
                return "CryptoHives-Stateless";
            if (name.EndsWith("(BouncyCastle)", StringComparison.InvariantCultureIgnoreCase))
                return "BouncyCastle";
            return name;
        }
    }

    /// <summary>
    /// Orders benchmarks by parameter set, then by operation, then by measured mean.
    /// </summary>
    private class CategoryThenOperationOrderer : IOrderer
    {
        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null) =>
            from benchmark in benchmarksCase
            orderby GetCategory(benchmark),
                benchmark.Descriptor.WorkloadMethodDisplayInfo
            select benchmark;

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary) =>
            from benchmark in benchmarksCase
            orderby GetCategory(benchmark),
                benchmark.Descriptor.WorkloadMethodDisplayInfo,
                summary[benchmark]?.ResultStatistics?.Mean ?? double.MaxValue
            select benchmark;

        public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase)
        {
            var kemAlgorithm = benchmarkCase.Parameters["TestKemAlgorithm"] as KemAlgorithmType;
            return kemAlgorithm?.Name.EndsWith("(CryptoHives)", StringComparison.Ordinal) == true
                ? "CryptoHives"
                : null;
        }

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
        {
            var category = GetCategory(benchmarkCase);
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            return $"{category} | {method}";
        }

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null) =>
            logicalGroups
                .OrderBy(g => ParameterSetRank(g.Key.Split('|')[0].Trim()))
                .ThenBy(g => {
                    var parts = g.Key.Split('|');
                    return parts.Length > 1 ? parts[1].Trim() : "";
                }, StringComparer.Ordinal);

        public bool SeparateLogicalGroups => true;

        /// <summary>
        /// Orders the parameter sets by security category rather than alphabetically, so
        /// 1024 does not sort between 512 and 768.
        /// </summary>
        private static int ParameterSetRank(string category) => category switch {
            "ML-KEM-512" => 0,
            "ML-KEM-768" => 1,
            "ML-KEM-1024" => 2,
            _ => int.MaxValue,
        };

        private static string GetCategory(BenchmarkCase benchmark)
        {
            var kemAlgorithm = benchmark.Parameters["TestKemAlgorithm"] as KemAlgorithmType;
            return kemAlgorithm?.Category ?? "ML-KEM internals";
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
