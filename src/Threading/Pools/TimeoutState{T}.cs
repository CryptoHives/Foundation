// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

/// <summary>
/// Timer callback state that stamps a waiter with the version it was created for.
/// </summary>
/// <remarks>
/// Timer disposal does not synchronize with an in-flight callback, so a timeout
/// callback can observe a waiter that has already been recycled for a new operation.
/// The callback validates <see cref="Version"/> against the waiter's current
/// <see cref="ManualResetValueTaskSource{T}.Version"/> under the owner's lock before
/// removing the waiter, so a stale callback cannot cancel the wrong operation.
/// </remarks>
/// <typeparam name="T">The result type of the value task source.</typeparam>
internal sealed class TimeoutState<T>
{
    /// <summary>
    /// The waiter the timeout applies to.
    /// </summary>
    public readonly ManualResetValueTaskSource<T> Source;

    /// <summary>
    /// The waiter version at the time the timer was created.
    /// </summary>
    public readonly short Version;

    /// <summary>
    /// Initializes the state with the waiter and its current version.
    /// </summary>
    /// <param name="source">The waiter the timeout applies to.</param>
    public TimeoutState(ManualResetValueTaskSource<T> source)
    {
        Source = source;
        Version = source.Version;
    }
}
