# ArrayPoolBufferWriterProvider&lt;T&gt; Class

An immutable set of [`ArrayPoolBufferWriter<T>`](arraypoolbufferwriter.md) settings that hands out
writers already configured with them.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Pools
```

## Inheritance

`Object` → **`ArrayPoolBufferWriterProvider<T>`**

## Syntax

```csharp
public sealed class ArrayPoolBufferWriterProvider<T>
```

## Type Parameters

**`T`** — The element type the writers accept.

## Why It Exists

A writer's `clearArray` and chunk sizes used to be fixed at construction, which meant **one pool per
configuration**. That is the wrong axis to shard on: pools multiply with use cases, each with its own
miss rate, defeating the point of pooling.

So settings are applied when a writer is **rented**, not when it is constructed. Pooled instances are
interchangeable, a single pool per `T` serves the whole application, and configuration lives here —
one provider per use case, declared once.

Two objects, two lifetimes: the provider is long-lived and readonly, the writer is short-lived and
reconfigured on its way out of the pool.

## Constructor

```csharp
public ArrayPoolBufferWriterProvider(
    bool clearArray = false,
    int defaultChunkBytes = ArrayPoolBufferWriter<T>.DefaultChunkBytes,
    int maxChunkBytes = ArrayPoolBufferWriter<T>.MaxChunkBytes,
    ObjectPool<ArrayPoolBufferWriter<T>>? pool = null);
```

| Parameter | Description |
|-----------|-------------|
| `clearArray` | Whether rented writers zero each buffer as it returns to the array pool |
| `defaultChunkBytes` | Size, in **bytes**, of the first chunk a rented writer takes |
| `maxChunkBytes` | Ceiling, in **bytes**, that the chunk size ramps up to. A value **at or below** `defaultChunkBytes` disables the ramp, pinning every chunk to that size. |

Both budgets are **bytes, not elements**, so a profile means the same thing whatever `T` is — see
[the writer's explanation](arraypoolbufferwriter.md) for why that keeps a chunk off the large object
heap.
| `pool` | The pool to draw from. Defaults to the shared pool for `T`. |

Throws `ArgumentOutOfRangeException` when `defaultChunkBytes` is less than one.

## Methods

```csharp
public ArrayPoolBufferWriter<T> Rent();
```

Returns a writer in its just-constructed state, carrying this provider's settings and attached to the
pool. Dispose it as usual and it returns itself.

## Usage

### One profile per use case

```csharp
static readonly ArrayPoolBufferWriterProvider<byte> JsonWriters   = new(maxChunkBytes: 1 << 20);
static readonly ArrayPoolBufferWriterProvider<byte> SecretWriters = new(clearArray: true);
static readonly ArrayPoolBufferWriterProvider<byte> SmallMessages = new(defaultChunkBytes: 64, maxChunkBytes: 512);

using var writer = JsonWriters.Rent();
```

All three draw from the same pool, so adding a profile costs no extra instances.

### Sensitive payloads

```csharp
static readonly ArrayPoolBufferWriterProvider<byte> SecretWriters = new(clearArray: true);

using (var writer = SecretWriters.Rent())
{
    WriteKeyMaterial(writer);
}   // buffers are zeroed before they reach the array pool
```

The zeroing is reliable because of *when* configuration is applied. A writer is reset — and therefore
clears its buffers, if that is what its renter asked for — while the outgoing settings are still in
force. Only afterwards does the next renter's configuration land:

```
Dispose → TryReset()  ← the outgoing renter's clearArray still applies
        → pool.Return
Rent    → pool.Get() → configure with the new settings
```

That is also why the settings are not publicly settable: a caller who could flip `clearArray` to
`false` after writing secrets would send those bytes back to the pool unzeroed.

### A fixed chunk size

A maximum at or below the default is a valid way to say *never grow*, not a mistake:

```csharp
// Every chunk is exactly 512 bytes' worth of elements
static readonly ArrayPoolBufferWriterProvider<byte> Fixed = new(defaultChunkBytes: 512, maxChunkBytes: 0);
```

### An isolated pool

Most callers should not do this — sharing the pool is what keeps the instance count down — but a use
case can be separated deliberately:

```csharp
ObjectPool<ArrayPoolBufferWriter<byte>> isolated = PoolFactory.CreateBufferWriterPool<byte>(maximumRetained: 8);
static readonly ArrayPoolBufferWriterProvider<byte> Isolated = new(pool: isolated);
```

## Thread Safety

A provider is **immutable and thread-safe**; share one freely, typically as a `static readonly` field.

The writers it hands out are **not** thread-safe and belong to one caller until disposed.

⚠️ **Do not use a writer after disposing it.** A returned instance does not throw
`ObjectDisposedException` — it silently becomes whatever the next renter is doing. This is the same
contract as `ArrayPool<T>` itself.

## See Also

- [ArrayPoolBufferWriter&lt;T&gt;](arraypoolbufferwriter.md)
- [ObjectPools](objectpools.md)
- [PoolFactory](poolfactory.md)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
