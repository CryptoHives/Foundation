## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven cryptography and performance library collection for the .NET ecosystem,
developed and maintained by **The Keepers of the CryptoHives**.

---

## CryptoHives.Foundation.Threading.Analyzers

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.Analyzers.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers)

Roslyn analyzers that detect common `ValueTask` misuse patterns at compile time — helping you avoid subtle bugs, undefined behavior, and performance pitfalls when working with `ValueTask` and pooled async primitives.

> **Note:** These analyzers are automatically included in the [CryptoHives.Foundation.Threading](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) package. Install this package separately only if you need the analyzers without the Threading library.

---

## 📦 Installation

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

## 🔍 Diagnostic Rules

| ID | Severity | Description |
|----|----------|-------------|
| [CHT001](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT001.html) | Error | `ValueTask` awaited multiple times |
| [CHT002](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT002.html) | Warning | `ValueTask.GetAwaiter().GetResult()` used (blocking) |
| [CHT003](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT003.html) | Warning | `ValueTask` stored in a field |
| [CHT004](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT004.html) | Error | `ValueTask.AsTask()` called multiple times |
| [CHT005](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT005.html) | Warning | `ValueTask.Result` accessed directly |
| [CHT006](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT006.html) | Warning | `ValueTask` passed to potentially unsafe method |
| [CHT007](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT007.html) | Info | `AsTask()` stored before signaling (performance degradation) |
| [CHT008](https://cryptohives.github.io/Foundation/packages/threading.analyzers/CHT008.html) | Warning | `ValueTask` not awaited or consumed |

---

## ❌ Anti-Patterns Detected

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

// CHT004: Multiple AsTask() — Error
ValueTask vt = GetValueTask();
var t1 = vt.AsTask();
var t2 = vt.AsTask(); // Error: already consumed

// CHT005: Direct .Result — Warning
ValueTask<int> vt = GetValueTask();
int result = vt.Result; // Warning: undefined behavior

// CHT006: Passed to unsafe method — Warning
await Task.WhenAll(GetValueTask()); // Warning: use AsTask() or Preserve()

// CHT007: AsTask() before signaling — Info (performance)
Task t = someAsyncLock.LockAsync().AsTask();
// ... other work ...
await t; // Info: storing AsTask() before signal causes 10–100x slowdown

// CHT008: Unconsumed — Warning
GetValueTask(); // Warning: result not awaited or discarded
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
```

---

## 🔧 Automatic Code Fixes

The analyzer package includes code fixes for most diagnostics:

| Diagnostic | Available Fixes |
|------------|-----------------|
| CHT001 | Convert to `AsTask()` at declaration; use `Preserve()` |
| CHT002 | Convert to `await`; use `AsTask()` before `GetAwaiter().GetResult()` |
| CHT003 | Change field type to `Task` |
| CHT004 | Store `AsTask()` result in variable |
| CHT005 | Convert to `await`; use `AsTask().Result` |
| CHT007 | Await `ValueTask` directly |
| CHT008 | Add `await`; explicitly discard with `_ =` |

---

## ⚙️ Configuration

Adjust rule severity in `.editorconfig`:

```ini
# Promote CHT007 from info to warning
dotnet_diagnostic.CHT007.severity = warning

# Disable CHT003 entirely
dotnet_diagnostic.CHT003.severity = none
```

Suppress inline when necessary:

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

## 🔐 Security Policy

If you discover a vulnerability, **please do not open a public issue.**
Follow the guidelines on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## ⚖️ License

MIT — © 2026 The Keepers of the CryptoHives
