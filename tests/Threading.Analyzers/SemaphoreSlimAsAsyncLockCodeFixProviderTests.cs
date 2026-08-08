// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

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
    public sealed class AsyncLock { }
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
}
