# macOS ARM64 Apple M4 Threading Benchmarks

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

| Primitive | vs Windows | Key Insight |
|-----------|:----------:|-------------|
| **AsyncAutoResetEvent** (Set) | ~34% faster | ARM64 fast path; System.AutoResetEvent ~4× cheaper than on Windows |
| **AsyncBarrier** (1 participant) | ~39% faster | System.Barrier ~4× cheaper on macOS than Windows at P=1 |
| **AsyncCountdownEvent** (1 participant) | ~28% faster | Pooled near-parity with System.CountdownEvent |
| **AsyncLock** (single) | ~9% faster | CryptoHives SpinLock ~20× faster than System.SpinLock |
| **AsyncManualResetEvent** (SetReset) | ~21% faster | ManualResetEvent kernel ~4× cheaper on macOS than Windows |
| **AsyncRWLock** (reader, uncontested) | **~2× faster** | Strongest uncontested advantage; inverts under high contention |
| **AsyncRWLock** (writer, uncontested) | ~34% faster | Near-parity with ProtoPromise |
| **AsyncSemaphore** | ~30% faster | System.SemaphoreSlim ~½ the cost of Windows |

> [!NOTE]
> On Apple M4, the Pooled `AsTask()` path is **2–3× slower** than on Windows x64 for low-contention scenarios (1–2 waiters). This reflects Windows ThreadPool's faster inline `Task` continuation scheduling. However, at 100 waiters the macOS `AsTask` path becomes faster — the Windows ThreadPool saturates first. For latency-sensitive code, prefer `AsValueTask()` or direct `ValueTask` consumption.

---

## AsyncLock

`AsyncLock` provides exclusive mutual exclusion with cancellation support. The `Single` benchmark measures the uncontested acquire+release cycle with no other waiters. The `Multiple` benchmark adds a configurable number of concurrent contending waiters.

### Single (uncontested)

The uncontested benchmark is a proxy for the underlying lock and `ValueTask` state machine cost when the fast path does not need to suspend. The CryptoHives `SpinLock` matches the speed of .NET's `Lock.EnterScope` — both roughly 20× faster than `System.SpinLock` due to the absence of OS kernel yield in the non-contended case. The async `Pooled` path is the fastest async lock on this platform.

**Key observations:**
- **Pooled**: Fastest async lock; ~9% faster than Windows x64
- **ProtoPromise**: ~12–15% faster than Pooled at this baseline (zero-allocation, no cancellation support)
- **System.Lock** / `lock()`: both ~3–4× cheaper than async paths (no await overhead)
- **CryptoHives SpinLock**: matches System.Lock; suitable only for very short critical sections
- **Nito** and **NeoSmart**: each allocate per-lock (320 B / 208 B respectively); in the order-of-magnitude slower range

[!INCLUDE[](asynclock-single.md)]

### Multiple (contended)

The `Multiple` benchmark drives `Iterations` concurrent waiters through a single lock. Iteration = 0 is the uncontested baseline; Iteration = 1 introduces one additional waiter triggering an actual async suspension and resume; 10 and 100 measure contention scaling.

**Key observations:**
- **Pooled (ValueTask)**: Fastest async lock path at all contention levels
- At 1 contender: Pooled (VT) leads; ProtoPromise ~20% slower; SemaphoreSlim ~55% slower
- **Pooled (AsTask)** at 1 contender: **~2.9× slower than Windows**. Task continuation scheduling via macOS ThreadPool is slower for a single resume. Prefer `AsValueTask()`.
- At 100 contenders: Pooled (VT) ~29% faster than Windows for the ValueTask path
- **Nito** and **VS.Threading** scale poorly under `NotCancelled` cancellation due to `CancellationToken.Register` overhead

[!INCLUDE[](asynclock-multiple.md)]

---

## AsyncAutoResetEvent

`AsyncAutoResetEvent` releases exactly one waiter per `Set()` call. Three benchmarks cover: `Set` (no waiters — measures pure signal cost), `SetThenWait` (signal then immediately wait on the newly-reset event), and `WaitThenSet` (N waiters await then are unblocked one by one).

### Set (no waiters)

The `Set` benchmark captures the cost of signaling an event that no one is waiting on — effectively a conditional interlocked operation plus any bookkeeping.

**Key observations:**
- **Pooled** and **ProtoPromise**: sub-nanosecond pure-signal cost
- **System.AutoResetEvent** (kernel): ~120× slower than Pooled; ~4× cheaper than on Windows
- Apple Silicon `mach_semaphore` signaling is significantly cheaper than Windows kernel event objects

[!INCLUDE[](asyncautoresetevent-set.md)]

### SetThenWait

Signals then immediately calls `WaitAsync`. Because the event was just set, `WaitAsync` returns synchronously — this measures the combined signal + synchronous check cost.

**Key observations:**
- **Pooled (ValueTask)** and **ProtoPromise**: sub-10 ns combined signal + synchronous check
- **RefImpl** and **Nito**: ~2× slower than Pooled

[!INCLUDE[](asyncautoresetevent-setthenw.md)]

### WaitThenSet

N waiters call `WaitAsync`, then `Set()` is called N times from another context. Each Set/Wait round trip involves a full async scheduling cycle (suspend + resume).

**Key observations:**
- **Pooled (AsValueTask)** at 1 waiter: ~14% faster than default `Pooled (ValueTask)` when using the `AsValueTask()` overload
- **Pooled (AsValueTask SyncCont)**: synchronized continuation (inline resume) saves a context switch; similar result
- At 100 waiters: Pooled (VT) **~25% faster** than Windows for the ValueTask path
- **Nito** at 100 waiters with `NotCancelled`: hundreds of microseconds — 100 per-waiter CancellationToken registrations dominate

[!INCLUDE[](asyncautoresetevent-waitthenset.md)]

---

## AsyncManualResetEvent

`AsyncManualResetEvent` releases **all** waiters when set and stays set until explicitly reset. The `SetReset` benchmark measures the rapid set/reset cycle. `SetThenWait` measures a set followed by a synchronous wait (which completes immediately since the event is already set). `WaitThenSet` drives N concurrent waiters.

### SetReset

Combined set-then-reset cycle — captures the cost of toggling the event state with no waiters.

**Key observations:**
- **Pooled**: ~4× faster than `ManualResetEventSlim.Set+Reset` and ~65× faster than `ManualResetEvent`
- **ProtoPromise**: fastest overall; **ManualResetEvent** (kernel): ~4× cheaper on macOS than Windows

[!INCLUDE[](asyncmanualresetevent-setreset.md)]

### SetThenWait

[!INCLUDE[](asyncmanualresetevent-setthenw.md)]

### WaitThenSet

Unlike `AsyncAutoResetEvent`, the `AsyncManualResetEvent` `WaitThenSet` benchmark releases all N waiters in a single `Set()` call (broadcast semantics). This means the allocation for `RefImpl` stays constant regardless of waiter count (single `TaskCompletionSource` shared by all).

**Key observations:**
- **Pooled (AsValueTask)** at 1 waiter: ~15% faster than Windows
- `NotCancelled` adds roughly 50–60% overhead per waiter at 1 iteration for the CancellationToken registration
- **Nito** `NotCancelled` at 100 waiters: hundreds of microseconds — 100 per-waiter registrations dominate

[!INCLUDE[](asyncmanualresetevent-waitthenset.md)]

---

## AsyncSemaphore

`AsyncSemaphore` manages a counted resource permit. The single-permit benchmark measures the wait+release cycle uncontested (the permit is available, so `WaitAsync` takes the fast path).

**Key observations:**
- **Pooled**: **~30% faster than Windows** — the largest relative advantage across all uncontested benchmarks
- **ProtoPromise**: ~25% faster than Pooled
- **System.SemaphoreSlim**: ~2× slower than Pooled; ~25% cheaper than on Windows (lighter macOS kernel semaphore)

[!INCLUDE[](asyncsemaphore-single.md)]

---

## AsyncCountdownEvent

