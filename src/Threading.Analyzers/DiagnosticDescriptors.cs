// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;

/// <summary>
/// Contains all diagnostic descriptors for the ValueTask analyzers.
/// </summary>
public static class DiagnosticDescriptors
{
    private const string Category = "Usage";
    private const string HelpLinkBase = "https://cryptohives.github.io/Foundation/packages/threading.analyzers/";

    /// <summary>
    /// CHT001: ValueTask consumed multiple times.
    /// </summary>
    /// <remarks>
    /// Worded as "consumed" rather than "awaited" because that is what the rule actually detects: a
    /// ValueTask is consumed by <c>await</c>, by <c>AsTask()</c>, by <c>Preserve()</c> and by
    /// <c>GetAwaiter().GetResult()</c> alike, and any second consumption in any combination is reported
    /// here. Saying "awaited" misdescribed code that, for instance, only calls <c>AsTask()</c> twice.
    /// </remarks>
    public static readonly DiagnosticDescriptor MultipleAwait = new(
        id: DiagnosticIds.MultipleAwait,
        title: "ValueTask consumed multiple times",
        messageFormat: "ValueTask '{0}' is consumed more than once",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        description: "A ValueTask may only be consumed once. Awaiting it, calling AsTask(), calling Preserve() or calling GetAwaiter().GetResult() each consume it, and doing any two of those to the same instance - in any combination - can cause undefined behavior or InvalidOperationException, because a ValueTask backed by a pooled IValueTaskSource may have been recycled in between. Convert once with .AsTask() and reuse the resulting Task, or use .Preserve() to make the ValueTask safe to consume repeatedly.",
        helpLinkUri: HelpLinkBase + "CHT001.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT002: ValueTask.GetAwaiter().GetResult() used (blocking).
    /// </summary>
    public static readonly DiagnosticDescriptor BlockingGetResult = new(
        id: DiagnosticIds.BlockingGetResult,
        title: "ValueTask blocked with GetAwaiter().GetResult()",
        messageFormat: "Using GetAwaiter().GetResult() on ValueTask '{0}' can cause deadlocks",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Calling GetAwaiter().GetResult() on a ValueTask is undefined behavior when backed by IValueTaskSource. Use await instead, or convert to Task first with .AsTask().GetAwaiter().GetResult() if blocking is absolutely necessary.",
        helpLinkUri: HelpLinkBase + "CHT002.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

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
        helpLinkUri: HelpLinkBase + "CHT003.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT005: ValueTask.Result accessed directly.
    /// </summary>
    public static readonly DiagnosticDescriptor DirectResultAccess = new(
        id: DiagnosticIds.DirectResultAccess,
        title: "Direct ValueTask.Result access",
        messageFormat: "Accessing .Result on ValueTask '{0}' is undefined behavior",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Accessing .Result directly on a ValueTask is undefined behavior when the ValueTask is backed by IValueTaskSource. Use await or convert to Task first.",
        helpLinkUri: HelpLinkBase + "CHT005.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT007: ValueTask.AsTask() stored before signaling.
    /// </summary>
    public static readonly DiagnosticDescriptor AsTaskStoredBeforeSignal = new(
        id: DiagnosticIds.AsTaskStoredBeforeSignal,
        title: "AsTask() stored before signaling may cause performance degradation",
        messageFormat: "Storing AsTask() result before the async operation completes can cause performance degradation",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        description: "When RunContinuationsAsynchronously is true (default), storing the result of AsTask() before the underlying operation signals completion forces asynchronous scheduling, causing severe performance degradation. Await the ValueTask directly for optimal performance.",
        helpLinkUri: HelpLinkBase + "CHT007.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT008: ValueTask not consumed.
    /// </summary>
    public static readonly DiagnosticDescriptor NotConsumed = new(
        id: DiagnosticIds.NotConsumed,
        title: "ValueTask not awaited or consumed",
        messageFormat: "ValueTask '{0}' is not awaited",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "A ValueTask should always be awaited or converted to Task. When backed by pooled IValueTaskSource, not consuming it may leak pooled objects.",
        helpLinkUri: HelpLinkBase + "CHT008.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT009: SemaphoreSlim(1, 1) used as an async lock.
    /// </summary>
    public static readonly DiagnosticDescriptor SemaphoreSlimAsAsyncLock = new(
        id: DiagnosticIds.SemaphoreSlimAsAsyncLock,
        title: "SemaphoreSlim(1, 1) used as async lock",
        messageFormat: "'{0}' is a SemaphoreSlim(1, 1) used as a mutex; consider replacing with AsyncLock for lower allocations and ValueTask-based async acquisition",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        description: "SemaphoreSlim(1, 1) is commonly used as an async-compatible exclusive lock, but CryptoHives.Foundation.Threading.Async.Pooled.AsyncLock is purpose-built for this pattern: it uses pooled ValueTask sources to eliminate per-wait allocations and provides a deterministic Releaser struct that works with using declarations.",
        helpLinkUri: HelpLinkBase + "CHT009.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT010: ValueTask captured in lambda/closure.
    /// </summary>
    public static readonly DiagnosticDescriptor CapturedInClosure = new(
        id: DiagnosticIds.CapturedInClosure,
        title: "ValueTask captured in lambda or closure",
        messageFormat: "ValueTask '{0}' is captured in a lambda/closure and may be consumed multiple times",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "Capturing a ValueTask in a lambda or local function is potentially unsafe because the lambda might be invoked multiple times, or the ValueTask may be consumed by other code before the lambda executes. If you need to use the result multiple times, convert it to a Task using .AsTask() or use .Preserve() to safely capture it for multiple consumes.",
        helpLinkUri: HelpLinkBase + "CHT010.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT011: async method only forwards an awaited ValueTask.
    /// </summary>
    public static readonly DiagnosticDescriptor RedundantAsyncForwarding = new(
        id: DiagnosticIds.RedundantAsyncForwarding,
        title: "async method only forwards an awaited ValueTask",
        messageFormat: "'{0}' only awaits and returns a ValueTask; remove async/await and return it directly",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Warning,
        isEnabledByDefault: true,
        description: "An async method compiles to a state machine, and its builder boxes that state machine onto the heap the first time the method suspends. When the method does nothing but await one ValueTask and return the result, that machinery buys nothing: returning the inner ValueTask directly is equivalent and removes the allocation. The synchronous fast path benefits too, because the builder costs setup work even when it never suspends. Note that the exception behaviour changes subtly - an argument validated inside the method would now throw synchronously instead of surfacing on the returned ValueTask - so split validation into a non-async wrapper if callers depend on it.",
        helpLinkUri: HelpLinkBase + "CHT011.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);

    /// <summary>
    /// CHT012: async ValueTask wrapper boxes a state machine on every suspension.
    /// </summary>
    public static readonly DiagnosticDescriptor AsyncWrapperBoxesStateMachine = new(
        id: DiagnosticIds.AsyncWrapperBoxesStateMachine,
        title: "async ValueTask wrapper boxes a state machine when it suspends",
        messageFormat: "'{0}' forwards a single ValueTask but cannot return it directly because of surrounding cleanup; every suspension boxes a state machine",
        category: Category,
        defaultSeverity: DiagnosticSeverity.Info,
        isEnabledByDefault: true,
        description: "This method awaits exactly one ValueTask and returns it, but the await is wrapped in cleanup (try/catch, try/finally or using) that keeps the async machinery load-bearing. The cost is real but conditional: a call that completes synchronously allocates nothing, while every call that actually suspends boxes a state machine onto the heap - so this is a contended-path cost that an uncontended benchmark will not show. Consider whether the cleanup can be relocated to the awaited operation's own completion and failure paths, which allows the inner ValueTask to be returned directly. Applying [AsyncMethodBuilder(typeof(PoolingAsyncValueTaskMethodBuilder<>))] to the method is a lower-effort alternative that pools the box, but it only helps when boxes are reused in sequence - it cannot reduce peak live objects, so it does little when many waiters suspend at the same time. Measure before choosing. If the cleanup genuinely requires the await boundary, suppress this diagnostic with a comment explaining why.",
        helpLinkUri: HelpLinkBase + "CHT012.html",
        customTags: WellKnownDiagnosticTags.CustomSeverityConfigurable);
}
