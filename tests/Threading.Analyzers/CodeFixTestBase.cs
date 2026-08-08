// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;

using Microsoft.CodeAnalysis.Testing;
using System.Threading.Tasks;

/// <summary>
/// Base class for code fix tests, verifying not just that a fix is offered but that the code it
/// produces is what was intended.
/// </summary>
/// <typeparam name="TAnalyzer">The analyzer that reports the diagnostic.</typeparam>
/// <typeparam name="TCodeFix">The code fix provider under test.</typeparam>
public abstract class CodeFixTestBase<TAnalyzer, TCodeFix>
    where TAnalyzer : DiagnosticAnalyzer, new()
    where TCodeFix : CodeFixProvider, new()
{
    /// <summary>
    /// Gets the reference assemblies to use for testing.
    /// Uses .NET Standard 2.1 which includes ValueTask.
    /// </summary>
    protected static ReferenceAssemblies TestReferenceAssemblies =>
        ReferenceAssemblies.NetStandard.NetStandard21;

    /// <summary>
    /// Reference assemblies for APIs that .NET Standard 2.1 does not carry, such as
    /// <c>PoolingAsyncValueTaskMethodBuilder</c>, which exists only on .NET 6 and later.
    /// </summary>
    protected static ReferenceAssemblies ModernReferenceAssemblies =>
        ReferenceAssemblies.Net.Net80;

    protected static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
        => CSharpCodeFixVerifier<TAnalyzer, TCodeFix, DefaultVerifier>.Diagnostic(descriptor);

    /// <summary>
    /// Verifies that applying the fix to <paramref name="source"/> yields exactly
    /// <paramref name="fixedSource"/>.
    /// </summary>
    protected static Task VerifyCodeFixAsync(
        string source,
        string fixedSource,
        params DiagnosticResult[] expected)
        => VerifyCodeFixAsync(source, fixedSource, codeActionIndex: null, TestReferenceAssemblies, expected);

    /// <summary>
    /// Verifies a specific fix when a diagnostic offers several, and/or against a chosen set of
    /// reference assemblies.
    /// </summary>
    /// <param name="source">The code to fix, with diagnostic markup.</param>
    /// <param name="fixedSource">The expected result. Pass the same text as the source to assert no fix is applied.</param>
    /// <param name="codeActionIndex">Which offered action to apply, or <see langword="null"/> for the default.</param>
    /// <param name="referenceAssemblies">The framework to compile against.</param>
    /// <param name="expected">The diagnostics the analyzer should report.</param>
    protected static async Task VerifyCodeFixAsync(
        string source,
        string fixedSource,
        int? codeActionIndex,
        ReferenceAssemblies referenceAssemblies,
        params DiagnosticResult[] expected)
    {
        var test = new CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> {
            TestCode = NormalizeLineEndings(source),
            FixedCode = NormalizeLineEndings(fixedSource),
            ReferenceAssemblies = referenceAssemblies,
            CodeActionIndex = codeActionIndex
        };

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Rewrites a test source to CRLF, which is what Roslyn's formatter emits for anything a fix
    /// inserts.
    /// </summary>
    /// <remarks>
    /// These sources are verbatim strings, so they carry whatever line endings the test file itself has
    /// - LF in this repository. Without normalizing, every fix that adds a line would fail on line
    /// endings alone, which says nothing about whether the fix is correct.
    /// </remarks>
    private static string NormalizeLineEndings(string source)
        => source.Replace("\r\n", "\n").Replace("\n", "\r\n");
}
