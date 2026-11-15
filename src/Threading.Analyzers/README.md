## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven collection of cryptography and performance libraries for the .NET ecosystem, maintained by **The Keepers of the CryptoHives**.

---

## 🔍 CryptoHives.Foundation.Threading.Analyzers

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.Analyzers.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers)

Roslyn analyzers that catch common `ValueTask` misuse at compile time — the kind of subtle bugs, undefined behavior, and performance pitfalls that tend to show up when working with `ValueTask` and pooled async primitives.

> **Note:** These analyzers are no longer bundled automatically with the [CryptoHives.Foundation.Threading](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) package. Install this package separately if you want the analyzers alongside the Threading library.

---

## 📥 Installation

```bash
dotnet add package CryptoHives.Foundation.Threading.Analyzers
```

Or as a development-only dependency (no runtime reference):

```xml
<PackageReference Include="CryptoHives.Foundation.Threading.Analyzers"
                  Version="*"
                  PrivateAssets="all" />
```

---

## 📋 Diagnostic Rules

| ID | Severity | Description |
|----|----------|-------------|
| [CHT001](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT001.html) | Error | `ValueTask` consumed multiple times |
| [CHT002](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT002.html) | Warning | `ValueTask.GetAwaiter().GetResult()` used (blocking) |
| [CHT003](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT003.html) | Warning | `ValueTask` stored in a field |
| [CHT005](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT005.html) | Warning | `ValueTask.Result` accessed directly |
| [CHT007](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT007.html) | Info | `AsTask()` stored before signaling (causes a performance hit) |
| [CHT008](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT008.html) | Warning | `ValueTask` not awaited or consumed |
| [CHT009](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT009.html) | Info | `SemaphoreSlim(1, 1)` used as an async lock; consider `AsyncLock` instead |
| [CHT010](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT010.html) | Warning | `ValueTask` captured in a lambda/closure |
| [CHT011](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT011.html) | Warning | `async` method only forwards an awaited `ValueTask` |
| [CHT012](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT012.html) | Info | `async` `ValueTask` wrapper boxes a state machine when it suspends |
| [CHT013](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT013.html) | Warning | `async` method returns an `AsyncReentrantLock` releaser, hiding the hold from its caller |

CHT001, CHT005 and CHT008 overlap the .NET SDK's [CA2012](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca2012), so with both enabled a line can be reported by each. The other rules have no CA2012 counterpart.

---

## ⚠️ Anti-Patterns Detected

```csharp
// CHT001: Multiple await — Error
ValueTask vt = GetValueTask();
await vt;
await vt; // Error: already consumed

// CHT002: Blocking call — Warning
ValueTask vt = GetValueTask();
vt.GetAwaiter().GetResult(); // Warning: undefined behavior

// CHT003: Stored in field — Warning
private ValueTask _task; // Warning: may be consumed multiple times

// CHT001 also covers repeated AsTask(): converting twice consumes twice — Error
ValueTask vt = GetValueTask();
var t1 = vt.AsTask();
var t2 = vt.AsTask(); // Error: already consumed

// CHT005: Direct .Result — Warning
ValueTask<int> vt = GetValueTask();
int result = vt.Result; // Warning: undefined behavior

// CHT007: AsTask() stored, then awaited once later — Info (performance)
Task t = _event.WaitAsync().AsTask(); // Info: allocates a Task the single await doesn't need
_event.Set();
await t;

// CHT008: Unconsumed — Warning
GetValueTask(); // Warning: result not awaited or discarded

// CHT009: SemaphoreSlim(1, 1) as async lock — Info
private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1); // Info: consider AsyncLock

// CHT010: Captured in a closure — Warning
ValueTask vt = GetValueTask();
Func<Task> f = async () => await vt; // Warning: the closure may run more than once

// CHT011: async only forwards — Warning
async ValueTask<int> GetAsync() => await GetValueTaskOfInt(); // Warning: return it directly

// CHT012: async ValueTask wrapper around cleanup — Info
async ValueTask<int> GetAsync()
{
    try { return await GetValueTaskOfInt(); } // Info: boxes a state machine when it suspends
    finally { Cleanup(); }
}

// CHT013: Releaser returned from an async method — Warning
async ValueTask<AsyncReentrantLock.Releaser> EnterAsync()
    => await _reentrantLock.LockAsync(); // Warning: the caller's nested LockAsync deadlocks
```

