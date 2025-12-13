// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

/// <summary>
/// BenchmarkDotNet configuration for hash benchmarks.
/// Groups results by category (algorithm) then data size, highlights CryptoHives implementations.
/// </summary>
public class HashConfig : ManualConfig
{
    public HashConfig()
    {
        Orderer = new CategoryThenDataSizeOrderer();
        AddColumn(new DescriptionColumn());
        HideColumns("Method", "TestHashAlgorithm");
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name like "ComputeHash | SHA-256 | BouncyCastle".
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
        public string Legend => "Benchmark description: Method | Category | Implementation";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            var method = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo;
            var hashAlgorithm = benchmarkCase.Parameters["TestHashAlgorithm"] as HashAlgorithmType;

            if (hashAlgorithm == null)
            {
                return method;
            }

            var implType = GetImplementationType(hashAlgorithm.Name);
            return $"{method} | {hashAlgorithm.Category} | {implType}";
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        public bool IsAvailable(Summary summary) => true;

        private static string GetImplementationType(string name)
        {
            if (name.EndsWith("_OS", System.StringComparison.Ordinal))
                return "OS Native";
            if (name.EndsWith("_OSManaged", System.StringComparison.Ordinal))
                return "OS Managed";
            if (name.EndsWith("_Managed", System.StringComparison.Ordinal))
                return "CryptoHives";
            if (name.EndsWith("_Bouncy", System.StringComparison.Ordinal))
                return "BouncyCastle";
            if (name.EndsWith("_Native", System.StringComparison.Ordinal))
                return "Native";
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
            return hashAlgorithm?.Name.EndsWith("_Managed", System.StringComparison.Ordinal) == true ? "Managed" : null!;
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
                .OrderBy(g =>
                {
                    // Order by category first
                    var parts = g.Key.Split('|');
                    return parts.Length > 0 ? parts[0].Trim() : "";
                })
                .ThenBy(g =>
                {
                    // Then by data size bytes
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
            var hashAlgorithm = benchmark.Parameters["TestHashAlgorithm"] as HashAlgorithmType;
            return hashAlgorithm?.Category ?? "Unknown";
        }
    }
}



