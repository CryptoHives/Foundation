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
| PooledAsyncAutoResetEventSet  |   3.920 ns |  0.90 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   4.340 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   4.574 ns |  1.05 |         - |          NA |
| AutoResetEventSet             | 230.634 ns | 53.14 |         - |          NA |

#### AsyncAutoResetEvent SetThenWait Benchmark

This is the fast path if the event is already Set and an immediate return from WaitAsync is possible. There is no contention and no allocation cost in all implementations.

| Method                                          | Mean     | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------ |---------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventSetThenWaitAsync       | 11.01 ns |  0.63 |         - |          NA |
| PooledAsTaskAsyncAutoResetEventSetThenWaitAsync | 11.12 ns |  0.64 |         - |          NA |
| NitoAsyncAutoResetEventSetThenWaitAsync         | 17.00 ns |  0.98 |         - |          NA |
| RefImplAsyncAutoResetEventSetThenWaitAsync      | 17.38 ns |  1.00 |         - |          NA |

#### AsyncAutoResetEvent Wait Benchmark

The benchmark measures the overhead of waiting on an unset event with no contention. Here the implementations have to start to allocate waiter objects. The pooled implementations can handle the requests without allocation and are almost on parity with the ref implementation. With the cancellation token an allocation is required for all implementations.

| Method                                      | ct    | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |----------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventTaskWaitAsync     | None  |  25.40 ns |  1.00 |      96 B |        1.00 |
| PooledAsyncAutoResetEventTaskWaitAsync      | None  |  31.33 ns |  1.23 |         - |        0.00 |
| NitoAsyncAutoResetEventTaskWaitAsync        | None  |  31.87 ns |  1.25 |     160 B |        1.67 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | None  |  40.85 ns |  1.61 |         - |        0.00 |
|                                             |       |           |       |           |             |
| PooledAsyncAutoResetEventValueTaskWaitAsync | Token |  56.45 ns |     ? |      64 B |           ? |
| PooledAsyncAutoResetEventTaskWaitAsync      | Token |  62.95 ns |     ? |      64 B |           ? |
| NitoAsyncAutoResetEventTaskWaitAsync        | Token | 331.26 ns |     ? |     400 B |           ? |

#### AsyncAutoResetEvent WaitThenSet Benchmark with varying contention (Iterations)

The series of tests measures the overhead of waiting on an unset event with varying contention levels (Iterations). Due to the different behavior of the pooled implementations with AsTask(), ValueTask and the RunContinuationAsynchronously flag, these variations are measured separately.
PooledAsTask is allocating a Task for awaiting, hence it adds to memory. ContSync is the tag that uses disabled RunContinuationsAsynchronously. Nevertheless, all of the pooled implementations using ValueTask only avoid allocations and show better performance under contention.

With one iteration, the result is similar to the previous Wait benchmark, but the pooled implementations with ValueTask show slightly better performance. It can be seen that awaiting with AsTask adds heavy overhead and extra allocations. This is due to the implementation in ManualResetValueTaskSource when RunContinuationsAsynchronously is enabled.

| Method                                                       | Iterations | ct    | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |------ |--------------:|------:|----------:|------------:|
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None  |      33.96 ns |  0.57 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None  |      34.85 ns |  0.58 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | None  |      37.36 ns |  0.63 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None  |      38.10 ns |  0.64 |     160 B |        1.67 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None  |      41.50 ns |  0.70 |         - |        0.00 |
| PooledAsTaskContSync                                         | 1          | None  |      49.95 ns |  0.84 |      80 B |        0.83 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None  |      59.74 ns |  1.00 |      96 B |        1.00 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None  |     400.12 ns |  6.70 |     232 B |        2.42 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | Token |      52.16 ns |     ? |      64 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | Token |      53.36 ns |     ? |      64 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | Token |      57.14 ns |     ? |      64 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | Token |      57.22 ns |     ? |      64 B |           ? |
| PooledAsTaskContSync                                         | 1          | Token |      77.67 ns |     ? |     144 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | Token |     337.78 ns |     ? |     400 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | Token |     468.45 ns |     ? |     296 B |           ? |

With two iterations, contention starts to increase in a linear fashion. The pooled implementations with ValueTask again show the best performance and no allocations, only outperformed by the reference implementation. The RefImpl and Nito implementations start to allocate more memory due to multiple waiters. The PooledAsTask implementation again shows the highest overhead due to the Task allocations per waiter.

