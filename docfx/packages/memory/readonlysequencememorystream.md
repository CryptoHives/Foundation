# ReadOnlySequenceMemoryStream Class

A read-only stream wrapper around `ReadOnlySequence<byte>` for zero-copy stream operations.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Buffers
```

## Inheritance

`Object` ? `MarshalByRefObject` ? `Stream` ? `MemoryStream` ? **`ReadOnlySequenceMemoryStream`**

## Syntax

```csharp
public sealed class ReadOnlySequenceMemoryStream : MemoryStream
```

## Overview

`ReadOnlySequenceMemoryStream` provides a `Stream` interface over a `ReadOnlySequence<byte>`, enabling zero-copy integration with APIs that require streams for reading. This is particularly useful when you have data in a `ReadOnlySequence<byte>` (from `ArrayPoolMemoryStream`, `ArrayPoolBufferWriter<T>`, or `PipeReader`) and need to pass it to deserializers, compression libraries, or other stream-based APIs.

## Benefits

- **Zero-Copy**: No data copying when wrapping a `ReadOnlySequence<byte>`
- **Stream Compatibility**: Works with any API expecting a `Stream`
- **Efficient Seeking**: Supports seeking within the sequence
- **Multi-Segment Support**: Handles sequences spanning multiple memory segments
- **Read-Only Safety**: Prevents accidental modifications

## Constructors

| Constructor | Description |
|-------------|-------------|
| `ReadOnlySequenceMemoryStream(ReadOnlySequence<byte> sequence)` | Creates a read-only stream from the given sequence |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Length` | `long` | Gets the total length of the sequence |
| `Position` | `long` | Gets or sets the current position |
| `CanRead` | `bool` | Always returns `true` |
| `CanWrite` | `bool` | Always returns `false` |
| `CanSeek` | `bool` | Always returns `true` |

## Methods

### Reading

```csharp
public override int Read(byte[] buffer, int offset, int count)
```
Reads bytes from the sequence into the buffer.

```csharp
public int Read(Span<byte> buffer) // .NET Standard 2.1+
```
Reads bytes from the sequence into the span.

```csharp
public override int ReadByte()
```
Reads a single byte from the sequence.

### Seeking

```csharp
public override long Seek(long offset, SeekOrigin loc)
```
Sets the position within the sequence.

### Conversion

```csharp
public override byte[] ToArray()
```
Copies the entire sequence to a new array. **Note**: This allocates a new array.

### Other Methods

```csharp
public override void Flush() // No-op for read-only stream
```

## Usage Examples

### Basic Reading

```csharp
ReadOnlySequence<byte> sequence = GetDataSequence();
using var stream = new ReadOnlySequenceMemoryStream(sequence);

byte[] buffer = new byte[1024];
int bytesRead = stream.Read(buffer, 0, buffer.Length);
```

### JSON Deserialization

```csharp
using System.Text.Json;

ReadOnlySequence<byte> jsonBytes = GetJsonData();
using var stream = new ReadOnlySequenceMemoryStream(jsonBytes);

MyObject obj = await JsonSerializer.DeserializeAsync<MyObject>(stream);
```

### Decompression

```csharp
using System.IO.Compression;

ReadOnlySequence<byte> compressedData = GetCompressedData();
using var compressedStream = new ReadOnlySequenceMemoryStream(compressedData);
using var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
using var decompressedStream = new MemoryStream();

await gzipStream.CopyToAsync(decompressedStream);
byte[] decompressed = decompressedStream.ToArray();
```

### Reading with Span (.NET Standard 2.1+)

```csharp
using var stream = new ReadOnlySequenceMemoryStream(sequence);

Span<byte> buffer = stackalloc byte[256];
int bytesRead = stream.Read(buffer);

ProcessData(buffer.Slice(0, bytesRead));
```

### Seeking

```csharp
using var stream = new ReadOnlySequenceMemoryStream(sequence);

// Seek to offset 100
stream.Seek(100, SeekOrigin.Begin);

// Seek forward 50 bytes
stream.Seek(50, SeekOrigin.Current);

// Seek to 100 bytes before end
stream.Seek(-100, SeekOrigin.End);
```

## Integration Examples

### With System.IO.Pipelines

```csharp
public async Task ProcessPipelineDataAsync(PipeReader reader)
{
    ReadResult result = await reader.ReadAsync();
    ReadOnlySequence<byte> buffer = result.Buffer;

    using (var stream = new ReadOnlySequenceMemoryStream(buffer))
    {
        var data = await JsonSerializer.DeserializeAsync<MyData>(stream);
        ProcessData(data);
 }
    
  reader.AdvanceTo(buffer.End);
}
```

### With Protocol Buffers

```csharp
using Google.Protobuf;

ReadOnlySequence<byte> protobufData = GetProtobufData();
using var stream = new ReadOnlySequenceMemoryStream(protobufData);

MyMessage message = MyMessage.Parser.ParseFrom(stream);
```

### With Image Processing

```csharp
using System.Drawing;

ReadOnlySequence<byte> imageData = GetImageData();
using var stream = new ReadOnlySequenceMemoryStream(imageData);

using var image = Image.FromStream(stream);
// Process image...
```

## Performance Characteristics

- **Construction**: O(1) - just stores reference to sequence
- **Reading**: O(n) where n is bytes read, with segment boundary crossing overhead
- **Seeking**: O(m) where m is number of segments to seek position
- **Memory**: O(1) - no additional allocations (except for `ToArray()`)

## Thread Safety

?? **Not thread-safe**. External synchronization required for concurrent access.

## Best Practices

### DO: Use for Zero-Copy Deserialization

```csharp
// Good: Zero-copy deserialization
using var stream = new ReadOnlySequenceMemoryStream(sequence);
var obj = Deserialize(stream);
```

### DON'T: Use ToArray() Unless Necessary

```csharp
// Bad: Defeats the zero-copy purpose
using var stream = new ReadOnlySequenceMemoryStream(sequence);
byte[] copy = stream.ToArray(); // Allocates!

// Better: Read directly
using var stream = new ReadOnlySequenceMemoryStream(sequence);
ProcessStream(stream);
```

### DO: Keep Stream Lifetime Short

```csharp
// Good: Stream disposed quickly
ReadOnlySequence<byte> Process()
{
    using var stream = new ReadOnlySequenceMemoryStream(sequence);
    return Deserialize(stream);
}
```

### DON'T: Hold Stream Reference Beyond Sequence Lifetime

```csharp
// Bad: Sequence may be invalidated
ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();
var stream = new ReadOnlySequenceMemoryStream(sequence);
// ... more writes to writer invalidate sequence and stream!
```

## Limitations

- **Read-Only**: Write operations throw `NotSupportedException`
- **Sequence Lifetime**: Stream is only valid as long as the underlying `ReadOnlySequence<byte>` remains valid
- **No Resize**: Cannot modify the sequence length

## Comparison with MemoryStream

| Feature | ReadOnlySequenceMemoryStream | MemoryStream |
|---------|------------------------------|--------------|
| Data source | `ReadOnlySequence<byte>` | `byte[]` or internal buffer |
| Memory allocation | None (zero-copy) | Allocates array |
| Multi-segment support | Yes | No |
| Write support | No | Yes |
| Resize support | No | Yes |
| Use case | Read-only deserialization | General-purpose buffering |

## See Also

- [ArrayPoolMemoryStream](arraypoolmemorystream.md)
- [ArrayPoolBufferWriter](arraypoolbufferwriter.md)
- [ReadOnlySequence&lt;T&gt; Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.buffers.readonlysequence-1)
- [Memory Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
