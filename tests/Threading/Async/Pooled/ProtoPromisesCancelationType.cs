// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETFRAMEWORK

#pragma warning disable CA1050 // Declare types in namespaces

using System;
using System.Collections.Generic;

public partial class CancellationType
{
    private static Proto.Promises.CancelationSource _cancelationSource = Proto.Promises.CancelationSource.New();
    public static readonly CancellationType ProtoPromisesNone = new (nameof(None), Proto.Promises.CancelationToken.None);
    public static readonly CancellationType ProtoPromisesCancelled = new(nameof(NotCancelled), new Proto.Promises.CancelationToken(canceled: true));
    public static readonly CancellationType ProtoPromisesNotCancelled = new (nameof(NotCancelled), _cancelationSource.Token);

    /// <summary>
    /// Provides a predefined array of cancellation type group representing None.
    /// </summary>
    public static IEnumerable<object[]> ProtoPromisesNoneGroup()
    {
        yield return new object[] { ProtoPromisesNone };
    }

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None and a not cancelled token.
    /// states.
    /// </summary>
    public static IEnumerable<object[]> ProtoPromisesNoneNotCanceledGroup()
    {
        yield return new object[] { ProtoPromisesNone };
        yield return new object[] { ProtoPromisesNotCancelled };
    }

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None, cancelled, and not cancelled token
    /// states.
    /// </summary>
    public static IEnumerable<object[]> ProtoPromisesNoneCancelledNotCancelledGroup()
    {
        yield return new object[] { ProtoPromisesNone };
        yield return new object[] { ProtoPromisesCancelled };
        yield return new object[] { ProtoPromisesNotCancelled };
    }

    public CancellationType(string description, Proto.Promises.CancelationToken cancelationToken)
    {
        Description = description;
        CancelationToken = cancelationToken;
    }

    public Proto.Promises.CancelationToken CancelationToken { get; } = Proto.Promises.CancelationToken.None;
}
#endif

