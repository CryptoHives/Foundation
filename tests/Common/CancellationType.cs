// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// A group of cancellation types for tests.
/// </summary>
public class CancellationType : IFormattable
{
    public static readonly CancellationType None = new(nameof(None), CancellationToken.None);
    public static readonly CancellationType Cancelled = new(nameof(Cancelled), new CancellationToken(true));
    public static readonly CancellationType NotCancelled = new(nameof(NotCancelled), new CancellationTokenSource().Token);

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None, cancelled, and not cancelled token
    /// states.
    /// </summary>
    public static IEnumerable<object[]> NoneCancelledNotCancelledGroup()
    {
        yield return new object[] { None };
        yield return new object[] { Cancelled };
        yield return new object[] { NotCancelled };
    }

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None and a not cancelled token.
    /// states.
    /// </summary>
    public static IEnumerable<object[]> NoneNotCancelledGroup()
    {
        yield return new object[] { None };
        yield return new object[] { NotCancelled };
    }

    /// <summary>
    /// Provides a predefined array of cancellation type group representing None.
    /// </summary>
    public static IEnumerable<object[]> NoneGroup()
    {
        yield return new object[] { None };
    }

    public CancellationType(string description, CancellationToken cancellationToken)
    {
        Description = description;
        CancellationToken = cancellationToken;
    }

    public string Description { get; }

    public CancellationToken CancellationToken { get; }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return Description;
    }

    public override string ToString()
    {
        return Description;
    }
}

