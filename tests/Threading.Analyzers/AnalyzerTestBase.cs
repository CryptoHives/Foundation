// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using System.Threading.Tasks;

/// <summary>
/// Base class for analyzer tests.
/// </summary>
/// <typeparam name="TAnalyzer">The type of analyzer to test.</typeparam>
public abstract class AnalyzerTestBase<TAnalyzer>
    where TAnalyzer : DiagnosticAnalyzer, new()
{
    /// <summary>
    /// Gets the reference assemblies to use for testing.
    /// Uses .NET Standard 2.1 which includes ValueTask.
    /// </summary>
    private static ReferenceAssemblies TestReferenceAssemblies =>
        ReferenceAssemblies.NetStandard.NetStandard21;

    protected static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
        => CSharpAnalyzerVerifier<TAnalyzer, DefaultVerifier>.Diagnostic(descriptor);

    protected static DiagnosticResult Diagnostic(string id)
        => CSharpAnalyzerVerifier<TAnalyzer, DefaultVerifier>.Diagnostic(id);

    /// <summary>
    /// Verifies that the analyzer produces no diagnostics for the given source.
    /// </summary>
    protected static async Task VerifyNoDiagnosticsAsync(string source)
    {
        var test = new CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> {
            TestCode = source,
            ReferenceAssemblies = TestReferenceAssemblies
        };

        await test.RunAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Verifies analyzer diagnostics using markup syntax.
    /// Use {|DiagnosticId:code|} to mark expected diagnostics in the source.
    /// </summary>
    protected static async Task VerifyWithMarkupAsync(string sourceWithMarkup)
    {
        var test = new CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> {
            TestCode = sourceWithMarkup,
            ReferenceAssemblies = TestReferenceAssemblies
        };

        await test.RunAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Verifies analyzer with explicit diagnostic results.
    /// </summary>
    protected static async Task VerifyAnalyzerAsync(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> {
            TestCode = source,
            ReferenceAssemblies = TestReferenceAssemblies
        };

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync().ConfigureAwait(false);
    }
}
