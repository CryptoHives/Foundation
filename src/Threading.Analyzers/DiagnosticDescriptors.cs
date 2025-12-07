// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;

/// <summary>
/// Contains all diagnostic descriptors for the ValueTask analyzers.
/// </summary>
public static class DiagnosticDescriptors
{
    private const string Category = "Usage";
    private const string HelpLinkBase = "https://github.com/CryptoHives/Foundation/blob/main/docs/analyzers/";

    /// <summary>
    /// CHT001: ValueTask awaited multiple times.
    /// </summary>
    public static readonly DiagnosticDescriptor MultipleAwait = new(
        id: DiagnosticIds.MultipleAwait,
        title: "ValueTask awaited multiple times",
        messageFormat: "ValueTask '{0}' is awaited multiple times. A ValueTask can only be awaited once",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "A ValueTask should only be awaited once. Awaiting it multiple times can cause undefined behavior or InvalidOperationException. Consider using .AsTask() if you need to await multiple times, or use .Preserve() to safely consume the ValueTask.",
        helpLinkUri: HelpLinkBase + "CHT001.md");

    /// <summary>
    /// CHT002: ValueTask.GetAwaiter().GetResult() used (blocking).
    /// </summary>
    public static readonly DiagnosticDescriptor BlockingGetResult = new(
        id: DiagnosticIds.BlockingGetResult,
        title: "ValueTask blocked with GetAwaiter().GetResult()",
        messageFormat: "Using GetAwaiter().GetResult() on ValueTask '{0}' can cause deadlocks and is undefined behavior for IValueTaskSource-backed ValueTasks",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Calling GetAwaiter().GetResult() on a ValueTask is undefined behavior when backed by IValueTaskSource. Use await instead, or convert to Task first with .AsTask().GetAwaiter().GetResult() if blocking is absolutely necessary.",
        helpLinkUri: HelpLinkBase + "CHT002.md");

    /// <summary>
    /// CHT003: ValueTask stored in field.
    /// </summary>
    public static readonly DiagnosticDescriptor StoredInField = new(
        id: DiagnosticIds.StoredInField,
        title: "ValueTask stored in field",
        messageFormat: "ValueTask stored in field '{0}' may be consumed multiple times",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Storing a ValueTask in a field increases the risk of consuming it multiple times, which causes undefined behavior. Consider storing the result of .AsTask() or .Preserve() instead.",
        helpLinkUri: HelpLinkBase + "CHT003.md");

    /// <summary>
    /// CHT004: ValueTask.AsTask() called multiple times.
    /// </summary>
    public static readonly DiagnosticDescriptor MultipleAsTask = new(
        id: DiagnosticIds.MultipleAsTask,
        title: "ValueTask.AsTask() called multiple times",
        messageFormat: "AsTask() called multiple times on ValueTask '{0}'. Each call creates a new Task wrapper",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "Calling AsTask() multiple times on the same ValueTask is undefined behavior and may throw InvalidOperationException. Store the result of AsTask() if you need to use it multiple times.",
        helpLinkUri: HelpLinkBase + "CHT004.md");

    /// <summary>
    /// CHT005: ValueTask.Result accessed directly.
    /// </summary>
    public static readonly DiagnosticDescriptor DirectResultAccess = new(
        id: DiagnosticIds.DirectResultAccess,
        title: "Direct ValueTask.Result access",
        messageFormat: "Accessing .Result on ValueTask '{0}' is undefined behavior for IValueTaskSource-backed ValueTasks",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Accessing .Result directly on a ValueTask is undefined behavior when the ValueTask is backed by IValueTaskSource. Use await or convert to Task first.",
        helpLinkUri: HelpLinkBase + "CHT005.md");

    /// <summary>
    /// CHT006: ValueTask passed to method that may consume it multiple times.
    /// </summary>
    public static readonly DiagnosticDescriptor PassedToUnsafeMethod = new(
        id: DiagnosticIds.PassedToUnsafeMethod,
        title: "ValueTask passed to potentially unsafe method",
        messageFormat: "ValueTask passed to '{0}' which may consume it multiple times",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Passing a ValueTask to certain methods like WhenAll, WhenAny, or custom methods may result in multiple consumption attempts. Consider using .AsTask() or .Preserve() before passing.",
        helpLinkUri: HelpLinkBase + "CHT006.md");

    /// <summary>
    /// CHT007: ValueTask.AsTask() stored before signaling.
    /// </summary>
    public static readonly DiagnosticDescriptor AsTaskStoredBeforeSignal = new(
        id: DiagnosticIds.AsTaskStoredBeforeSignal,
        title: "AsTask() stored before signaling may cause performance degradation",
        messageFormat: "Storing AsTask() result before the async operation completes can cause 10-100x performance degradation",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        description: "When RunContinuationsAsynchronously is true (default), storing the result of AsTask() before the underlying operation signals completion forces asynchronous scheduling, causing severe performance degradation. Await the ValueTask directly for optimal performance.",
        helpLinkUri: HelpLinkBase + "CHT007.md");

    /// <summary>
    /// CHT008: ValueTask not consumed.
    /// </summary>
    public static readonly DiagnosticDescriptor NotConsumed = new(
        id: DiagnosticIds.NotConsumed,
        title: "ValueTask not awaited or consumed",
        messageFormat: "ValueTask '{0}' is not awaited. This may cause resource leaks when backed by pooled IValueTaskSource",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "A ValueTask should always be awaited or converted to Task. When backed by pooled IValueTaskSource, not consuming it may leak pooled objects.",
        helpLinkUri: HelpLinkBase + "CHT008.md");
}
