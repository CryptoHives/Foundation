# Windows X64 AMD Ryzen 5 7600X Threading Benchmarks

## Machine Profile

[!INCLUDE[](machine-spec.md)]

BenchmarkDotNet microbenchmarks for all async synchronization primitives in `CryptoHives.Foundation.Threading`. Benchmarks cover uncontested fast paths (0 other waiters), single-waiter async round trips (1 waiter), and high-contention scenarios (10–100 waiters). All implementations are tested with both a default `CancellationToken.None` and a non-cancelled `CancellationToken` to isolate the registration overhead.

Implementations are compared against:

- **Pooled** — CryptoHives pooled `ValueTask`-returning implementation (the baseline, ratio = 1.00)
- **ProtoPromise** — ProtoPromise zero-allocation async primitives
- **RefImpl** — Simple reference implementation using `TaskCompletionSource<bool>` (demonstrates heap-allocating baselines)
- **Nito.AsyncEx** — Nito.AsyncEx async synchronization primitives (Stephen Cleary)
- **NeoSmart** — NeoSmart.AsyncLock
- **VS.Threading** / **NonKeyed** — Microsoft.VisualStudio.Threading / non-keyed async lock variants
- **System** — .NET built-in synchronization primitives (`SemaphoreSlim`, `ReaderWriterLockSlim`, `CountdownEvent`, `Barrier`, `ManualResetEventSlim`, `ManualResetEvent`, `AutoResetEvent`)

## Highlights

| Primitive | vs macOS M4 | Key Insight |
|-----------|:-----------:|-------------|
| **AsyncAutoResetEvent** (Set) | ~35% slower | System.AutoResetEvent ~4× more expensive than macOS |
| **AsyncBarrier** (1 participant) | ~63% slower | System.Barrier **2.8× faster** than macOS at 10 participants |
| **AsyncCountdownEvent** (1 participant) | ~38% slower | Near parity with System.CountdownEvent |
| **AsyncLock** (single) | ~10% slower | ProtoPromise leads; CryptoHives SpinLock ~14× faster than System.SpinLock |
| **AsyncManualResetEvent** (SetReset) | ~26% slower | ManualResetEvent kernel ~4× more expensive than macOS |
| **AsyncRWLock** (reader, uncontested) | **~2× slower** | Windows faster under contention; inverts at 1+ readers |
| **AsyncRWLock** (writer, uncontested) | ~52% slower | ProtoPromise leads |
| **AsyncSemaphore** | ~43% slower | Task continuation scheduling advantage shown in AsTask paths |

> [!NOTE]
> On Windows x64, `AsTask()` continuations are **2–3× faster** than on Apple M4 at low contention (1–2 waiters). This reflects the Windows ThreadPool's efficient inline `Task` continuation scheduling (the posting overhead to the `ThreadPool` work queue is lower). However, under very high contention (100 waiters) the macOS M4 ValueTask path becomes faster as Windows ThreadPool scheduling saturates. For maximum throughput at all contention levels prefer `AsValueTask()`.

---

## AsyncLock

`AsyncLock` provides exclusive mutual exclusion with cancellation support. The `Single` benchmark measures the uncontested acquire+release cycle with no other waiters. The `Multiple` benchmark adds a configurable number of concurrent contending waiters.

### Single (uncontested)

The uncontested benchmark is a proxy for the underlying lock and `ValueTask` state machine cost when the fast path does not need to suspend. On x64 RyuJIT, interlocked operations (`Interlocked.Add`, `Interlocked.Inc`) run sub-nanosecond — faster than ARM64 due to the x86 TSO memory model's more relaxed fence requirements for increment operations.

**Key observations:**
- **Pooled**: Fastest async lock; ~10% slower than macOS M4
- **ProtoPromise**: ~15% faster than Pooled (zero-allocation, no cancellation support)
- **System.Lock** / `lock()`: both ~3–4× cheaper than async paths (no await overhead)
- **CryptoHives SpinLock**: matches System.Lock speed; ~14× faster than System.SpinLock
- **Nito** and **NeoSmart**: each allocate per-lock (320 B / 208 B respectively); in the order-of-magnitude slower range
- `Interlocked.Add` / `Inc`: sub-nanosecond — x64 TSO memory model enables cheaper atomics than ARM64 in this micro-benchmark

[!INCLUDE[](asynclock-single.md)]

### Multiple (contended)

