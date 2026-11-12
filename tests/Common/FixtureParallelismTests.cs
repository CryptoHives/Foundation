// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable IL2026, IL2070 // reflection over the test assembly itself

namespace Tests.Common;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// Ensures every test fixture states how it runs: in parallel, or explicitly serial.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class FixtureParallelismTests
{
    private static IEnumerable<Type> Fixtures() =>
        typeof(FixtureParallelismTests).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsNested && t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Any(m => m.IsDefined(typeof(TestAttribute), true) ||
                          m.IsDefined(typeof(TestCaseAttribute), true) ||
                          m.IsDefined(typeof(TestCaseSourceAttribute), true)));

    [TestCaseSource(nameof(Fixtures))]
    public void FixtureIsParallelizableOrExplicitlySerial(Type fixture)
    {
        bool serial = fixture.IsDefined(typeof(NonParallelizableAttribute), true);
        bool parallel = fixture.GetCustomAttributes<ParallelizableAttribute>(true).Any(a => a.Scope == ParallelScope.All);

        Assert.That(serial || parallel, Is.True, $"{fixture.FullName} needs [Parallelizable(ParallelScope.All)] or [NonParallelizable].");
    }
}
