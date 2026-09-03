# SequenceLease&lt;T&gt; Struct

A payload and the disposable that ends its life, carried together as a single value — so the pair can
travel through a pipeline without the consumer knowing what produced it, and without an allocation.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Syntax

```csharp
public readonly struct SequenceLease<T> : ISequenceOwner<T>, IEquatable<SequenceLease<T>>
```

## Type Parameters

**`T`** — The element type of the sequence.

## Why a Struct

Handing a payload out of the scope that built it needs a handle carrying two things: the
`ReadOnlySequence<T>`, and something to dispose when the buffers are finished with. As a class that
handle costs an allocation — which is awkward for a package whose job is avoiding them.

As a `readonly struct` it costs nothing. Measured against simply holding the producer and borrowing
its sequence, a lease adds **0 bytes**:

| pattern | 1 segment | 4 segments | 16 segments |
|---|---|---|---|
| borrow — producer held in scope | 56 B/op | 224 B/op | 280 B/op |
| **lease — payload escapes the scope** | **56 B/op** | **224 B/op** | **280 B/op** |
| lease boxed to `ISequenceOwner<T>` | 104 B/op | 272 B/op | 328 B/op |

This is the same bargain [`ObjectOwner<T>`](objectowner.md) makes, and it comes with the same two
rules: don't copy it, and don't box it.

## Members

| Member | Type | Description |
|--------|------|-------------|
| `Sequence` | `ReadOnlySequence<T>` | The payload |
| `Length` | `long` | Total number of elements |
| `IsEmpty` | `bool` | Whether the lease holds nothing |
| `Dispose()` | `void` | Disposes the owner, releasing the payload |

### Constructor

```csharp
public SequenceLease(ReadOnlySequence<T> sequence, IDisposable? owner);
```

Usually you do not call this — [`ArrayPoolBufferWriter<T>.LeaseSequence()`](arraypoolbufferwriter.md)
and [`ArrayPoolMemoryStream.LeaseSequence()`](arraypoolmemorystream.md) build one with the producer as
the owner. Construct directly to lease a payload whose lifetime is managed by something else, or pass
`null` for a payload that owns nothing.

## Usage

### Building inside, consuming outside

```csharp
static SequenceLease<byte> BuildPayload()
{
    var writer = ObjectPools.RentBufferWriter<byte>();   // deliberately not `using`
    Serialize(writer);
    return writer.LeaseSequence();                       // the writer rides along
}

using SequenceLease<byte> payload = BuildPayload();
Send(payload.Sequence);
// dispose returns the writer to its pool, which returns the buffers
```

The caller never learns that a pooled `ArrayPoolBufferWriter<byte>` was involved. Swap the producer
for an `ArrayPoolMemoryStream` and nothing at the call site changes.

### Reading through a Stream API

```csharp
using SequenceLease<byte> payload = BuildPayload();
using var reader = new ReadOnlySequenceMemoryStream(payload.Sequence);

await client.UploadAsync(reader);
```

### An empty lease

`default(SequenceLease<T>)` is valid: no payload, no owner, and disposing it does nothing. Useful as a
"nothing to send" return without a null check.

```csharp
SequenceLease<byte> payload = condition ? BuildPayload() : default;

using (payload)
{
    if (!payload.IsEmpty) Send(payload.Sequence);
}
```

## The Two Rules

### Do not copy it

Two copies disposed means the producer is disposed twice.

```csharp
using SequenceLease<byte> lease = BuildPayload();
SequenceLease<byte> copy = lease;   // don't

lease.Dispose();
copy.Dispose();                     // disposes the producer a second time
```

Both producers in this package tolerate a second dispose — the writer's return-to-pool is guarded so
it cannot be pooled twice — so this degrades rather than corrupts. It is still a bug in the caller.

### Do not box it

Casting to `ISequenceOwner<T>` or `IDisposable` allocates, which is the one thing this type exists to
avoid. Measured at **+48 bytes**:

```csharp
ISequenceOwner<byte> boxed = BuildPayload();   // allocates
```

That is a legitimate trade when you genuinely need polymorphism across owner kinds — just make it a
choice rather than an accident.

Storing a lease in a `Channel<SequenceLease<byte>>`, a `List<>`, or an async method's locals is fine:
those hold the struct inline.

## Choosing Between the Two

| API | Cost | The producer | Use when |
|-----|------|--------------|----------|
| `GetReadOnlySequence()` | 0 B | you hold and dispose it yourself | consumption happens inside the producer's scope |
| **`LeaseSequence()`** | **0 B** | rides along; freed with the lease | the payload must leave the scope |

Both cost the same. The difference is only who owns the producer's lifetime: with a borrowed sequence
that is you, with a lease it is the lease. So the moment a payload needs to outlive the block that
built it, take the lease and do **not** dispose the producer yourself.

## Thread Safety

**Not thread-safe**, and single-owner by design. The intended pattern is a short scope with `using`.

## See Also

- [ISequenceOwner&lt;T&gt;](isequenceowner.md)
- [ArrayPoolBufferWriter&lt;T&gt;](arraypoolbufferwriter.md)
- [ArrayPoolMemoryStream](arraypoolmemorystream.md)
- [ObjectOwner&lt;T&gt;](objectowner.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
