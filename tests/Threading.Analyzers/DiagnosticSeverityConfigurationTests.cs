// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers.Tests;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

/// <summary>
/// Tests that the severity of every CHT diagnostic can be configured through the standard
/// <c>dotnet_diagnostic.CHTxxx.severity</c> analyzer config option, as documented in the README.
/// </summary>
/// <remarks>
/// A descriptor tagged <see cref="WellKnownDiagnosticTags.CustomSeverityConfigurable"/> tells the compiler that
/// the analyzer has its own severity mechanism, so the compiler then ignores the analyzer config option.
/// These analyzers have no such mechanism.
/// </remarks>
[TestFixture]
public class DiagnosticSeverityConfigurationTests
{
    private const string BlockingGetResultCode = @"
using System;
using System.Threading.Tasks;

public class TestClass
{
    public void TestMethod()
    {
        ValueTask vt = default;
        {|#0:vt.GetAwaiter().GetResult()|};
    }
}";

    [Test]
    public void NoDescriptorOptsOutOfAnalyzerConfigSeverity()
    {
        DiagnosticDescriptor[] descriptors = typeof(DiagnosticDescriptors)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(DiagnosticDescriptor))
            .Select(f => (DiagnosticDescriptor)f.GetValue(null)!)
            .ToArray();

        Assert.That(descriptors, Is.Not.Empty);
        foreach (DiagnosticDescriptor descriptor in descriptors)
        {
            Assert.That(
                descriptor.CustomTags,
                Does.Not.Contain(WellKnownDiagnosticTags.CustomSeverityConfigurable),
                $"{descriptor.Id} ignores dotnet_diagnostic severity configuration");
        }
    }

    [Test]
    public async Task SeverityNoneInAnalyzerConfigSuppressesDiagnostic()
    {
        // The same code reports CHT002 as a warning without the config entry (see ValueTaskMisuseAnalyzerTests).
        var test = CreateTest(BlockingGetResultCode, "none");

        await test.RunAsync().ConfigureAwait(false);
    }

    private static CSharpAnalyzerTest<ValueTaskMisuseAnalyzer, DefaultVerifier> CreateTest(string source, string severity)
    {
        var test = new CSharpAnalyzerTest<ValueTaskMisuseAnalyzer, DefaultVerifier> {
            TestCode = source,
            ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard21
        };

        test.TestState.AnalyzerConfigFiles.Add((
            "/.editorconfig",
            $"is_global = true\ndotnet_diagnostic.{DiagnosticIds.BlockingGetResult}.severity = {severity}\n"));
        return test;
    }
}
