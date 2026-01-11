## Threading Benchmarks

This page documents how the benchmarks are executed which are included in the Threading library.

### Overview

BenchmarkDotNet is used for microbenchmarks. Benchmarks live under `tests/Threading/Async/Pooled/` and can be executed with the BenchmarkSwitcher entry point at `tests/Common/Main.cs`.

### Updating Benchmark Results

First run the benchmarks locally (see below).
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
- All pooled implementations are tested with cancellable and default CancellationTokens.
- For the pooled implementations, variations with AsTask() and await are separately benchmarked to capture the overhead.
- Some implementations that are tested against for reference do not support cancellation tokens and hence their benchmark result is out of contest.
- Some .NET built-in primitives (e.g. SemaphoreSlim) do not have async wait APIs and hence may not qualify to be tested in a single benchmark function because they would require multiple threads to emulate the tested behavior.

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
- Switch computer to high-performance power mode and close other applications for more stable results.
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
5. Update documentation using the provided scripts.

## See Also

- [Threading Package Overview](index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [AsyncCountdownEvent](asynccountdownevent.md) - Async countdown event
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive

---

© 2026 The Keepers of the CryptoHives
