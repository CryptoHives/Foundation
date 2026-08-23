// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;

using Microsoft.CodeAnalysis.Testing;
using System;
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

        test.TestState.AnalyzerConfigFiles.Add((EditorConfigPath, EditorConfig));

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Path of the analyzer config file handed to the testing harness.
    /// </summary>
    /// <remarks>
    /// The harness compiles a virtual document at <c>/0/Test0.cs</c> in an in-memory workspace, so
    /// the repository's on-disk <c>.editorconfig</c> is not part of that solution and has no effect
    /// on it. The pin has to be handed to the harness in code, at a path that is a prefix of the
    /// virtual document's.
    /// </remarks>
    private const string EditorConfigPath = "/.editorconfig";

    /// <summary>
    /// Pins the newline Roslyn's formatter emits, so the expectations below are absolute rather than
    /// relative to the machine the suite runs on.
    /// </summary>
    /// <remarks>
    /// Without this the formatter takes its newline from <see cref="Environment.NewLine"/>, and only
    /// for the lines a fix inserts or reformats - the rest of the document keeps whatever the input
    /// had. That mismatch is invisible on Windows and fails on Linux and macOS, on the one or two
    /// lines each fix rewrites: the opening brace of a reformatted block, or an inserted directive.
    /// An analyzer config file overrides the environment, so <c>end_of_line = lf</c> makes the
    /// formatter emit LF on every platform.
    /// </remarks>
    private const string EditorConfig = "root = true\n\n[*.cs]\nend_of_line = lf\n";

    /// <summary>
    /// Rewrites a test source to LF, matching the newline pinned by <see cref="EditorConfig"/>.
    /// </summary>
    /// <remarks>
    /// These sources are verbatim strings, so they carry whatever line endings the test file itself
    /// has - LF in this repository, and CRLF on a Windows checkout, where <c>.gitattributes</c>'
    /// <c>text=auto</c> makes the working tree platform-native. Without normalizing, every fix that
    /// adds a line would fail on line endings alone, which says nothing about whether the fix is
    /// correct. Both halves have to agree: pinning the formatter without pinning the expectations
    /// just relocates the mismatch.
    /// </remarks>
    private static string NormalizeLineEndings(string source)
        => source.Replace("\r\n", "\n");
}
