// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="AsyncReentrantReleaserAnalyzer"/> (CHT013).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncReentrantReleaserAnalyzerTests : AnalyzerTestBase<AsyncReentrantReleaserAnalyzer>
{
    private const string Stubs = @"
namespace CryptoHives.Foundation.Threading.Async.Pooled
{
    using System;
    using System.Threading.Tasks;

    public sealed class AsyncReentrantLock
    {
        public readonly struct Releaser : IDisposable
        {
            public void Dispose() { }
        }

        public ValueTask<Releaser> LockAsync() => default;

        public ValueTask<Releaser> LockLeafAsync() => default;
    }

    public sealed class AsyncLock
    {
        public readonly struct Releaser : IDisposable
        {
            public void Dispose() { }
        }

        public ValueTask<Releaser> LockAsync() => default;
    }
}
";

    // ── Positive cases (diagnostic expected) ──────────────────────────────────

    [Test]
    public async Task AsyncMethodReturningValueTaskOfReleaserReportsDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncReentrantLock _lock = new AsyncReentrantLock();

        public async ValueTask<AsyncReentrantLock.Releaser> {|#0:EnterAsync|}()
            => await _lock.LockAsync().ConfigureAwait(false);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync)
            .WithLocation(0)
            .WithArguments("EnterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncMethodReturningTaskOfReleaserReportsDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncReentrantLock _lock = new AsyncReentrantLock();

        public async Task<AsyncReentrantLock.Releaser> {|#0:EnterAsync|}()
        {
            System.Console.WriteLine(""entering"");
            return await _lock.LockAsync().ConfigureAwait(false);
        }
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync)
            .WithLocation(0)
            .WithArguments("EnterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLocalFunctionReturningReleaserReportsDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        public async Task RunAsync(AsyncReentrantLock mutex)
        {
            async ValueTask<AsyncReentrantLock.Releaser> {|#0:EnterAsync|}() => await mutex.LockAsync().ConfigureAwait(false);

            using (await EnterAsync().ConfigureAwait(false)) { }
        }
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync)
            .WithLocation(0)
            .WithArguments("EnterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLambdaReturningReleaserReportsDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System;
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        public Func<ValueTask<AsyncReentrantLock.Releaser>> Create(AsyncReentrantLock mutex)
            => {|#0:async|} () => await mutex.LockAsync().ConfigureAwait(false);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync)
            .WithLocation(0)
            .WithArguments("async lambda");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    // ── Negative cases (no diagnostic expected) ───────────────────────────────

    [Test]
    public async Task NonAsyncMethodReturningLockAsyncNoDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncReentrantLock _lock = new AsyncReentrantLock();

        public ValueTask<AsyncReentrantLock.Releaser> EnterAsync() => _lock.LockAsync();
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncMethodReturningLeafReleaserNoDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncReentrantLock _lock = new AsyncReentrantLock();

        public async ValueTask<AsyncReentrantLock.Releaser> EnterLeafAsync()
            => await _lock.LockLeafAsync().ConfigureAwait(false);
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncMethodChoosingLockOrLeafReportsDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncReentrantLock _lock = new AsyncReentrantLock();

        public async ValueTask<AsyncReentrantLock.Releaser> {|#0:EnterAsync|}(bool leaf)
            => leaf ? await _lock.LockLeafAsync() : await _lock.LockAsync();
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync)
            .WithLocation(0)
            .WithArguments("EnterAsync");

        await VerifyAnalyzerAsync(code, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncMethodReturningAnotherLocksReleaserNoDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncLock _lock = new AsyncLock();

        public async ValueTask<AsyncLock.Releaser> EnterAsync()
        {
            System.Console.WriteLine(""entering"");
            return await _lock.LockAsync().ConfigureAwait(false);
        }
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLambdaReturningTaskNoDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System;
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        public Func<Task> Create(AsyncReentrantLock mutex)
            => async () => await mutex.LockAsync().ConfigureAwait(false);
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncMethodHoldingTheLockInsideNoDiagnostic()
    {
        string code = Stubs + @"
namespace App
{
    using System.Threading.Tasks;
    using CryptoHives.Foundation.Threading.Async.Pooled;

    public class Worker
    {
        private readonly AsyncReentrantLock _lock = new AsyncReentrantLock();
        private int _value;

        public async Task<int> ReadAsync()
        {
            using (await _lock.LockAsync().ConfigureAwait(false))
            {
                return _value;
            }
        }
    }
}";
        await VerifyNoDiagnosticsAsync(code).ConfigureAwait(false);
    }
}
