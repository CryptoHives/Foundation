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

### Segment Ownership

| Class | Description | Documentation |
|-------|-------------|---------------|
| [ISegmentOwner&lt;T&gt;](isegmentowner.md) | Ownership interface for an `ArraySegment<T>` | [Details](isegmentowner.md) |
| [PooledSegment&lt;T&gt;](pooledsegment.md) | Rents from `ArrayPool<T>.Shared`; returns on dispose | [Details](pooledsegment.md) |
| [AllocatedSegment&lt;T&gt;](allocatedsegment.md) | Wraps a GC-managed `T[]`; no pool return | [Details](allocatedsegment.md) |
| [EmptySegment&lt;T&gt;](emptysegment.md) | Zero-allocation null-object sentinel | [Details](emptysegment.md) |

### Sequence Ownership

| Class | Description | Documentation |
|-------|-------------|---------------|
| [ISequenceOwner&lt;T&gt;](isequenceowner.md) | Ownership interface for a `ReadOnlySequence<T>` | [Details](isequenceowner.md) |
| [SequenceLease&lt;T&gt;](sequencelease.md) | Zero-allocation payload handle carrying its producer | [Details](sequencelease.md) |
| [SegmentSequence&lt;T&gt;](segmentsequence.md) | Adapts any `ISegmentOwner<T>` into a one-node sequence | [Details](segmentsequence.md) |
| [EmptySequence&lt;T&gt;](emptysequence.md) | Zero-allocation null-object sentinel | [Details](emptysequence.md) |

### Object Pool Utilities

| Class | Description | Documentation |
|-------|-------------|---------------|
| [ObjectOwner&lt;T&gt;](objectowner.md) | RAII wrapper for pooled objects | [Details](objectowner.md) |
| [ObjectPools](objectpools.md) | Ready-made rent helpers for common types | [Details](objectpools.md) |
| [PoolFactory](poolfactory.md) | Builds pools, including for types this package does not reference | [Details](poolfactory.md) |
| [ArrayPoolBufferWriterProvider&lt;T&gt;](arraypoolbufferwriterprovider.md) | Immutable writer settings that rent from a shared pool | [Details](arraypoolbufferwriterprovider.md) |

### Internal Support Classes

| Class | Description |
|-------|-------------|
| ArrayPoolBufferSegment&lt;T&gt; | Internal buffer segment for ReadOnlySequence |
| ArrayPoolBufferSequence&lt;T&gt; | Internal `IDisposable` over a chain of pooled segments. Has never had a caller; [`SequenceLease<T>`](sequencelease.md) fills the role. |

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

### Handing a payload on, past the scope that built it

```csharp
static SequenceLease<byte> BuildPayload()
{
    var writer = ObjectPools.RentBufferWriter<byte>();   // deliberately not `using`
    Serialize(writer);
    return writer.LeaseSequence();                       // 0 bytes; the writer rides along
}

using SequenceLease<byte> payload = BuildPayload();
var reader = new Utf8JsonReader(payload.Sequence);       // read in place, no copy
// disposing the lease returns the writer to its pool, and its buffers to ArrayPool
```

### Pooled buffer writers

```csharp
// One profile per use case; every profile draws from the same pool
static readonly ArrayPoolBufferWriterProvider<byte> JsonWriters = new(maxChunkBytes: 1 << 20);

using var writer = JsonWriters.Rent();
// ... write ...
// Disposing returns the writer itself to the pool, not just its buffers
```

### ObjectOwner

```csharp
// Pool your own type with a factory and a reset delegate
ObjectPool<MyClass> pool = PoolFactory.CreatePool(
    create: () => new MyClass(),
    reset: obj => { obj.Clear(); return true; });

using var owner = new ObjectOwner<MyClass>(pool);
MyClass obj = owner.PooledObject;

// Use obj...

// Automatically returned to the pool when owner is disposed
```

### Segment Ownership

