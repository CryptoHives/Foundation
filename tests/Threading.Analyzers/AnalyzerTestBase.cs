// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
    protected static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
        => CSharpAnalyzerVerifier<TAnalyzer, DefaultVerifier>.Diagnostic(descriptor);

    protected static DiagnosticResult Diagnostic(string id)
        => CSharpAnalyzerVerifier<TAnalyzer, DefaultVerifier>.Diagnostic(id);

    protected static async Task VerifyAnalyzerAsync(string source, params DiagnosticResult[] expected)
    {
        var test = new CSharpAnalyzerTest<TAnalyzer, DefaultVerifier>
        {
            TestCode = source,
            ReferenceAssemblies = ReferenceAssemblies.Net.Net80
        };

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync().ConfigureAwait(false);
    }

    protected static async Task VerifyNoDiagnosticsAsync(string source)
    {
        await VerifyAnalyzerAsync(source).ConfigureAwait(false);
    }

    protected static string WrapInClass(string code) => $$"""
        using System;
        using System.Threading.Tasks;

        namespace TestNamespace
        {
            public class TestClass
            {
                {{code}}
            }
        }
        """;

    protected static string WrapInMethod(string code) => WrapInClass($$"""
        public async Task TestMethod()
        {
            {{code}}
        }
        """);
}
