## Threading Benchmarks

This page documents how the benchmarks are executed which are included in the Threading library.

### Overview

BenchmarkDotNet is used for microbenchmarks. Benchmarks live under `tests/Threading/Async/Pooled/` and can be executed with the BenchmarkSwitcher entry point at `tests/Common/Main.cs`.

### Viewing Benchmark Results

Published results live in the interactive benchmark trends dashboard below rather than static per-platform pages. The dashboard loads a small SQLite database client-side (no server) and lets you pick platform, primitive family, and operation, plotting every matching implementation as its own line — including a scaling-by-contention view and trend-over-time comparisons. Because `platform` is a free-form value in the database, results from any contributor's machine can appear side by side, not just a fixed set of CI hosts.

<iframe src="benchmark-trends/index.html" style="width:100%; height:900px; border:1px solid var(--border-color, #ddd); border-radius:6px;" loading="lazy" title="Threading benchmark trends dashboard"></iframe>

[Open the dashboard in its own page →](benchmark-trends/index.html)

### Recording a benchmark run

First run the benchmarks locally (see below). For a quick local before/after comparison, mirror the generated markdown into a scratch folder (not published, see `.gitignore`):

```powershell
.\scripts\update-benchmark-docs.ps1 -Project Threading
```

Only if the run is worth keeping as a trend data point, record it into the tracked dashboard database — a deliberate, separate step since not every local run needs to become history:

```powershell
.\scripts\threading-benchmark-trends\record-benchmark-run.ps1
```

The script derives a platform id from the report's machine-spec preamble (override with `-PlatformId` for self-reported/custom machines), tags the run with the current commit/branch, and appends it to `benchmark-trends/benchmark-history.sqlite`. It never commits or pushes — review the diff and commit yourself if you want the run published.

### Included benchmark suites

Benchmarking contention is tricky and not all possible scenarios can be covered.
The included benchmarks try uncontested and contested scenarios:

- Run with no contention (single waiter) to measure baseline overhead.
- Run with multiple concurrent waiters to measure contention behavior. The number of waiters is increased to measure memory allocations and execution time.
- All pooled implementations are tested with cancellable and default CancellationTokens.
- For the pooled implementations, variations with AsTask() and await are separately benchmarked to capture the overhead.
- Newer comparison sets include ProtoPromise and Microsoft.VisualStudio.Threading where the corresponding primitive exists and can be exercised fairly on the target framework.
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

After running benchmarks, see "Recording a benchmark run" above for how to compare locally or record a run into the published dashboard.

### Adding a new benchmark

1. Add a new `Benchmark` class under `tests/` following existing patterns in `tests/Threading/Async/Pooled/`.
2. Include `[Benchmark]` methods and `[GlobalSetup]` where needed.
3. Add a `[Params]` or `FixtureArgs` entry if parameterized runs are required.
4. Run locally and inspect generated artifacts in `tests/Threading/BenchmarkDotNet.Artifacts/results/`.
5. Once the results look right, record the run into the trends dashboard (see "Recording a benchmark run" above).

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
