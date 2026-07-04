// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="SemaphoreSlimAsAsyncLockAnalyzer"/> (CHT009).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SemaphoreSlimAsAsyncLockAnalyzerTests : AnalyzerTestBase<SemaphoreSlimAsAsyncLockAnalyzer>
{
    // ── Positive cases (diagnostic expected) ──────────────────────────────────

    [Test]
    public async Task FieldDeclarationWithExplicitTypeReportsDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim {|#0:_sem|} = {|#1:new SemaphoreSlim(1, 1)|};
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(1)
            .WithArguments("_sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task LocalVariableWithExplicitTypeReportsDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    public void TestMethod()
    {
        SemaphoreSlim sem = {|#0:new SemaphoreSlim(1, 1)|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(0)
            .WithArguments("sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task LocalVariableWithVarTypeReportsDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    public void TestMethod()
    {
        var sem = {|#0:new SemaphoreSlim(1, 1)|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(0)
            .WithArguments("sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task FullyQualifiedTypeNameReportsDiagnostic()
    {
        string code = @"
public class TestClass
{
    public void TestMethod()
    {
        System.Threading.SemaphoreSlim sem = {|#0:new System.Threading.SemaphoreSlim(1, 1)|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(0)
            .WithArguments("sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AssignmentExpressionReportsDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private SemaphoreSlim _sem;

    public void Init()
    {
        _sem = {|#0:new SemaphoreSlim(1, 1)|};
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(0)
            .WithArguments("_sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ImplicitObjectCreationReportsDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem = {|#0:new(1, 1)|};
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(0)
            .WithArguments("_sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task ConstantArgumentsReportsDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private const int One = 1;
    private readonly SemaphoreSlim _sem = {|#0:new SemaphoreSlim(One, One)|};
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock)
            .WithLocation(0)
            .WithArguments("_sem");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    // ── Negative cases (no diagnostic expected) ───────────────────────────────

    [Test]
    public async Task SemaphoreSlimWithInitialCountGreaterThanOneNoDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem = new SemaphoreSlim(2, 2);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task SemaphoreSlimWithDifferentCountsNoDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem = new SemaphoreSlim(0, 1);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task SemaphoreSlimWithSingleArgNoDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem = new SemaphoreSlim(1);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task SemaphoreSlimWithZeroInitialCountNoDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem = new SemaphoreSlim(0, 10);
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task SemaphoreSlimWithNonConstantArgumentNoDiagnostic()
    {
        string code = @"
using System.Threading;

public class TestClass
{
    private readonly int _count = 1;
    private readonly SemaphoreSlim _sem;

    public TestClass()
    {
        _sem = new SemaphoreSlim(_count, _count);
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }
}
