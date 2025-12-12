# CryptoHives.Foundation.Threading.Analyzers

## Overview

This package provides Roslyn analyzers that detect common `ValueTask` misuse patterns at compile time. These analyzers help developers avoid subtle bugs and performance issues when working with `ValueTask` and the pooled async primitives in the CryptoHives Threading library.

## Installation

```bash
dotnet add package CryptoHives.Foundation.Threading.Analyzers
```

Or add to your project file:

```xml
<PackageReference Include="CryptoHives.Foundation.Threading.Analyzers" Version="*" PrivateAssets="all" />
```

## Diagnostic Rules

| ID | Severity | Description |
|----|----------|----------|
| [CHT001](CHT001.md) | Error | ValueTask awaited multiple times |
| [CHT002](CHT002.md) | Warning | ValueTask.GetAwaiter().GetResult() used (blocking) |
| [CHT003](CHT003.md) | Warning | ValueTask stored in field |
| [CHT004](CHT004.md) | Error | ValueTask.AsTask() called multiple times |
| [CHT005](CHT005.md) | Warning | ValueTask.Result accessed directly |
| [CHT006](CHT006.md) | Warning | ValueTask passed to potentially unsafe method |
| [CHT007](CHT007.md) | Info | AsTask() stored before signaling (performance) |
| [CHT008](CHT008.md) | Warning | ValueTask not awaited or consumed |

## Quick Reference

### ❌ Anti-Patterns Detected

```csharp
// CHT001: Multiple await (Error)
ValueTask vt = GetValueTask();
await vt;
await vt; // Error: already consumed

// CHT002: Blocking with GetAwaiter().GetResult() (Warning)
ValueTask vt = GetValueTask();
vt.GetAwaiter().GetResult(); // Warning: undefined behavior

// CHT003: Stored in field (Warning)
private ValueTask _task; // Warning: may be consumed multiple times

// CHT004: Multiple AsTask() calls (Error)
ValueTask vt = GetValueTask();
var t1 = vt.AsTask();
var t2 = vt.AsTask(); // Error: already consumed

// CHT005: Direct .Result access (Warning)
ValueTask<int> vt = GetValueTask();
int result = vt.Result; // Warning: undefined behavior

// CHT006: Passed to unsafe method (Warning)
await Task.WhenAll(GetValueTask()); // Warning: use AsTask() or Preserve()

// CHT007: AsTask() stored before signaling (Info)
Task t = GetValueTask().AsTask(); // Info: may cause perf degradation
DoSomething();
await t;

// CHT008: Not consumed (Warning)
GetValueTask(); // Warning: result not awaited
```

### ✅ Correct Patterns

```csharp
// Single await - correct
await GetValueTask();

// Store, then single await - correct
ValueTask vt = GetValueTask();
await vt;

// Use Preserve() for safe multiple consumption (built-in on most platforms)
ValueTask vt = GetValueTask();
ValueTask preserved = vt.Preserve();
await preserved;
await preserved; // Safe!

// Use AsTask() once, store Task - correct (all platforms)
Task t = GetValueTask().AsTask();
await t;
await t; // Task can be awaited multiple times

// Pass Task to WhenAll - correct
await Task.WhenAll(
    GetValueTask().AsTask(),
    GetValueTask().AsTask()
);

// Explicit discard - correct
_ = GetValueTask();
```

## Code Fixes

The analyzer package includes automatic code fixes for most diagnostics:

| Diagnostic | Available Fixes |
|------------|-----------------|
| CHT001 | Convert to AsTask() at declaration, Use Preserve() |
| CHT002 | Convert to await, Use AsTask() before GetAwaiter().GetResult() |
| CHT003 | Change field type to Task |
| CHT004 | Store AsTask() result in variable |
| CHT005 | Convert to await, Use AsTask().Result |
| CHT007 | Await ValueTask directly |
| CHT008 | Add await, Explicitly discard with _ = |

## The Preserve() Method

### Built-in Preserve()

The `ValueTask.Preserve()` is available on all platforms.

```csharp
ValueTask vt = GetValueTask();
ValueTask preserved = vt.Preserve(); // Returns ValueTask that can be awaited multiple times

await preserved;
await preserved; // Safe!
```


## Configuration

### Suppressing Diagnostics

You can suppress specific diagnostics using standard methods:

```csharp
// Pragma directive
#pragma warning disable CHT002
valueTask.GetAwaiter().GetResult();
#pragma warning restore CHT002

// SuppressMessage attribute
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CHT002")]
public void Method() { }
```

### .editorconfig

Configure rule severity in `.editorconfig`:

```ini
# Make CHT007 a warning instead of info
dotnet_diagnostic.CHT007.severity = warning

# Disable CHT003 entirely
dotnet_diagnostic.CHT003.severity = none
```

## See Also

- [CryptoHives.Foundation.Threading Package](../threading/index.md)
- [ValueTask Best Practices](https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/)
- [CA2012: Use ValueTasks correctly](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca2012)
- [ValueTask.Preserve() API Reference](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask.preserve)

---

© 2025 The Keepers of the CryptoHives