**Key observations:**
- **Pooled (ValueTask)**: Fastest async lock path at all contention levels
- At 1 contender: Pooled (VT) leads; ProtoPromise ~30% slower; SemaphoreSlim ~50% slower
- **Pooled (AsTask)** at 1 contender: **~2.9× faster than macOS**. Windows ThreadPool inlines `Task` continuations more efficiently at low concurrency.
- At 100 contenders: Pooled (VT) ~29% slower than macOS M4 for the ValueTask path at saturation
- **Pooled (AsTask)** at 100 contenders with `NotCancelled`: Windows **~3.4× faster** than macOS for asynchronous task-based paths at high contention

[!INCLUDE[](asynclock-multiple.md)]

---

## AsyncAutoResetEvent

`AsyncAutoResetEvent` releases exactly one waiter per `Set()` call. Three benchmarks cover: `Set` (no waiters — measures pure signal cost), `SetThenWait` (signal then immediately wait on the newly-reset event), and `WaitThenSet` (N waiters await then are unblocked one by one).

### Set (no waiters)

**Key observations:**
- **Pooled** and **ProtoPromise**: sub-nanosecond pure-signal cost
- **System.AutoResetEvent** (kernel): **~320×** slower than Pooled; **~4× more expensive than macOS** — Windows kernel event objects carry a significantly larger overhead than Apple's `mach_semaphore`

[!INCLUDE[](asyncautoresetevent-set.md)]

### SetThenWait

Signals then immediately calls `WaitAsync`. Because the event was just set, `WaitAsync` returns synchronously — measures the combined signal + synchronous check cost.

**Key observations:**
- **Pooled (ValueTask)** and **ProtoPromise**: sub-10 ns combined signal + synchronous check
- **RefImpl** and **Nito**: ~2× slower than Pooled; `SetThenWait` for RefImpl is slower here than macOS because Windows's `TaskCompletionSource` fast-path post has more overhead

[!INCLUDE[](asyncautoresetevent-setthenw.md)]

### WaitThenSet

N waiters call `WaitAsync`, then `Set()` is called N times from another context. Each Set/Wait round trip involves a full async scheduling cycle (suspend + resume).

**Key observations:**
- **Pooled (AsValueTask)** at 1 waiter: ~25% slower than macOS; the continuation dispatch overhead through `ValueTask` pooling is slightly more expensive on x64 vs ARM64 for single-waiter
- **Pooled (AsTask)** at 1 waiter: **~2.75× faster than macOS** for the Task path; ThreadPool Task scheduling is faster at low concurrency on Windows
- At 100 waiters `None`: Pooled (VT) ~25% slower than macOS for the ValueTask path at saturation
- **Nito** at 100 waiters `NotCancelled`: tens of microseconds — scales linearly with per-waiter CancellationToken registration

[!INCLUDE[](asyncautoresetevent-waitthenset.md)]

---

## AsyncManualResetEvent

`AsyncManualResetEvent` releases **all** waiters when set and stays set until explicitly reset. The `SetReset` benchmark measures the rapid set/reset cycle. `SetThenWait` measures a set followed by a synchronous wait. `WaitThenSet` drives N concurrent waiters through a broadcast release.

### SetReset

**Key observations:**
- **Pooled**: ~2.8× faster than `ManualResetEventSlim.Set+Reset`
- **ManualResetEvent** (kernel): ~210× slower than Pooled; **~4× more expensive than macOS** — Windows kernel event objects are significantly heavier
- ProtoPromise leads at the lowest absolute cost

[!INCLUDE[](asyncmanualresetevent-setreset.md)]

### SetThenWait

[!INCLUDE[](asyncmanualresetevent-setthenw.md)]

### WaitThenSet

Because `AsyncManualResetEvent` broadcasts to all waiters from a single `Set()`, `RefImpl` uses one `TaskCompletionSource` shared across all waiters — its allocation stays constant at 96 B regardless of waiter count. This gives it an unusual cost profile.

**Key observations:**
- **Pooled (AsValueTask)** at 1 waiter: **~36% slower than macOS**; this is one of the scenarios where the x64 ValueTask dispatch is slower than ARM64
- **Pooled (AsTask)** at 1 waiter: **~2.9× faster than macOS** for Task path
- At 100 waiters `None`: Pooled (VT) ~30% slower than macOS; broadcast release at high contention favours Apple Silicon
- **Nito** at 100 waiters `NotCancelled`: tens of microseconds — **Windows ~23% faster** than macOS; the Nito `CancellationToken.Register` scales with thread count and Windows ThreadPool completes registrations faster

[!INCLUDE[](asyncmanualresetevent-waitthenset.md)]

---

