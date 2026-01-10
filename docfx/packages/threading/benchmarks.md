## Threading Benchmarks

This page documents the benchmarks included in the Threading library.

### Overview

BenchmarkDotNet is used for microbenchmarks. Benchmarks live under `tests/Threading/Async/Pooled/` and can be executed with the BenchmarkSwitcher entry point at `tests/Common/Main.cs`.

### Updating Benchmark Results

Benchmark results are stored in `docfx/packages/threading/benchmarks/` and can be updated after a local benchmark run using:

```cmd
scripts\update-benchmark-docs.cmd
```

Or on PowerShell:

```powershell
.\scripts\update-benchmark-docs.ps1
```

See [benchmarks/README.md](benchmarks/README.md) for details.

### Included benchmark suites

Benchmarking contention is tricky and not all possible scenarios can be covered.
The included benchmarks try uncontested and contested scenarios:

- Run with no contention (single waiter) to measure baseline overhead.
- Run with multiple concurrent waiters to measure contention behavior. The number of waiters is increased to measure memory allocations and execution time.
- For the pooled implementations, variations with AsTask() and await are separately benchmarked.

- `tests/Threading/Async/Pooled/AsyncLock*Benchmark.cs` — single and multiple queued waiters for various `AsyncLock` implementations (Pooled, Nito, AsyncKeyedLock, reference implementation, NeoSmart).
- `tests/Threading/Async/Pooled/AsyncAutoResetEvent*Benchmark.cs` — set/wait and contention scenarios for `AsyncAutoResetEvent` implementations (Pooled, Nito, reference implementation).
- `tests/Threading/Async/Pooled/AsyncManualResetEvent*Benchmark.cs` — set/wait and contention scenarios for `AsyncManualResetEvent` implementations (Pooled, Nito, reference implementation).

### Run benchmarks locally

From repository root:

- Using the provided scripts:

  ```powershell
  # Run all benchmarks
  .\scripts\run-benchmarks.ps1

  # Filter to specific benchmarks
  .\scripts\run-benchmarks.ps1 -Filter "*AsyncLock*"

  # Run on specific framework and runtime
  .\scripts\run-benchmarks.ps1 -Framework net10.0 -Runtimes net10.0

  # List available benchmarks
  .\scripts\run-benchmarks.ps1 -List
  ```

  Or using the cmd wrapper:

  ```cmd
  scripts\run-benchmarks.cmd -Filter "*AsyncLock*"
  ```

- Or run BenchmarkSwitcher directly:

  ```cmd
  cd tests\Threading
  dotnet run -c Release --framework net10.0 -- --runtimes net10.0 --filter "*AsyncLock*"
  ```

Notes:
- Use `Release` builds for meaningful results.
- All benchmarks are also run as tests in NUnit to validate correctness.
- The test runner disables some BenchmarkDotNet validators because the test assembly references NUnit; keep the provided `ManualConfig` in `tests/Common/Main.cs`.
- Switch computer to high-performance mode and close other applications for more stable results.
- Benchmarks are non-parallelizable; run them on an otherwise idle machine for stable output.

### Where results appear

When run locally in `Release` mode, BenchmarkDotNet writes results and artifacts to:
- `tests/Threading/BenchmarkDotNet.Artifacts/results/`

After running benchmarks, use the update scripts to copy results to the documentation folder.

### Adding a new benchmark

1. Add a new `Benchmark` class under `tests/` following existing patterns in `tests/Threading/Async/Pooled/`.
2. Include `[Benchmark]` methods and `[GlobalSetup]` where needed.
3. Add a `[Params]` or `FixtureArgs` entry if parameterized runs are required.
4. Run locally and inspect generated artifacts in `tests/Threading/BenchmarkDotNet.Artifacts/results/`.

## Discussion of benchmark results

The benchmarks show that the pooled implementations generally have lower allocations and better performance under contention compared to popular existing libraries like Nito.AsyncEx and NeoSmart's AsyncLock.
However there can be usage patterns where the overhead of pooling and specific implementation details in the underlying ManualResetValueTaskSource lead to higher latency or allocations in low contention scenarios.
ValueTask/IValueTaskSource management may not yield benefits, especially in low contention scenarios.
When considering using these primitives in a production system, it's important to evaluate the specific workload characteristics and contention patterns to determine if the pooled implementations provide a net benefit.

---

## Benchmark Results

[!INCLUDE[Machine Specification](benchmarks/machine-spec.md)]

For this documentation all results are sorted by mean execution time, fastest first.
In general with the release of .NET 10 the results improved for the reference implementations against pooled compared to previous .NET versions, often outperforming now the pooled implementations but still requiring more memory allocations. However, due to lack of support for cancellation token in the reference implementation only the pooled and Nito versions are compared in these tables.

---

### AsyncLock Benchmarks

The benchmarks compare various `AsyncLock` implementations:

