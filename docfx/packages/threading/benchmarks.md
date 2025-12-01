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
BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
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
| PooledAsyncAutoResetEventSet  |   3.909 ns |  0.90 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   4.348 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   4.541 ns |  1.04 |         - |          NA |
| AutoResetEventSet             | 229.109 ns | 52.69 |         - |          NA |

#### AsyncAutoResetEvent SetThenWait Benchmark

This is the fast path if the event is already Set and an immediate return from WaitAsync is possible. There is no contention and no allocation cost in all implementations.

| Method                                          | Mean     | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------ |---------:|------:|----------:|------------:|
| PooledAsTaskAsyncAutoResetEventSetThenWaitAsync | 11.00 ns |  0.64 |         - |          NA |
| PooledAsyncAutoResetEventSetThenWaitAsync       | 11.04 ns |  0.64 |         - |          NA |
| NitoAsyncAutoResetEventSetThenWaitAsync         | 16.28 ns |  0.94 |         - |          NA |
| RefImplAsyncAutoResetEventSetThenWaitAsync      | 17.28 ns |  1.00 |         - |          NA |

#### AsyncAutoResetEvent Wait Benchmark

The benchmark measures the overhead of waiting on an unset event with no contention. Here the implementations have to start to allocate waiter objects. The pooled implementations can handle the requests without allocation and are almost on parity with the ref implementation. With the cancellation token an allocation is required for all implementations.

| Method                                      | cancellationType | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |----------------- |----------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventTaskWaitAsync     | None             |  24.32 ns |  1.00 |      96 B |        1.00 |
| PooledAsyncAutoResetEventTaskWaitAsync      | None             |  31.33 ns |  1.29 |         - |        0.00 |
| NitoAsyncAutoResetEventTaskWaitAsync        | None             |  31.97 ns |  1.31 |     160 B |        1.67 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | None             |  35.13 ns |  1.44 |         - |        0.00 |
|                                             |                  |           |       |           |             |
| PooledAsyncAutoResetEventTaskWaitAsync      | NotCancelled     |  55.28 ns |     ? |      64 B |           ? |
| PooledAsyncAutoResetEventValueTaskWaitAsync | NotCancelled     |  56.62 ns |     ? |      64 B |           ? |
| NitoAsyncAutoResetEventTaskWaitAsync        | NotCancelled     | 330.50 ns |     ? |     400 B |           ? |

#### AsyncAutoResetEvent WaitThenSet Benchmark with varying contention (Iterations)

The series of tests measures the overhead of waiting on an unset event with varying contention levels (Iterations). Due to the different behavior of the pooled implementations with AsTask(), ValueTask and the RunContinuationAsynchronously flag, these variations are measured separately.
PooledAsTask is allocating a Task for awaiting, hence it adds to memory. ContSync is the tag that uses disabled RunContinuationsAsynchronously. Nevertheless, all of the pooled implementations using ValueTask only avoid allocations and show better performance under contention.

With one iteration, the result is similar to the previous Wait benchmark, but the pooled implementations with ValueTask show slightly better performance. It can be seen that awaiting with AsTask adds heavy overhead and extra allocations. This is due to the implementation in ManualResetValueTaskSource when RunContinuationsAsynchronously is enabled.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None             |      31.25 ns |  1.00 |      96 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None             |      34.68 ns |  1.11 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None             |      35.05 ns |  1.12 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | None             |      36.56 ns |  1.17 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None             |      36.90 ns |  1.18 |     160 B |        1.67 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None             |      37.62 ns |  1.20 |         - |        0.00 |
| PooledAsTaskContSync                                         | 1          | None             |      50.64 ns |  1.62 |      80 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None             |     464.75 ns | 14.87 |     232 B |        2.42 |
|                                                              |            |                  |               |       |           |             |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | NotCancelled     |      56.59 ns |     ? |      64 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | NotCancelled     |      56.88 ns |     ? |      64 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | NotCancelled     |      56.97 ns |     ? |      64 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | NotCancelled     |      63.16 ns |     ? |      64 B |           ? |
| PooledAsTaskContSync                                         | 1          | NotCancelled     |      82.37 ns |     ? |     144 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | NotCancelled     |     346.65 ns |     ? |     400 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | NotCancelled     |     538.74 ns |     ? |     296 B |           ? |

