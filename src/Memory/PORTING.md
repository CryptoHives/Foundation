# CryptoHives.Foundation.Memory — Guide for LLM Agents

Machine-readable usage + porting guide for coding assistants. All APIs below are verified
against the shipped source. Do not invent members. Human-oriented docs live in `README.md`.

- **Package:** `CryptoHives.Foundation.Memory`
- **Namespaces:** `CryptoHives.Foundation.Memory.Buffers`, `CryptoHives.Foundation.Memory.Pools`
- **What it is:** `ArrayPool<T>`-backed buffer/stream types and RAII object-pool helpers that
  keep allocations and LOH/GC pressure out of high-throughput and crypto pipelines.

---

## When to use / what to replace

| Existing code | Replace with |
|---|---|
| Hand-rolled growable `byte[]`, or `MemoryStream` used only to accumulate then read back | `ArrayPoolBufferWriter<byte>` → `GetReadOnlySequence()` |
| `ArrayBufferWriter<T>` where pooled backing is wanted | `ArrayPoolBufferWriter<T>` |
| `new MemoryStream()` as a scratch/accumulation buffer | `ArrayPoolMemoryStream` (drop-in `MemoryStream` subclass) |
| Copying a `ReadOnlySequence<byte>` into `byte[]` just to `new MemoryStream(bytes)` | `new ReadOnlySequenceMemoryStream(sequence)` |
| Manual `ObjectPool<T>.Get()`/`Return()` pairs; `StringBuilder` churn | `ObjectOwner<T>` / `ObjectPools.GetStringBuilder()` |
| `ArrayPool<T>.Shared.Rent(n)` with manual return; caller owns a fixed-size `T[]` slice | `PooledSegment<T>.Rent(n)` — same pool, no manual return |
| `new T[n]` handed to a method that needs to signal "no data" via `null` or length 0 | `AllocatedSegment<T>.Create(buffer)` / `EmptySegment<T>.Instance` |
| `IMemoryOwner<T>` patterns where `ArraySegment<T>` is preferred over `Memory<T>` | `ISegmentOwner<T>` |

---

## Verified API surface

```csharp
namespace CryptoHives.Foundation.Memory.Buffers;

sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable, IResettable {
    const int DefaultChunkBytes = 256;            // budgets are BYTES, divided by sizeof(T)
    const int MaxChunkBytes     = 64 * 1024;      // ceiling that keeps a chunk off the LOH
    ArrayPoolBufferWriter();                                                     // 256 B → 64 KiB, doubling
    ArrayPoolBufferWriter(int defaultChunkBytes, int maxChunkBytes);
    ArrayPoolBufferWriter(bool clearArray, int defaultChunkBytes, int maxChunkBytes); // zeroes on return
    Span<T>   GetSpan(int sizeHint = 0);
    Memory<T> GetMemory(int sizeHint = 0);
    void      Advance(int count);
    ReadOnlySequence<T> GetReadOnlySequence();   // borrowed: valid only until next write or Dispose()
    SequenceLease<T>    LeaseSequence();         // lets the payload outlive this scope, 0 alloc
    bool      TryReset();                         // IResettable, for pooling
    void      Dispose();                          // returns pooled arrays, or self to its pool
}

sealed class ArrayPoolMemoryStream : MemoryStream {                // pooled; Dispose returns segments
    ArrayPoolMemoryStream(bool clearArray = false, …);             // clearArray on every owning ctor
    ReadOnlySequence<byte> GetReadOnlySequence();                  // borrowed
    SequenceLease<byte>    LeaseSequence();                        // escapes the scope, 0 alloc
    // GetBuffer() throws and TryGetBuffer() returns false: the payload spans several segments.
}
sealed class ReadOnlySequenceMemoryStream : MemoryStream {         // read-only Stream over an existing sequence
    ReadOnlySequenceMemoryStream(ReadOnlySequence<byte> sequence);
}

// ── Segment ownership ────────────────────────────────────────────────────────
// ISegmentOwner<T> mirrors IMemoryOwner<T> but exposes ArraySegment<T> instead of Memory<T>.
// Three implementations cover all ownership strategies; choose by memory source.

interface ISegmentOwner<T> : IDisposable {
    ArraySegment<T> Segment { get; }
    T    this[int i] { get; set; }               // element access relative to Segment.Offset
    bool TrySetSegment(int offset, int length);   // narrows/repositions the view; false if out-of-range
}

sealed class PooledSegment<T> : ISegmentOwner<T> {
    // Rents from ArrayPool<T>.Shared; Segment.Count == minimumLength; array may be larger.
    static ISegmentOwner<T> Rent(int minimumLength);
    // Dispose returns the rented array to the pool and resets Segment to default.
}

sealed class AllocatedSegment<T> : ISegmentOwner<T> {
    // Wraps an existing GC-managed T[]; no pool involved.
    // Segment.Array is the same reference as the passed-in buffer (no copy).
    static ISegmentOwner<T> Create(T[] buffer);
    // Dispose clears Segment to default; the underlying array is unaffected.
}

sealed class EmptySegment<T> : ISegmentOwner<T> {
    // Null-object singleton. Segment.Count == 0. TrySetSegment always returns false.
    // Dispose and indexer access are no-ops / throw ArgumentOutOfRangeException.
    static ISegmentOwner<T> Instance { get; }
}

namespace CryptoHives.Foundation.Memory.Pools;

readonly struct ObjectOwner<T> : IDisposable where T : class {
    ObjectOwner(ObjectPool<T> pool);
    T PooledObject { get; }       // NOTE: the member is PooledObject, not Object
    void Dispose();               // returns the object to the pool
}

static class ObjectPools {
    static ObjectOwner<StringBuilder> GetStringBuilder();
}
```

