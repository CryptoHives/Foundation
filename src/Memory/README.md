## CryptoHives Open Source Initiative 🐝

An open, community-driven collection of cryptography and performance libraries for the .NET ecosystem, maintained by **The Keepers of the CryptoHives**.

---

## CryptoHives.Foundation.Memory

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)

Pooled buffer management for .NET, built to keep allocations and GC pressure out of high-throughput transformation pipelines and crypto workloads.

---

## Installation

```bash
dotnet add package CryptoHives.Foundation.Memory
```

---

## Key Features

- **Pooled memory streams** — a `MemoryStream` replacement backed by `ArrayPool<byte>.Shared`; no resize-copy, no LOH pressure
- **Zero-copy handoff** — expose written data as a `ReadOnlySequence<byte>` without copying anything
- **`IBufferWriter<T>` support** — `ArrayPoolBufferWriter<T>` works directly with `Utf8JsonWriter`, `PipeWriter`, or any other `IBufferWriter` consumer
- **Read-only sequence streaming** — wrap an existing `ReadOnlySequence<byte>` as a `Stream` without copying
- **RAII ownership** — `ObjectOwner<T>` returns pooled objects automatically on dispose
- **Segment ownership primitives** — `ISegmentOwner<T>` unifies three strategies: `PooledSegment<T>` rents from `ArrayPool<T>`, `AllocatedSegment<T>` wraps GC-managed arrays, and `EmptySegment<T>` is a zero-allocation null-object sentinel

---

## Quick Examples

### Pooled Memory Stream

```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Write data in chunks, then hand off as ReadOnlySequence — zero copy
using var stream = new ArrayPoolMemoryStream();

await stream.WriteAsync(headerBytes, ct).ConfigureAwait(false);
await stream.WriteAsync(payloadBytes, ct).ConfigureAwait(false);

// No copy — memory stays in the pool segments
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
await SendAsync(sequence, ct).ConfigureAwait(false);

// Pooled buffers are returned when the stream is disposed
```

### Buffer Writer (e.g. with `Utf8JsonWriter`)

```csharp
using CryptoHives.Foundation.Memory.Buffers;
using System.Text.Json;

using var writer = new ArrayPoolBufferWriter<byte>();
using var json   = new Utf8JsonWriter(writer);

json.WriteStartObject();
json.WriteString("key", "value");
json.WriteEndObject();
json.Flush();

ReadOnlySequence<byte> result = writer.GetReadOnlySequence();
await socket.SendAsync(result.First, WebSocketMessageType.Text, true, ct).ConfigureAwait(false);

// Pooled chunks returned on dispose
```

### Read-Only Sequence as Stream

```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Consume an existing ReadOnlySequence<byte> through a Stream interface — zero copy
ReadOnlySequence<byte> data = pipeline.GetData();

using var stream = new ReadOnlySequenceMemoryStream(data);
await DeserializeFromStreamAsync(stream, ct).ConfigureAwait(false);
```

### RAII Object Ownership

```csharp
using CryptoHives.Foundation.Memory.Pools;

var pool = ObjectPools.Create<MyExpensiveObject>();

using var owner = new ObjectOwner<MyExpensiveObject>(pool);
MyExpensiveObject obj = owner.Object;

// Use obj...

// Automatically returned to the pool when owner is disposed — even on exception
```

### segment ownership

```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Pool-backed: rented from ArrayPool<byte>, returned on dispose
using ISegmentOwner<byte> pooled = PooledSegment<byte>.Rent(256);
Span<byte> span = pooled.Segment.AsSpan();
FillData(span);

// Slice the view without copying
if (pooled.TrySetSegment(offset: 16, length: 64))
{
    Span<byte> payload = pooled.Segment.AsSpan();
    SendPayload(payload);
}

// GC-managed: wrap an existing array, no pool lifecycle needed
byte[] buffer = new byte[256];
using ISegmentOwner<byte> alloc = AllocatedSegment<byte>.Create(buffer);

// Empty sentinel: null-object that avoids null checks
ISegmentOwner<byte> none = EmptySegment<byte>.Instance;
```

---

## Documentation

| Resource | Link |
|----------|------|
| Full package documentation | [cryptohives.github.io/Foundation/packages/memory](https://cryptohives.github.io/Foundation/packages/memory/index.html) |
| API reference | [cryptohives.github.io/Foundation/api](https://cryptohives.github.io/Foundation/api/index.html) |
| Source repository | [github.com/CryptoHives/Foundation](https://github.com/CryptoHives/Foundation) |

---

## Security Policy

If you discover a vulnerability, please don't open a public issue — follow the process on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md) instead.

---

## License

MIT — © 2026 The Keepers of the CryptoHives

