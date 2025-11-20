# ArrayPoolBufferWriter&lt;T&gt; Class

A high-performance implementation of `IBufferWriter<T>` that uses pooled memory segments from `ArrayPool<T>`.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` ? **`ArrayPoolBufferWriter<T>`**

## Implements

- `IBufferWriter<T>`
- `IDisposable`

## Syntax

```csharp
public sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable
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
- **IBufferWriter Support**: Works with `System.Text.Json`, Protocol Buffers, and other modern serializers
- **Disposable**: Returns arrays to the pool on disposal
- **Configurable**: Customizable chunk sizes and clearing behavior

## Constructors

| Constructor | Description |
|-------------|-------------|
| `ArrayPoolBufferWriter()` | Creates with default settings (256-byte initial chunks, 64KB max) |
| `ArrayPoolBufferWriter(int defaultChunksize, int maxChunkSize)` | Creates with custom chunk sizes |
| `ArrayPoolBufferWriter(bool clearArray, int defaultChunksize, int maxChunkSize)` | Creates with full customization including array clearing |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `DefaultChunkSize` | `int` (static) | Default initial chunk size (256 bytes) |
| `MaxChunkSize` | `int` (static) | Default maximum chunk size (64KB) |

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
Returns a `ReadOnlySequence<T>` representing all written data. The sequence is valid until the next write operation or disposal.

### Disposal

```csharp
public void Dispose()
```
Returns all pooled arrays to `ArrayPool<T>.Shared` and invalidates the writer.

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

## Comparison with Alternatives

| Approach | Allocations | LOH Pressure | Complexity |
|----------|-------------|--------------|------------|
| `List<T>` + `ToArray()` | High | High for large data | Low |
| `MemoryStream` | Medium | Medium | Low |
| `ArrayPoolBufferWriter<T>` | Low | Low | Medium |
| Manual pooling | Lowest | Lowest | High |

## See Also

- [ArrayPoolMemoryStream](arraypoolmemorystream.md)
- [IBufferWriter&lt;T&gt; Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.ibufferwriter-1)
- [Memory Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
