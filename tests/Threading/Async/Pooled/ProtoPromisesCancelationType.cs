// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETFRAMEWORK

#pragma warning disable CA1050 // Declare types in namespaces

using System.Collections.Generic;

public partial class CancellationType
{
    public static readonly CancellationType ProtoPromisesNone = new (nameof(None), Proto.Promises.CancelationToken.None);
    public static readonly CancellationType ProtoPromisesNotCancelled = new (nameof(NotCancelled), new Proto.Promises.CancelationSource().Token);

    /// <summary>
    /// Provides a predefined array of cancellation type groups representing None and a not cancelled token.
    /// states.
    /// </summary>
    public static IEnumerable<object[]> ProtoPromisesNoneNotCanceledGroup()
    {
        yield return new object[] { None };
        yield return new object[] { NotCancelled };
    }

    public CancellationType(string description, Proto.Promises.CancelationToken cancelationToken)
    {
        Description = description;
        CancelationToken = cancelationToken;
    }

    public Proto.Promises.CancelationToken CancelationToken { get; }
}
#endif

