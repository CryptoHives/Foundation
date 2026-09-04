// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

/// <summary>
/// BenchmarkDotNet configuration for threading benchmarks.
/// Consolidates common settings (memory diagnoser, orderer, hidden columns, short-name exporter)
/// so that individual benchmark classes only need <c>[Config(typeof(ThreadingConfig))]</c>.
/// </summary>
public class ThreadingConfig : ManualConfig
{
    public ThreadingConfig()
    {
        WithOptions(ConfigOptions.DisableLogFile);

        AddDiagnoser(MemoryDiagnoser.Default);
        Orderer = new ParameterGroupOrderer();
        HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "Alloc Ratio", "Gen0", "Gen1", "Gen2", "Method");

        AddColumn(new DescriptionColumn());
        AddExporter(ShortNameMarkdownExporter.Default);
    }

    /// <summary>
    /// Orders the report's logical groups by their parameter values, so a group appears next to the ones
    /// it varies from by a single parameter.
    /// </summary>
    /// <remarks>
    /// <para>
    /// BenchmarkDotNet forms a logical group per distinct parameter combination, and a variant that only
    /// some implementations support - a timed wait, say - therefore lands in groups of its own. Under the
    /// default group ordering those one-row groups collect at the very bottom of the report, far from the
    /// rows they are meant to be read against, which makes the interesting comparison (the same
    /// KeyCount and Iterations, with and without a timer) impossible to see.
    /// </para>
    /// <para>
    /// Sorting groups by their parameter values in declaration order interleaves them instead: every
    /// variant of KeyCount = 1, Iterations = 100 sits together regardless of how many implementations
    /// contribute to each. The groups themselves are left intact - merging them would put several
    /// baselines in one group, which BenchmarkDotNet rejects - so ratios still compare like with like.
    /// </para>
    /// </remarks>
    private sealed class ParameterGroupOrderer : DefaultOrderer
    {
        public ParameterGroupOrderer()
            : base(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)
        {
        }

        public override IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(
            IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
            IEnumerable<BenchmarkLogicalGroupRule>? order = null)
            => logicalGroups.OrderBy(group => group.First(), ParameterValueComparer.Instance);

        /// <summary>
        /// Compares benchmark cases by their parameter values, position by position: numbers numerically
        /// so 100 follows 10 rather than preceding it, and wait configurations in the order they are
        /// declared rather than alphabetically.
        /// </summary>
        private sealed class ParameterValueComparer : IComparer<BenchmarkCase>
        {
            public static readonly ParameterValueComparer Instance = new();

            public int Compare(BenchmarkCase? x, BenchmarkCase? y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (x is null) return -1;
                if (y is null) return 1;

                var left = x.Parameters.Items;
                var right = y.Parameters.Items;
                int shared = Math.Min(left.Count, right.Count);

                for (int i = 0; i < shared; i++)
                {
                    int comparison = CompareValues(left[i].Value, right[i].Value);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }

                return left.Count.CompareTo(right.Count);
            }

            private static int CompareValues(object? left, object? right)
            {
                if (left is null || right is null)
                {
                    return left is null ? (right is null ? 0 : -1) : 1;
                }

                if (left is IConvertible && right is IConvertible
                    && TryToDouble(left, out double leftNumber) && TryToDouble(right, out double rightNumber))
                {
                    return leftNumber.CompareTo(rightNumber);
                }

                // Wait configurations sort by how they are declared, so the untimed baseline precedes the
                // variants that add machinery to it.
                int leftRank = WaitConfigurationRank(left);
                int rightRank = WaitConfigurationRank(right);
                if (leftRank != rightRank)
                {
                    return leftRank.CompareTo(rightRank);
                }

                return string.CompareOrdinal(left.ToString(), right.ToString());
            }

            private static bool TryToDouble(object value, out double result)
            {
                switch (value)
                {
                    case bool flag:
                        result = flag ? 1 : 0;
                        return true;
                    case string:
                        result = 0;
                        return false;
                    default:
                        try
                        {
                            result = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                            return true;
                        }
                        catch (Exception e) when (e is FormatException or InvalidCastException or OverflowException)
                        {
                            result = 0;
                            return false;
                        }
                }
            }

            private static int WaitConfigurationRank(object value)
                => value.ToString() switch {
                    "None" => 0,
                    "NotCancelled" => 1,
                    "Cancelled" => 2,
                    "Timed" => 3,
                    "NotCancelledTimed" => 4,
                    _ => int.MaxValue,
                };
        }
    }

    /// <summary>
    /// Custom column that creates a descriptive benchmark name like "Set · AsyncAutoResetEvent · Pooled".
    /// </summary>
    /// <remarks>
    /// Derives the description from <c>[BenchmarkCategory]</c> attributes on the method and class:
    /// <list type="bullet">
    /// <item><description>Method categories[0] → Operation (e.g. "Set", "WaitThenSet", "LockAsync")</description></item>
    /// <item><description>Method categories[2], if present, → Implementation variant for a sync baseline
    /// comparison (e.g. "Lock.EnterScope", "AutoResetEvent"); otherwise categories[1] (e.g. "Pooled",
    /// "Nito.AsyncEx")</description></item>
    /// <item><description>Method categories[3], if present, → Family override (e.g. "SyncLock" for the
    /// pure synchronous lock/interlocked/spin baselines, which form their own comparison table rather
    /// than the class-level primitive's); otherwise the class-level category (e.g. "AsyncLock",
    /// "AsyncAutoReset") — so sync baselines that ARE meant as a direct comparison (AutoResetEvent,
    /// ManualResetEvent, Barrier, CountdownEvent, ReaderWriterLockSlim) land in the same family/table
    /// as the async implementation being compared against.</description></item>
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

            // categories[2], when present, names the specific sync-baseline implementation
            // (e.g. "Lock.EnterScope", "AutoResetEvent"); otherwise categories[1] is the
            // implementation name for the common two-category case (e.g. "Pooled", "Nito.AsyncEx").
            string implementation = methodCategories.Length > 2
                ? methodCategories[2]
                : methodCategories.Length > 1 ? methodCategories[1] : "";

            // Family defaults to the class-level category (the primitive being benchmarked), so
            // sync baselines plot in the same family/table as the async implementations they're
            // compared against — unless categories[3] overrides it (e.g. "SyncLock" for the
            // sync-only lock/spin/interlocked baselines, which get their own table instead).
            string typeName = methodCategories.Length > 3
                ? methodCategories[3]
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

        private static string FormatPrimitive(string name) => name switch {
            "AsyncAutoResetEvent" => "AsyncAutoReset",
            "AsyncManualResetEvent" => "AsyncManualReset",
            "AsyncLock" => "AsyncLock",
            "AsyncSemaphore" => "AsyncSemaphore",
            "AsyncReaderWriterLock" => "AsyncRWLock",
            "AsyncBarrier" => "AsyncBarrier",
            _ => name,
        };
    }
}
