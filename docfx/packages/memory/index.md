# CryptoHives.Foundation.Memory Package

The Memory package provides high-performance, allocation-efficient buffer management utilities for .NET applications.

## Overview

This package contains classes that leverage `ArrayPool<T>` and modern .NET memory APIs to minimize allocations and reduce garbage collection pressure in high-throughput scenarios.

## Key Features

- **Pooled Memory Streams**: Memory streams backed by `ArrayPool<byte>.Shared`
- **Zero-Copy APIs**: Support for `ReadOnlySequence<T>` and `Span<T>`
- **Buffer Writers**: IBufferWriter implementations with pooled storage
- **RAII Pattern**: Safe object pool resource management with `ObjectOwner<T>`

## Installation

```bash
dotnet add package CryptoHives.Foundation.Memory
```

## Namespace

```csharp
using CryptoHives.Foundation.Memory.Buffers;
using CryptoHives.Foundation.Memory.Pools;
```

## Classes

### Buffer Management

| Class | Description | Documentation |
|-------|-------------|---------------|
| [ArrayPoolMemoryStream](arraypoolmemorystream.md) | Memory stream using pooled buffers | [Details](arraypoolmemorystream.md) |
| [ArrayPoolBufferWriter&lt;T&gt;](arraypoolbufferwriter.md) | IBufferWriter implementation with pooled chunks | [Details](arraypoolbufferwriter.md) |
| [ReadOnlySequenceMemoryStream](readonlysequencememorystream.md) | Stream wrapper for ReadOnlySequence | [Details](readonlysequencememorystream.md) |

### Object Pool Utilities

| Class | Description | Documentation |
|-------|-------------|---------------|
| [ObjectOwner&lt;T&gt;](objectowner.md) | RAII wrapper for pooled objects | [Details](objectowner.md) |
| [ObjectPools](objectpools.md) | Static helpers for creating object pools | [Details](objectpools.md) |

### Internal Support Classes

| Class | Description |
|-------|-------------|
| ArrayPoolBufferSegment&lt;T&gt; | Internal buffer segment for ReadOnlySequence |
| ArrayPoolBufferSequence&lt;T&gt; | Internal buffer sequence management |

## Quick Examples

### ArrayPoolMemoryStream

```csharp
using var stream = new ArrayPoolMemoryStream();

// Write data
await stream.WriteAsync(data, cancellationToken);

// Get zero-copy ReadOnlySequence
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();

// Process without copying
ProcessSequence(sequence);
```

### ArrayPoolBufferWriter

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();

// Get span and write
Span<byte> span = writer.GetSpan(1024);
int written = encoder.GetBytes(text, span);
writer.Advance(written);

// Get the complete sequence
ReadOnlySequence<byte> result = writer.GetReadOnlySequence();
```

### ObjectOwner

```csharp
var pool = ObjectPools.Create<MyClass>();

using var owner = new ObjectOwner<MyClass>(pool);
MyClass obj = owner.Object;

// Use obj...
// Automatically returned to pool when owner is disposed
```

## Benefits

### Reduced Allocations

- Rents buffers from `ArrayPool<T>.Shared` instead of allocating new arrays
- Reuses pooled segments to avoid allocation churn
- No resize-copy operations during growth

### Lower GC Pressure

- Fewer short-lived objects
- Avoids Large Object Heap (LOH) allocations
- Better for high-throughput scenarios

### Zero-Copy Access

- `ReadOnlySequence<T>` exposes internal segments without copying
- `Span<T>` based Read/Write APIs
- Efficient data processing pipelines

## Performance Characteristics

- **ArrayPoolMemoryStream**: O(1) segment append, no copy-on-grow
- **ArrayPoolBufferWriter**: Exponential chunk growth with configurable limits
- **ReadOnlySequenceMemoryStream**: Zero-copy wrapper with O(n) seeking

## Best Practices

1. **Always dispose**: Use `using` statements to ensure buffers are returned
2. **Don't hold references**: ReadOnlySequence is only valid until the next write or dispose
3. **Size hints**: Provide size hints to minimize reallocations
4. **Scope carefully**: Keep writer/stream lifetime as short as possible

## See Also

- [API Reference](../../api/CryptoHives.Foundation.Memory.Buffers.html)
- [Threading Package](../threading/index.md)

---

© 2025 The Keepers of the CryptoHives
