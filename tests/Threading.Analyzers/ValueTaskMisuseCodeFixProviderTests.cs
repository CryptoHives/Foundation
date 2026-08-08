// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="ValueTaskMisuseCodeFixProvider"/>, covering the primary fix offered for each
/// diagnostic it declares fixable.
/// </summary>
/// <remarks>
/// Several diagnostics offer more than one fix; where that is so, <c>codeActionIndex</c> selects the
/// alternative so both are exercised rather than only whichever happens to be registered first.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ValueTaskMisuseCodeFixProviderTests
    : CodeFixTestBase<ValueTaskMisuseAnalyzer, ValueTaskMisuseCodeFixProvider>
{
    // ── CHT001: ValueTask awaited multiple times ─────────────────────────────

    [Test]
    public async Task MultipleAwaitConvertsToTaskAtDeclaration()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        ValueTask<int> vt = GetAsync();
        int a = await vt;
        int b = await {|CHT001:vt|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        Task<int> vt = GetAsync().AsTask();
        int a = await vt;
        int b = await vt;
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── CHT002: blocking GetAwaiter().GetResult() ────────────────────────────

    [Test]
    public async Task BlockingGetResultConvertsToAwait()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        int value = {|CHT002:GetAsync().GetAwaiter().GetResult()|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        int value = await GetAsync();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── CHT003: ValueTask stored in a field ──────────────────────────────────

    [Test]
    public async Task StoredInFieldChangesTypeToTask()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> {|CHT003:_pending|};
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private Task<int> _pending;
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── CHT005: ValueTask.Result accessed directly ───────────────────────────

    [Test]
    public async Task DirectResultAccessConvertsToAwait()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        int value = {|CHT005:GetAsync().Result|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        int value = await GetAsync();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── CHT008: ValueTask never consumed ─────────────────────────────────────

    [Test]
    public async Task NotConsumedAddsAwait()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask GetAsync() => default;

    public async Task RunAsync()
    {
        {|CHT008:GetAsync()|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask GetAsync() => default;

    public async Task RunAsync()
    {
        await GetAsync();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task NotConsumedCanDiscardInstead()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask GetAsync() => default;

    public async Task RunAsync()
    {
        {|CHT008:GetAsync()|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask GetAsync() => default;

    public async Task RunAsync()
    {
        _ = GetAsync();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource, codeActionIndex: 1, TestReferenceAssemblies)
            .ConfigureAwait(false);
    }
}