- PooledAsyncLock: The pooled implementation from this library
- RefImplAsyncLock: The reference implementation, which does not support cancellation tokens
- NitoAsyncLock: The implementation from Nito.AsyncEx library
- NeoSmartAsyncLock: The implementation from NeoSmart.AsyncLock library
- SemaphoreSlim: The .NET built-in synchronization primitive

#### AsyncLock Single (No Contention)

Single lock acquire/release performance without contention:

[!INCLUDE[AsyncLock Single Benchmark](benchmarks/asynclock-single.md)]

#### AsyncLock Multiple (With Contention)

Multiple concurrent lock operations with varying contention levels:

[!INCLUDE[AsyncLock Multiple Benchmark](benchmarks/asynclock-multiple.md)]

---

### AsyncAutoResetEvent Benchmarks

The benchmarks compare various `AsyncAutoResetEvent` implementations with the default platform `AutoResetEvent` on Windows:

- PooledAsyncAutoResetEvent: The pooled implementation from this library
- RefImplAsyncAutoResetEvent: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncAutoResetEvent: The implementation from Nito.AsyncEx library

#### AsyncAutoResetEvent Set Benchmark

Just the overhead of setting the event without any waiters. There is no contention and no allocation cost in all implementations.

[!INCLUDE[AsyncAutoResetEvent Set Benchmark](benchmarks/asyncautoresetevent-set.md)]

#### AsyncAutoResetEvent SetThenWait Benchmark

This is the fast path if the event is already Set and an immediate return from WaitAsync is possible. There is no contention and no allocation cost in all implementations.

[!INCLUDE[AsyncAutoResetEvent SetThenWait Benchmark](benchmarks/asyncautoresetevent-setthenw.md)]

#### AsyncAutoResetEvent WaitThenSet Benchmark

The series of tests measures the overhead of waiting on an unset event with varying contention levels (Iterations). Due to the different behavior of the pooled implementations with AsTask(), ValueTask and the RunContinuationAsynchronously flag, these variations are measured separately.

[!INCLUDE[AsyncAutoResetEvent WaitThenSet Benchmark](benchmarks/asyncautoresetevent-waitthenset.md)]

---

### AsyncManualResetEvent Benchmarks

The benchmarks compare various `AsyncManualResetEvent` implementations:

- PooledAsyncManualResetEvent: The pooled implementation from this library
- RefImplAsyncManualResetEvent: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncManualResetEvent: The implementation from Nito.AsyncEx library

Unlike `AsyncAutoResetEvent` which releases one waiter per signal, `AsyncManualResetEvent` releases **all waiters** when signaled and remains signaled until explicitly reset.

#### AsyncManualResetEvent Set/Reset Benchmark

Measures the overhead of setting and resetting the event without any waiters.

[!INCLUDE[AsyncManualResetEvent SetReset Benchmark](benchmarks/asyncmanualresetevent-setreset.md)]

#### AsyncManualResetEvent SetThenWait Benchmark

This is the fast path when the event is already set before waiting.

[!INCLUDE[AsyncManualResetEvent SetThenWait Benchmark](benchmarks/asyncmanualresetevent-setthenw.md)]

#### AsyncManualResetEvent WaitThenSet Benchmark

This benchmark measures signaling behavior when multiple waiters are queued. Unlike `AsyncAutoResetEvent`, all waiters are released simultaneously when the event is set.

[!INCLUDE[AsyncManualResetEvent WaitThenSet Benchmark](benchmarks/asyncmanualresetevent-waitthenset.md)]

---

### AsyncSemaphore Benchmarks

The benchmarks compare various semaphore implementations:

- PooledAsyncSemaphore: The pooled implementation from this library
- SemaphoreSlim: The .NET built-in synchronization primitive
- NitoAsyncSemaphore: The implementation from Nito.AsyncEx library

#### AsyncSemaphore Single (No Contention)

Single semaphore wait/release without contention:

[!INCLUDE[AsyncSemaphore Single Benchmark](benchmarks/asyncsemaphore-single.md)]

---

### AsyncCountdownEvent Benchmarks

The benchmarks compare countdown event implementations.

#### AsyncCountdownEvent Signal Benchmark

Signal operation performance:

[!INCLUDE[AsyncCountdownEvent Signal Benchmark](benchmarks/asynccountdownevent-signal.md)]

---

### AsyncBarrier Benchmarks

The benchmarks compare barrier implementations.

#### AsyncBarrier SignalAndWait Benchmark

Barrier synchronization with multiple participants:

[!INCLUDE[AsyncBarrier SignalAndWait Benchmark](benchmarks/asyncbarrier-signalandwait.md)]

---

### AsyncReaderWriterLock Benchmarks

The benchmarks compare reader-writer lock implementations.

#### AsyncReaderWriterLock Reader Benchmark

Reader lock acquisition performance:

[!INCLUDE[AsyncReaderWriterLock Reader Benchmark](benchmarks/asyncreaderwriterlock-reader.md)]

#### AsyncReaderWriterLock Writer Benchmark

Writer lock acquisition performance:

[!INCLUDE[AsyncReaderWriterLock Writer Benchmark](benchmarks/asyncreaderwriterlock-writer.md)]