With two iterations, contention starts to increase in a linear fashion. The pooled implementations with ValueTask again show the best performance and no allocations, only outperformed by the reference implementation. The RefImpl and Nito implementations start to allocate more memory due to multiple waiters. The PooledAsTask implementation again shows the highest overhead due to the Task allocations per waiter.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None             |      55.68 ns |  1.00 |     192 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None             |      66.39 ns |  1.19 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None             |      66.88 ns |  1.20 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None             |      69.50 ns |  1.25 |     320 B |        1.67 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | None             |      71.82 ns |  1.29 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None             |      74.15 ns |  1.33 |         - |        0.00 |
| PooledAsTaskContSync                                         | 2          | None             |     105.16 ns |  1.89 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None             |     883.71 ns | 15.87 |     344 B |        1.79 |
|                                                              |            |                  |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | NotCancelled     |     110.39 ns |     ? |     128 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | NotCancelled     |     110.51 ns |     ? |     128 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | NotCancelled     |     111.60 ns |     ? |     128 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | NotCancelled     |     112.51 ns |     ? |     128 B |           ? |
| PooledAsTaskContSync                                         | 2          | NotCancelled     |     150.59 ns |     ? |     288 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | NotCancelled     |     617.75 ns |     ? |     800 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | NotCancelled     |     940.93 ns |     ? |     472 B |           ? |

With ten iterations, contention increases further. The pooled implementations with ValueTask continue to show strong performance and zero allocations, only outperformed by the reference implementation that doesn't support cancellation tokens. The RefImpl and Nito implementations allocate even more memory due to the increased number of waiters. The PooledAsTask implementation continues to show the highest overhead due to Task allocations per waiter, but remains as fast as the pooled implementations.
The only pooled outlier uses AsTask with async continuations, a combination that should really be avoided based on these results. With cancellation token the pooled implementations outperform Nito by at least 5 times.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None             |     284.91 ns |  1.00 |     960 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None             |     319.82 ns |  1.12 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None             |     320.75 ns |  1.13 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None             |     328.51 ns |  1.15 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None             |     345.13 ns |  1.21 |    1600 B |        1.67 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | None             |     356.90 ns |  1.25 |         - |        0.00 |
| PooledAsTaskContSync                                         | 10         | None             |     499.48 ns |  1.75 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None             |   2,449.01 ns |  8.60 |    1240 B |        1.29 |
|                                                              |            |                  |               |       |           |             |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | NotCancelled     |     535.62 ns |     ? |     640 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | NotCancelled     |     538.50 ns |     ? |     640 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | NotCancelled     |     552.47 ns |     ? |     640 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | NotCancelled     |     571.28 ns |     ? |     640 B |           ? |
| PooledAsTaskContSync                                         | 10         | NotCancelled     |     787.51 ns |     ? |    1440 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | NotCancelled     |   2,963.21 ns |     ? |    4000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | NotCancelled     |   3,101.28 ns |     ? |    1880 B |           ? |

With 100 iterations, contention is high. The pooled implementations with ValueTask still show the best performance but get into allocations with the queue and ObjectPool exhaustion. The RefImpl and Nito implementations allocate significant memory due to the large number of waiters. The PooledAsTask version cannot keep up with the other implementations by means of perf and memory.
With cancellation token the pooled implementations outperform Nito by almost 10 times, if AsTask() is not being used.

| Method                                                       | Iterations | cancellationType | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |----------------- |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None             |   2,923.69 ns |  1.00 |    9600 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None             |   3,033.15 ns |  1.04 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None             |   3,171.93 ns |  1.09 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None             |   3,261.67 ns |  1.12 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | None             |   3,288.53 ns |  1.12 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None             |   3,556.17 ns |  1.22 |   16000 B |        1.67 |
| PooledAsTaskContSync                                         | 100        | None             |   4,718.91 ns |  1.61 |    8000 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None             |  14,972.57 ns |  5.12 |   11320 B |        1.18 |
|                                                              |            |                  |               |       |           |             |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | NotCancelled     |   5,444.12 ns |     ? |    6400 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | NotCancelled     |   5,544.22 ns |     ? |    6400 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | NotCancelled     |   5,572.22 ns |     ? |    6400 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | NotCancelled     |   5,787.41 ns |     ? |    6400 B |           ? |
| PooledAsTaskContSync                                         | 100        | NotCancelled     |   7,446.64 ns |     ? |   14400 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | NotCancelled     |  54,244.57 ns |     ? |   40000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | NotCancelled     | 258,460.14 ns |     ? |   17737 B |           ? |

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
| IncrementSingle                    |  0.0037 ns | 0.000 |         - |          NA |
| InterlockedIncrementSingle         |  0.2005 ns | 0.010 |         - |          NA |
| LockEnterScopeSingle               |  3.3892 ns | 0.167 |         - |          NA |
| LockUnlockSingle                   |  3.4177 ns | 0.168 |         - |          NA |
| ObjectLockUnlockSingle             |  4.3104 ns | 0.212 |         - |          NA |

