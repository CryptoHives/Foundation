# SegmentSequence&lt;T&gt; Class

An [`ISequenceOwner<T>`](isequenceowner.md) that adapts a single
[`ISegmentOwner<T>`](isegmentowner.md) into a one-node `ReadOnlySequence<T>`, taking over its
lifetime.

This is the composition point between the two ownership abstractions: every segment strategy —
[`PooledSegment<T>`](pooledsegment.md), [`AllocatedSegment<T>`](allocatedsegment.md),
[`EmptySegment<T>`](emptysegment.md) — becomes a sequence owner for free, so code written against
`ISequenceOwner<T>` works with all of them without caring which is underneath.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` → **`SegmentSequence<T>`**

## Implements

- [`ISequenceOwner<T>`](isequenceowner.md)
- `IDisposable`

## Syntax

```csharp
public sealed class SegmentSequence<T> : ISequenceOwner<T>
```

## Type Parameters

**`T`** — The element type of the segment.

## Methods

```csharp
public static ISequenceOwner<T> Create(ISegmentOwner<T> owner);
```

Wraps `owner` so its segment can be consumed as a `ReadOnlySequence<T>`. No copy is made.

Throws `ArgumentNullException` when `owner` is `null`.

## Ownership Transfers

`Create` **adopts** the segment owner. Disposing the returned sequence owner disposes the inner one —
which is what returns a pooled buffer to its pool. Do not dispose the segment owner separately after
handing it over:

```csharp
ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(1024);

using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(segment);
// ... use owner.Sequence ...

// One dispose, at the end of the using: the pooled array goes back here.
```

## The Sequence Tracks Re-Windowing

`Sequence` is built on each read rather than cached at construction, so a
`ISegmentOwner<T>.TrySetSegment` call on the inner owner is reflected. Constructing the sequence is
a struct operation and allocates nothing.

```csharp
ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(128);
using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(segment);

owner.Length;                       // 128

segment.TrySetSegment(16, 32);
owner.Length;                       // 32 — the narrowed view
```

## Usage

### Uniform handling of any segment strategy

```csharp
void Consume(ISequenceOwner<byte> payload)
{
    Process(payload.Sequence);
}

// Pooled
Consume(SegmentSequence<byte>.Create(PooledSegment<byte>.Rent(4096)));

// GC-managed
Consume(SegmentSequence<byte>.Create(AllocatedSegment<byte>.Create(new byte[4096])));

// Nothing at all
Consume(SegmentSequence<byte>.Create(EmptySegment<byte>.Instance));
```

## Members

| Member | Type | Description |
|--------|------|-------------|
| `Sequence` | `ReadOnlySequence<T>` | A single-node sequence over the adopted segment |
| `Length` | `long` | The adopted segment's element count |
| `IsEmpty` | `bool` | Whether the segment holds nothing |
| `Dispose()` | `void` | Disposes the adopted segment owner. Idempotent. |

## Thread Safety

Instances are **not thread-safe**.

## See Also

- [ISequenceOwner&lt;T&gt;](isequenceowner.md)
- [ISegmentOwner&lt;T&gt;](isegmentowner.md)
- [EmptySequence&lt;T&gt;](emptysequence.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
