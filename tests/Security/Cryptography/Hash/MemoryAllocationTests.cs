// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Measures and reports heap memory allocated by each hash algorithm constructor.
/// </summary>
[TestFixture]
[NonParallelizable]
public class MemoryAllocationTests
{
    /// <summary>
    /// Measures the managed heap bytes allocated when creating each CryptoHives hash
    /// algorithm and prints a formatted table to test output.
    /// </summary>
    [Test]
    public void ReportConstructorAllocations()
    {
        var factories = CryptoHivesManagedImplementations.All.Cast<HashAlgorithmFactory>().ToList();
        var results = new List<(string Name, long Bytes)>();

        foreach (var factory in factories)
        {
            // Warm up: JIT and static constructors
            using (factory.Create()) { }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long before = GC.GetAllocatedBytesForCurrentThread();
            var algo = factory.Create();
            long after = GC.GetAllocatedBytesForCurrentThread();

            results.Add((factory.Name, after - before));
            algo.Dispose();
        }

        // Print table sorted by allocation size
        var sorted = results.OrderBy(r => r.Bytes).ThenBy(r => r.Name).ToList();

        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"Algorithm",-40} {"Allocated",10}");
        TestContext.Out.WriteLine(new string('-', 51));

        foreach (var (name, bytes) in sorted)
        {
            TestContext.Out.WriteLine($"{name,-40} {bytes,10:N0} B");
        }

        TestContext.Out.WriteLine(new string('-', 51));
        TestContext.Out.WriteLine($"{"Total",-40} {sorted.Sum(r => r.Bytes),10:N0} B");
        TestContext.Out.WriteLine($"{"Average",-40} {sorted.Average(r => r.Bytes),10:N0} B");
        TestContext.Out.WriteLine($"{"Count",-40} {sorted.Count,10}");

        Assert.That(results, Is.Not.Empty);
    }
}