The new .NET 9 `Lock` and `LockEnterScope` methods are slightly faster than a classic lock statement. Apparently it's interesting to see here that an Interlocked operation is still significantly faster than any locking mechanism with an increment.

Next, various AsyncLock implementations without contention and without cancellation token:

| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| LockUnlockPooledSingleAsync        | 13.2511 ns | 0.652 |         - |          NA |
| LockUnlockSemaphoreSlimSingleAsync | 19.0860 ns | 0.940 |         - |          NA |
| LockUnlockRefImplSingleAsync       | 20.3133 ns | 1.000 |         - |          NA |
| LockUnlockNonKeyedSingleAsync      | 22.7757 ns | 1.121 |         - |          NA |
| LockUnlockNitoSingleAsync          | 40.4106 ns | 1.989 |     320 B |          NA |
| LockUnlockNeoSmartSingleAsync      | 62.8990 ns | 3.096 |     208 B |          NA |

The pooled implementation is the fastest AsyncLock implementation, followed by the reference implementation.
SemaphoreSlim and NonKeyedAsyncLock have moderate overhead, while Nito.AsyncEx and NeoSmart's AsyncLock have the highest overhead and they need allocations.

#### AsyncLock Multiple Benchmark with varying contention (Iterations)

The case with 0 iterations measures the uncontested lock/unlock overhead with multiple concurrent waiters and with a cancellation token.
Benchmarks with 1, 10, and 100 iterations measure the behavior under contention with increasing number of concurrent waiters.
In addition to the previous uncontested benchmark, the pooled implementation with AsTask() is included to show the overhead of ValueTask/IValueTaskSource management with conversion to Task.
All implementations happen to deal efficiently with an uncostested lock even with cancellation token.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 0          | None             |     14.17 ns |  0.68 |         - |          NA |
| LockUnlockPooledTaskMultipleAsync    | 0          | None             |     15.88 ns |  0.76 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          | None             |     20.88 ns |  1.00 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          | None             |     23.63 ns |  1.13 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          | None             |     24.24 ns |  1.16 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          | None             |     42.49 ns |  2.04 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          | None             |     62.23 ns |  2.98 |     208 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 0          | NotCancelled     |     14.41 ns |     ? |         - |           ? |
| LockUnlockPooledTaskMultipleAsync    | 0          | NotCancelled     |     15.30 ns |     ? |         - |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 0          | NotCancelled     |     20.32 ns |     ? |         - |           ? |
| LockUnlockNonKeyedMultipleAsync      | 0          | NotCancelled     |     24.88 ns |     ? |         - |           ? |
| LockUnlockNitoMultipleAsync          | 0          | NotCancelled     |     42.92 ns |     ? |     320 B |           ? |
| LockUnlockNeoSmartMultipleAsync      | 0          | NotCancelled     |     65.11 ns |     ? |     208 B |           ? |

The case with 1 iteration measures the overhead of a single waiter for the contested lock. Noticeable the SemaphoreSlim implementation is the fastest here, pooled almost on parity and the reference implementation a lot slower.
The pooled implementation with an AsTask() conversion, due to the RunContinuationsAsynchronously=true causes a high performance degradation and a moderate allocation in the underlying IValueTaskSource implementation.
However only because in the benchmark the Task is awaited outside the lock, which causes to hit that inefficient code path in the IValueTaskSource.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 1          | None             |     46.28 ns |  0.55 |      88 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 1          | None             |     48.70 ns |  0.58 |         - |        0.00 |
| LockUnlockRefImplMultipleAsync       | 1          | None             |     83.45 ns |  1.00 |     216 B |        1.00 |
| LockUnlockNitoMultipleAsync          | 1          | None             |    106.15 ns |  1.27 |     728 B |        3.37 |
| LockUnlockNeoSmartMultipleAsync      | 1          | None             |    147.60 ns |  1.77 |     416 B |        1.93 |
| LockUnlockPooledTaskMultipleAsync    | 1          | None             |    468.97 ns |  5.62 |     272 B |        1.26 |
| LockUnlockNonKeyedMultipleAsync      | 1          | None             |    529.00 ns |  6.34 |     352 B |        1.63 |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 1          | NotCancelled     |     70.61 ns |     ? |      64 B |           ? |
| LockUnlockNeoSmartMultipleAsync      | 1          | NotCancelled     |    125.96 ns |     ? |     416 B |           ? |
| LockUnlockNitoMultipleAsync          | 1          | NotCancelled     |    409.55 ns |     ? |     968 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 1          | NotCancelled     |    555.56 ns |     ? |     336 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 1          | NotCancelled     |    562.10 ns |     ? |     504 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 1          | NotCancelled     |    682.40 ns |     ? |     640 B |           ? |

