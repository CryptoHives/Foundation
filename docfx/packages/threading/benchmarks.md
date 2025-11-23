## Threading Benchmarks

This page documents the benchmarks included in the Threading library.

### Overview

BenchmarkDotNet is used for microbenchmarks. Benchmarks live under `tests/Threading/Async/Pooled/` and can be executed with the BenchmarkSwitcher entry point at `tests/Common/Main.cs`.

### Included benchmark suites

Benchmarking contention is tricky and not all possible scenarios can be covered. 
The included benchmarks try uncontestested and contested scenarios:

- Run with no contention (single waiter) to measure baseline overhead.
- Run with multiple concurrent waiters to measure contention behavior. The number of waiters is increased to measure memory allocations and execution time.
- For the pooled implementations, variations with AsTask() and await are separately benchmarked.

- `tests/Threading/Async/Pooled/AsyncLock*Benchmark.cs` — single and multiple queued waiters for various `AsyncLock` implementations (Pooled, Nito, AsyncKeyedLock, reference implementation, NeoSmart).  
- `tests/Threading/Async/Pooled/AsyncAutoResetEvent*Benchmark.cs` — set/wait and contention scenarios for `AsyncAutoResetEvent` implementations (Pooled, Nito, reference implementation).

### Where results appear

When run locally in `Release` mode, BenchmarkDotNet writes results and artifacts to:
- `tests/Threading/BenchmarkDotNet.Artifacts/results/`

Precomputed Markdown reports for some runs are available in the repository under:
- `tests/Threading/BenchmarkDotNet.Artifacts/results/Threading.Tests.Async.Pooled.AsyncLockSingleBenchmark-report-github.md`  
- `tests/Threading/BenchmarkDotNet.Artifacts/results/Threading.Tests.Async.Pooled.AsyncAutoResetEventSetBenchmark-report-github.md`  
- `tests/Threading/BenchmarkDotNet.Artifacts/results/Threading.Tests.Async.Pooled.AsyncLockMultipleBenchmark-report-github.md`  
(There are additional per-benchmark reports in the same folder.)

### Discussion of results

The benchmarks show that the pooled implementations generally have lower allocations and better performance under contention compared to popular existing libraries like Nito.AsyncEx and NeoSmart's AsyncLock.
However there can be usage patterns where the overhead of pooling and specific implementation details in the underlying ManualResetValueTaskSource lead to higher latency or allocations in low contention scenarios.
ValueTask/IValueTaskSource management may not yield benefits, especially in low contention scenarios.
When considering using these primitives in a production system, it's important to evaluate the specific workload characteristics and contention patterns to determine if the pooled implementations provide a net benefit.

### Run benchmarks locally

From repository root:

- Using the provided script (Windows):
  - `tests\benchmarks.cmd` — adjust the target framework in the script or use the included parameters.

- Or run BenchmarkSwitcher directly:
  - dotnet run -p tests --configuration Release --framework net9.0 -- --runtimes net9.0 --filter AsyncLock*

Notes:
- Use `Release` builds for meaningful results.
- All benchmarks are also run as tests in NUnit to validate correctness.
- The test runner disables some BenchmarkDotNet validators because the test assembly references NUnit; keep the provided `ManualConfig` in `tests/Common/Main.cs`.
- Benchmarks are non-parallelizable; run them on an otherwise idle machine for stable output.

### Adding a new benchmark

1. Add a new `Benchmark` class under `tests/` following existing patterns in `tests/Threading/Async/Pooled/`.
2. Include `[Benchmark]` methods and `[GlobalSetup]` where needed.
3. Add a `[Params]` or `FixtureArgs` entry if parameterized runs are required.
4. Run locally and inspect generated artifacts in `tests/Threading/BenchmarkDotNet.Artifacts/results/`.
