// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#if !NETFRAMEWORK

#pragma warning disable CA1050 // Declare types in namespaces

using System;
using System.Collections.Generic;

public partial class CancellationType
{
    private static readonly Proto.Promises.CancelationSource _cancelationSource = Proto.Promises.CancelationSource.New();
    public static readonly CancellationType ProtoPromisesNone = new(nameof(None), Proto.Promises.CancelationToken.None);
    public static readonly CancellationType ProtoPromisesCancelled = new(nameof(NotCancelled), new Proto.Promises.CancelationToken(canceled: true));
    public static readonly CancellationType ProtoPromisesNotCancelled = new(nameof(NotCancelled), _cancelationSource.Token);

    /// <summary>
    /// Provides a predefined array of cancellation type group representing None.
    /// </summary>
    public static IEnumerable<CancellationType> ProtoPromisesNoneGroup()
    {
        yield return ProtoPromisesNone;
    }

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None and a not cancelled token.
    /// states.
    /// </summary>
    public static IEnumerable<CancellationType> ProtoPromisesNoneNotCanceledGroup()
    {
        yield return ProtoPromisesNone;
        yield return ProtoPromisesNotCancelled;
    }

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None, cancelled, and not cancelled token
    /// states.
    /// </summary>
    public static IEnumerable<CancellationType> ProtoPromisesNoneCancelledNotCancelledGroup()
    {
        yield return ProtoPromisesNone;
        yield return ProtoPromisesCancelled;
        yield return ProtoPromisesNotCancelled;
    }

    public CancellationType(string description, Proto.Promises.CancelationToken cancelationToken)
    {
        Description = description;
        CancelationToken = cancelationToken;
    }

    public Proto.Promises.CancelationToken CancelationToken { get; } = Proto.Promises.CancelationToken.None;
}
#endif

