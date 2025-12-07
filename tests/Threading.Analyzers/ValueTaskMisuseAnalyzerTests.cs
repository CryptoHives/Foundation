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
    public async Task SingleAwait_NoDiagnostic()
    {
        var code = WrapInMethod("""
            ValueTask vt = default;
            await vt;
            """);

        await VerifyNoDiagnosticsAsync(code);
    }

    [Test]
    public async Task SingleAwaitWithConfigureAwait_NoDiagnostic()
    {
        var code = WrapInMethod("""
            ValueTask vt = default;
            await vt.ConfigureAwait(false);
            """);

        await VerifyNoDiagnosticsAsync(code);
    }

    [Test]
    public async Task MultipleAwait_ReportsError()
    {
        var code = WrapInMethod("""
            ValueTask vt = default;
            await vt;
            await vt;
            """);

        var expected = Diagnostic(DiagnosticDescriptors.MultipleAwait)
            .WithLocation(12, 19)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task GetAwaiterGetResult_ReportsWarning()
    {
        var code = WrapInMethod("""
            ValueTask vt = default;
            vt.GetAwaiter().GetResult();
            """);

        var expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(11, 13)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task GenericValueTaskGetAwaiterGetResult_ReportsWarning()
    {
        var code = WrapInMethod("""
            ValueTask<int> vt = default;
            int result = vt.GetAwaiter().GetResult();
            """);

        var expected = Diagnostic(DiagnosticDescriptors.BlockingGetResult)
            .WithLocation(11, 26)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task StoredInField_ReportsWarning()
    {
        var code = WrapInClass("""
            private ValueTask _valueTask;
            """);

        var expected = Diagnostic(DiagnosticDescriptors.StoredInField)
            .WithLocation(9, 31)
            .WithArguments("_valueTask");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task GenericValueTaskStoredInField_ReportsWarning()
    {
        var code = WrapInClass("""
            private ValueTask<int> _valueTask;
            """);

        var expected = Diagnostic(DiagnosticDescriptors.StoredInField)
            .WithLocation(9, 36)
            .WithArguments("_valueTask");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task DirectResultAccess_ReportsWarning()
    {
        var code = WrapInMethod("""
            ValueTask<int> vt = default;
            int result = vt.Result;
            """);

        var expected = Diagnostic(DiagnosticDescriptors.DirectResultAccess)
            .WithLocation(11, 26)
            .WithArguments("vt");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task NotConsumed_ReportsWarning()
    {
        var code = WrapInClass("""
            public void TestMethod()
            {
                GetValueTask();
            }

            private ValueTask GetValueTask() => default;
            """);

        var expected = Diagnostic(DiagnosticDescriptors.NotConsumed)
            .WithLocation(12, 13)
            .WithArguments("GetValueTask()");

        await VerifyAnalyzerAsync(code, expected);
    }

    [Test]
    public async Task AwaitedValueTask_NoDiagnostic()
    {
        var code = WrapInMethod("""
            await GetValueTask();

            ValueTask GetValueTask() => default;
            """);

        await VerifyNoDiagnosticsAsync(code);
    }

    [Test]
    public async Task ValueTaskStoredThenAwaited_NoDiagnostic()
    {
        var code = WrapInMethod("""
            var vt = GetValueTask();
            await vt;

            ValueTask GetValueTask() => default;
            """);

        await VerifyNoDiagnosticsAsync(code);
    }

    [Test]
    public async Task AsTaskThenAwait_NoDiagnostic()
    {
        var code = WrapInMethod("""
            ValueTask vt = default;
            await vt.AsTask();
            """);

        await VerifyNoDiagnosticsAsync(code);
    }

    [Test]
    public async Task TaskFieldHoldingTask_NoDiagnostic()
    {
        var code = WrapInClass("""
            private Task _task;
            """);

        await VerifyNoDiagnosticsAsync(code);
    }

    [Test]
    public async Task AsTaskStoredBeforeSignal_ReportsInfo()
    {
        var code = WrapInMethod("""
            ValueTask vt = default;
            Task t = vt.AsTask();
            await t;
            """);

        var expected = Diagnostic(DiagnosticDescriptors.AsTaskStoredBeforeSignal)
            .WithLocation(11, 13);

        await VerifyAnalyzerAsync(code, expected);
    }
}
