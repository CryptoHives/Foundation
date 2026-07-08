# Porting a C# Project to CryptoHives.Foundation

**Audience:** an LLM performing a mechanical + semantic port of an existing C# codebase onto
the `CryptoHives.Foundation.*` NuGet packages.

**Goal:** replace BCL async synchronization primitives with the allocation-free CryptoHives
`ValueTask`-based primitives, replace ad-hoc buffer/stream/pool code with the `Memory`
ArrayPool-based primitives, and replace hashing with the managed, deterministic
`Security.Cryptography` hash implementations — **without changing observable behavior**.

Follow these instructions exactly. Do not invent APIs. If a source pattern has no clean
mapping below, leave it unchanged and record it in the "Unmapped" report at the end.

---

## 0. Ground rules

1. **Behavior-preserving first.** Every replacement must keep the same semantics
   (fairness, reentrancy expectations, exceptions, timeout/cancellation contract). When a
   CryptoHives type has a *different* semantic (e.g. `AsyncLock` is **not reentrant**),
   stop and flag it rather than silently swapping.
2. **One concern per commit.** Do the packages/`csproj` wiring first, then async, then
   memory, then hashing. Build and run tests between each phase.
3. **`ValueTask` is single-consumption.** Every CryptoHives async primitive returns
   `ValueTask`/`ValueTask<T>`. It may be awaited **exactly once** and must never be stored
   in a field, awaited twice, `.Result`-ed, or passed to `Task.WhenAll`/`WhenAny`. The
   `CryptoHives.Foundation.Threading.Analyzers` package enforces this — **add it and treat
   its diagnostics as the source of truth** (see §2.4).
4. Match surrounding code style: nullable is enabled, warnings are errors in this repo;
   any code you add must compile clean under `TreatWarningsAsErrors=true`.

---

## 1. Add package references

Add the packages the port actually uses. Package IDs:

| Need | Package ID |
|---|---|
| Async primitives (`AsyncLock`, `AsyncSemaphore`, …) | `CryptoHives.Foundation.Threading` |
| Analyzer that enforces correct `ValueTask` usage | `CryptoHives.Foundation.Threading.Analyzers` |
| Buffers / streams / object pools | `CryptoHives.Foundation.Memory` |
| Managed hashes / MAC / KDF / KEM | `CryptoHives.Foundation.Security.Cryptography` |

In each consuming `.csproj`:

```xml
<ItemGroup>
  <PackageReference Include="CryptoHives.Foundation.Threading" />
  <PackageReference Include="CryptoHives.Foundation.Threading.Analyzers">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="CryptoHives.Foundation.Memory" />
  <PackageReference Include="CryptoHives.Foundation.Security.Cryptography" />
</ItemGroup>
```

If the target project uses Central Package Management (`Directory.Packages.props` with
`<PackageVersion>` entries), put versions there, not inline. Otherwise add `Version="…"`.

---

## 2. Async primitives (`CryptoHives.Foundation.Threading.Async.Pooled`)

`using CryptoHives.Foundation.Threading.Async.Pooled;`

### 2.1 Mapping table

| Existing (BCL / third-party) | Replace with | Notes |
|---|---|---|
| `private readonly object _gate = new();` + `lock (_gate) { … }` guarding **async** work | `AsyncLock` + `using (await _lock.LockAsync())` | Only when you need to `await` inside the critical section. Pure-sync `lock` blocks that never await should stay as `lock`. |
| `SemaphoreSlim(1, 1)` used as a mutex | `AsyncLock` | Analyzer flags this as **CHT009**. |
| `SemaphoreSlim(n, …)` used for concurrency limiting | `AsyncSemaphore(n)` | |
| `ManualResetEventSlim` / TCS-based manual gate awaited async | `AsyncManualResetEvent` | |
| `AutoResetEvent` semantics, async | `AsyncAutoResetEvent` | |
| `CountdownEvent` awaited async | `AsyncCountdownEvent` | |
| `Barrier` awaited async | `AsyncBarrier` | |
| `ReaderWriterLockSlim` awaited async | `AsyncReaderWriterLock` | |
| `Nito.AsyncEx.AsyncLock`, `NeoSmart.AsyncLock`, `AsyncKeyedLock` (single-key) | `AsyncLock` | Verify the source did not rely on reentrancy. |

