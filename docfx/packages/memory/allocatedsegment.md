# AllocatedSegment&lt;T&gt; Class

An [`ISegmentOwner<T>`](isegmentowner.md) that wraps a GC-managed `T[]` in an
`ArraySegment<T>`. The underlying array is collected by the garbage collector;
`Dispose` only clears the segment wrapper.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` → **`AllocatedSegment<T>`**

## Implements

- [`ISegmentOwner<T>`](isegmentowner.md)
- `IDisposable`

## Syntax

```csharp
public sealed class AllocatedSegment<T> : ISegmentOwner<T>
```

## Overview

Use `AllocatedSegment<T>` when you already have a heap-allocated array and want to hand it
to code that expects `ISegmentOwner<T>`, or when a short-lived buffer is needed and pool
lifecycle management would add unnecessary complexity.

Unlike `PooledSegment<T>`, the array is not returned to any pool on dispose — it is
eligible for GC as soon as there are no more live references to it.

## Factory Method

```csharp
public static ISegmentOwner<T> Create(T[] buffer)
```

Wraps `buffer` in an `AllocatedSegment<T>` as a full-array segment (offset 0, length equal
to `buffer.Length`).

| Parameter | Description |
|-----------|-------------|
| `buffer` | The array to wrap. The full array is exposed as the initial segment. |

**Returns** — An owner whose `Segment.Array` is the same reference as `buffer`.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Segment` | `ArraySegment<T>` | Current segment view; updated by `TrySetSegment` calls |

## Methods

| Method | Description |
|--------|-------------|
| `bool TrySetSegment(int offset, int length)` | Repositions the segment view; returns `false` if `offset + length > array.Length` |
| `void Dispose()` | Clears `Segment` to `default`; the underlying array is unaffected |

## Usage Examples

### Wrapping an Existing Array

```csharp
using CryptoHives.Foundation.Memory.Buffers;

byte[] data = File.ReadAllBytes(path);
using ISegmentOwner<byte> segment = AllocatedSegment<byte>.Create(data);

Process(segment);
// Array is GC-eligible once `segment` and `data` go out of scope
```

### Narrowing the View with TrySetSegment

```csharp
byte[] raw = new byte[128];
using ISegmentOwner<byte> segment = AllocatedSegment<byte>.Create(raw);

// Focus on bytes 8..39 (offset=8, length=32)
if (segment.TrySetSegment(8, 32))
{
    Span<byte> slice = segment.Segment.AsSpan();
    ReadHeader(slice);
}
```

### Indexed Access

```csharp
using ISegmentOwner<byte> segment = AllocatedSegment<byte>.Create(new byte[4]);
segment[0] = 0xDE;
segment[1] = 0xAD;
segment[2] = 0xBE;
segment[3] = 0xEF;
```

## Remarks

- `Create` does **not** copy the array; the `Segment.Array` reference is the same object
  passed in.
- Writes via the indexer are immediately visible through the original array reference.
- Calling `Dispose` more than once is safe.
- After `Dispose`, `Segment.Array` is `null`, but the array itself is unchanged.

## See Also

- [`ISegmentOwner<T>`](isegmentowner.md)
- [`PooledSegment<T>`](pooledsegment.md)
- [`EmptySegment<T>`](emptysegment.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives


