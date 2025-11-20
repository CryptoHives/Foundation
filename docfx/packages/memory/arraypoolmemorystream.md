# ArrayPoolMemoryStream Class

A memory-backed stream implementation that rents fixed-size buffers from `ArrayPool<byte>.Shared` and stores data in multiple segments.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` ? `MarshalByRefObject` ? `Stream` ? `MemoryStream` ? **`ArrayPoolMemoryStream`**

## Syntax

```csharp
public sealed class ArrayPoolMemoryStream : MemoryStream
```

## Overview

`ArrayPoolMemoryStream` is designed for high-throughput and temporary in-memory I/O scenarios where reducing allocations and Large Object Heap (LOH) churn matters. Instead of continuously resizing a single contiguous array like the standard `MemoryStream`, it rents fixed-size buffers from the shared array pool and chains them together.

## Benefits

- **Lower allocation churn**: Rents buffers from `ArrayPool<byte>.Shared` instead of allocating new arrays
- **Fewer large allocations**: Reuses rented buffers to avoid repeated large allocations and LOH churn
- **No resize-copy on growth**: Appends new rented segments instead of reallocating and copying
- **Zero-copy multi-segment access**: `GetReadOnlySequence()` exposes internal segments as `ReadOnlySequence<byte>`
- **Span APIs**: Span-based read/write paths reduce intermediate allocations

## Constructors

| Constructor | Description |
|-------------|-------------|
| `ArrayPoolMemoryStream()` | Creates a writable stream with default buffer size (4096 bytes) |
| `ArrayPoolMemoryStream(int bufferSize)` | Creates a writable stream with specified buffer size |
| `ArrayPoolMemoryStream(int bufferListSize, int bufferSize)` | Creates a writable stream with custom buffer list and buffer sizes |
| `ArrayPoolMemoryStream(int bufferListSize, int bufferSize, int start, int count)` | Creates a writable stream with full customization |
| `ArrayPoolMemoryStream(IEnumerable<ArraySegment<byte>> buffers)` | Creates a read-only stream from existing buffer segments |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Length` | `long` | Gets the total length of data in all segments |
| `Position` | `long` | Gets or sets the current position |
| `CanRead` | `bool` | Always returns `true` |
| `CanWrite` | `bool` | Returns `true` for writable streams, `false` for read-only |
| `CanSeek` | `bool` | Always returns `true` |

## Methods

### Read Methods

```csharp
public override int Read(byte[] buffer, int offset, int count)
public int Read(Span<byte> buffer) // .NET Standard 2.1+
public override int ReadByte()
```

### Write Methods

```csharp
public override void Write(byte[] buffer, int offset, int count)
public void Write(ReadOnlySpan<byte> buffer) // .NET Standard 2.1+
public override void WriteByte(byte value)
```

### Seeking

```csharp
public override long Seek(long offset, SeekOrigin loc)
```

### Zero-Copy Access

```csharp
public ReadOnlySequence<byte> GetReadOnlySequence()
```

Returns a `ReadOnlySequence<byte>` representing all data in the stream. The sequence is valid until the next write operation or disposal.

### Other Methods

```csharp
public override void Flush() // No-op
public override byte[] ToArray() // Copies all data to a new array
protected override void Dispose(bool disposing) // Returns buffers to pool
```

## Usage Examples

### Basic Write and Read

```csharp
using CryptoHives.Foundation.Memory.Buffers;
using System;
using System.Text;

// Create a writable stream
using var stream = new ArrayPoolMemoryStream();

// Write data
byte[] data = Encoding.UTF8.GetBytes("Hello, World!");
stream.Write(data, 0, data.Length);

// Reset position
stream.Position = 0;

// Read data back
byte[] buffer = new byte[data.Length];
int bytesRead = stream.Read(buffer, 0, buffer.Length);

Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
// Output: Hello, World!
```

### Using Span APIs (.NET Standard 2.1+)

```csharp
using var stream = new ArrayPoolMemoryStream();

// Write using Span
ReadOnlySpan<byte> data = stackalloc byte[] { 1, 2, 3, 4, 5 };
stream.Write(data);

// Read using Span
stream.Position = 0;
Span<byte> buffer = stackalloc byte[5];
int bytesRead = stream.Read(buffer);
```

### Zero-Copy Access with ReadOnlySequence

```csharp
using var stream = new ArrayPoolMemoryStream();

// Write data
await WriteDataAsync(stream);

// Get zero-copy sequence
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();

// Process without copying
foreach (ReadOnlyMemory<byte> segment in sequence)
{
    ProcessSegment(segment.Span);
}
```

### Async Write and Read

```csharp
using var stream = new ArrayPoolMemoryStream();

// Async write
byte[] data = GetData();
await stream.WriteAsync(data, 0, data.Length, cancellationToken);

// Async read
stream.Position = 0;
byte[] buffer = new byte[1024];
int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
```

### Custom Buffer Sizing

```csharp
// Create stream with 8KB buffers
using var stream = new ArrayPoolMemoryStream(bufferSize: 8192);

// Create stream with custom buffer list capacity
using var stream2 = new ArrayPoolMemoryStream(
    bufferListSize: 16,  // Initial capacity for buffer list
    bufferSize: 4096     // Size of each buffer
);
```

### Read-Only Stream from Existing Buffers

```csharp
var buffers = new List<ArraySegment<byte>>
{
    new ArraySegment<byte>(buffer1),
    new ArraySegment<byte>(buffer2)
};

// Create read-only stream (buffers NOT returned to pool on dispose)
using var stream = new ArrayPoolMemoryStream(buffers);

// Read data
byte[] data = stream.ToArray();
```

### Integration with Serialization

```csharp
using var stream = new ArrayPoolMemoryStream();

// Serialize object
JsonSerializer.Serialize(stream, myObject);

// Get the data as ReadOnlySequence
ReadOnlySequence<byte> jsonBytes = stream.GetReadOnlySequence();

// Send over network without copying
await SendAsync(jsonBytes, cancellationToken);
```

### Copying to Another Stream

```csharp
using var source = new ArrayPoolMemoryStream();
await WriteDataAsync(source);

source.Position = 0;

using var destination = new FileStream("output.dat", FileMode.Create);
await source.CopyToAsync(destination);
```

## Performance Considerations

### When to Use

- High-throughput transformation pipelines with many temporary streams and unknown, varying final sizes
- Large data sets that might trigger LOH allocations
- When you need zero-copy access to the data
- Building tranformation pipelines with lifetime managed `ReadOnlySequence<byte>`

### When NOT to Use

- Very small buffers (< 1KB) - overhead might outweigh benefits
- Long-lived streams - pooled buffers are meant for temporary use
- When you need the data as a contiguous array anyway

### Buffer Size Guidelines

- **Small data (< 4KB)**: Use default 4096-byte buffers
- **Medium data (4KB - 64KB)**: Use 8192 or 16384-byte buffers
- **Large data (> 64KB)**: Use 32768 or 65536-byte buffers

## Thread Safety

⚠️ **Not thread-safe**. External synchronization required for concurrent access.

## Disposal

Always dispose `ArrayPoolMemoryStream` to return rented buffers to the pool:

```csharp
using var stream = new ArrayPoolMemoryStream();

// Use stream...
stream.Write(data);

// Process final sequence
var sequence = stream.GetReadOnlySequence();

// Automatically disposed and buffers returned
```

## See Also

- [ArrayPoolBufferWriter&lt;T&gt;](arraypoolbufferwriter.md)
- [ReadOnlySequenceMemoryStream](readonlysequencememorystream.md)
- [Memory Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
