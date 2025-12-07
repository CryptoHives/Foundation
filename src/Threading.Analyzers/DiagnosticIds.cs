// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

/// <summary>
/// Contains all diagnostic IDs for the ValueTask analyzers.
/// </summary>
public static class DiagnosticIds
{
    /// <summary>
    /// ValueTask awaited multiple times.
    /// </summary>
    public const string MultipleAwait = "CHT001";

    /// <summary>
    /// ValueTask.GetAwaiter().GetResult() used (blocking).
    /// </summary>
    public const string BlockingGetResult = "CHT002";

    /// <summary>
    /// ValueTask stored in field (potential double consumption).
    /// </summary>
    public const string StoredInField = "CHT003";

    /// <summary>
    /// ValueTask.AsTask() called multiple times.
    /// </summary>
    public const string MultipleAsTask = "CHT004";

    /// <summary>
    /// ValueTask.Result accessed directly (blocking and potential misuse).
    /// </summary>
    public const string DirectResultAccess = "CHT005";

    /// <summary>
    /// ValueTask passed to method that may consume it multiple times.
    /// </summary>
    public const string PassedToUnsafeMethod = "CHT006";

    /// <summary>
    /// ValueTask.AsTask() stored before signaling can cause performance issues.
    /// </summary>
    public const string AsTaskStoredBeforeSignal = "CHT007";

    /// <summary>
    /// ValueTask not awaited or converted to Task.
    /// </summary>
    public const string NotConsumed = "CHT008";
}
