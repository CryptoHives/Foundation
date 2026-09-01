# PooledSegment&lt;T&gt; Class

An [`ISegmentOwner<T>`](isegmentowner.md) that rents a buffer from `ArrayPool<T>.Shared`
and returns it automatically on dispose.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` → **`PooledSegment<T>`**

## Implements

- [`ISegmentOwner<T>`](isegmentowner.md)
- `IDisposable`

## Syntax

```csharp
public sealed class PooledSegment<T> : ISegmentOwner<T>
```

## Overview

`PooledSegment<T>` is the right choice whenever you need a temporary, right-sized buffer
that should go back to the pool once work is done. It wraps the rented array in an
`ArraySegment<T>` so the actual rented length (which `ArrayPool<T>` may round up) is hidden
behind a clean `Count == minimumLength` view.

Implemented as a `sealed class` so the backing array can never be disposed more than once
by an unintended struct copy.

## Factory Method

```csharp
public static ISegmentOwner<T> Rent(int minimumLength, bool clearArray = false)
```

Rents a buffer with at least `minimumLength` elements from `ArrayPool<T>.Shared` and
returns it wrapped in an `PooledSegment<T>`.

| Parameter | Description |
|-----------|-------------|
| `minimumLength` | The minimum number of elements required |
| `clearArray` | Whether to zero the buffer as it returns to the pool. Defaults to `false`. |

**Returns** — An owner whose `Segment.Count` equals `minimumLength`.

### Holding secrets

A rented buffer arrives holding whatever the previous tenant left in it, and by default goes back the
same way. Pass `clearArray: true` for key material or anything else that should not be legible to the
next renter:

```csharp
using ISegmentOwner<byte> key = PooledSegment<byte>.Rent(32, clearArray: true);

DeriveKey(key.Segment.AsSpan());
Sign(payload, key.Segment.AsSpan());
// the buffer is zeroed on the way back to the pool
```

Two things it does **not** do. It says nothing about the window in which the data was live, or about
copies taken elsewhere — it only stops the *next* renter reading it. And it is not free: disposal
costs a pass over the buffer, proportional to its length.

The whole array is zeroed, not just the current segment window, so narrowing the view with
`TrySetSegment` cannot leave part of it legible.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Segment` | `ArraySegment<T>` | Current segment view (offset and length track `TrySetSegment` calls) |

## Methods

| Method | Description |
|--------|-------------|
| `bool TrySetSegment(int offset, int length)` | Repositions the segment view; returns `false` if `offset + length > array.Length` |
| `void Dispose()` | Returns the rented array to `ArrayPool<T>.Shared` and resets `Segment` to `default` |

## Usage Examples

### Basic Rent and Use

```csharp
using CryptoHives.Foundation.Memory.Buffers;

using ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(1024);

Span<byte> buffer = segment.Segment.AsSpan();
int written = encoder.GetBytes(text, buffer);

// Use only the filled portion
ProcessData(buffer[..written]);

// Rented array is returned to the pool when segment is disposed
```

### Narrowing the View with TrySetSegment

```csharp
using ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(256);

// Skip a 4-byte header and work on 64 data bytes
if (segment.TrySetSegment(offset: 4, length: 64))
{
    Span<byte> data = segment.Segment.AsSpan();
    FillData(data);
}
```

### Indexed Access

```csharp
using ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(4);
segment[0] = 0x01;
segment[1] = 0x02;
segment[2] = 0x03;
segment[3] = 0x04;
```

## Remarks

- The backing array rented from `ArrayPool<T>.Shared` may be larger than `minimumLength`;
  `Segment.Count` always reflects the requested length.
- `DEBUG` builds clear every returned array whatever `clearArray` says, turning a use-after-return
  into obvious zeroes rather than plausible stale data. That is a **diagnostic, not a security
  control** — never conclude from debug behaviour that a release build wipes anything. The
  `clearArray` flag itself is honoured in every configuration.
- Calling `Dispose` more than once is safe; subsequent calls are no-ops.
- After `Dispose`, `Segment.Array` is `null`.

## See Also

- [`ISegmentOwner<T>`](isegmentowner.md)
- [`AllocatedSegment<T>`](allocatedsegment.md)
- [`EmptySegment<T>`](emptysegment.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives


