// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Supplies the <see cref="DataSize"/> cases of a test method from a static member on the
/// <em>fixture being built</em>, rather than on the type that declares the method.
/// </summary>
/// <remarks>
/// <param name="sourceName">
/// Name of a public static parameterless member returning <see cref="IEnumerable{DataSize}"/>.
/// </param>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class FixtureDataSizeSourceAttribute(string sourceName) : NUnitAttribute, ITestBuilder
{
    private readonly NUnitTestCaseBuilder _builder = new();

    /// <summary>
    /// Gets the name of the member the sizes are read from.
    /// </summary>
    public string SourceName { get; } = sourceName ?? throw new ArgumentNullException(nameof(sourceName));

    /// <inheritdoc/>
    public IEnumerable<TestMethod> BuildFrom(IMethodInfo method, Test? suite)
    {
        Type fixtureType = suite?.TypeInfo?.Type ?? method.TypeInfo.Type;

        foreach (DataSize size in GetSizes(fixtureType))
        {
            var parameters = new TestCaseParameters([size]);
            yield return _builder.BuildTestMethod(method, suite, parameters);
        }
    }

#if NET8_0_OR_GREATER
    // The trim analyzer only runs on the targets where IsAotCompatible is set, and
    // UnconditionalSuppressMessageAttribute is not public downlevel.
    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2070", Justification = "Test-only reflection over a fixture type NUnit has already instantiated.")]
    [System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("Trimming", "IL2075", Justification = "Test-only reflection over a fixture type NUnit has already instantiated.")]
#endif
    private IEnumerable<DataSize> GetSizes(Type fixtureType)
    {
        // DeclaredOnly, walking up: the most derived declaration wins, which is what makes a
        // `new Sizes()` in a fixture take precedence over the base class one.
        for (Type? type = fixtureType; type is not null; type = type.BaseType)
        {
            MemberInfo[] members = type.GetMember(
                SourceName,
                MemberTypes.Method | MemberTypes.Property | MemberTypes.Field,
                BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (MemberInfo member in members)
            {
                object? value = member switch {
                    MethodInfo methodSource when methodSource.GetParameters().Length == 0 => methodSource.Invoke(null, null),
                    PropertyInfo propertySource => propertySource.GetValue(null),
                    FieldInfo fieldSource => fieldSource.GetValue(null),
                    _ => null
                };

                if (value is IEnumerable<DataSize> sizes)
                {
                    return sizes;
                }
            }
        }

        throw new InvalidOperationException(
            $"'{fixtureType.Name}' has no public static '{SourceName}' returning IEnumerable<DataSize>.");
    }
}
