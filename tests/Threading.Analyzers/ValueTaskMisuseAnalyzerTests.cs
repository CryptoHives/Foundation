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
        var code = @"
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
        var code = @"
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
        var code = @"
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
        var expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task GetAwaiterGetResultReportsWarning()
    {
        var code = @"
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
        var expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task GenericValueTaskGetAwaiterGetResultReportsWarning()
    {
        var code = @"
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
        var expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task StoredInFieldReportsWarning()
    {
        var code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask {|#0:_valueTask|};
}";
        var expected = Diagnostic(DiagnosticDescriptors.StoredInField)
            .WithLocation(0)
            .WithArguments("_valueTask");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task GenericValueTaskStoredInFieldReportsWarning()
    {
        var code = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> {|#0:_valueTask|};
}";
        var expected = Diagnostic(DiagnosticDescriptors.StoredInField)
            .WithLocation(0)
            .WithArguments("_valueTask");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task DirectResultAccessReportsWarning()
    {
        var code = @"
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
        var expected = Diagnostic(DiagnosticDescriptors.DirectResultAccess)
            .WithLocation(0)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task NotConsumedReportsWarning()
    {
        var code = @"
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
        var expected = Diagnostic(DiagnosticDescriptors.NotConsumed)
            .WithLocation(0)
            .WithArguments("GetValueTask()");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AwaitedValueTaskNoDiagnostic()
    {
        var code = @"
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
        var code = @"
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
        var code = @"
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
        var code = @"
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
        // Note: The AsTaskStoredBeforeSignal diagnostic is intended for cases where
        // storing AsTask() result before signaling causes performance degradation.
        // Currently the analyzer only checks ValueTask variable initializers,
        // but AsTask() returns Task, so this scenario isn't detected.
        // This test documents the current behavior.
        var code = @"
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
}