### 2.2 `AsyncLock` — exact usage

```csharp
private readonly AsyncLock _lock = new();

public async Task DoStuffAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct))          // ct only observed if not acquired immediately
    {
        await SomethingAsync();
    }
}
```

Signatures actually present:

- `ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default)`
- `ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)`
  - `timeout` throws `TimeoutException` if it elapses; `TimeSpan.Zero` throws immediately if
    the lock is held; `Timeout.InfiniteTimeSpan` waits forever.
- `bool IsTaken { get; }`

Rules:
- **`AsyncLock` is NOT recursive.** If the original lock was taken re-entrantly (same call
  stack re-acquires), do not port it — flag it. Re-entrant acquisition will deadlock.
- The `Releaser` is a `readonly struct` implementing `IDisposable`/`IAsyncDisposable`.
  Release **only** by disposing it via `using`. Do not store it in a field.
- Do not `.GetAwaiter().GetResult()` the `ValueTask<Releaser>` (blocking) — that is CHT002.

### 2.3 `AsyncSemaphore` — exact usage

```csharp
private readonly AsyncSemaphore _semaphore = new(3);   // 3 concurrent permits

public async Task AccessAsync(CancellationToken ct)
{
    await _semaphore.WaitAsync(ct);
    try
    {
        await DoWorkAsync();
    }
    finally
    {
        _semaphore.Release();
    }
}
```

Signatures actually present:
- `AsyncSemaphore(int initialCount, bool runContinuationAsynchronously = true, …)`
- `ValueTask WaitAsync(CancellationToken cancellationToken = default)`
- `ValueTask WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)`
  (throws `TimeoutException` / `OperationCanceledException`)
- `void Release()` / `void Release(int releaseCount)`
- `int CurrentCount { get; }`

Note: there is **no** `SemaphoreSlim`-style bool-returning `WaitAsync(timeout)`. The BCL
pattern `if (await sem.WaitAsync(timeout)) { … }` must be rewritten to try/catch on
`TimeoutException`, or use a `CancellationToken`.

### 2.4 Enforce correctness with the analyzer

After porting, build. The analyzer emits (see `CLAUDE.md` for the full table):

| ID | Meaning — fix |
|---|---|
| CHT001 (Error) | `ValueTask` awaited multiple times — await once, capture the result. |
| CHT002 (Warn) | `.GetAwaiter().GetResult()` on `ValueTask` — make the caller async and `await`. |
| CHT003 (Warn) | `ValueTask` stored in a field — don't; await it locally. |
| CHT004 (Error) | `AsTask()` called multiple times. |
| CHT005 (Warn) | `.Result` on a `ValueTask` — `await` instead. |
| CHT006 (Warn) | `ValueTask` passed to `WhenAll`/`WhenAny` — call `.AsTask()` once first, or restructure. |
| CHT008 (Warn) | `ValueTask` not awaited/consumed. |
| CHT009 (Info) | `SemaphoreSlim(1,1)` — switch to `AsyncLock`. |
| CHT010 (Warn) | `ValueTask` captured in a lambda/closure. |

Resolve every CHT00x before considering the async phase done. Do not suppress them to make
the build pass unless a human explicitly approves a specific instance.

---

## 3. Memory: buffers, streams, pools (`CryptoHives.Foundation.Memory`)

### 3.1 `ArrayPoolBufferWriter<T>` — pooled `IBufferWriter<T>`

`using CryptoHives.Foundation.Memory.Buffers;`

Replace: hand-rolled growable buffers, `MemoryStream` used only to accumulate bytes then
read them back, `ArrayBufferWriter<T>` where you want ArrayPool backing, or manual
`ArrayPool<T>.Shared.Rent`/`Return` accumulation loops.

