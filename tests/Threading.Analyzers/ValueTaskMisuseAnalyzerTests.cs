// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="ValueTaskMisuseAnalyzer"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ValueTaskMisuseAnalyzerTests : AnalyzerTestBase<ValueTaskMisuseAnalyzer>
{
    [Test]
    public async Task SingleAwaitNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        await vt;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task SingleAwaitWithConfigureAwaitNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        await vt.ConfigureAwait(false);
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task MultipleAwaitReportsError()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        await vt;
        await {|#0:vt|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task GetAwaiterGetResultReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        {|#0:vt.GetAwaiter().GetResult()|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task GenericValueTaskGetAwaiterGetResultReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        ValueTask<int> vt = default;
        int result = {|#0:vt.GetAwaiter().GetResult()|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task StoredInFieldReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask {|#0:_valueTask|};
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.StoredInField)
            .WithLocation(0)
            .WithArguments("_valueTask");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task GenericValueTaskStoredInFieldReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> {|#0:_valueTask|};
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.StoredInField)
            .WithLocation(0)
            .WithArguments("_valueTask");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task DirectResultAccessReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        ValueTask<int> vt = default;
        int result = {|#0:vt.Result|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.DirectResultAccess)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task NotConsumedReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        {|#0:GetValueTask()|};
    }

    private ValueTask GetValueTask() => default;
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.NotConsumed)
            .WithLocation(0)
            .WithArguments("GetValueTask()");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AwaitedValueTaskNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        await GetValueTask();
    }

    private ValueTask GetValueTask() => default;
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task ValueTaskStoredThenAwaitedNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        var vt = GetValueTask();
        await vt;
    }

    private ValueTask GetValueTask() => default;
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AsTaskThenAwaitNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        await vt.AsTask();
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task TaskFieldHoldingTaskNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private Task _task;
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AsTaskStoredInTaskVariableNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        Task t = vt.AsTask();
        await t;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveAllowsMultipleAwaitsNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();
        await preserved;
        await preserved;
        await preserved;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveGenericAllowsMultipleAwaitsNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask<int> vt = new ValueTask<int>(42);
        ValueTask<int> preserved = vt.Preserve();
        int r1 = await preserved;
        int r2 = await preserved;
        int r3 = await preserved;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveWithConfigureAwaitAllowsMultipleAwaitsNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveConsumesOriginalValueTask()
    {
        // The original ValueTask should be marked as consumed when Preserve() is called
        // Using it again after Preserve() should report an error
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();
        await preserved;
        await {|#0:vt|}; // Error: vt was already consumed by Preserve()
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task OriginalValueTaskWithoutPreserveStillReportsMultipleAwait()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        await vt;
        await {|#0:vt|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task PreservedValueTaskGetAwaiterGetResultNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        ValueTask<int> vt = new ValueTask<int>(42);
        ValueTask<int> preserved = vt.Preserve();
        int result = preserved.GetAwaiter().GetResult();
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task PreservedValueTaskGetAwaiterGetResultMultipleTimesNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        ValueTask<int> vt = new ValueTask<int>(42);
        ValueTask<int> preserved = vt.Preserve();
        int r1 = preserved.GetAwaiter().GetResult();
        int r2 = preserved.GetAwaiter().GetResult();
        int r3 = preserved.GetAwaiter().GetResult();
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task NonPreservedValueTaskGetAwaiterGetResultReportsWarning()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        ValueTask<int> vt = new ValueTask<int>(42);
        int result = {|#0:vt.GetAwaiter().GetResult()|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ValueTaskArrayFieldNoDiagnostic()
    {
        // Arrays of ValueTask are allowed - they are used to collect multiple pending operations
        // before awaiting them sequentially (e.g., in benchmarks or batch processing scenarios)
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int>[] _valueTasks;
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task ValueTaskArrayLocalVariableNoDiagnostic()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask<int>[] tasks = new ValueTask<int>[10];
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = GetValueAsync(i);
        }
        foreach (var task in tasks)
        {
            await task;
        }
    }

    private ValueTask<int> GetValueAsync(int i) => new ValueTask<int>(i);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task CapturedValueTaskInLambdaReportsError()
    {
        // A ValueTask captured and awaited in a lambda is potentially unsafe
        // because the lambda could execute after the ValueTask is already consumed
        // or could be invoked multiple times
        var code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        Func<Task> lambda = async () => await {|#0:vt|};
        await lambda();
    }
}";
        var expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task CapturedValueTaskWithConfigureAwaitInLambdaReportsError()
    {
        var code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        Func<Task> lambda = async () => await {|#0:vt|}.ConfigureAwait(false);
        await lambda();
    }
}";
        var expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task CapturedPreservedValueTaskInLambdaNoDiagnostic()
    {
        // If the preserved ValueTask is captured, it's safe to await in the lambda
        var code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task TestMethod()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();
        Func<Task> lambda = async () => await preserved;
        await lambda();
        await lambda();
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task ValueTaskPreserveTestsPatternsAreDetected()
    {
        // This test verifies that the patterns used in ValueTaskPreserveTests.cs
        // (which are suppressed with #pragma warning disable CHT001)
        // would actually be detected by the analyzer.

        // Pattern: Multiple awaits on original ValueTask (from OriginalPooledSourceThrowsOnMultipleAwaitWithoutPreserve)
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task OriginalPooledSourceThrowsOnMultipleAwaitWithoutPreserve()
    {
        ValueTask<int> vt = new ValueTask<int>(42);
        
        // first await works
        int result = await vt;
        
        // second await should be flagged
        await {|#0:vt|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ValueTaskPreserveTestsMultipleAwaitOnPreservedIsAllowed()
    {
        // This test verifies that Preserve() properly allows multiple awaits
        // (corresponding to tests like PreserveCanBeAwaitedMultipleTimes)
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public async Task PreserveCanBeAwaitedMultipleTimes()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();
        
        await preserved;
        await preserved;
        await preserved;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }
}
