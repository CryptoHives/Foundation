// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    public CipherConfig()
    {
        // Disable default exporters
        WithOptions(ConfigOptions.DisableLogFile);

        Orderer = new CategoryThenDataSizeOrderer();
        AddColumn(new DescriptionColumn());
        HideColumns("Method", "TestCipherAlgorithm");

        // Use GitHub markdown exporter
        AddExporter(MarkdownExporter.GitHub);
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
    /// Orders benchmarks by category (algorithm) then by data size.
    /// </summary>
    private class CategoryThenDataSizeOrderer : IOrderer
    {
        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase, IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => benchmarksCase;

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary)
            => benchmarksCase
                .OrderBy(b => b.Parameters["TestCipherAlgorithm"]?.ToString() ?? "")
                .ThenBy(b => GetDataSizeBytes(b));

        public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase) => null;

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
            => benchmarkCase.Parameters["TestDataSize"]?.ToString() ?? "Default";

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(
            IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => logicalGroups.OrderBy(g => GetDataSizeBytes(g.Key));

        public bool SeparateLogicalGroups => true;

        private static int GetDataSizeBytes(BenchmarkCase benchmarkCase)
        {
            var param = benchmarkCase.Parameters["TestDataSize"];
            if (param is DataSize ds) return ds.Bytes;
            return 0;
        }

        private static int GetDataSizeBytes(string name)
        {
            return name switch
            {
                "128B" => 128,
                "1KB" => 1024,
                "8KB" => 8192,
                "128KB" => 131072,
                _ => 0
            };
        }
    }
}
