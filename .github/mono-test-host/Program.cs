// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

// Runs the Cryptography tests in-process on the NUnit framework runner, for the Mono runtimes in
// .github/workflows/mono-runtimes.yml. VSTest cannot host browser-wasm and aborts on ppc64le Mono,
// and NUnitLite always starts an event-pump thread, which single-threaded wasm cannot.
//
//   TEST_WORKERS  Parallel workers. 0 (the default) runs everything on the main thread.
//   TEST_FILTER   Regular expression a test's full name must match, besides not being a benchmark.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Threading;
using NUnit;
using NUnit.Framework.Api;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

int workers = int.TryParse(Environment.GetEnvironmentVariable("TEST_WORKERS"), out int w) ? w : 0;
string? pattern = Environment.GetEnvironmentVariable("TEST_FILTER");

var runner = new NUnitTestAssemblyRunner(new DefaultTestAssemblyBuilder());
runner.Load(Assembly.Load("Cryptography.Tests"), new Dictionary<string, object>
{
    [FrameworkPackageSettings.NumberOfTestWorkers] = workers,
    [FrameworkPackageSettings.RunOnMainThread] = workers == 0,
    [FrameworkPackageSettings.SynchronousEvents] = true,
});

const string NotBenchmark = "<not><test re=\"1\">^Cryptography\\.Tests\\.Benchmarks\\.</test></not>";
TestFilter filter = TestFilter.FromXml(string.IsNullOrEmpty(pattern)
    ? $"<filter>{NotBenchmark}</filter>"
    : $"<filter><and>{NotBenchmark}<test re=\"1\">{SecurityElement.Escape(pattern)}</test></and></filter>");

var listener = new ConsoleListener();

// A timer callback needs a second thread, so the watchdog runs only alongside workers.
using Timer? watchdog = workers > 0
    ? new Timer(_ => listener.ReportLongRunning(TimeSpan.FromMinutes(10)), null, 60_000, 60_000)
    : null;

ITestResult result = runner.Run(listener, filter);

Console.WriteLine(
    $"{result.ResultState.Status}: {result.FailCount} failed, {result.PassCount} passed, " +
    $"{result.SkipCount + result.InconclusiveCount} skipped");
return result.ResultState.Status == TestStatus.Failed ? 1 : 0;

// NUnit redirects Console.Out while the run is in progress; keep the real one.
sealed class ConsoleListener : ITestListener
{
    private readonly TextWriter _out = Console.Out;
    private readonly ConcurrentDictionary<string, DateTime> _running = new();
    private readonly ConcurrentDictionary<string, bool> _reported = new();

    public void TestStarted(ITest test)
    {
        if (test.IsSuite) return;
        _running[test.FullName] = DateTime.UtcNow;
        _out.WriteLine($"=> {test.FullName}");
    }

    public void TestFinished(ITestResult result)
    {
        _running.TryRemove(result.FullName, out _);
        if (result.ResultState.Status != TestStatus.Failed) return;
        if (result.Test.IsSuite && result.ResultState.Site == FailureSite.Child) return;

        _out.WriteLine($"FAILED {result.FullName}: {result.Message}");
        if (!string.IsNullOrEmpty(result.StackTrace)) _out.WriteLine(result.StackTrace);
    }

    public void ReportLongRunning(TimeSpan limit)
    {
        foreach (KeyValuePair<string, DateTime> test in _running)
        {
            TimeSpan elapsed = DateTime.UtcNow - test.Value;
            if (elapsed > limit && _reported.TryAdd(test.Key, true))
                _out.WriteLine($"STILL RUNNING after {elapsed.TotalMinutes:F0} min: {test.Key}");
        }
    }

    public void TestOutput(TestOutput output) { }

    public void SendMessage(TestMessage message) { }
}
