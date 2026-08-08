// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// How a benchmarked wait is configured: which cancellation token it observes, and whether it also
/// arms a timeout.
/// </summary>
/// <remarks>
/// <para>
/// Despite the name, this describes the whole wait configuration rather than cancellation alone. The two
/// belong together because they are the same kind of knob - optional per-waiter machinery that costs
/// nothing until the operation actually has to wait - and folding them into one benchmark argument keeps
/// the report a single readable column instead of a cross product of two.
/// </para>
/// <para>
/// An absent timeout is expressed as <see cref="System.Threading.Timeout.InfiniteTimeSpan"/>, which every
/// primitive in this library already treats as "do not arm a timer". Call sites can therefore always use
/// the timeout overload and pass <see cref="Timeout"/> straight through, rather than branching on which
/// variant is being measured.
/// </para>
/// <para>
/// Groups exist rather than one universal set so an implementation that lacks a feature can be pointed at
/// a smaller group and simply contribute fewer rows, instead of being emulated into an unfair comparison.
/// </para>
/// </remarks>
public partial class CancellationType : IFormattable
{
    /// <summary>
    /// A timeout long enough that it never elapses during a benchmark, so what gets measured is the cost
    /// of arming and disposing the timer rather than the cost of handling an expiry.
    /// </summary>
    public static readonly TimeSpan NonElapsingTimeout = TimeSpan.FromMinutes(10);

    private static readonly CancellationTokenSource _cancellationSource = new CancellationTokenSource();
    public static readonly CancellationType None = new(nameof(None), CancellationToken.None);
    public static readonly CancellationType Cancelled = new(nameof(Cancelled), new CancellationToken(canceled: true));
    public static readonly CancellationType NotCancelled = new(nameof(NotCancelled), _cancellationSource.Token);

    /// <summary>No token, but a timeout - isolates the timer's cost from a registration's.</summary>
    public static readonly CancellationType Timed = new(nameof(Timed), CancellationToken.None, NonElapsingTimeout);

    /// <summary>Both a live token and a timeout: everything a waiter can be asked to carry at once.</summary>
    public static readonly CancellationType NotCancelledTimed =
        new(nameof(NotCancelledTimed), _cancellationSource.Token, NonElapsingTimeout);

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
    /// Adds a timed variant to <see cref="NoneNotCancelledGroup"/>, so one report shows the bare wait, what
    /// a cancellation registration adds, and what a timer adds, each against the same baseline.
    /// </summary>
    /// <remarks>
    /// For implementations supporting both. Point ones with no timeout overload at
    /// <see cref="NoneNotCancelledGroup"/>, and ones with neither at <see cref="NoneGroup"/>.
    /// </remarks>
    public static IEnumerable<object[]> NoneNotCancelledTimedGroup()
    {
        yield return new object[] { None };
        yield return new object[] { NotCancelled };
        yield return new object[] { Timed };
    }

    /// <summary>
    /// Provides None and a timed variant, for implementations offering a timeout but no cancellation token.
    /// </summary>
    public static IEnumerable<object[]> NoneTimedGroup()
    {
        yield return new object[] { None };
        yield return new object[] { Timed };
    }

    /// <summary>
    /// Provides only the timed variant, for benchmark methods that exist solely to populate the timed
    /// rows.
    /// </summary>
    /// <remarks>
    /// Some libraries express a timed wait through a different method with a different return type - a
    /// nullable releaser reporting whether the wait succeeded, rather than one that always did. Those
    /// cannot be another variant of the untimed benchmark, since the two cannot share a handle array, so
    /// they get their own method pinned to this group. It keeps them out of the untimed rows while still
    /// landing them in the same timed group, which is what gives that group something to compare.
    /// </remarks>
    public static IEnumerable<object[]> TimedGroup()
    {
        yield return new object[] { Timed };
    }

    /// <summary>
    /// Provides a predefined array of cancellation type group representing None.
    /// </summary>
    public static IEnumerable<object[]> NoneGroup()
    {
        yield return new object[] { None };
    }

    public CancellationType(string description, CancellationToken cancellationToken)
        : this(description, cancellationToken, System.Threading.Timeout.InfiniteTimeSpan)
    {
    }

    public CancellationType(string description, CancellationToken cancellationToken, TimeSpan timeout)
    {
        Description = description;
        CancellationToken = cancellationToken;
        Timeout = timeout;
    }

    public string Description { get; }

    public CancellationToken CancellationToken { get; } = CancellationToken.None;

    /// <summary>
    /// The timeout to pass to the operation, or <see cref="System.Threading.Timeout.InfiniteTimeSpan"/>
    /// when this variant does not use one. Safe to hand to a timeout overload either way.
    /// </summary>
    public TimeSpan Timeout { get; } = System.Threading.Timeout.InfiniteTimeSpan;

    /// <summary>Whether this variant arms a timer, i.e. whether <see cref="Timeout"/> is finite.</summary>
    public bool HasTimeout => Timeout != System.Threading.Timeout.InfiniteTimeSpan;

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return Description;
    }

    public override string ToString()
    {
        return Description;
    }
}

