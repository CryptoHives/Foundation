# ISequenceOwner&lt;T&gt; Interface

`ISequenceOwner<T>` is the sequence-shaped counterpart to [`ISegmentOwner<T>`](isegmentowner.md),
and follows the same idea as `IMemoryOwner<T>`: the interface carries the payload, and
`IDisposable` carries the lifetime.

It exists because the sequences returned by `ArrayPoolMemoryStream.GetReadOnlySequence()` and
`ArrayPoolBufferWriter<T>.GetReadOnlySequence()` are **borrowed** — they stay valid only while their
producer lives, so the payload dies when the stream or writer is disposed. An `ISequenceOwner<T>`
*owns* the buffers instead, which lets a payload be produced in one place, handed on, and released
by whoever finishes with it.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`IDisposable` → **`ISequenceOwner<T>`**

## Syntax

```csharp
public interface ISequenceOwner<T> : IDisposable
```

## Type Parameters

**`T`** — The element type of the sequence.

## Overview

| Concern | Member |
|---------|--------|
| Data access | `Sequence` property |
| Size | `Length`, `IsEmpty` |
| Lifetime management | `Dispose()` (from `IDisposable`) |

There is deliberately **no indexer and no re-window method**, unlike `ISegmentOwner<T>`. A
`ReadOnlySequence<T>` is read-only, and narrowing it is already a cheap value operation that leaves
ownership untouched:

```csharp
ReadOnlySequence<byte> view = owner.Sequence.Slice(start, length);
```

## Implementations

| Source | What it owns | Dispose behaviour |
|--------|--------------|-------------------|
| [`SequenceLease<T>`](sequencelease.md) | Nothing itself — it holds the producer | Disposes the producer, which frees the buffers |
| [`SegmentSequence<T>`](segmentsequence.md) | One adopted `ISegmentOwner<T>` | Disposes the inner owner |
| [`EmptySequence<T>`](emptysequence.md) | Nothing | No-op |

`SequenceLease<T>` is what the producers hand out, and it is the one to reach for by default.

> [!IMPORTANT]
> [`SequenceLease<T>`](sequencelease.md) is a **struct**. Using it through this interface boxes it —
> a measured 48 bytes — which is exactly the allocation it exists to avoid. Take the lease by its own
> type unless you genuinely need to treat several owner kinds uniformly.

## Members

### Properties

| Property | Type | Description |
|----------|------|-------------|
| `Sequence` | `ReadOnlySequence<T>` | The payload. Valid until the owner is disposed. |
| `Length` | `long` | Total number of elements. |
| `IsEmpty` | `bool` | Whether the owner holds nothing. |

### Methods

```csharp
void Dispose();
```

Releases the underlying memory according to the concrete implementation.

## Ownership Is Exclusive

There is **no reference counting**. A single holder is responsible for disposal, and reading
`Sequence` afterwards is undefined — with pooled buffers the arrays behind it may already have been
handed to another tenant.

If several consumers need the same payload, either keep the owner alive until the last of them is
finished, or copy.

## Usage

### Letting a payload leave its scope

The cheap way is a [`SequenceLease<T>`](sequencelease.md), which carries the producer along as the
disposable and costs nothing:

```csharp
static SequenceLease<byte> BuildPayload()
{
    var writer = ObjectPools.RentBufferWriter<byte>();
    Serialize(writer);
    return writer.LeaseSequence();
}

using SequenceLease<byte> payload = BuildPayload();
Process(payload.Sequence);
```

Note the producer is deliberately not disposed inside `BuildPayload` — the lease owns it now, and
disposing it there would release the very buffers the payload is made of.

### Reading through a Stream API

`ReadOnlySequenceMemoryStream` wraps a sequence as a readable `Stream`, reading the buffers in place
rather than copying them, and leaves ownership where it is:

```csharp
using SequenceLease<byte> payload = stream.LeaseSequence();
using var reader = new ReadOnlySequenceMemoryStream(payload.Sequence);

await client.UploadAsync(reader);
```

### Feeding the cryptography package

The hash algorithms accept a `ReadOnlySequence<byte>` directly, so a multi-segment payload is hashed
without ever being flattened:

```csharp
using SequenceLease<byte> payload = writer.LeaseSequence();
byte[] digest = Blake3.HashData(payload.Sequence);
```

### Composing with segment ownership

Any [`ISegmentOwner<T>`](isegmentowner.md) becomes a sequence owner through
[`SegmentSequence<T>`](segmentsequence.md), so code written against `ISequenceOwner<T>` works with
every segment strategy without caring which is underneath:

```csharp
ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(1024);
using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(segment);
```

## Thread Safety

Instances are **not thread-safe**. The intended pattern is single-owner, short-lived, scoped with
`using`.

## See Also

- [SequenceLease&lt;T&gt;](sequencelease.md)
- [SegmentSequence&lt;T&gt;](segmentsequence.md)
- [EmptySequence&lt;T&gt;](emptysequence.md)
- [ISegmentOwner&lt;T&gt;](isegmentowner.md)
- [ArrayPoolBufferWriter&lt;T&gt;](arraypoolbufferwriter.md)
- [ArrayPoolMemoryStream](arraypoolmemorystream.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