## AsyncSemaphore

`AsyncSemaphore` manages a counted resource permit (here initialized to 1). The single-permit benchmark measures the wait+release cycle uncontested (the permit is available on entry).

**Key observations:**
- **Pooled**: ~43% slower than macOS for the uncontested path
- **ProtoPromise**: leads across all configurations
- **System.SemaphoreSlim**: ~85% slower than Pooled; macOS equivalent is ~25% cheaper due to lighter kernel semaphore
- **RefImpl**: Windows `TaskCompletionSource` creation is ~55% more expensive than on macOS

[!INCLUDE[](asyncsemaphore-single.md)]

---

## AsyncCountdownEvent

`AsyncCountdownEvent` completes when signaled N times. Two scenarios are benchmarked: `SignalAndWait` where the last signal also observes the countdown reaching zero, and `WaitAndSignal` where a waiter is already blocking.

**Key observations:**
- **Pooled** at P=1: ~38% slower than macOS
- **System.CountdownEvent**: virtually identical on both platforms; kernel countdown objects normalize across architectures
- At P=10: Pooled near-identical on both platforms; contention equalizes them
- **ProtoPromise** consistently leads or matches System.CountdownEvent at both P=1 and P=10

[!INCLUDE[](asynccountdownevent-signal.md)]

---

## AsyncBarrier

`AsyncBarrier` blocks all N participants until all have signaled, then releases them simultaneously.

**Key observations:**
- **Pooled** at P=1: **~63% slower than macOS**; largest uncontested gap across all primitives
- **System.Barrier** at P=1: ~42× slower than Pooled; **~2.4× faster than macOS** — `System.Barrier` uses a spin-wait strategy that performs better on x64 than macOS at low participant counts
- At P=10: Pooled ~30% slower than macOS; **System.Barrier ~2.8× slower on Windows** at P=10 — the x86 spin-wait amplifies context switching cost as participant count grows

[!INCLUDE[](asyncbarrier-signalandwait.md)]

---

## AsyncReaderWriterLock

`AsyncReaderWriterLock` supports multiple concurrent readers or a single exclusive writer, plus an upgradeable reader that can atomically promote to writer.

### WriterLock (uncontested)

**Key observations:**
- **Pooled**: **~52% slower than macOS**; the writer lock has more bookkeeping than simple exclusion locks, amplifying the ARM64 JIT advantage
- **ProtoPromise**: leads Pooled (~20% faster)
- **System.ReaderWriterLockSlim**: ~½ the cost of Pooled; ~50% slower than macOS equivalent
- **VS.Threading**: async overhead model (~100× vs Pooled); ~30% faster than macOS

[!INCLUDE[](asyncreaderwriterlock-writer.md)]

### ReaderLock

The reader lock benchmark shows a **contention inversion** from macOS:

- **Uncontested (0 concurrent readers)**: **macOS ~2× faster**; the uncontested reader lock path on ARM64 is exceptionally efficient
- **1 concurrent reader**: **Windows ~32% faster** with a single contending reader; the Windows ThreadPool schedules the read-lock resume continuation faster at low concurrency
- **100 concurrent readers**: **Windows ~2× faster** at high contention; the Pooled reader lock's internal structure for multi-reader scheduling benefits from the Windows ThreadPool's scalable task dispatching
- **ProtoPromise** at 100 readers: dramatically different scaling ratios between platforms; macOS ProtoPromise handles the broadcast release with far fewer overheads

[!INCLUDE[](asyncreaderwriterlock-reader.md)]

### UpgradeableReaderLock

Same inversion pattern as the plain reader lock:
- **Uncontested**: **macOS ~2× faster**
- **1–2 concurrent upgradeables**: Windows is faster (~10–37%)
- **VS.Threading** upgradeable: allocates 616 B per acquire; slowest by far at all contention levels

[!INCLUDE[](asyncreaderwriterlock-upgradeablereader.md)]

### UpgradedWriterLock

The upgraded writer acquires an upgradeable read lock then promotes to exclusive writer, draining all active readers first.

- **Uncontested**: **macOS ~32% faster**
- **1 concurrent upgraded writer**: **Windows ~30% faster** (same inversion as Reader at 1 contender); the Windows ThreadPool inline-completes the queued upgrade faster
- **5 concurrent upgraded writers**: **Windows ~2.5× faster**; the writer upgrade queue is the starkest scenario where Windows ThreadPool's Task scheduling advantage over macOS is most visible

[!INCLUDE[](asyncreaderwriterlock-upgradedwriter.md)]