## ✅ Correct Patterns

```csharp
// Single await — correct
await GetValueTask();

// Store, then single await — correct
ValueTask vt = GetValueTask();
await vt;

// Preserve() for safe multiple consumption
ValueTask preserved = GetValueTask().Preserve();
await preserved;
await preserved; // Safe — Preserve() wraps in a reusable Task

// AsTask() once, reuse the Task
Task t = GetValueTask().AsTask();
await t;
await t; // Task can be awaited multiple times

// Pass to WhenAll via AsTask()
await Task.WhenAll(
    GetValueTask().AsTask(),
    GetValueTask().AsTask());

// Explicit discard
_ = GetValueTask();

// Closure: convert once, capture the Task
Task t = GetValueTask().AsTask();
Func<Task> f = () => t;

// Forwarding: return the ValueTask without async
ValueTask<int> GetAsync() => GetValueTaskOfInt();

// AsyncReentrantLock: return the ValueTask from LockAsync without async
ValueTask<AsyncReentrantLock.Releaser> EnterAsync() => _reentrantLock.LockAsync();
```

---

## 🔧 Automatic Code Fixes

Most diagnostics come with a code fix:

| Diagnostic | Available Fixes |
|------------|-----------------|
| CHT001 | Convert to `AsTask()` at declaration; use `Preserve()` |
| CHT002 | Convert to `await`; use `AsTask()` before `GetAwaiter().GetResult()` |
| CHT003 | Change field type to `Task` |
| CHT005 | Convert to `await`; use `AsTask().Result` |
| CHT007 | Await the `ValueTask` directly |
| CHT008 | Add `await`; discard explicitly with `_ =` |
| CHT009 | Replace `SemaphoreSlim(1,1)` with `AsyncLock` |
| CHT010 | Convert to `AsTask()` at declaration; use `Preserve()` |
| CHT011 | Remove `async` and return the `ValueTask` directly |
| CHT012 | Pool the state machine box (.NET 6+ only; a partial mitigation) |
| CHT013 | None; return the `ValueTask` from `LockAsync` directly (the CHT011 fix does this when it applies) |

---

## ⚙️ Configuration

Adjust rule severity in `.editorconfig`:

```ini
# Promote CHT007 from info to warning
dotnet_diagnostic.CHT007.severity = warning

# Disable CHT003 entirely
dotnet_diagnostic.CHT003.severity = none
```

Or suppress inline when it's genuinely intentional:

```csharp
#pragma warning disable CHT002
valueTask.GetAwaiter().GetResult(); // intentional blocking call
#pragma warning restore CHT002
```

---

## 📚 Documentation

| Resource | Link |
|----------|------|
| Full package documentation | [cryptohives.github.io/Foundation/packages/threading.analyzers](https://cryptohives.github.io/Foundation/packages/threading.analyzers/index.html) |
| Threading package | [cryptohives.github.io/Foundation/packages/threading](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| Source repository | [github.com/CryptoHives/Foundation](https://github.com/CryptoHives/Foundation) |

---

## 🚨 Security Policy

If you discover a vulnerability, please don't open a public issue — report it privately through [GitHub's private vulnerability reporting](https://github.com/CryptoHives/Foundation/security/advisories/new). The [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md) has the details.

---

## ⚖️ License

MIT OR Apache-2.0 — © 2026 The Keepers of the CryptoHives

See [Choosing a license](https://github.com/CryptoHives/Foundation#-choosing-a-license) for how to record which one you use.
