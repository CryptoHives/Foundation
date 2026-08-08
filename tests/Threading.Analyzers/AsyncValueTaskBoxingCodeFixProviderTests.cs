// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="AsyncValueTaskBoxingCodeFixProvider"/> (CHT011).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncValueTaskBoxingCodeFixProviderTests
    : CodeFixTestBase<AsyncValueTaskBoxingAnalyzer, AsyncValueTaskBoxingCodeFixProvider>
{
    [Test]
    public async Task FixesExpressionBodiedForwarder()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> {|#0:OuterAsync|}() => await InnerAsync().ConfigureAwait(false);
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public ValueTask<int> OuterAsync() => InnerAsync();
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyCodeFixAsync(source, fixedSource, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task FixesBlockBodiedForwarder()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> {|#0:OuterAsync|}()
    {
        return await InnerAsync().ConfigureAwait(false);
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public ValueTask<int> OuterAsync()
    {
        return InnerAsync();
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyCodeFixAsync(source, fixedSource, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task FixesNonGenericForwarderByIntroducingReturn()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask InnerAsync() => default;

    public async ValueTask {|#0:OuterAsync|}()
    {
        await InnerAsync().ConfigureAwait(false);
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask InnerAsync() => default;

    public ValueTask OuterAsync()
    {
        return InnerAsync();
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyCodeFixAsync(source, fixedSource, expected).ConfigureAwait(false);
    }

    [Test]
    public async Task PreservesStatementsBeforeTheForwardedAwait()
    {
        string source = @"
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
        string fixedSource = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync(int value) => default;

    public ValueTask<int> OuterAsync(int value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
        return InnerAsync(value);
    }
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyCodeFixAsync(source, fixedSource, expected).ConfigureAwait(false);
    }

    // ── CHT012: pooling the box, offered only where the builder exists ───────

    [Test]
    public async Task PoolingFixAddsAsyncMethodBuilderAttribute()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private void Cleanup() { }

    public async ValueTask<int> {|CHT012:OuterAsync|}()
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
        // No markup in the fixed source: once the builder is declared, the analyzer stands down, which
        // is also what stops the fix stacking a second attribute when applied iteratively.
        string fixedSource = @"
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private void Cleanup() { }

    [AsyncMethodBuilder(typeof(PoolingAsyncValueTaskMethodBuilder<>))]
    public async ValueTask<int> OuterAsync()
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
        await VerifyCodeFixAsync(source, fixedSource, codeActionIndex: null, ModernReferenceAssemblies)
            .ConfigureAwait(false);
    }

    [Test]
    public async Task PoolingFixIsNotOfferedWhereTheBuilderDoesNotExist()
    {
        // netstandard2.1 has no PoolingAsyncValueTaskMethodBuilder, so applying the attribute would not
        // compile. The diagnostic still reports; only the fix is withheld.
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    private void Cleanup() { }

    public async ValueTask<int> {|CHT012:OuterAsync|}()
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
        // Same text for source and fixed source: nothing should change.
        await VerifyCodeFixAsync(source, source, codeActionIndex: null, TestReferenceAssemblies)
            .ConfigureAwait(false);
    }

    [Test]
    public async Task FixesForwarderWithoutConfigureAwait()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public async ValueTask<int> {|#0:OuterAsync|}() => await InnerAsync();
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> InnerAsync() => default;

    public ValueTask<int> OuterAsync() => InnerAsync();
}";
        DiagnosticResult expected = Diagnostic(DiagnosticDescriptors.RedundantAsyncForwarding)
            .WithLocation(0)
            .WithArguments("OuterAsync");

        await VerifyCodeFixAsync(source, fixedSource, expected).ConfigureAwait(false);
    }
}
