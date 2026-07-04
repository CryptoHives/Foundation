# CryptoHives.Foundation.Memory Package

Buffer management utilities for .NET, built on `ArrayPool<T>` and the modern .NET memory APIs to keep allocations and GC pressure out of high-throughput code.

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

// Get a zero-copy ReadOnlySequence
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();

// Process without copying
ProcessSequence(sequence);

// The sequence's memory is returned to the pool once the stream is disposed
```

### ArrayPoolBufferWriter

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();

// Get a span and write into it
Span<byte> span = writer.GetSpan(1024);
int written = encoder.GetBytes(text, span);
writer.Advance(written);

// Get the complete sequence
ReadOnlySequence<byte> result = writer.GetReadOnlySequence();

// Pooled chunks are returned once the writer is disposed
```

### ObjectOwner

```csharp
var pool = ObjectPools.Create<MyClass>();

using var owner = new ObjectOwner<MyClass>(pool);
MyClass obj = owner.Object;

// Use obj...

// Automatically returned to the pool when owner is disposed
```

## Why Pooled Buffers

Renting from `ArrayPool<T>.Shared` instead of allocating avoids resize-copy churn and keeps large buffers off the Large Object Heap, which matters once you're pushing enough throughput that allocations start showing up in GC pauses. `ReadOnlySequence<T>` then lets you hand that pooled data to a consumer without copying it at all.

- **ArrayPoolMemoryStream**: O(1) segment append, no copy-on-grow
- **ArrayPoolBufferWriter**: exponential chunk growth with configurable limits
- **ReadOnlySequenceMemoryStream**: zero-copy wrapper with O(n) seeking

## A Few Things to Watch For

- Always wrap streams and writers in a `using` so pooled buffers actually get returned.
- A `ReadOnlySequence<byte>` from these types is only valid until the next write or dispose — don't hold onto it past that point.
- If you know roughly how much you'll write, pass a size hint; it cuts down on reallocations.
- Keep writer/stream lifetimes short and scoped to the operation that needs them.

## See Also

- [Threading Package](../threading/index.md)

---

© 2026 The Keepers of the CryptoHives