| Method                                                       | Iterations | ct    | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |------ |-------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None  |      55.35 ns |  1.00 |     192 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None  |      66.63 ns |  1.20 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None  |      69.49 ns |  1.26 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None  |      72.72 ns |  1.31 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | None  |      74.06 ns |  1.34 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None  |      74.45 ns |  1.35 |     320 B |        1.67 |
| PooledAsTaskContSync                                         | 2          | None  |     109.80 ns |  1.98 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None  |     898.70 ns | 16.24 |     344 B |        1.79 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | Token |     101.11 ns |     ? |     128 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | Token |     102.22 ns |     ? |     128 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | Token |     112.57 ns |     ? |     128 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | Token |     113.01 ns |     ? |     128 B |           ? |
| PooledAsTaskContSync                                         | 2          | Token |     148.57 ns |     ? |     288 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | Token |     594.21 ns |     ? |     800 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | Token |     981.18 ns |     ? |     472 B |           ? |

With ten iterations, contention increases further. The pooled implementations with ValueTask continue to show strong performance and zero allocations, only outperformed by the reference implementation that doesn't support cancellation tokens. The RefImpl and Nito implementations allocate even more memory due to the increased number of waiters. The PooledAsTask implementation continues to show the highest overhead due to Task allocations per waiter, but remains as fast as the pooled implementations.
The only pooled outlier uses AsTask with async continuations, a combination that should really be avoided based on these results. With cancellation token the pooled implementations outperform Nito by at least 5 times.

| Method                                                       | Iterations | ct    | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |------ |-------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None  |     289.66 ns |  1.00 |     960 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None  |     311.52 ns |  1.08 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None  |     321.24 ns |  1.11 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | None  |     337.32 ns |  1.16 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None  |     340.43 ns |  1.18 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None  |     353.50 ns |  1.22 |    1600 B |        1.67 |
| PooledAsTaskContSync                                         | 10         | None  |     496.50 ns |  1.71 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None  |   2,380.59 ns |  8.22 |    1240 B |        1.29 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | Token |     512.12 ns |     ? |     640 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | Token |     525.50 ns |     ? |     640 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | Token |     547.90 ns |     ? |     640 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | Token |     556.48 ns |     ? |     640 B |           ? |
| PooledAsTaskContSync                                         | 10         | Token |     836.04 ns |     ? |    1440 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | Token |   2,833.31 ns |     ? |    4000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | Token |   3,231.17 ns |     ? |    1880 B |           ? |

With 100 iterations, contention is high. The pooled implementations with ValueTask still show the best performance but get into allocations with the queue and ObjectPool exhaustion. The RefImpl and Nito implementations allocate significant memory due to the large number of waiters. The PooledAsTask version cannot keep up with the other implementations by means of perf and memory.
With cancellation token the pooled implementations outperform Nito by almost 10 times, if AsTask() is not being used.

| Method                                                       | Iterations | ct    | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |------ |--------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None  |   2,882.22 ns |  1.00 |    9600 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None  |   3,259.85 ns |  1.13 |    5984 B |        0.62 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | None  |   3,349.00 ns |  1.16 |    5984 B |        0.62 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None  |   3,373.86 ns |  1.17 |    5984 B |        0.62 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None  |   3,463.55 ns |  1.20 |    5984 B |        0.62 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None  |   3,555.03 ns |  1.23 |   16000 B |        1.67 |
| PooledAsTaskContSync                                         | 100        | None  |   4,998.23 ns |  1.73 |   13984 B |        1.46 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None  |  14,524.21 ns |  5.04 |   17303 B |        1.80 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | Token |   5,418.03 ns |     ? |   12384 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | Token |   5,426.49 ns |     ? |   12384 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | Token |   5,588.02 ns |     ? |   12384 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | Token |   5,617.25 ns |     ? |   12384 B |           ? |
| PooledAsTaskContSync                                         | 100        | Token |   7,359.18 ns |     ? |   20384 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | Token |  35,352.35 ns |     ? |   40000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | Token | 131,102.34 ns |     ? |   23733 B |           ? |

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
| IncrementSingle                    |  0.0020 ns | 0.000 |         - |          NA |
| InterlockedIncrementSingle         |  0.2070 ns | 0.010 |         - |          NA |
| LockEnterScopeSingle               |  3.3850 ns | 0.166 |         - |          NA |
| LockUnlockSingle                   |  3.4422 ns | 0.169 |         - |          NA |
| ObjectLockUnlockSingle             |  4.3128 ns | 0.212 |         - |          NA |

The new .NET 9 `Lock` and `LockEnterScope` methods are slightly faster than a classic lock statement. Apparently it's interesting to see here that an Interlocked operation is still significantly faster than any locking mechanism with an increment.

Next, various AsyncLock implementations without contention:

| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| LockUnlockPooledSingleAsync        | 12.6773 ns | 0.623 |         - |          NA |
| LockUnlockSemaphoreSlimSingleAsync | 19.0709 ns | 0.937 |         - |          NA |
| LockUnlockRefImplSingleAsync       | 20.3435 ns | 1.000 |         - |          NA |
| LockUnlockNonKeyedSingleAsync      | 23.3824 ns | 1.149 |         - |          NA |
| LockUnlockNitoSingleAsync          | 41.5297 ns | 2.041 |     320 B |          NA |
| LockUnlockNeoSmartSingleAsync      | 60.6365 ns | 2.981 |     208 B |          NA |

The pooled implementation is the fastest AsyncLock implementation, followed by the reference implementation.
SemaphoreSlim and NonKeyedAsyncLock have moderate overhead, while Nito.AsyncEx and NeoSmart's AsyncLock have the highest overhead and they need allocations.

#### AsyncLock Multiple Benchmark with varying contention (Iterations)

The case with 0 iterations measures the uncontested lock/unlock overhead with multiple concurrent waiters.
Benchmarks with 1, 10, and 100 iterations measure the behavior under contention with increasing number of concurrent waiters.
In addition to the previous uncontested benchmark, the pooled implementation with AsTask() is included to show the overhead of ValueTask/IValueTaskSource management with conversion to Task.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledTaskMultipleAsync    | 0          |     13.82 ns |  0.67 |         - |          NA |
| LockUnlockPooledMultipleAsync        | 0          |     15.31 ns |  0.74 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          |     19.79 ns |  0.96 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          |     20.55 ns |  1.00 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          |     24.30 ns |  1.18 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          |     44.96 ns |  2.19 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          |     62.02 ns |  3.02 |     208 B |          NA |

The case with 1 iteration measures the overhead of a single waiter for the contested lock. Noticeable the pooled implementation is still the fastest here, followed by SemaphoreSlim and the reference implementation.
But the pooled implementation with an AsTask() conversion, due to the RunContinuationsAsynchronously=true causes a nightmare performance degradation and a moderate allocation in the underlying IValueTaskSource implementation.
However only because the Task is awaited outside the lock, which causes to hit that less efficient code path in the IValueTaskSource.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 1          |     45.01 ns |  0.10 |         - |        0.00 |
| LockUnlockSemaphoreSlimMultipleAsync | 1          |     48.16 ns |  0.10 |      88 B |        0.26 |
| LockUnlockNitoMultipleAsync          | 1          |    111.64 ns |  0.24 |     728 B |        2.17 |
| LockUnlockNeoSmartMultipleAsync      | 1          |    128.92 ns |  0.28 |     416 B |        1.24 |
| LockUnlockRefImplMultipleAsync       | 1          |    467.48 ns |  1.00 |     336 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 1          |    475.77 ns |  1.02 |     264 B |        0.79 |
| LockUnlockNonKeyedMultipleAsync      | 1          |    500.57 ns |  1.07 |     336 B |        1.00 |

The case with 10 iterations manifests the same behavior with moderate contention, as the ObjectPool is not exhausted. But SemaphoreSlim is now the fastest implementation, although using moderate allocations, followed by the pooled implementation.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 10         |    305.27 ns |  0.10 |     880 B |        0.39 |
| LockUnlockPooledMultipleAsync        | 10         |    375.00 ns |  0.12 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 10         |    598.06 ns |  0.19 |    4400 B |        1.93 |
| LockUnlockNeoSmartMultipleAsync      | 10         |    725.40 ns |  0.23 |    2288 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 10         |  3,016.88 ns |  0.97 |    1344 B |        0.59 |
| LockUnlockRefImplMultipleAsync       | 10         |  3,121.51 ns |  1.00 |    2280 B |        1.00 |
| LockUnlockNonKeyedMultipleAsync      | 10         |  3,195.60 ns |  1.02 |    2208 B |        0.97 |

On the case with 100 iterations the pooled implementation is again slower than the semaphore slim implementation but still allocates less memory, likely due to the exhaustion on the ObjectPool or allocations on the internal queue. Still the pooled implementation has significantly lower allocations than the other implementations.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 100        |  2,779.92 ns |  0.09 |    8800 B |        0.40 |
| LockUnlockPooledMultipleAsync        | 100        |  3,314.03 ns |  0.10 |    6528 B |        0.30 |
| LockUnlockNeoSmartMultipleAsync      | 100        |  6,437.42 ns |  0.20 |   21008 B |        0.96 |
| LockUnlockNitoMultipleAsync          | 100        |  6,829.20 ns |  0.21 |   41120 B |        1.89 |
| LockUnlockPooledTaskMultipleAsync    | 100        | 31,072.52 ns |  0.95 |   18736 B |        0.86 |
| LockUnlockRefImplMultipleAsync       | 100        | 32,582.67 ns |  1.00 |   21784 B |        1.00 |
| LockUnlockNonKeyedMultipleAsync      | 100        | 35,925.37 ns |  1.10 |   20992 B |        0.96 |