```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Pool-backed buffer — returned to ArrayPool on dispose
using ISegmentOwner<byte> pooled = PooledSegment<byte>.Rent(256);
Span<byte> span = pooled.Segment.AsSpan();
// fill span ...

// Wrap an existing array with no pool lifecycle
byte[] existing = new byte[256];
using ISegmentOwner<byte> alloc = AllocatedSegment<byte>.Create(existing);

// Empty sentinel — avoids null checks
ISegmentOwner<byte> none = EmptySegment<byte>.Instance;
if (none.Segment.Count == 0) { /* nothing to process */ }
```

## Why Pooled Buffers

Renting from `ArrayPool<T>.Shared` instead of allocating avoids resize-copy churn and keeps large buffers off the Large Object Heap, which matters once you're pushing enough throughput that allocations start showing up in GC pauses. `ReadOnlySequence<T>` then lets you hand that pooled data to a consumer without copying it at all.

- **ArrayPoolMemoryStream**: O(1) segment append, no copy-on-grow
- **ArrayPoolBufferWriter**: exponential chunk growth with configurable limits
- **ReadOnlySequenceMemoryStream**: zero-copy wrapper with O(n) seeking

## Clearing Sensitive Buffers

A buffer arrives from `ArrayPool<T>` holding whatever the previous tenant left in it and, by default,
goes back the same way. Any type here that owns pooled memory takes a `clearArray` flag that zeroes
each buffer on its way back, so the next renter cannot read what you wrote:

```csharp
using var stream  = new ArrayPoolMemoryStream(clearArray: true);
using var segment = PooledSegment<byte>.Rent(256, clearArray: true);

// For writers the flag belongs to the profile, not the call site
static readonly ArrayPoolBufferWriterProvider<byte> Secrets = new(clearArray: true);
using var writer = Secrets.Rent();
```

| Type | How to ask |
|------|-----------|
| [ArrayPoolMemoryStream](arraypoolmemorystream.md) | `clearArray` on any owning constructor |
| [PooledSegment&lt;T&gt;](pooledsegment.md) | `Rent(minimumLength, clearArray)` |
| [ArrayPoolBufferWriter&lt;T&gt;](arraypoolbufferwriter.md) | `clearArray` on the constructor, or on the [provider](arraypoolbufferwriterprovider.md) |

It is opt-in everywhere. Zeroing costs a pass over each buffer, and most callers carry nothing worth
hiding. Types that do **not** own their buffers — the read-only `ArrayPoolMemoryStream` constructor,
`AllocatedSegment<T>` — have no such flag, because they never return anything to a pool.

For a pooled writer the flag is applied when the writer is *rented* and read when it is *released*,
so the outgoing renter's setting is always the one in force. That ordering is what makes the zeroing
trustworthy, and it is why the settings are not publicly writable.

## Pools and Memory Pressure

The two layers behave differently, which is worth knowing before you size anything:

- **Rented arrays** are released automatically. `ArrayPool<T>.Shared` registers a gen-2 GC callback
  and trims itself according to memory pressure.
- **Pooled objects are not.** `DefaultObjectPool<T>` never trims — it drops an instance only when a
  policy rejects it or the pool is already full, and otherwise holds what it has for the life of the
  process. Bound it with `maximumRetained` if that matters. See [PoolFactory](poolfactory.md).

## A Few Things to Watch For

- Always wrap streams and writers in a `using` so pooled buffers actually get returned.
- A `ReadOnlySequence<byte>` from `GetReadOnlySequence()` is **borrowed** — valid only until the next write or dispose. When the payload has to leave that scope, use `LeaseSequence()` — it costs nothing and carries the producer along. See [`SequenceLease<T>`](sequencelease.md).
- `ArrayPoolMemoryStream` cannot hand out a single contiguous array, so `GetBuffer()` throws and `TryGetBuffer()` returns `false`. Reach for the sequence instead.
- If you know roughly how much you'll write, pass a size hint; it cuts down on reallocations.
- Keep writer/stream lifetimes short and scoped to the operation that needs them.
- Carrying secrets? Pass `clearArray: true`, or the buffer goes back to the pool exactly as you wrote it.
- **Never touch a pooled writer after disposing it.** A returned instance does not throw `ObjectDisposedException`; it silently becomes whatever the next renter is doing — the same contract as `ArrayPool<T>` itself.

## See Also

- [Threading Package](../threading/index.md)

---

© 2026 The Keepers of the CryptoHives


