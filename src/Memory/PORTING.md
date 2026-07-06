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

---

## Verified API surface

```csharp
namespace CryptoHives.Foundation.Memory.Buffers;

sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable {
    ArrayPoolBufferWriter();                                              // default 256 → max 65536 chunks
    ArrayPoolBufferWriter(int defaultChunkSize, int maxChunkSize);
    ArrayPoolBufferWriter(bool clearArray, int defaultChunkSize, int maxChunkSize); // clearArray zeroes on return
    Span<T>   GetSpan(int sizeHint = 0);
    Memory<T> GetMemory(int sizeHint = 0);
    void      Advance(int count);
    ReadOnlySequence<T> GetReadOnlySequence();   // valid only until next write or Dispose()
    void      Dispose();                          // returns pooled arrays
}

sealed class ArrayPoolMemoryStream : MemoryStream { … }           // pooled MemoryStream; Dispose returns segments
sealed class ReadOnlySequenceMemoryStream : MemoryStream {         // read-only Stream over an existing sequence
    ReadOnlySequenceMemoryStream(ReadOnlySequence<byte> sequence);
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

using CryptoHives.Foundation.Memory.Pools;

using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.PooledObject;
// … use sb; do NOT use it after the using scope …
```

---

## Hard rules

1. **Everything here is scope-bound. Always `using`.** `ArrayPoolBufferWriter<T>`,
   `ArrayPoolMemoryStream`, and `ObjectOwner<T>` all return pooled memory on `Dispose`.
   Never let one escape its scope.
2. **The `ReadOnlySequence<T>` from `GetReadOnlySequence()` is only valid until the next
   write or `Dispose()`.** Fully consume or copy it before disposing; never return it to a
   caller that outlives the `using`.
3. **`ObjectOwner<T>` is a `readonly struct` — never cast it to `IDisposable` and never box
   it** (double-return / boxing hazard). Use only `using var`; do not copy it.
4. **Do not use a pooled object after its owner is disposed** — it has been returned and may
   be handed to another caller.
5. For sensitive data, construct `new ArrayPoolBufferWriter<byte>(clearArray: true, …)` so
   buffers are zeroed on return.
6. The pooled `PooledObject` accessor is named **`PooledObject`** (not `Object`).

---

## Porting procedure

1. Add `CryptoHives.Foundation.Memory`.
2. Swap buffer/stream/pool patterns per the table; ensure every new type is `using`-scoped
   and no pooled buffer or `ReadOnlySequence` escapes its scope.
3. Build clean; run existing tests.
4. Report: `file:line` → old type → new type.

Full cross-package porting guide: <https://cryptohives.github.io/Foundation/porting-to-cryptohives.html>