```csharp
using var writer = new ArrayPoolBufferWriter<byte>();
// standard IBufferWriter<T> surface:
Span<byte> span = writer.GetSpan(sizeHint);   // or GetMemory
// … write into span …
writer.Advance(bytesWritten);
// consume as a ReadOnlySequence (valid until next write or Dispose):
ReadOnlySequence<byte> result = writer.GetReadOnlySequence();
```

Critical rules:
- It is `IDisposable` and rents from `ArrayPool<T>.Shared`. **Always `using`** it so pooled
  arrays are returned. Never let one escape its scope.
- The `ReadOnlySequence<T>` from `GetReadOnlySequence()` is **only valid until the next
  write or `Dispose()`**. Fully consume/copy it before disposing. Do not return it to a
  caller that outlives the `using`.
- For sensitive data, construct with `new ArrayPoolBufferWriter<byte>(clearArray: true,
  defaultChunksize, maxChunkSize)` so buffers are zeroed on return.
- Chunk sizing: default 256, grows (doubling) to max 65536; override via the ctor.

### 3.2 `ArrayPoolMemoryStream` — pooled `MemoryStream`

Replace `new MemoryStream()` used as a scratch/accumulation buffer where the allocation of
one large backing array is wasteful. It is a `MemoryStream` subclass backed by pooled
`ArrayPool<byte>` segments, so it is a drop-in for APIs typed as `MemoryStream`/`Stream`.
`using` it (it returns segments on `Dispose`).

### 3.3 `ReadOnlySequenceMemoryStream` — read-only `Stream` over an existing sequence

Replace code that copies a `ReadOnlySequence<byte>` into a `byte[]` just to wrap it in a
`new MemoryStream(bytes)`. Wrap the sequence directly:
`new ReadOnlySequenceMemoryStream(sequence)`.

### 3.4 `ObjectOwner<T>` + object pools

`using CryptoHives.Foundation.Memory.Pools;`

Replace manual `ObjectPool<T>.Get()/Return()` pairs and `StringBuilder` churn.

```csharp
using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.PooledObject;
// … use sb …
```

For your own pools:
```csharp
using var owner = new ObjectOwner<MyType>(myObjectPool);
MyType obj = owner.PooledObject;
```

Critical rules:
- `ObjectOwner<T>` is a `readonly struct`. Use it **only** with `using var` in a narrow
  scope. **Never cast it to `IDisposable`** and never box it — that defeats the purpose and
  can double-return. Do not copy it around.
- Whatever you got from `PooledObject` must not be used after the `using` scope ends (it has
  been returned to the pool).

### 3.5 `ISegmentOwner<T>` — segment ownership primitives

`using CryptoHives.Foundation.Memory.Buffers;`

`ISegmentOwner<T>` is the `ArraySegment<T>` counterpart to the BCL's `IMemoryOwner<T>`.
Use it when code passes a fixed-size, directly-addressable buffer and the caller needs to
control whether the backing memory comes from a pool, the GC heap, or is simply empty.

#### Replacement table

| Existing pattern | Replace with |
|---|---|
| `ArrayPool<T>.Shared.Rent(n)` + manual `Return` | `PooledSegment<T>.Rent(n)` |
| `new T[n]` handed across an ownership boundary | `AllocatedSegment<T>.Create(buffer)` |
| `null` or zero-length array as "no data" sentinel | `EmptySegment<T>.Instance` |
| `IMemoryOwner<T>` where `ArraySegment<T>` is preferred | `ISegmentOwner<T>` |

#### Choosing the right implementation

| Class | Memory source | When to use |
|---|---|---|
| `PooledSegment<T>` | `ArrayPool<T>.Shared` | Hot-path, short-lived, fixed-size buffers where you want pool reuse. |
| `AllocatedSegment<T>` | `new T[]` (GC heap) | You already have an array and just need a uniform ownership wrapper. |
| `EmptySegment<T>` | `Array.Empty<T>()` singleton | Default/uninitialized state; avoids `null` checks in consumers. |

#### Patterns