`AsyncCountdownEvent` completes when signaled N times. Two scenarios: `SignalAndWait` (last signal also unblocks the single waiter atomically), and `WaitAndSignal` (the waiter is already blocking when signals arrive).

**Key observations:**
- **Pooled** (SignalAndWait, P=1): **~28% faster than Windows**
- **System.CountdownEvent**: near-identical on both platforms — kernel countdown objects normalize across architectures
- At P=10, all implementations are within 2× of each other; Pooled matches System.CountdownEvent

[!INCLUDE[](asynccountdownevent-signal.md)]

---

## AsyncBarrier

`AsyncBarrier` blocks all N participants until all have signaled, then releases them simultaneously. The `SignalAndWait` benchmark measures the end-to-end barrier phase cycle.

**Key observations:**
- **Pooled** at P=1: **~39% faster than Windows**
- **System.Barrier** at P=1: ~160× slower than Pooled; the ratio vs Pooled is much worse here than on Windows (~42×); `System.Barrier` performs full OS thread synchronization internally
- At P=10: Pooled ~23% faster than Windows; **System.Barrier ~2.8× cheaper than on Windows** at P=10

[!INCLUDE[](asyncbarrier-signalandwait.md)]

---

## AsyncReaderWriterLock

`AsyncReaderWriterLock` supports multiple concurrent readers or a single exclusive writer, plus an upgradeable reader that can atomically promote to writer. Benchmarks cover four access patterns:

- **WriterLock** — exclusive write acquire+release (uncontested)
- **ReaderLock** — shared read acquire+release at N concurrent readers
- **UpgradeableReaderLock** — upgradeable acquire at N concurrent upgradeables
- **UpgradedWriterLock** — upgrade from upgradeable to writer at N concurrent upgradeables

### WriterLock (uncontested)

**Key observations:**
- **Pooled** and **ProtoPromise**: near parity — fastest async writer lock on this platform
- Both are **~34% faster than Windows** for the Pooled path
- **System.ReaderWriterLockSlim**: ~35% faster than Pooled (synchronous acquire path); ~33% faster than Windows equivalent
- **VS.Threading**: async overhead ~215× vs Pooled due to its queuing model

[!INCLUDE[](asyncreaderwriterlock-writer.md)]

### ReaderLock

The reader lock benchmark reveals a notable **contention inversion** between platforms:
- **Uncontested (0 concurrent readers)**: M4 **~2× faster** than Windows — the strongest single uncontested advantage across all threading benchmarks
- **1 concurrent reader**: **Windows ~32% faster** with a single contending reader; scheduling a resume on macOS ThreadPool costs more for the RWLock resumption path
- **100 concurrent readers**: **Windows ~2× faster** at high contention
- **ProtoPromise** at 100 readers: macOS dramatically outperforms Windows (~0.13 vs 0.73 ratio to Pooled) — ProtoPromise's lock-free reader promotion is particularly effective at broadcast-style reader release on M4

[!INCLUDE[](asyncreaderwriterlock-reader.md)]

### UpgradeableReaderLock

Same contention inversion pattern as reader lock:
- **Uncontested**: M4 **~2× faster** than Windows
- **System.ReaderWriterLockSlim** upgradeable: ~40% faster than Pooled uncontested; ~30% cheaper than on Windows
- **VS.Threading** upgradeable: ~1.4× slower than Windows uncontested due to lock-free upgradeable state tracking differences; allocates 616 B per acquire

[!INCLUDE[](asyncreaderwriterlock-upgradeablereader.md)]

### UpgradedWriterLock

The upgraded writer lock holds an upgradeable reader then atomically promotes to exclusive writer, requiring all active readers to drain first.

- **Uncontested**: M4 **~32% faster** than Windows
- **1 concurrent upgraded writer**: **Windows ~30% faster** (same inversion as reader lock)
- **5 concurrent upgraded writers**: **Windows ~2.5× faster** — writer upgrade queuing is the scenario where Windows ThreadPool's Task scheduling advantage is most visible

[!INCLUDE[](asyncreaderwriterlock-upgradedwriter.md)]
