## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven cryptography and performance library collection for the .NET ecosystem,
developed and maintained by **The Keepers of the CryptoHives**.

---

## CryptoHives.Foundation.Memory

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)

Pooled buffer management utilities for .NET — designed to minimize allocations and reduce GC pressure in high-throughput transformation pipelines and cryptographic workloads.

---

## 📦 Installation

```bash
dotnet add package CryptoHives.Foundation.Memory
```

---

## ✨ Key Features

- **Pooled memory streams** — `MemoryStream` replacement backed by `ArrayPool<byte>.Shared`; no resize-copy, no LOH pressure
- **Zero-copy handoff** — expose written data as `ReadOnlySequence<byte>` without any copying
- **`IBufferWriter<T>` support** — `ArrayPoolBufferWriter<T>` works directly with `Utf8JsonWriter`, `PipeWriter`, and any `IBufferWriter` consumer
- **Read-only sequence streaming** — wrap an existing `ReadOnlySequence<byte>` as a `Stream` without copying
- **RAII ownership** — `ObjectOwner<T>` safely returns pooled objects when disposed

---

## 🚀 Quick Examples

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

// Pooled buffers are returned when stream is disposed
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

// Automatically returned to pool when owner is disposed — even on exception
```

---

## 📚 Documentation

| Resource | Link |
|----------|------|
| Full package documentation | [cryptohives.github.io/Foundation/packages/memory](https://cryptohives.github.io/Foundation/packages/memory/index.html) |
| API reference | [cryptohives.github.io/Foundation/api](https://cryptohives.github.io/Foundation/api/index.html) |
| Source repository | [github.com/CryptoHives/Foundation](https://github.com/CryptoHives/Foundation) |

---

## 🔐 Security Policy

If you discover a vulnerability, **please do not open a public issue.**
Follow the guidelines on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## ⚖️ License

MIT — © 2026 The Keepers of the CryptoHives