The case with 10 iterations manifests the same behavior with moderate contention, as the ObjectPool is not exhausted. But SemaphoreSlim is now the fastest implementation, although using moderate allocations, followed by the pooled implementation.
With cancellation token the pooled implementations outperform others except NeoSmart by at least 5 times.

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 10         | None             |    297.34 ns |  0.44 |     880 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 10         | None             |    338.51 ns |  0.50 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 10         | None             |    635.05 ns |  0.93 |    4400 B |        2.04 |
| LockUnlockRefImplMultipleAsync       | 10         | None             |    681.88 ns |  1.00 |    2160 B |        1.00 |
| LockUnlockNeoSmartMultipleAsync      | 10         | None             |    692.90 ns |  1.02 |    2288 B |        1.06 |
| LockUnlockPooledTaskMultipleAsync    | 10         | None             |  3,035.87 ns |  4.45 |    1352 B |        0.63 |
| LockUnlockNonKeyedMultipleAsync      | 10         | None             |  3,259.92 ns |  4.78 |    2296 B |        1.06 |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 10         | NotCancelled     |    574.55 ns |     ? |     640 B |           ? |
| LockUnlockNeoSmartMultipleAsync      | 10         | NotCancelled     |    688.91 ns |     ? |    2288 B |           ? |
| LockUnlockNitoMultipleAsync          | 10         | NotCancelled     |  2,892.20 ns |     ? |    6800 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 10         | NotCancelled     |  3,581.86 ns |     ? |    1992 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 10         | NotCancelled     |  4,259.71 ns |     ? |    3888 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 10         | NotCancelled     |  5,137.07 ns |     ? |    5176 B |           ? |

On the case with 100 iterations the pooled implementation is again slower than the semaphore slim implementation but still allocates no memory, because the ObjectPool defaults to 128 items. For the cancellable case, the pooled implementation has significantly lower allocations than the other implementations. Every registration needs 64 bytes. 

| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 100        | None             |  2,676.41 ns |  0.42 |    8800 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 100        | None             |  3,182.88 ns |  0.50 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 100        | None             |  5,777.34 ns |  0.90 |   41120 B |        1.90 |
| LockUnlockRefImplMultipleAsync       | 100        | None             |  6,385.51 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockNeoSmartMultipleAsync      | 100        | None             |  6,423.83 ns |  1.01 |   21008 B |        0.97 |
| LockUnlockPooledTaskMultipleAsync    | 100        | None             | 33,070.77 ns |  5.18 |   12216 B |        0.57 |
| LockUnlockNonKeyedMultipleAsync      | 100        | None             | 34,922.75 ns |  5.47 |   21800 B |        1.01 |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 100        | NotCancelled     |  5,662.61 ns |     ? |    6400 B |           ? |
| LockUnlockNeoSmartMultipleAsync      | 100        | NotCancelled     |  6,497.43 ns |     ? |   21008 B |           ? |
| LockUnlockNitoMultipleAsync          | 100        | NotCancelled     | 30,746.66 ns |     ? |   65120 B |           ? |
| LockUnlockPooledTaskMultipleAsync    | 100        | NotCancelled     | 36,769.07 ns |     ? |   18616 B |           ? |
| LockUnlockSemaphoreSlimMultipleAsync | 100        | NotCancelled     | 42,587.26 ns |     ? |   37792 B |           ? |
| LockUnlockNonKeyedMultipleAsync      | 100        | NotCancelled     | 51,507.86 ns |     ? |   50600 B |           ? |

