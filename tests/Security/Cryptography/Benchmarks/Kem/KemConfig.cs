// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Kem;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        AddExporter(ShortNameMarkdownExporter.Default);
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
            // BenchmarkDotNet wraps a description containing spaces in single quotes, which the
            // markdown exporter then HTML-escapes into &#39;. Strip them here so neither the
            // table nor the trends database carries them as part of the operation name.
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo.Trim('\'');
            var kemAlgorithm = benchmarkCase.Parameters["TestKemAlgorithm"] as KemAlgorithmType;

            if (kemAlgorithm != null)
            {
                return $"{method} · {kemAlgorithm.Category} · {GetImplementationType(kemAlgorithm.Name)}";
            }

            // Benchmarks without a TestKemAlgorithm parameter — the internals suite, which is
            // CryptoHives-only — fall back to the bare method description.
            return method;
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
            if (name.EndsWith("(CryptoHives-NoPct)", StringComparison.InvariantCultureIgnoreCase))
                return "CryptoHives-NoPct";
            if (name.EndsWith("(BouncyCastle)", StringComparison.InvariantCultureIgnoreCase))
                return "BouncyCastle";
            if (name.EndsWith("(KyberNET)", StringComparison.InvariantCultureIgnoreCase))
                return "KyberNET";
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
            orderby MethodRank(GetMethod(benchmark)),
                GetMethod(benchmark),
                ParameterSetRank(GetParameterSet(benchmark))
            select benchmark;

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary) =>
            from benchmark in benchmarksCase
            orderby MethodRank(GetMethod(benchmark)),
                GetMethod(benchmark),
                ParameterSetRank(GetParameterSet(benchmark)),
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
            => $"{GetMethod(benchmarkCase)} | {GetParameterSet(benchmarkCase)}";

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null) =>
            logicalGroups
                .OrderBy(g => MethodRank(g.Key.Split('|')[0].Trim()))
                .ThenBy(g => g.Key.Split('|')[0].Trim(), StringComparer.Ordinal)
                .ThenBy(g => {
                    string[] parts = g.Key.Split('|');
                    return ParameterSetRank(parts.Length > 1 ? parts[1].Trim() : string.Empty);
                });

        public bool SeparateLogicalGroups => true;

        /// <summary>
        /// Orders the operations the way one reads them — generate a key, encapsulate,
        /// decapsulate — rather than alphabetically, which would lead with Decapsulate.
        /// </summary>
        /// <remarks>
        /// Grouping is method-major and parameter-set-minor on purpose: every implementation
        /// of one operation sits together, and the three parameter sets run smallest first,
        /// so a table is read down a single operation instead of hopping between blocks.
        /// Methods without a rank fall back to alphabetical, which is what the internals
        /// suite gets.
        /// </remarks>
        private static int MethodRank(string method) => method switch {
            "KeyGen" => 0,
            "Encapsulate" => 1,
            "Decapsulate" => 2,
            "Decapsulate (rejected)" => 3,
            _ => int.MaxValue,
        };

        /// <summary>
        /// Orders the parameter sets by security category rather than alphabetically, so
        /// 1024 does not sort between 512 and 768.
        /// </summary>
        private static int ParameterSetRank(string parameterSet) => parameterSet switch {
            "ML-KEM-512" => 0,
            "ML-KEM-768" => 1,
            "ML-KEM-1024" => 2,
            _ => int.MaxValue,
        };

        /// <summary>
        /// Gets the operation name, stripped of the quotes BenchmarkDotNet adds around
        /// descriptions containing spaces.
        /// </summary>
        private static string GetMethod(BenchmarkCase benchmark)
            => benchmark.Descriptor.WorkloadMethodDisplayInfo.Trim('\'');

        /// <summary>
        /// Gets the parameter set, whether it arrives via the cross-implementation suite's
        /// algorithm parameter or the internals suite's plain string parameter.
        /// </summary>
        private static string GetParameterSet(BenchmarkCase benchmark)
        {
            if (benchmark.Parameters["TestKemAlgorithm"] is KemAlgorithmType kemAlgorithm)
            {
                return kemAlgorithm.Category;
            }

            return benchmark.Parameters["ParameterSet"] as string ?? string.Empty;
        }
    }
}
