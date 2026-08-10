## Threading Benchmarks

This page documents how the benchmarks are executed which are included in the Threading library.

### Overview

BenchmarkDotNet is used for microbenchmarks. Benchmarks live under `tests/Threading/Async/Pooled/` and can be executed with the BenchmarkSwitcher entry point at `tests/Common/Main.cs`.

### Viewing Benchmark Results

Published results live in the interactive benchmark trends dashboard below rather than static per-platform pages. The dashboard loads a small SQLite database client-side (no server) and lets you pick platform, primitive family, and operation, plotting every matching implementation as its own line — including a scaling-by-contention view and trend-over-time comparisons. Because `platform` is a free-form value in the database, results from any contributor's machine can appear side by side, not just a fixed set of CI hosts.

<iframe src="benchmark-trends/index.html" style="width:100%; height:900px; border:1px solid var(--border-color, #ddd); border-radius:6px;" loading="lazy" title="Threading benchmark trends dashboard"></iframe>

[Open the dashboard in its own page →](benchmark-trends/index.html)

### Recording a benchmark run

Recorded runs live on the orphan **`benchmarks`** branch, one directory per run:

```
threading/<code-commit>/<platform>/<framework>/
    run.json          what the numbers measure, and against which library versions
    machine-spec.md   the machine and runtime they were measured on
    <scenario>.md     one report per benchmark class
```

A run is keyed by the commit its binaries were built from, not by the commit that records it. Two machines measuring the same build therefore land in one run directory as two platform directories, which is what makes a cross-platform comparison possible at all.

The framework level below that does the same job for target frameworks: the same commit on the same machine under net10.0 and net8.0 is two runs, so the Table view can put them side by side exactly as it does two platforms. Pass `-Framework` to `run-benchmarks.ps1` and the matching `-TargetFramework` to `update-benchmark-docs.ps1`. A single run covering several runtimes at once (`-Runtimes "net8.0, net10.0"`) works too and needs neither: BenchmarkDotNet emits a `Runtime` column when the runtime varies, and each row is recorded against its own framework.

Run the benchmarks locally first (see below), then write the reports into a worktree of that branch:

```powershell
git worktree add ../foundation-bench benchmarks
.\scripts\update-benchmark-docs.ps1 -Project Threading -DestDir ../foundation-bench/threading
```

`update-benchmark-docs.ps1` derives a platform id from the report's machine-spec preamble (override with `-PlatformId` for self-reported machines) and writes `run.json`, defaulting the code commit to `HEAD` — pass `-CodeCommit` when recording a run after the fact, or when `HEAD` has moved on since the run. It never commits or pushes: review the result and commit in that worktree when the run is worth keeping.

It also records the version of every third-party library the run measured against, read from the benchmark project's resolved NuGet graph. A competitor's trend line steps when that competitor ships a release just as readily as when this library changes, and nothing else in a recorded run tells the two apart — `Microsoft.VisualStudio.Threading` moved 17.14.15 to 18.7.23 between runs already in the archive. The dashboard shows the version in each point's tooltip, and marks any compared row whose library moved between the two runs. Pass `-TargetFramework` if the benchmarks did not run on the default `net10.0`.

Pushing the branch does not republish the site on its own. The dashboard database is generated at build time rather than committed, so a new run becomes visible only when the docs workflow runs again — and a push to `benchmarks` cannot start it, because GitHub only runs workflows that exist in the pushed branch and that orphan branch carries no `.github/`. Publish it deliberately with `gh workflow run docfx.yml`, or let the next push to `main` pick it up.

### Rebuilding the dashboard database

`benchmark-history.sqlite` is a derived artifact, not a tracked file: SQLite rewrites pages throughout on every change, so committing it added a fresh multi-megabyte blob per rebuild for data that is fully reproducible from the archive. The docs workflow builds it, and so can you:

```powershell
.\scripts\build-trends-database.ps1          # from the committed branch, via a throwaway worktree
.\scripts\build-trends-database.ps1 -Archive ../foundation-bench   # including runs you have not committed
```

`.\scripts\run-docfx.ps1` does this for you before building, so the local site always has data.

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

After running benchmarks, see "Recording a benchmark run" above for how to record a run into the archive so it appears in the published dashboard.

### Adding a new benchmark

1. Add a new `Benchmark` class under `tests/` following existing patterns in `tests/Threading/Async/Pooled/`.
2. Include `[Benchmark]` methods and `[GlobalSetup]` where needed.
3. Add a `[Params]` or `FixtureArgs` entry if parameterized runs are required.
4. Run locally and inspect generated artifacts in `tests/Threading/BenchmarkDotNet.Artifacts/results/`.
5. Once the results look right, record the run into the archive (see "Recording a benchmark run" above). A new benchmark class also needs an entry in `scripts/update-benchmark-docs.ps1`, which maps report file names onto the archive's scenario names.

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