---

## Canonical patterns

```csharp
using CryptoHives.Foundation.Memory.Buffers;

using var writer = new ArrayPoolBufferWriter<byte>();
Span<byte> span = writer.GetSpan(sizeHint);
// … write into span …
writer.Advance(bytesWritten);
ReadOnlySequence<byte> seq = writer.GetReadOnlySequence();   // consume before the using scope ends
Consume(seq);

// ── PooledSegment<T> — ArrayPool-backed, fixed-size ──────────────────────────
using ISegmentOwner<byte> seg = PooledSegment<byte>.Rent(256);
Span<byte> data = seg.Segment.AsSpan();   // Segment.Count == 256
FillData(data);
// narrow the view without reallocating:
if (seg.TrySetSegment(offset: 16, length: 64))
    Send(seg.Segment.AsSpan());
// array returned to pool when seg is disposed

// ── AllocatedSegment<T> — wrap an existing GC-managed array ─────────────────
byte[] existing = File.ReadAllBytes(path);
using ISegmentOwner<byte> alloc = AllocatedSegment<byte>.Create(existing);
Process(alloc);
// only the wrapper is cleared on Dispose; array itself is GC-eligible as usual

// ── EmptySegment<T> — null-object sentinel ───────────────────────────────────
void Process(ISegmentOwner<byte> owner)
{
    if (owner.Segment.Count == 0) return;   // handles EmptySegment gracefully
    Span<byte> span = owner.Segment.AsSpan();
    // …
}
ISegmentOwner<byte> none = EmptySegment<byte>.Instance;   // never null, never allocates
Process(none);

using CryptoHives.Foundation.Memory.Pools;

using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.PooledObject;
// … use sb; do NOT use it after the using scope …
```

---

## Hard rules

1. **Everything here is scope-bound. Always `using`.** `ArrayPoolBufferWriter<T>`,
   `ArrayPoolMemoryStream`, `PooledSegment<T>`, and `ObjectOwner<T>` all return pooled
   memory on `Dispose`. Never let one escape its scope.
2. **The `ReadOnlySequence<T>` from `GetReadOnlySequence()` is only valid until the next
   write or `Dispose()`.** Fully consume or copy it before disposing. When the payload must
   outlive the scope, do not copy it — hand back `LeaseSequence()`, a `readonly struct`
   carrying the sequence plus the producer that owns it, at no cost over borrowing. Do not
   copy the lease or cast it to `ISequenceOwner<T>`/`IDisposable`; both boxing and copying
   defeat it, exactly as with `ObjectOwner<T>`.
3. **`ObjectOwner<T>` is a `readonly struct` — never cast it to `IDisposable` and never box
   it** (double-return / boxing hazard). Use only `using var`; do not copy it.
4. **Do not use a pooled object after its owner is disposed** — it has been returned and may
   be handed to another caller. This applies equally to `PooledSegment<T>` (array is back in
   the pool) and `ObjectOwner<T>` (object is back in the pool).
5. For sensitive data, pass `clearArray: true` — on the writer, on any owning
   `ArrayPoolMemoryStream` constructor, or to `PooledSegment<T>.Rent(length, clearArray: true)`
   — so buffers are zeroed on their way back to the pool. Debug builds zero every returned
   `PooledSegment<T>` buffer regardless, but that is a use-after-return diagnostic, **not** a
   security control: never verify a wipe in Debug and ship a Release build that never asked
   for one.
6. The `ObjectOwner<T>` accessor is named **`PooledObject`** (not `Object`).
7. **`TrySetSegment` does not reallocate.** It only repositions the view within the existing
   backing array. If the requested range does not fit (`offset + length > array.Length`),
   it returns `false` and the segment is unchanged. Never use it as a resize operation.
8. **`EmptySegment<T>.Instance` is a singleton — never `Dispose` it** (the call is a no-op
   by design, but relying on that would indicate confusion about ownership). Treat it as an
   immutable sentinel value.

---

## Porting procedure

1. Add `CryptoHives.Foundation.Memory`.
2. Swap buffer/stream/pool patterns per the table; ensure every new type is `using`-scoped
   and no pooled buffer or `ReadOnlySequence` escapes its scope.
3. Build clean; run existing tests.
4. Report: `file:line` → old type → new type.

Full cross-package porting guide: <https://cryptohives.github.io/Foundation/porting-to-cryptohives.html>
