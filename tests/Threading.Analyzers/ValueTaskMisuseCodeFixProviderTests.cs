// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

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

    [Test]
    public async Task NotConsumedInASyncMethodOffersOnlyTheDiscard()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask GetAsync() => default;

    public void Run()
    {
        {|CHT008:GetAsync()|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask GetAsync() => default;

    public void Run()
    {
        _ = GetAsync();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task NotConsumedInALambdaBodyIsDiscarded()
    {
        string source = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask FooAsync() => default;

    public Action Create() => () => {|CHT008:FooAsync()|};
}";
        string fixedSource = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask FooAsync() => default;

    public Action Create() => () => _ = FooAsync();
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── Await fixes need an async context, and parentheses where precedence demands ──

    [Test]
    public async Task BlockingGetResultInASyncMethodOffersOnlyAsTask()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public int Run()
    {
        return {|CHT002:GetAsync().GetAwaiter().GetResult()|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public int Run()
    {
        return GetAsync().AsTask().GetAwaiter().GetResult();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task ConfiguredGetResultConvertsBeforeConfigureAwait()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    public int Run(ValueTask<int> vt)
    {
        return {|CHT002:vt.ConfigureAwait(false).GetAwaiter().GetResult()|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    public int Run(ValueTask<int> vt)
    {
        return vt.AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task DirectResultAccessInASyncMethodOffersOnlyAsTaskResult()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public int Run()
    {
        return {|CHT005:GetAsync().Result|};
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public int Run()
    {
        return GetAsync().AsTask().Result;
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task DirectResultAccessFollowedByAMemberIsParenthesized()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task<string> RunAsync()
    {
        return {|CHT005:GetAsync().Result|}.ToString();
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task<string> RunAsync()
    {
        return (await GetAsync()).ToString();
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── CHT001: declarations the AsTask fix must not damage ──────────────────

    [Test]
    public async Task MultipleAwaitInAMultiDeclaratorDeclarationKeepsEveryDeclarator()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        ValueTask<int> vt = GetAsync(), other = GetAsync();
        int a = await vt;
        int b = await {|CHT001:vt|};
        int c = await other;
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;

    public async Task RunAsync()
    {
        ValueTask<int> vt = GetAsync().Preserve(), other = GetAsync();
        int a = await vt;
        int b = await vt;
        int c = await other;
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task MultipleAwaitConvertsToTaskWithTheShortestTypeName()
    {
        string source = @"
using System.Collections.Generic;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<List<int>> GetAsync() => default;

    public async Task RunAsync()
    {
        ValueTask<List<int>> vt = GetAsync();
        var a = await vt;
        var b = await {|CHT001:vt|};
    }
}";
        string fixedSource = @"
using System.Collections.Generic;
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<List<int>> GetAsync() => default;

    public async Task RunAsync()
    {
        Task<List<int>> vt = GetAsync().AsTask();
        var a = await vt;
        var b = await vt;
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    // ── CHT003: the field fix converts the assignments too ───────────────────

    [Test]
    public async Task StoredInFieldConvertsAssignmentsToAsTask()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> {|CHT003:_pending|};

    public TestClass()
    {
        _pending = GetAsync();
    }

    private ValueTask<int> GetAsync() => default;
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private Task<int> _pending;

    public TestClass()
    {
        _pending = GetAsync().AsTask();
    }

    private ValueTask<int> GetAsync() => default;
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }

    [Test]
    public async Task StoredInPropertyOffersNoFix()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    {|CHT003:public ValueTask<int> Pending { get; set; }|}
}";
        await VerifyCodeFixAsync(source, source).ConfigureAwait(false);
    }

    // ── CHT007: AsTask() stored before other work ────────────────────────────

    [Test]
    public async Task AsTaskStoredBeforeOtherWorkKeepsTheValueTask()
    {
        string source = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;
    private void Prepare() { }

    public async Task<int> RunAsync()
    {
        Task<int> {|CHT007:t = GetAsync().AsTask()|};
        Prepare();
        return await t;
    }
}";
        string fixedSource = @"
using System.Threading.Tasks;

public class TestClass
{
    private ValueTask<int> GetAsync() => default;
    private void Prepare() { }

    public async Task<int> RunAsync()
    {
        ValueTask<int> t = GetAsync();
        Prepare();
        return await t;
    }
}";
        await VerifyCodeFixAsync(source, fixedSource).ConfigureAwait(false);
    }
}
