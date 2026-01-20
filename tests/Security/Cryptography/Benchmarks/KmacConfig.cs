// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

/// <summary>
/// BenchmarkDotNet configuration for KMAC benchmarks.
/// Produces a Description column in the format: "ComputeHash | KMAC-128 | CryptoHives"
/// Orders by category (KMAC-128/KMAC-256) then by size (DataSize or OutputSize).
/// </summary>
public class KmacConfig : ManualConfig
{
    public KmacConfig()
    {
        Orderer = new KmacOrderer();
        AddColumn(new KmacDescriptionColumn());
        HideColumns("Method");
    }

    private class KmacDescriptionColumn : IColumn
    {
        public string Id => "Description";
        public string ColumnName => "Description";
        public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Job;
        public int PriorityInCategory => -10;
        public bool IsNumeric => false;
        public UnitType UnitType => UnitType.Dimensionless;
        public string Legend => "Benchmark description: Method | Category | Implementation";

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            // We want: ComputeHash | KMAC-128 | CryptoHives
            var workload = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo ?? "ComputeHash";
            // workload is expected like "KMAC128 CryptoHives" or "KMAC128 BouncyCastle"
            var parts = workload.Split(' ');
            var category = parts.Length > 0 ? MapCategory(parts[0]) : "KMAC";
            var impl = parts.Length > 1 ? MapImpl(parts[1]) : "Unknown";
            return $"ComputeHash | {category} | {impl}";
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
            => GetValue(summary, benchmarkCase);

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
        public bool IsAvailable(Summary summary) => true;

        private static string MapCategory(string token)
        {
            if (token.StartsWith("KMAC128", StringComparison.OrdinalIgnoreCase)) return "KMAC128";
            if (token.StartsWith("KMAC256", StringComparison.OrdinalIgnoreCase)) return "KMAC256";
            return token;
        }

        private static string MapImpl(string token)
        {
            if (token.Contains("Bouncy", StringComparison.OrdinalIgnoreCase)) return "BouncyCastle";
            if (token.Contains("CryptoHives", StringComparison.OrdinalIgnoreCase)) return "CryptoHives";
            if (token.Contains(".NET", StringComparison.OrdinalIgnoreCase) || token.Contains("DotNet", StringComparison.OrdinalIgnoreCase)) return "OS Native";
            return token;
        }
    }

    private class KmacOrderer : IOrderer
    {
        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => benchmarksCase.OrderBy(b => GetCategoryKey(b))
                             .ThenBy(b => GetSizeBytes(b))
                             .ThenBy(b => b.Descriptor.WorkloadMethodDisplayInfo);

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCase, Summary summary)
            => benchmarksCase.OrderBy(b => GetCategoryKey(b))
                             .ThenBy(b => GetSizeBytes(b))
                             .ThenBy(b => summary[b]?.ResultStatistics?.Mean ?? double.MaxValue);

        public string GetHighlightGroupKey(BenchmarkCase benchmarkCase)
        {
            var workload = benchmarkCase.Descriptor.WorkloadMethodDisplayInfo ?? "";
            return workload.Contains("CryptoHives", StringComparison.OrdinalIgnoreCase) ? "Managed" : null!;
        }

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
        {
            var category = GetCategoryKey(benchmarkCase);
            var size = GetSizeName(benchmarkCase);
            return $"{category} | {size}";
        }

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => logicalGroups.OrderBy(g => g.Key);

        public bool SeparateLogicalGroups => true;

        private static long GetSizeBytes(BenchmarkCase benchmark)
        {
            if (benchmark.Parameters.Items.Any(p => p.Name == "DataSize"))
            {
                var val = benchmark.Parameters.Items.First(p => p.Name == "DataSize").Value;
                if (val is DataSize ds) return ds.Bytes;
                var name = val?.ToString();
                if (!string.IsNullOrEmpty(name))
                {
                    var match = DataSize.AllSizes.FirstOrDefault(s => s.Name == name);
                    if (match != null) return match.Bytes;
                }
            }

            if (benchmark.Parameters.Items.Any(p => p.Name == "OutputSize"))
            {
                var val = benchmark.Parameters.Items.First(p => p.Name == "OutputSize").Value;
                if (int.TryParse(val?.ToString(), out var outSize)) return outSize;
            }

            return int.MaxValue;
        }

        private static string GetSizeName(BenchmarkCase benchmark)
        {
            if (benchmark.Parameters.Items.Any(p => p.Name == "DataSize"))
                return benchmark.Parameters.Items.First(p => p.Name == "DataSize").Value?.ToString() ?? "Unknown";
            if (benchmark.Parameters.Items.Any(p => p.Name == "OutputSize"))
                return benchmark.Parameters.Items.First(p => p.Name == "OutputSize").Value?.ToString() ?? "Unknown";
            return "N/A";
        }

        private static string GetCategoryKey(BenchmarkCase benchmark)
        {
            var workload = benchmark.Descriptor.WorkloadMethodDisplayInfo ?? string.Empty;
            var token = workload.Split(' ').FirstOrDefault() ?? string.Empty;
            if (token.StartsWith("KMAC128", StringComparison.OrdinalIgnoreCase)) return "KMAC-128";
            if (token.StartsWith("KMAC256", StringComparison.OrdinalIgnoreCase)) return "KMAC-256";
            return token;
        }
    }
}