```csharp
using CryptoHives.Foundation.Memory.Buffers;

// PooledSegment<T> — pool-backed, Segment.Count == minimumLength
using ISegmentOwner<byte> seg = PooledSegment<byte>.Rent(256);
Span<byte> span = seg.Segment.AsSpan();
FillData(span);
// narrow the view without reallocating (returns false if out-of-range):
if (seg.TrySetSegment(offset: 16, length: 64))
    Send(seg.Segment.AsSpan());
// rented array is returned to ArrayPool on dispose

// AllocatedSegment<T> — wraps an existing GC-managed array, no pool
byte[] raw = new byte[256];
using ISegmentOwner<byte> alloc = AllocatedSegment<byte>.Create(raw);
Process(alloc.Segment.AsSpan());
// only the wrapper is cleared on Dispose; the array itself is unchanged

// EmptySegment<T> — null-object sentinel
ISegmentOwner<byte> none = EmptySegment<byte>.Instance;

void Process(ISegmentOwner<byte> owner)
{
    if (owner.Segment.Count == 0) return;   // handles EmptySegment cleanly
    Span<byte> data = owner.Segment.AsSpan();
    // …
}
```

#### Critical rules

- **`PooledSegment<T>` must be `using`-scoped** — the rented array is returned to
  `ArrayPool<T>.Shared` on dispose. Never let one escape its scope or use the segment after
  disposal (`Segment.Array` becomes `null`).
- **`TrySetSegment` does not resize.** It only repositions the view within the existing
  backing array. It returns `false` when `offset + length > array.Length`; the segment is
  unchanged. Never use it as a grow/resize operation.
- **`EmptySegment<T>.Instance` is a permanent singleton.** Calling `Dispose` on it is a
  no-op by design; treat it as an immutable sentinel value, not as a resource to manage.
- **Indexer `this[int i]` is offset-aware.** `owner[i]` accesses `Segment.Array[i + Segment.Offset]`.
  After `TrySetSegment(offset, length)`, index 0 is element `offset` in the original array.
- For sensitive data, prefer `PooledSegment<T>` (which clears the array on return in DEBUG
  builds) or ensure you zero the span manually before disposing.

---

## 4. Hashing (`CryptoHives.Foundation.Security.Cryptography`)

`using CryptoHives.Foundation.Security.Cryptography.Hash;`

These are fully managed, deterministic, cross-platform implementations that **extend
`System.Security.Cryptography.HashAlgorithm`**, so they are drop-in wherever a
`HashAlgorithm` is expected. Use them to replace BouncyCastle digests, third-party hash
libs, or `System.Security.Cryptography` types when you want managed determinism across all
target frameworks (including legacy TFMs where the BCL lacks e.g. SHA-3).

### 4.1 One-shot hashing (preferred — pooled, allocation-light)

Concrete classes expose static `HashData` / `TryHashData` that pool their instance:

```csharp
byte[] digest = SHA256.HashData(data);                        // ReadOnlySpan<byte> or ReadOnlySequence<byte>
bool ok      = SHA256.TryHashData(data, destination, out int written);
```

