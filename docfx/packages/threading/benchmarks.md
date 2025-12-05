## Threading Benchmarks

This page documents the benchmarks included in the Threading library.

### Overview

BenchmarkDotNet is used for microbenchmarks. Benchmarks live under `tests/Threading/Async/Pooled/` and can be executed with the BenchmarkSwitcher entry point at `tests/Common/Main.cs`.

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

#### AsyncAutoResetEvent Wait Benchmark

The benchmark measures the overhead of waiting on an unset event with no contention. Here the implementations have to start to allocate waiter objects. The pooled implementations can handle the requests without allocation and are almost on parity with the ref implementation. With the cancellation token an allocation is required for all implementations except the pooled one if compiled for .NET6+.

| Method                                      | cancellationType | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |----------------- |----------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventTaskWaitAsync     | None             |  24.48 ns |  1.00 |      96 B |        1.00 |
| **PooledAsyncAutoResetEventTaskWaitAsync**      | None             |  26.01 ns |  1.06 |         - |        0.00 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | None             |  29.89 ns |  1.22 |         - |        0.00 |
| NitoAsyncAutoResetEventTaskWaitAsync        | None             |  33.01 ns |  1.35 |     160 B |        1.67 |
|                                             |                  |           |       |           |             |
| **PooledAsyncAutoResetEventValueTaskWaitAsync** | NotCancelled     |  43.84 ns |     ? |         - |           ? |
| PooledAsyncAutoResetEventTaskWaitAsync      | NotCancelled     |  46.69 ns |     ? |         - |           ? |
| NitoAsyncAutoResetEventTaskWaitAsync        | NotCancelled     | 341.37 ns |     ? |     400 B |           ? |

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

With **10 iterations** (ten waiters), the cost of releasing all waiters becomes more apparent. The pooled implementation is slower than the reference implementation but maintains zero allocations:

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
|                                                                |            |                  |              |       |           |             |
| **PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync** | 10         | NotCancelled     |    518.46 ns |     ? |         - |           ? |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 10         | NotCancelled     |    520.64 ns |     ? |         - |           ? |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 10         | NotCancelled     |    533.18 ns |     ? |         - |           ? |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 10         | NotCancelled     |    553.67 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                           | 10         | NotCancelled     |    778.84 ns |     ? |     800 B |           ? |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 10         | NotCancelled     |  3,141.91 ns |     ? |    1240 B |           ? |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 10         | NotCancelled     |  4,231.36 ns |     ? |    6464 B |           ? |

With **100 iterations** (hundred waiters), the overhead of releasing all waiters is substantial, but the pooled implementation still provides zero allocations. The reference implementation is fastest but allocates per waiter. With cancellation tokens, the pooled implementation significantly outperforms Nito.AsyncEx:

| Method                                                         | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|--------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventWaitThenSetAsync                   | 100        | None             |    568.25 ns |  1.00 |      96 B |        1.00 |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 100        | None             |  1,008.70 ns |  1.78 |      96 B |        1.00 |
| **PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync** | 100        | None             |  3,216.88 ns |  5.66 |         - |        0.00 |
| PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync         | 100        | None             |  3,220.85 ns |  5.67 |         - |        0.00 |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 100        | None             |  3,437.26 ns |  6.05 |         - |        0.00 |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 100        | None             |  3,444.67 ns |  6.06 |         - |        0.00 |
| PooledAsTaskContSync                                           | 100        | None             |  5,138.45 ns |  9.04 |    8000 B |       83.33 |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 100        | None             | 16,021.67 ns | 28.20 |   11321 B |      117.93 |
|                                                                |            |                  |              |       |           |             |
| **PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync**         | 100        | NotCancelled     |  4,840.71 ns |     ? |         - |           ? |
| PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync | 100        | NotCancelled     |  4,844.07 ns |     ? |         - |           ? |
| PooledContSyncAsyncManualResetEventWaitThenSetAsync            | 100        | NotCancelled     |  4,965.78 ns |     ? |         - |           ? |
| PooledAsyncManualResetEventWaitThenSetAsync                    | 100        | NotCancelled     |  5,245.90 ns |     ? |         - |           ? |
| PooledAsTaskContSync                                           | 100        | NotCancelled     |  7,508.13 ns |     ? |    8000 B |           ? |
| NitoAsyncManualResetEventWaitThenSetAsync                      | 100        | NotCancelled     | 37,276.17 ns |     ? |   61650 B |           ? |
| PooledAsTaskManualResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 77,166.22 ns |     ? |   11361 B |           ? |

**Summary:** `AsyncManualResetEvent` pooled implementations trade latency for memory efficiency. When you have many waiters that need to be released simultaneously, the reference implementation is faster but allocates per-waiter. The pooled implementation maintains zero allocations regardless of contention level, making it ideal for sustained high-throughput scenarios where memory pressure matters more than absolute latency. Avoid `AsTask()` conversion with `RunContinuationAsynchronously=true` for best performance.

### AsyncLock Benchmarks

A research of available AsyncLock implementations was done and the following popular implementations were included in the benchmarks:
- PooledAsyncLock: The pooled implementation from this library
- RefImplAsyncLock: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NonKeyedAsyncLock: The implementation from the AsyncKeyedLock library by Mark Cilia Vincenti, which supports cancellation tokens but is out of competition due to its support of nested async locks
- NitoAsyncLock: The implementation from Nito.AsyncEx library
- NeoSmartAsyncLock: The implementation from the NeoSmart.Async library
- SemaphoreSlim: The classic SemaphoreSlim used as an AsyncLock

#### AsyncLock Single Benchmark

The overhead of various synchronization methods without contention.
The standard lock patterns including the new .NET 9 `Lock` and `LockEnterScope` method are measured alongside interlocked increment and a simple increment baseline.

First the classic synchronization methods, increment and Interlocked.Increment as reference:

| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| IncrementSingle                    |  0.0054 ns | 0.000 |         - |          NA |
| InterlockedIncrementSingle         |  0.2067 ns | 0.010 |         - |          NA |
| LockEnterScopeSingle               |  3.3855 ns | 0.160 |         - |          NA |
| LockUnlockSingle                   |  3.4291 ns | 0.162 |         - |          NA |
| ObjectLockUnlockSingle             |  4.3611 ns | 0.207 |         - |          NA |

The new .NET 9 `Lock` and `LockEnterScope` methods are slightly faster than a classic lock statement. Apparently it's interesting to see here that an Interlocked operation is still significantly faster than any locking mechanism with an increment.

Next, various AsyncLock implementations without contention and without cancellation token:

| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| **LockUnlockPooledSingleAsync**        | 13.4359 ns | 0.637 |         - |          NA |
| LockUnlockSemaphoreSlimSingleAsync | 19.2174 ns | 0.910 |         - |          NA |
| LockUnlockRefImplSingleAsync       | 21.1066 ns | 1.000 |         - |          NA |
| LockUnlockNonKeyedSingleAsync      | 22.7554 ns | 1.078 |         - |          NA |
| LockUnlockNitoSingleAsync          | 41.8696 ns | 1.984 |     320 B |          NA |
| LockUnlockNeoSmartSingleAsync      | 61.7783 ns | 2.927 |     208 B |          NA |

The pooled implementation is the fastest AsyncLock implementation, followed by the reference implementation.
SemaphoreSlim and NonKeyedAsyncLock have moderate overhead, while Nito.AsyncEx and NeoSmart's AsyncLock have the highest overhead and they need allocations.

#### AsyncLock Multiple Benchmark with varying contention (Iterations)

The case with 0 iterations measures the uncontested lock/unlock overhead with multiple concurrent waiters and with a cancellation token.
Benchmarks with 1, 10, and 100 iterations measure the behavior under contention with increasing number of concurrent waiters.
In addition to the previous uncontested benchmark, the pooled implementation with AsTask() is included to show the overhead of ValueTask/IValueTaskSource management with conversion to Task.
All implementations happen to deal efficiently with an uncostested lock even with cancellation token.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| **LockUnlockPooledMultipleAsync**        | 0          | None             |     14.08 ns |  0.67 |         - |          NA |
| LockUnlockPooledTaskMultipleAsync    | 0          | None             |     15.01 ns |  0.71 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          | None             |     20.42 ns |  0.97 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          | None             |     21.04 ns |  1.00 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          | None             |     23.78 ns |  1.13 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          | None             |     43.51 ns |  2.07 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          | None             |     65.92 ns |  3.13 |     208 B |          NA |
|                                      |            |                  |              |       |           |             |
| **LockUnlockPooledMultipleAsync**        | 0          | NotCancelled     |     14.12 ns |     ? |         - |           ? |
| LockUnlockPooledTaskMultipleAsync    | 0          | NotCancelled     |     15.35 ns |     ? |         - |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 0          | NotCancelled     |     19.67 ns |     ? |         - |           ? |
| LockUnlockNonKeyedMultipleAsync      | 0          | NotCancelled     |     24.43 ns |     ? |         - |           ? |
| LockUnlockNitoMultipleAsync          | 0          | NotCancelled     |     42.91 ns |     ? |     320 B |           ? |
| LockUnlockNeoSmartMultipleAsync      | 0          | NotCancelled     |     62.93 ns |     ? |     208 B |           ? |

The case with 1 iteration measures the overhead of a single waiter for the contested lock. Noticeable the pooled implementation is the fastest here because of the local value task source, SemaphoreSlim almost on parity and the reference implementation a lot slower.
The pooled implementation with an AsTask() conversion, due to the RunContinuationsAsynchronously=true causes a high performance degradation and a moderate allocation in the underlying IValueTaskSource implementation.
However only because in the benchmark the Task is awaited outside the lock, which causes to hit that inefficient code path in the IValueTaskSource.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| **LockUnlockPooledMultipleAsync**        | 1          | None             |     41.79 ns |  0.51 |         - |        0.00 |
| LockUnlockSemaphoreSlimMultipleAsync | 1          | None             |     46.54 ns |  0.57 |      88 B |        0.41 |
| LockUnlockRefImplMultipleAsync       | 1          | None             |     81.51 ns |  1.00 |     216 B |        1.00 |
| LockUnlockNitoMultipleAsync          | 1          | None             |    103.40 ns |  1.27 |     728 B |        3.37 |
| LockUnlockNeoSmartMultipleAsync      | 1          | None             |    129.47 ns |  1.59 |     416 B |        1.93 |
| LockUnlockPooledTaskMultipleAsync    | 1          | None             |    460.20 ns |  5.65 |     272 B |        1.26 |
| LockUnlockNonKeyedMultipleAsync      | 1          | None             |    511.72 ns |  6.28 |     352 B |        1.63 |
|                                      |            |                  |              |       |           |             |
| **LockUnlockPooledMultipleAsync**        | 1          | NotCancelled     |     60.39 ns |     ? |         - |           ? |
| LockUnlockNeoSmartMultipleAsync      | 1          | NotCancelled     |    128.10 ns |     ? |     416 B |           ? |
| LockUnlockNitoMultipleAsync          | 1          | NotCancelled     |    413.92 ns |     ? |     968 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 1          | NotCancelled     |    528.06 ns |     ? |     272 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 1          | NotCancelled     |    579.05 ns |     ? |     504 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 1          | NotCancelled     |    705.81 ns |     ? |     640 B |           ? |

The case with 10 iterations manifests the same behavior with moderate contention, as the ObjectPool is not exhausted. But SemaphoreSlim is now the fastest implementation, although using moderate allocations, followed by the pooled implementation.
With cancellation token the pooled implementations outperform others except NeoSmart by at least 5 times AND doesn't allocate extra memory.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 10         | None             |    304.43 ns |  0.44 |     880 B |        0.41 |
| **LockUnlockPooledMultipleAsync**        | 10         | None             |    367.17 ns |  0.53 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 10         | None             |    607.12 ns |  0.87 |    4400 B |        2.04 |
| LockUnlockRefImplMultipleAsync       | 10         | None             |    695.61 ns |  1.00 |    2160 B |        1.00 |
| LockUnlockNeoSmartMultipleAsync      | 10         | None             |    699.72 ns |  1.01 |    2288 B |        1.06 |
| LockUnlockPooledTaskMultipleAsync    | 10         | None             |  3,073.14 ns |  4.42 |    1352 B |        0.63 |
| LockUnlockNonKeyedMultipleAsync      | 10         | None             |  3,243.04 ns |  4.66 |    2296 B |        1.06 |
|                                      |            |                  |              |       |           |             |
| **LockUnlockPooledMultipleAsync**        | 10         | NotCancelled     |    541.77 ns |     ? |         - |           ? |
| LockUnlockNeoSmartMultipleAsync      | 10         | NotCancelled     |    707.20 ns |     ? |    2288 B |           ? |
| LockUnlockNitoMultipleAsync          | 10         | NotCancelled     |  2,899.35 ns |     ? |    6800 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 10         | NotCancelled     |  3,568.60 ns |     ? |    1352 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 10         | NotCancelled     |  4,328.64 ns |     ? |    3888 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 10         | NotCancelled     |  5,149.05 ns |     ? |    5176 B |           ? |

On the case with 100 iterations the pooled implementation is again slower than the semaphore slim implementation but still allocates no memory, because the ObjectPool defaults to 128 items. For the cancellable case, the pooled implementation has still no allocations in contrary to the other implementations.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 100        | None             |  2,797.20 ns |  0.42 |    8800 B |        0.41 |
| **LockUnlockPooledMultipleAsync**        | 100        | None             |  3,481.82 ns |  0.52 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 100        | None             |  5,994.04 ns |  0.90 |   41120 B |        1.90 |
| LockUnlockNeoSmartMultipleAsync      | 100        | None             |  6,414.68 ns |  0.96 |   21008 B |        0.97 |
| LockUnlockRefImplMultipleAsync       | 100        | None             |  6,694.16 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 100        | None             | 33,296.81 ns |  4.97 |   12216 B |        0.57 |
| LockUnlockNonKeyedMultipleAsync      | 100        | None             | 34,825.87 ns |  5.20 |   21800 B |        1.01 |
|                                      |            |                  |              |       |           |             |
| **LockUnlockPooledMultipleAsync**        | 100        | NotCancelled     |  5,149.70 ns |     ? |         - |           ? |
| LockUnlockNeoSmartMultipleAsync      | 100        | NotCancelled     |  6,522.29 ns |     ? |   21008 B |           ? |
| LockUnlockNitoMultipleAsync          | 100        | NotCancelled     | 28,969.26 ns |     ? |   65120 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 100        | NotCancelled     | 35,583.80 ns |     ? |   12216 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 100        | NotCancelled     | 42,677.37 ns |     ? |   37792 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 100        | NotCancelled     | 51,308.63 ns |     ? |   50600 B |           ? |

---

© 2025 The Keepers of the CryptoHives
