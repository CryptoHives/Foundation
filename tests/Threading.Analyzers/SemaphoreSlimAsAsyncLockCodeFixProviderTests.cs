// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="SemaphoreSlimAsAsyncLockCodeFixProvider"/> (CHT009).
/// </summary>
/// <remarks>
/// The fix introduces <c>AsyncLock</c>, which is not part of the reference assemblies these tests
/// compile against, so each source declares a minimal stub in the namespace the fix imports. That keeps
/// the fixed code compiling without giving the analyzer tests a dependency on the Threading package.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SemaphoreSlimAsAsyncLockCodeFixProviderTests
    : CodeFixTestBase<SemaphoreSlimAsAsyncLockAnalyzer, SemaphoreSlimAsAsyncLockCodeFixProvider>
{
    private const string AsyncLockStub = @"
namespace CryptoHives.Foundation.Threading.Async.Pooled
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class AsyncLock
    {
        public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default) => default;

        public readonly struct Releaser : IDisposable
        {
            public void Dispose() { }
        }
    }
}
";

    [Test]
    public async Task FieldDeclarationIsReplacedWithAsyncLock()
    {
        string source = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim {|#0:_sem|} = {|#1:new SemaphoreSlim(1, 1)|};
}" + AsyncLockStub;

        string fixedSource = @"
using System.Threading;
using CryptoHives.Foundation.Threading.Async.Pooled;

public class TestClass
{
    private readonly AsyncLock _sem = new AsyncLock();
}" + AsyncLockStub;

        // The diagnostic anchors on the object creation rather than the identifier, so location 1.
        await VerifyCodeFixAsync(
            source,
            fixedSource,
            Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock).WithLocation(1).WithArguments("_sem"))
            .ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAndReleasePairsBecomeUsingBlocks()
    {
        string source = @"
using System.Threading;
using System.Threading.Tasks;

public class TestClass
{
    private readonly SemaphoreSlim _sem = {|#0:new SemaphoreSlim(1, 1)|};

    public async Task RunAsync(CancellationToken ct)
    {
        await _sem.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            Work();
        }
        finally
        {
            _sem.Release();
        }
    }

    public async Task RunAgainAsync()
    {
        await _sem.WaitAsync();
        try
        {
            Work();
        }
        finally
        {
            _sem.Release();
        }
    }

    private void Work() { }
}" + AsyncLockStub;

        string fixedSource = @"
using System.Threading;
using System.Threading.Tasks;
using CryptoHives.Foundation.Threading.Async.Pooled;

public class TestClass
{
    private readonly AsyncLock _sem = new AsyncLock();

    public async Task RunAsync(CancellationToken ct)
    {
        using (await _sem.LockAsync(ct).ConfigureAwait(false))
        {
            Work();
        }
    }

    public async Task RunAgainAsync()
    {
        using (await _sem.LockAsync())
        {
            Work();
        }
    }

    private void Work() { }
}" + AsyncLockStub;

        await VerifyCodeFixAsync(
            source,
            fixedSource,
            Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock).WithLocation(0).WithArguments("_sem"))
            .ConfigureAwait(false);
    }

    [Test]
    public async Task ConstructorAssignmentChangesTheFieldType()
    {
        string source = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem;

    public TestClass()
    {
        _sem = {|#0:new SemaphoreSlim(1, 1)|};
    }
}" + AsyncLockStub;

        string fixedSource = @"
using System.Threading;
using CryptoHives.Foundation.Threading.Async.Pooled;

public class TestClass
{
    private readonly AsyncLock _sem;

    public TestClass()
    {
        _sem = new AsyncLock();
    }
}" + AsyncLockStub;

        await VerifyCodeFixAsync(
            source,
            fixedSource,
            Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock).WithLocation(0).WithArguments("_sem"))
            .ConfigureAwait(false);
    }

    [Test]
    public async Task SynchronousWaitOffersNoFix()
    {
        string source = @"
using System.Threading;

public class TestClass
{
    private readonly SemaphoreSlim _sem = {|#0:new SemaphoreSlim(1, 1)|};

    public void Run()
    {
        _sem.Wait();
        try
        {
        }
        finally
        {
            _sem.Release();
        }
    }
}" + AsyncLockStub;

        await VerifyCodeFixAsync(
            source,
            source,
            Diagnostic(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock).WithLocation(0).WithArguments("_sem"))
            .ConfigureAwait(false);
    }
}
