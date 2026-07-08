# ISegmentOwner&lt;T&gt; Interface

`ISegmentOwner<T>` complements `IMemoryOwner<T>` with a unified ownership contract for an
`ArraySegment<T>` that controls the lifetime of its underlying memory. 
Implementors decide how to acquire and release that memory (pool return,
GC collection, or no-op), while callers use a single consistent API.
In conjunction with `ArrayPool<T>`, an allocated `ArraySegment<T>` has the advantage 
that the underlying buffer is adjustable in terms of the offset and the size of the segment without 
losing the ownership of the underlying pooled buffer. 
Due to the simple conversion to `Span<T>` and `Memory<T>`, 
it is easy to use in the hot path of the code.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`IDisposable` → **`ISegmentOwner<T>`**

## Syntax

```csharp
public interface ISegmentOwner<T> : IDisposable
```

## Type Parameters

**`T`** — The element type of the segment.

## Overview

`ISegmentOwner<T>` bundles three concerns:

| Concern | Member |
|---------|--------|
| Data access | `Segment` property and `this[int]` indexer |
| Slice adjustment | `TrySetSegment(offset, length)` |
| Lifetime management | `Dispose()` (from `IDisposable`) |

Three built-in implementations cover the most common ownership strategies:

| Class | Memory source | Dispose behaviour |
|-------|--------------|-------------------|
| [`PooledSegment<T>`](pooledsegment.md) | `ArrayPool<T>.Shared` | Returns array to pool |
| [`AllocatedSegment<T>`](allocatedsegment.md) | `new T[]` (GC heap) | Clears the segment wrapper |
| [`EmptySegment<T>`](emptysegment.md) | `Array.Empty<T>()` | No-op |

## Members

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Segment` | `ArraySegment<T>` | The current segment view of the underlying array |

### Indexer

```csharp
T this[int i] { get; set; }
```

Gets or sets element `i` relative to `Segment.Offset` inside `Segment.Array`.

### Methods

```csharp
bool TrySetSegment(int offset, int length);
```

Narrows or repositions the segment view. Returns `true` on success; `false` when the
underlying array is `null` or too small to satisfy `offset + length`.

```csharp
void Dispose();
```

Releases ownership of the underlying memory according to the concrete implementation.

## Usage

### Consuming code

Write consumer code against `ISegmentOwner<T>` and let the caller decide the ownership
strategy via the concrete factory:

```csharp
void Process(ISegmentOwner<byte> owner)
{
    Span<byte> span = owner.Segment.AsSpan();
    // ... work with span ...
}

// Caller chooses ArrayPool (cheap in hot path)
using ISegmentOwner<byte> pooled = PooledSegment<byte>.Rent(1024);
Process(pooled);

// Or GC-managed array (simple, no pool lifecycle to track)
using ISegmentOwner<byte> alloc = AllocatedSegment<byte>.Create(new byte[1024]);
Process(alloc);
```

### Slicing after rent

```csharp
using ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(256);

if (segment.TrySetSegment(offset: 16, length: 64))
{
    // Segment is now [16..80) inside the rented array
    Span<byte> slice = segment.Segment.AsSpan();
    DecryptPayload(slice);
}
```

## Thread Safety

Instances are **not thread-safe**. The intended pattern is single-owner, short-lived, scoped with `using`.

## See Also

- [PooledSegment&lt;T&gt;](pooledsegment.md)
- [AllocatedSegment&lt;T&gt;](allocatedsegment.md)
- [EmptySegment&lt;T&gt;](emptysegment.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives


