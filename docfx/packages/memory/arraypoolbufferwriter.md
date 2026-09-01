# ArrayPoolBufferWriter&lt;T&gt; Class

A high-performance implementation of `IBufferWriter<T>` that uses pooled memory segments from `ArrayPool<T>`.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` → **`ArrayPoolBufferWriter<T>`**

## Implements

- `IBufferWriter<T>`
- `IDisposable`
- `IResettable`

## Syntax

```csharp
public sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable, IResettable
```

## Type Parameters

**`T`** - The type of elements in the buffer

## Overview

`ArrayPoolBufferWriter<T>` provides an efficient way to build sequences of data using pooled memory segments. It implements `IBufferWriter<T>`, making it compatible with serializers and other APIs that write to buffers. The writer grows by allocating progressively larger chunks from the array pool, avoiding continuous reallocations.

## Benefits

- **Pooled Memory**: Uses `ArrayPool<T>.Shared` to minimize allocations
- **ArrayPool Backed**: Efficient recycling of arrays for high-performance scenarios
- **Buffer Clear Option**: Optionally clears arrays before returning to pool for privacy
- **Progressive Growth**: Chunks grow exponentially up to a maximum size
- **Zero-Copy Access**: `GetReadOnlySequence()` provides direct access without copying
- **Escapes the Scope**: `LeaseSequence()` hands the payload on with its own lifetime, at no cost
- **IBufferWriter Support**: Works with `System.Text.Json`, Protocol Buffers, and other modern serializers
- **Disposable**: Returns arrays to the pool on disposal
- **Poolable**: The writer object itself can be recycled, not just its buffers
- **Configurable**: Customizable chunk sizes and clearing behavior

## Constructors

| Constructor | Description |
|-------------|-------------|
| `ArrayPoolBufferWriter()` | Creates with default settings (256-element initial chunks, 64K max) |
| `ArrayPoolBufferWriter(int defaultChunksize, int maxChunkSize)` | Creates with custom chunk sizes |
| `ArrayPoolBufferWriter(bool clearArray, int defaultChunksize, int maxChunkSize)` | Creates with full customization including array clearing |

All three throw `ArgumentOutOfRangeException` when `defaultChunksize` is less than one.

To rent a pooled writer instead of constructing one, see
[`ArrayPoolBufferWriterProvider<T>`](arraypoolbufferwriterprovider.md) and
[`ObjectPools.RentBufferWriter<T>()`](objectpools.md).

## Constants

| Constant | Value | Description |
|----------|-------|-------------|
| `DefaultChunkSize` | 256 | Default initial chunk size |
| `MaxChunkSize` | 65536 | Default maximum chunk size |

## Methods

### IBufferWriter Implementation

```csharp
public void Advance(int count)
```
Advances the writer by the specified number of elements that were written to the span/memory obtained from `GetSpan`/`GetMemory`.

```csharp
public Memory<T> GetMemory(int sizeHint = 0)
```
Returns a `Memory<T>` to write to. The memory is at least `sizeHint` elements large.

```csharp
public Span<T> GetSpan(int sizeHint = 0)
```
Returns a `Span<T>` to write to. The span is at least `sizeHint` elements large.

### Sequence Access

```csharp
public ReadOnlySequence<T> GetReadOnlySequence()
```
Returns a `ReadOnlySequence<T>` representing all written data. The sequence **borrows** the writer's buffers: it is valid only until the next write operation or disposal.

```csharp
public SequenceLease<T> LeaseSequence()
```
Pairs the written data with this writer as a single disposable value, so the payload can leave the scope that produced it. Disposing the [`SequenceLease<T>`](sequencelease.md) disposes the writer, which returns it to its pool if it was rented, and its buffers to the array pool.

**This allocates nothing** — the lease is a struct and the sequence is the one the writer already holds. It is the usual way to hand a payload to a caller.

```csharp
static SequenceLease<byte> BuildPayload()
{
    var writer = ObjectPools.RentBufferWriter<byte>();   // deliberately not `using`
    Serialize(writer);
    return writer.LeaseSequence();
}

using SequenceLease<byte> payload = BuildPayload();
Send(payload.Sequence);
```

### Reset and Disposal

```csharp
public bool TryReset()
```
Restores the writer to its just-constructed state, returning every rented array to `ArrayPool<T>.Shared`. Returns `false` if the writer has been disposed and must be discarded. Implements `IResettable` from `Microsoft.Extensions.ObjectPool`, so a `DefaultObjectPool<T>` recycles instances without a custom policy. Idempotent.

```csharp
public void Dispose()
```
For a writer rented from a pool, resets the instance and returns it to that pool. Otherwise returns all pooled arrays to `ArrayPool<T>.Shared` and invalidates the writer.

## Usage Examples

### Basic Usage

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();

// Get span and write
Span<byte> span = writer.GetSpan(100);
for (int i = 0; i < 100; i++)
{
  span[i] = (byte)i;
}
writer.Advance(100);

// Get the result
ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();
```

### With JSON Serialization

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();
using var jsonWriter = new Utf8JsonWriter(writer);

jsonWriter.WriteStartObject();
jsonWriter.WriteString("name"u8, "value"u8);
jsonWriter.WriteEndObject();
await jsonWriter.FlushAsync();

ReadOnlySequence<byte> jsonBytes = writer.GetReadOnlySequence();
mqttClient.Publish("topic", jsonBytes);
```

### Building Protocol Messages

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();

// Write header
Span<byte> header = writer.GetSpan(4);
BinaryPrimitives.WriteInt32LittleEndian(header, messageId);
writer.Advance(4);

// Write payload
payload.CopyTo(writer.GetSpan(payload.Length));
writer.Advance(payload.Length);

ReadOnlySequence<byte> message = writer.GetReadOnlySequence();
```

## Performance Characteristics

- **Memory Allocation**: array allocations as chunks overflow, but size grows exponentially to upper limit
- **Write Operations**: O(1) amortized for sequential writes
- **Sequence Access**: O(n) to get `ReadOnlySequence<T>`
- **Disposal**: O(n) (returns arrays to pool)

(where n is number of memory chunks)

## Configuration

### Chunk Growth Strategy

The writer starts with `defaultChunksize` and doubles the chunk size on each allocation until reaching `maxChunkSize`:

```csharp
// Start with 1KB, grow to max 16KB
using var writer = new ArrayPoolBufferWriter<byte>(
    defaultChunksize: 1024,
    maxChunkSize: 16384
);
```

A `maxChunkSize` **at or below** `defaultChunksize` is a valid way to say *never grow* rather than a
mistake — the ramp is skipped entirely and every chunk stays at the default size:

```csharp
// Every chunk is exactly 512 elements
using var writer = new ArrayPoolBufferWriter<byte>(
    defaultChunksize: 512,
    maxChunkSize: 0
);
```

### Array Clearing

For sensitive data, enable array clearing before returning to pool:

```csharp
using var writer = new ArrayPoolBufferWriter<byte>(
    clearArray: true,
    defaultChunksize: 4096,
    maxChunkSize: 65536
);
```

## Thread Safety

⚠️ **Not thread-safe**. External synchronization required for concurrent access.

## Best Practices

### DO: Dispose Properly

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();
// Use writer...
// Automatically disposed and arrays returned
```

### DO: Provide Size Hints

```csharp
// If you know the size, provide a hint
Span<byte> span = writer.GetSpan(sizeHint: 1024);
```

### DON'T: Use ReadOnlySequence After More Writes

```csharp
var sequence1 = writer.GetReadOnlySequence();
writer.GetSpan(100); // This invalidates sequence1!
```

### DO: Get Sequence Once at the End

```csharp
// Write all data
WriteData(writer);

// Get sequence once at the end
ReadOnlySequence<byte> finalSequence = writer.GetReadOnlySequence();
```

### DO: Lease When the Payload Must Leave the Scope

```csharp
static SequenceLease<byte> BuildPayload()
{
    var writer = ObjectPools.RentBufferWriter<byte>();
    Serialize(writer);
    return writer.LeaseSequence();   // 0 bytes; the writer rides along
}
```

### Choosing Between the Two

| API | Cost | The producer | Use when |
|-----|------|--------------|----------|
| `GetReadOnlySequence()` | 0 B | you hold and dispose it yourself | consumption is inside the writer's scope |
| **`LeaseSequence()`** | **0 B** | rides along; freed with the lease | the payload leaves the scope |

Note the writer must **not** be disposed in the scope that leases it — the lease owns it now, and
disposing it there would release the very buffers the payload is made of.

### DON'T: Touch a Pooled Writer After Disposing It

```csharp
using var writer = ObjectPools.RentBufferWriter<byte>();
// ...
writer.Dispose();
writer.GetSpan(16);   // No exception — you are now writing into someone else's buffer
```

A returned instance does not throw `ObjectDisposedException`; it silently becomes whatever the next
renter is doing. This is the same contract as `ArrayPool<T>` itself.

## Comparison with Alternatives

| Approach | Allocations | LOH Pressure | Complexity |
|----------|-------------|--------------|------------|
| `List<T>` + `ToArray()` | High | High for large data | Low |
| `MemoryStream` | Medium | Medium | Low |
| `ArrayPoolBufferWriter<T>` | Low | Low | Medium |
| Manual pooling | Lowest | Lowest | High |

## Pooling the Writer Itself

The buffers are pooled by default; the writer object is not, unless you rent one. Declare a profile
per use case and every one of them draws from the same pool:

```csharp
static readonly ArrayPoolBufferWriterProvider<byte> JsonWriters = new(maxChunkSize: 1 << 20);

using var writer = JsonWriters.Rent();
// ... write ...
// Disposing returns the writer to the pool, reset and ready for the next renter
```

For the default settings, [`ObjectPools.RentBufferWriter<T>()`](objectpools.md) is the shorthand.

See [`ArrayPoolBufferWriterProvider<T>`](arraypoolbufferwriterprovider.md) for why configuration is
applied at rent time rather than at construction, and what that means for `clearArray`.

## See Also

- [ArrayPoolBufferWriterProvider&lt;T&gt;](arraypoolbufferwriterprovider.md)
- [ISequenceOwner&lt;T&gt;](isequenceowner.md)
- [ArrayPoolMemoryStream](arraypoolmemorystream.md)
- [ObjectPools](objectpools.md)
- [IBufferWriter&lt;T&gt; Documentation](https://learn.microsoft.com/dotnet/api/system.buffers.ibufferwriter-1)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