Prefer these over `ComputeHash` for one-shot cases — no `IDisposable` bookkeeping and they
accept `ReadOnlySequence<byte>` directly (pairs well with §3.1's `GetReadOnlySequence()`).

### 4.2 Streaming / incremental hashing

For multi-chunk input, use the instance API (same shape as the BCL base type):

```csharp
using var sha = SHA256.Create();
sha.AppendData(chunk1);          // or TransformBlock for the classic pattern
sha.AppendData(chunk2);
sha.TryGetHashAndReset(dest, out int written);
// or: byte[] h = sha.ComputeHash(stream);
```

Every concrete type has a static `Create()` returning the concrete type, plus the inherited
`HashAlgorithm` surface (`ComputeHash`, `TransformBlock`/`TransformFinalBlock`, etc.).

### 4.3 Available concrete hash types (use the exact class name)

- **SHA-2:** `SHA224`, `SHA256`, `SHA384`, `SHA512`, `SHA512_224`, `SHA512_256`
- **SHA-3 (FIPS 202):** `SHA3_224`, `SHA3_256`, `SHA3_384`, `SHA3_512`
- **Keccak (original padding):** `Keccak256`, `Keccak384`, `Keccak512`
- **XOF:** `Shake128`, `Shake256`, `CShake128`, `CShake256`, `TurboShake128`,
  `TurboShake256`, `KT128`, `KT256`
- **BLAKE:** `Blake2b`, `Blake2s`, `Blake3`
- **Legacy (deprecated, kept for compat):** `SHA1`, `MD5`, `Ripemd160`
- **Regional / other:** `SM3`, `Whirlpool`, `Kupyna`, `Streebog`, `Lsh256`, `Lsh512`,
  `AsconHash256`, `AsconXof128`
- **Parallel:** `ParallelHash`, `IncrementalParallelHash`

### 4.4 Extendable-output functions (XOF)

XOF types (`Shake*`, `CShake*`, `TurboShake*`, `KT*`, `Blake3`, `AsconXof128`) implement
`IExtendableOutput`:

```csharp
void Absorb(ReadOnlySpan<byte> input);   // absorb all input first
void Squeeze(Span<byte> output);         // then squeeze arbitrary-length output (repeatable)
void Reset();
```

After the first `Squeeze`, the state is finalized — no more `Absorb`. Map any
"digest of arbitrary length" or SHAKE usage to this pattern.

### 4.5 Choosing managed vs. OS implementation

`HashAlgorithm.Create(string hashName, bool osVersion = false)` is available: pass
`osVersion: true` to get the (often faster) OS implementation for algorithms the BCL
supports, or the default managed CryptoHives implementation otherwise. For a straight port,
prefer the concrete-class static `HashData` calls (§4.1) for clarity.

### 4.6 Do NOT touch cryptographic correctness

Do not change algorithm choice, key sizes, IV/nonce handling, digest length, or padding as
part of this port. Swap the *implementation type* only. If the source uses a broken/weak
algorithm (MD5/SHA-1), keep it as-is (the equivalent CryptoHives type exists) and note it —
do not "upgrade" it silently.

---

## 5. Procedure & verification

Work phase by phase; build + test after each:

1. **Wire packages** (§1). Restore/build.
2. **Async** (§2): swap primitives, add the analyzer, drive CHT00x to zero.
3. **Memory** (§3): swap buffer/stream/pool patterns; verify every new type is `using`-scoped.
4. **Hashing** (§4): swap hash implementations; confirm identical digests.

Verification checklist:
- [ ] Solution builds clean under `TreatWarningsAsErrors=true`.
- [ ] Zero unresolved `CHT001`–`CHT010` diagnostics.
- [ ] All existing tests pass. For hashing, add/keep a test asserting the new digest equals
      a known-answer vector or the pre-port output for representative inputs.
- [ ] No `ValueTask` stored in a field, awaited twice, `.Result`-ed, or `WhenAll`-ed.
- [ ] Every `ArrayPoolBufferWriter<T>`, `ArrayPoolMemoryStream`, `PooledSegment<T>`, and
      `ObjectOwner<T>` is in a `using` scope; no pooled buffer or `ReadOnlySequence` escapes it.
- [ ] No `AsyncLock` used re-entrantly.
- [ ] No code uses a `PooledSegment<T>` segment or its backing array after `Dispose`.
- [ ] `TrySetSegment` return value is checked; it is not used as a resize/grow operation.

## 6. Report

At the end, produce a short report:
- **Replaced:** table of `file:line` → old type → new CryptoHives type.
- **Unmapped / flagged:** patterns you intentionally left alone (re-entrant locks, sync-only
  `lock` blocks, bool-returning `WaitAsync(timeout)` usages that need human decision, weak
  hashes retained), each with a one-line reason.
- **Behavioral risks:** anything where semantics *might* differ (fairness, continuation
  scheduling, timeout-as-exception vs. bool), for human review.
