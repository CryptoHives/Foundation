// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="AsyncValueTaskBoxingAnalyzer"/> (CHT011 and CHT012).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncValueTaskBoxingAnalyzerTests : AnalyzerTestBase<AsyncValueTaskBoxingAnalyzer>
{
    // ── CHT011: nothing stands in the way of returning the inner ValueTask ────

    [Test]
    public async Task ExpressionBodiedForwarderReportsRedundantAsync()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> {|#0:OuterAsync|}() => await InnerAsync().ConfigureAwait(false);
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task BlockBodiedForwarderReportsRedundantAsync()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> {|#0:OuterAsync|}()
    {
        return await InnerAsync().ConfigureAwait(false);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task NonGenericValueTaskForwarderReportsRedundantAsync()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask InnerAsync() => default;

    public async ValueTask {|#0:OuterAsync|}()
    {
        await InnerAsync().ConfigureAwait(false);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ForwarderWithPrecedingSynchronousWorkReportsRedundantAsync()
    {
        // Work before the await is fine: it would simply run before the return in the rewritten form.
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync(int value) => default;

    public async ValueTask<int> {|#0:OuterAsync|}(int value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        return await InnerAsync(value).ConfigureAwait(false);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    // ── CHT012: cleanup keeps the async machinery load-bearing ───────────────

    [Test]
    public async Task ForwarderWrappedInTryCatchReportsBoxing()
    {
        // The exact shape that cost AsyncKeyedLock ~250 B per queued waiter: a single forwarded
        // ValueTask whose failure path has to release an administrative reference.
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private void Cleanup() { }

    public async ValueTask<int> {|#0:OuterAsync|}()
    {
        try
        {
            return await InnerAsync().ConfigureAwait(false);
        }
        catch
        {
            Cleanup();
            throw;
        }
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncWrapperBoxesStateMachine)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ForwarderWrappedInTryFinallyReportsBoxing()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private void Cleanup() { }

    public async ValueTask<int> {|#0:OuterAsync|}()
    {
        try
        {
            return await InnerAsync().ConfigureAwait(false);
        }
        finally
        {
            Cleanup();
        }
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncWrapperBoxesStateMachine)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ForwarderUnderUsingDeclarationReportsBoxing()
    {
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private IDisposable Enter() => null;

    public async ValueTask<int> {|#0:OuterAsync|}()
    {
        using var scope = Enter();
        return await InnerAsync().ConfigureAwait(false);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncWrapperBoxesStateMachine)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    // ── Negative cases ───────────────────────────────────────────────────────

    [Test]
    public async Task NonAsyncForwarderReportsNothing()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public ValueTask<int> OuterAsync() => InnerAsync();
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task MultipleAwaitsReportNothing()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> OuterAsync()
    {
        int first = await InnerAsync().ConfigureAwait(false);
        int second = await InnerAsync().ConfigureAwait(false);
        return first + second;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AwaitedResultUsedRatherThanForwardedReportsNothing()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> OuterAsync()
    {
        int result = await InnerAsync().ConfigureAwait(false);
        return result + 1;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task TaskReturningForwarderReportsNothing()
    {
        // Task has the same boxing behaviour, but returning it in place of the wrapper is a different
        // refactor with different exception semantics, so it is out of scope for these rules.
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private Task<int> InnerAsync() => null;

    public async Task<int> OuterAsync() => await InnerAsync().ConfigureAwait(false);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AwaitingATaskFromValueTaskMethodReportsNothing()
    {
        // The awaited operand is a Task, so there is no ValueTask to hand back directly.
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private Task<int> InnerAsync() => null;

    public async ValueTask<int> OuterAsync() => await InnerAsync().ConfigureAwait(false);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AwaitInsideNestedLambdaReportsNothing()
    {
        // The lambda compiles to its own state machine; the outer method never suspends on it.
        string code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private void Run(Func<ValueTask<int>> callback) { }

    public ValueTask<int> OuterAsync()
    {
        Run(async () => await InnerAsync().ConfigureAwait(false));
        return default;
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task WorkAfterTheAwaitReportsNothing()
    {
        string code = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask InnerAsync() => default;

    private void After() { }

    public async ValueTask OuterAsync()
    {
        await InnerAsync().ConfigureAwait(false);
        After();
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }
}
