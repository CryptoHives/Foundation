
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

- Using the provided script (Windows):
  - `tests\benchmarks.cmd` — adjust the target framework in the script or use the included parameters.

- Or run BenchmarkSwitcher directly:
  - dotnet run -p tests --configuration Release --framework net10.0 -- --runtimes net10.0 --filter AsyncLock*

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

### Benchmark results

Benchmarks were run on a machine with the following specifications:

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
```

For this documentation all results are sorted by mean execution time, fastest first. 
In general with the release of .NET 10 the results improved for the reference implementations against pooled compared to previous .NET versions, often outperforming now the pooled implementations but still requiring more memory allocations. However, due to lack of support for cancellation token in the reference implementation only the pooled and Nito versions are compared in these tables.

### AsyncAutoResetEvent Benchmarks

The benchmarks compare various `AsyncAutoResetEvent` implementations with the default platform `AutoResetEvent` on Windows:

- PooledAsyncAutoResetEvent: The pooled implementation from this library
- RefImplAsyncAutoResetEvent: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncAutoResetEvent: The implementation from Nito.AsyncEx library

#### AsyncAutoResetEvent Set Benchmark

Just the overhead of setting the event without any waiters. There is no contention and no allocation cost in all implementations.

| Method                        | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------:|----------:|------------:|
| **PooledAsyncAutoResetEventSet**  |   3.913 ns |  0.88 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   4.454 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   4.542 ns |  1.02 |         - |          NA |
| AutoResetEventSet             | 230.497 ns | 51.75 |         - |          NA |

#### AsyncAutoResetEvent SetThenWait Benchmark

This is the fast path if the event is already Set and an immediate return from WaitAsync is possible. There is no contention and no allocation cost in all implementations.

| Method                                          | Mean     | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------ |---------:|------:|----------:|------------:|
| **PooledAsyncAutoResetEventSetThenWaitAsync**       | 10.66 ns |  0.61 |         - |          NA |
| PooledAsTaskAsyncAutoResetEventSetThenWaitAsync | 11.08 ns |  0.63 |         - |          NA |
| NitoAsyncAutoResetEventSetThenWaitAsync         | 16.39 ns |  0.93 |         - |          NA |
| RefImplAsyncAutoResetEventSetThenWaitAsync      | 17.53 ns |  1.00 |         - |          NA |


#### AsyncAutoResetEvent WaitThenSet Benchmark with varying contention (Iterations)

The series of tests measures the overhead of waiting on an unset event with varying contention levels (Iterations). Due to the different behavior of the pooled implementations with AsTask(), ValueTask and the RunContinuationAsynchronously flag, these variations are measured separately.
PooledAsTask is allocating a Task for awaiting, hence it adds to memory. ContSync is the tag that uses disabled RunContinuationsAsynchronously. Nevertheless, all of the pooled implementations using ValueTask avoid allocations and show better performance under contention.

With one iteration, the result is similar to the previous Wait benchmark, but the pooled implementations with ValueTask show slightly better performance. It can be seen that awaiting with AsTask adds heavy overhead and extra allocations. This is due to the implementation in ManualResetValueTaskSource when RunContinuationsAsynchronously is enabled.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None             |      28.56 ns |  0.92 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None             |      29.27 ns |  0.95 |         - |        0.00 |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 1          | None             |      30.60 ns |  0.99 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None             |      30.94 ns |  1.00 |      96 B |        1.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None             |      31.47 ns |  1.02 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None             |      37.40 ns |  1.21 |     160 B |        1.67 |
| PooledAsTaskContSync                                         | 1          | None             |      43.44 ns |  1.40 |      80 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None             |     374.69 ns | 12.11 |     232 B |        2.42 |
|                                                              |            |                  |               |       |           |             |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 1          | NotCancelled     |      45.23 ns |     ? |         - |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | NotCancelled     |      45.57 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | NotCancelled     |      45.94 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | NotCancelled     |      48.71 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                         | 1          | NotCancelled     |      70.23 ns |     ? |      80 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | NotCancelled     |     330.53 ns |     ? |     400 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | NotCancelled     |     474.32 ns |     ? |     232 B |           ? |

With two iterations, contention starts to increase in a linear fashion. The pooled implementations with ValueTask again show the best performance and no allocations, only outperformed by the reference implementation. The RefImpl and Nito implementations start to allocate more memory due to multiple waiters. The PooledAsTask implementation again shows the highest overhead due to the Task allocations per waiter.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None             |      59.32 ns |  1.00 |     192 B |        1.00 |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 2          | None             |      70.20 ns |  1.18 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None             |      70.26 ns |  1.18 |     320 B |        1.67 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None             |      72.59 ns |  1.22 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None             |      72.72 ns |  1.23 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None             |      79.44 ns |  1.34 |         - |        0.00 |
| PooledAsTaskContSync                                         | 2          | None             |     108.11 ns |  1.82 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None             |     812.66 ns | 13.70 |     344 B |        1.79 |
|                                                              |            |                  |               |       |           |             |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 2          | NotCancelled     |      96.07 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | NotCancelled     |      98.60 ns |     ? |         - |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | NotCancelled     |      99.33 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | NotCancelled     |     100.63 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                         | 2          | NotCancelled     |     147.87 ns |     ? |     160 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | NotCancelled     |     619.72 ns |     ? |     800 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | NotCancelled     |     931.10 ns |     ? |     344 B |           ? |

With ten iterations, contention increases further. The pooled implementations with ValueTask continue to show strong performance and zero allocations, only outperformed by the reference implementation that doesn't support cancellation tokens. The RefImpl and Nito implementations allocate even more memory due to the increased number of waiters. The PooledAsTask implementation continues to show the highest overhead due to Task allocations per waiter, but remains as fast as the pooled implementations.
The only pooled outlier uses AsTask with async continuations, a combination that should really be avoided based on these results. With cancellation token the pooled implementations outperform Nito by at least 5 times.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None             |     291.32 ns |  1.00 |     960 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None             |     342.20 ns |  1.17 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None             |     350.56 ns |  1.20 |         - |        0.00 |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 10         | None             |     359.11 ns |  1.23 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None             |     359.64 ns |  1.23 |    1600 B |        1.67 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None             |     360.86 ns |  1.24 |         - |        0.00 |
| PooledAsTaskContSync                                         | 10         | None             |     520.19 ns |  1.79 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None             |   2,383.24 ns |  8.18 |    1240 B |        1.29 |
|                                                              |            |                  |               |       |           |             |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | NotCancelled     |     493.33 ns |     ? |         - |           ? |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 10         | NotCancelled     |     502.97 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | NotCancelled     |     508.14 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | NotCancelled     |     510.85 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                         | 10         | NotCancelled     |     740.64 ns |     ? |     800 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | NotCancelled     |   2,687.88 ns |     ? |    4000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | NotCancelled     |   3,118.89 ns |     ? |    1240 B |           ? |

With 100 iterations, contention is high. The pooled implementations with ValueTask still show the best performance and still doesn't get into allocations, because the queue and ObjectPool are set to higher values. The RefImpl and Nito implementations allocate significant memory due to the large number of waiters. The PooledAsTask version cannot keep up with the other implementations by means of perf and memory.
With cancellation token the pooled implementations outperform Nito by almost 10 times, if AsTask() is not being used.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None             |   2,789.32 ns |  1.00 |    9600 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None             |   3,149.86 ns |  1.13 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None             |   3,156.97 ns |  1.13 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None             |   3,478.59 ns |  1.25 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None             |   3,615.64 ns |  1.30 |   16000 B |        1.67 |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 100        | None             |   3,713.97 ns |  1.33 |         - |        0.00 |
| PooledAsTaskContSync                                         | 100        | None             |   5,029.70 ns |  1.80 |    8000 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None             |  15,086.62 ns |  5.41 |   11320 B |        1.18 |
|                                                              |            |                  |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | NotCancelled     |   4,799.01 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | NotCancelled     |   4,824.36 ns |     ? |         - |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | NotCancelled     |   4,868.17 ns |     ? |         - |           ? |
| **PooledAsyncAutoResetEventWaitThenSetAsync**                    | 100        | NotCancelled     |   4,908.89 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                         | 100        | NotCancelled     |   7,189.91 ns |     ? |    8000 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | NotCancelled     |  41,873.17 ns |     ? |   40000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 247,247.20 ns |     ? |   11347 B |           ? |

### AsyncManualResetEvent Benchmarks

The benchmarks compare various `AsyncManualResetEvent` implementations:

- PooledAsyncManualResetEvent: The pooled implementation from this library
- RefImplAsyncManualResetEvent: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncManualResetEvent: The implementation from Nito.AsyncEx library

Unlike `AsyncAutoResetEvent` which releases one waiter per signal, `AsyncManualResetEvent` releases **all waiters** when signaled and remains signaled until explicitly reset. This creates different performance characteristics and allocation patterns.

#### AsyncManualResetEvent Set/Reset Benchmark

Measures the overhead of setting and resetting the event without any waiters. The pooled implementation shows the best performance with zero allocations.

| Method                               | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |-----------:|------:|----------:|------------:|
| **PooledAsyncManualResetEventSetReset**  |   8.616 ns |  0.80 |         - |        0.00 |
| RefImplAsyncManualResetEventSetReset |  10.787 ns |  1.00 |      96 B |        1.00 |
| NitoAsyncManualResetEventSetReset    |  21.765 ns |  2.02 |      96 B |        1.00 |
| ManualResetEventSet                  | 459.853 ns | 42.64 |         - |        0.00 |

#### AsyncManualResetEvent SetThenWait Benchmark

This is the fast path when the event is already set before waiting. All async implementations complete synchronously with minimal overhead. The reference implementation is fastest, but the pooled implementation is competitive with zero allocations.

| Method                                            | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------------- |----------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventSetThenWaitAsync      |  6.676 ns |  1.00 |         - |          NA |
| **PooledAsyncManualResetEventSetThenWaitAsync**       | 14.065 ns |  2.11 |         - |          NA |
| PooledAsTaskAsyncManualResetEventSetThenWaitAsync | 14.328 ns |  2.15 |         - |          NA |
| NitoAsyncManualResetEventSetThenWaitAsync         | 23.025 ns |  3.45 |         - |          NA |

#### AsyncManualResetEvent WaitThenSet Benchmark with varying contention (Iterations)

This benchmark measures signaling behavior when multiple waiters are queued. Unlike `AsyncAutoResetEvent`, all waiters are released simultaneously when the event is set. This creates more overhead as the number of waiters increases, but the pooled implementation maintains zero allocations even under high contention.

**Key Insight:** The pooled implementation's overhead increases with waiter count because each waiter needs its own `IValueTaskSource`. In contrast, Task-based implementations can share a single `Task` for all waiters. Despite this, the pooled version still provides better memory characteristics under sustained load. Also when a cancellable token is used, the pooled version outperforms all other versions.

With **1 iteration** (single waiter), the pooled implementations show competitive performance with zero allocations:

| Method                                                         | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 1          | None             |     20.29 ns |  1.00 |      96 B |        1.00 |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 1          | None             |     31.36 ns |  1.55 |      96 B |        1.00 |
| **PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync**         | 1          | None             |     42.88 ns |  2.12 |         - |        0.00 |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 1          | None             |     43.58 ns |  2.15 |         - |        0.00 |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 1          | None             |     43.68 ns |  2.15 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 1          | None             |     43.76 ns |  2.16 |         - |        0.00 |
| PooledAsTaskContSync                                           | 1          | None             |     59.86 ns |  2.95 |      80 B |        0.83 |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 1          | None             |    377.14 ns | 18.60 |     232 B |        2.42 |
|                                                                |            |                  |              |       |           |             |
| **PooledAsyncManualResetEventWaitThenSetAsync**                    | 1          | NotCancelled     |     57.39 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 1          | NotCancelled     |     59.38 ns |     ? |         - |           ? |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 1          | NotCancelled     |     60.11 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 1          | NotCancelled     |     61.87 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                           | 1          | NotCancelled     |     83.01 ns |     ? |      80 B |           ? |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 1          | NotCancelled     |    467.26 ns |     ? |     232 B |           ? |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 1          | NotCancelled     |    702.69 ns |     ? |     808 B |           ? |

With **2 iterations** (two waiters), overhead starts to show as all waiters must be released simultaneously. Pooled implementations maintain zero allocations:

| Method                                                         | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 2          | None             |     26.78 ns |  1.00 |      96 B |        1.00 |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 2          | None             |     48.21 ns |  1.80 |      96 B |        1.00 |
| **PooledAsyncManualResetEventWaitThenSetAsync**                    | 2          | None             |     78.87 ns |  2.94 |         - |        0.00 |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 2          | None             |     80.28 ns |  3.00 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 2          | None             |     82.12 ns |  3.07 |         - |        0.00 |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 2          | None             |     85.81 ns |  3.20 |         - |        0.00 |
| PooledAsTaskContSync                                           | 2          | None             |    118.24 ns |  4.41 |     160 B |        1.67 |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 2          | None             |    821.80 ns | 30.68 |     344 B |        3.58 |
|                                                                |            |                  |              |       |           |             |
| **PooledAsyncManualResetEventWaitThenSetAsync**                    | 2          | NotCancelled     |    106.60 ns |     ? |         - |           ? |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 2          | NotCancelled     |    107.65 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 2          | NotCancelled     |    120.10 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 2          | NotCancelled     |    121.45 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                           | 2          | NotCancelled     |    169.77 ns |     ? |     160 B |           ? |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 2          | NotCancelled     |    928.79 ns |     ? |     344 B |           ? |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 2          | NotCancelled     |  1,232.19 ns |     ? |    1488 B |           ? |

With **10 iterations**, the cost of releasing all waiters becomes more apparent. The pooled implementation is slower than the reference implementation but maintains zero allocations:

| Method                                                         | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 10         | None             |    568.25 ns |  1.00 |      96 B |        1.00 |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | None             |  1,008.70 ns |  1.78 |      96 B |        1.00 |
| **PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync**         | 10         | None             |    360.97 ns |  5.10 |         - |        0.00 |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | None             |    368.02 ns |  5.20 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 10         | None             |    382.85 ns |  5.41 |         - |        0.00 |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | None             |    390.19 ns |  5.51 |         - |        0.00 |
| PooledAsTaskContSync                                           | 10         | None             |    565.94 ns |  7.99 |     800 B |        8.33 |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | None             |  2,425.78 ns | 34.25 |    1240 B |       12.92 |
|                                                              |            |                  |               |       |           |             |
| **PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync** | 10         | NotCancelled     |    518.46 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 10         | NotCancelled     |    520.64 ns |     ? |         - |           ? |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | NotCancelled     |    533.18 ns |     ? |         - |           ? |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | NotCancelled     |    553.67 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                           | 10         | NotCancelled     |    778.84 ns |     ? |     800 B |           ? |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | NotCancelled     |  3,141.91 ns |     ? |    1240 B |           ? |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | NotCancelled     |  4,231.36 ns |     ? |    6464 B |           ? |

On the case with **100 iterations** the pooled implementation is again slower than the semaphore slim implementation but still allocates no memory, because the ObjectPool defaults to 128 items. For the cancellable case, the pooled implementation has still no allocations in contrary to the other implementations.

| Method                                                         | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|--------------------------------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 100        | None             |  2,797.20 ns |  0.42 |    8800 B |        0.41 |
| **LockUnlockPooledMultipleAsync**        | 100        | None             |  3,481.82 ns |  0.52 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 100        | None             |  5,994.04 ns |  0.90 |   41120 B |        1.90 |
| LockUnlockNeoSmartMultipleAsync      | 100        | None             |  6,414.68 ns |  0.96 |   21008 B |        0.97 |
| LockUnlockRefImplMultipleAsync       | 100        | None             |  6,694.16 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 100        | None             | 33,296.81 ns |  4.97 |   12216 B |        0.57 |
| LockUnlockNonKeyedMultipleAsync      | 100        | None             | 34,825.87 ns |  5.20 |   21800 B |        1.06 |
|                                      |            |                  |              |       |           |             |
| **LockUnlockPooledMultipleAsync**        | 100        | NotCancelled     |  5,149.70 ns |     ? |         - |           ? |
| LockUnlockNeoSmartMultipleAsync      | 100        | NotCancelled     |  6,522.29 ns |     ? |   21008 B |           ? |
| LockUnlockNitoMultipleAsync          | 100        | NotCancelled     | 28,969.26 ns |     ? |   65120 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 100        | NotCancelled     | 35,583.80 ns |     ? |   12216 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 100        | NotCancelled     | 42,677.37 ns |     ? |   37792 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 100        | NotCancelled     | 51,308.63 ns |     ? |   50600 B |           ? |
