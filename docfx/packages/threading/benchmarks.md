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
In general with the release of .NET 10 the results improved for the reference implementations against pooled compared to previous .NET versions, often outperforming now the pooled implementations but still requiring more memory allocations. However, due to lack of support for cancellation token in the reference implementation only the pooled and Nito versions ar compared in these tables.

### AsyncAutoResetEvent Benchmarks

The benchmarks compare various `AsyncAutoResetEvent` implementations with the default platform `AutoResetEvent` on Windows:

- PooledAsyncAutoResetEvent: The pooled implementation from this library
- RefImplAsyncAutoResetEvent: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncAutoResetEvent: The implementation from Nito.AsyncEx library

#### AsyncAutoResetEvent Set Benchmark

Just the overhead of setting the event without any waiters. There is no contention and no allocation cost in all implementations.

| Method                        | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventSet  |   3.811 ns |  0.88 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   4.350 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   4.383 ns |  1.01 |         - |          NA |
| AutoResetEventSet             | 235.773 ns | 54.20 |         - |          NA |

#### AsyncAutoResetEvent SetThenWait Benchmark

This is the fast path if the event is already Set and an immediate return from WaitAsync is possible. There is no contention and no allocation cost in all implementations.

| Method                                          | Mean     | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------ |---------:|------:|----------:|------------:|
| PooledAsTaskAsyncAutoResetEventSetThenWaitAsync | 11.03 ns |  0.65 |         - |          NA |
| PooledAsyncAutoResetEventSetThenWaitAsync       | 11.58 ns |  0.68 |         - |          NA |
| NitoAsyncAutoResetEventSetThenWaitAsync         | 14.84 ns |  0.87 |         - |          NA |
| RefImplAsyncAutoResetEventSetThenWaitAsync      | 17.02 ns |  1.00 |         - |          NA |

#### AsyncAutoResetEvent Task Wait Benchmark

The benchmark measures the overhead of waiting on an unset event with no contention. Here the implementations have to start to allocate waiter objects. The pooled implementations can handle the requests without allocation and and is almost on parity with the ref implementation. Wit the cancellation token an allocation is required for all implementations.

| Method                                      | ct    | Mean      | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |------ |----------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventTaskWaitAsync     | None  |  24.84 ns |  1.00 |      96 B |        1.00 |
| PooledAsyncAutoResetEventTaskWaitAsync      | None  |  25.40 ns |  1.02 |         - |        0.00 |
| NitoAsyncAutoResetEventTaskWaitAsync        | None  |  31.20 ns |  1.26 |     160 B |        1.67 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | None  |  31.64 ns |  1.27 |         - |        0.00 |
|                                             |       |           |       |           |             |
| PooledAsyncAutoResetEventTaskWaitAsync      | Token |  49.35 ns |     ? |      64 B |           ? |
| PooledAsyncAutoResetEventValueTaskWaitAsync | Token |  49.83 ns |     ? |      64 B |           ? |
| NitoAsyncAutoResetEventTaskWaitAsync        | Token | 336.10 ns |     ? |     400 B |           ? |

#### AsyncAutoResetEvent WaitThenSet Benchmark with varying contention (Iterations)

The series of tests measures the overhead of waiting on an unset event with varying contention levels (Iterations). Due to the different behavior of the pooled implementations with AsTask(), ValueTask and the RunContinuationAsynchronously flag, these variations are measured separately.
PooledAsTask is allocating a Task for awaiting, hence it adds to memory. ContSync is the tag that uses disabled RunContinuationsAsynchronously. Nevertheless, all of the pooled implementations using ValueTask only avoid allocations and show better performance under contention.

With one iteration, the result is similar to the previous Wait benchmark, but the pooled implementations with ValueTask show slightly better performance. It can be seen that awaiting with AsTask adds heavy overhead and extra allocations. This is due to the implementation in ManualResetValueTaskSource when RunContinuationsAsynchronously is enabled.

| Method                                                       | Iterations | ct    | Mean          | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |------ |--------------:|------:|----------:|------------:|
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | None  |      28.85 ns |  0.95 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | None  |      29.23 ns |  0.97 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          | None  |      30.24 ns |  1.00 |      96 B |        1.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | None  |      31.21 ns |  1.03 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | None  |      31.61 ns |  1.05 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | None  |      36.10 ns |  1.19 |     160 B |        1.67 |
| PooledAsTaskContSync                                         | 1          | None  |      45.04 ns |  1.49 |      80 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | None  |     367.44 ns | 12.15 |     232 B |        2.42 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          | Token |      45.97 ns |     ? |      64 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          | Token |      46.05 ns |     ? |      64 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          | Token |      48.49 ns |     ? |      64 B |           ? |
| PooledAsTaskContSync                                         | 1          | Token |      64.69 ns |     ? |     144 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          | Token |      75.35 ns |     ? |      64 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          | Token |     344.53 ns |     ? |     400 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          | Token |     475.52 ns |     ? |     296 B |           ? |

With two iterations, contention starts to increase in a linear fashion. The pooled implementations with ValueTask again show the best performance and no allocations, only outperfomred by the reference implementation. The RefImpl and Nito implementations start to allocate more memory due to multiple waiters. The PooledAsTask implementation again shows the highest overhead due to the Task allocations per waiter.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          | None  |      56.80 ns |  1.00 |     192 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | None  |      66.36 ns |  1.17 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | None  |      66.78 ns |  1.18 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | None  |      70.33 ns |  1.24 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | None  |      71.51 ns |  1.26 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | None  |      73.98 ns |  1.30 |     320 B |        1.67 |
| PooledAsTaskContSync                                         | 2          | None  |     111.76 ns |  1.97 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | None  |     804.94 ns | 14.17 |     344 B |        1.79 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          | Token |     103.67 ns |     ? |     128 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          | Token |     107.73 ns |     ? |     128 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          | Token |     107.94 ns |     ? |     128 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          | Token |     113.13 ns |     ? |     128 B |           ? |
| PooledAsTaskContSync                                         | 2          | Token |     142.72 ns |     ? |     288 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          | Token |     594.73 ns |     ? |     800 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          | Token |     966.97 ns |     ? |     472 B |           ? |

With ten iterations, contention increases further. The pooled implementations with ValueTask continue to show strong performance and zero allocations, only outperformed by the reference implementation that doesn't support cancellation tokens. The RefImpl and Nito implementations allocate even more memory due to the increased number of waiters. The PooledAsTask implementation continues to show the highest overhead due to Task allocations per waiter, but remain as fast as the pooled implementations.
The only pooled outlier uses AsTask with async continuations, a combination that should really be avoided base on these results. With cancellation token the pooled implementations outperform Nito by at least 5 times.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         | None  |     300.42 ns |  1.00 |     960 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | None  |     309.50 ns |  1.03 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | None  |     312.02 ns |  1.04 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | None  |     346.64 ns |  1.15 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | None  |     347.22 ns |  1.16 |    1600 B |        1.67 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | None  |     348.55 ns |  1.16 |         - |        0.00 |
| PooledAsTaskContSync                                         | 10         | None  |     492.12 ns |  1.64 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | None  |   2,461.95 ns |  8.20 |    1240 B |        1.29 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         | Token |     515.73 ns |     ? |     640 B |           ? |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         | Token |     518.59 ns |     ? |     640 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         | Token |     559.07 ns |     ? |     640 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         | Token |     565.19 ns |     ? |     640 B |           ? |
| PooledAsTaskContSync                                         | 10         | Token |     764.75 ns |     ? |    1440 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         | Token |   3,149.21 ns |     ? |    1880 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         | Token |   3,167.35 ns |     ? |    4000 B |           ? |

With 100 iterations, contention is high. The pooled implementations with ValueTask still show the best performance but get into allocations with the queue and ObjectPool exhaustion. The RefImpl and Nito implementations allocate significant memory due to the large number of waiters. The PooledAsTask version can not keep up with the other implementations by means of perf and memory.
With cancellation token the pooled implementations outperform Nito by almost 10 times, if AsTask() is not being used.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        | None  |   2,877.40 ns |  1.00 |    9600 B |        1.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | None  |   3,175.37 ns |  1.10 |    5896 B |        0.61 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | None  |   3,187.68 ns |  1.11 |    5896 B |        0.61 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | None  |   3,559.46 ns |  1.24 |    5896 B |        0.61 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | None  |   3,599.06 ns |  1.25 |   16000 B |        1.67 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | None  |   4,136.83 ns |  1.44 |    5896 B |        0.61 |
| PooledAsTaskContSync                                         | 100        | None  |   4,916.44 ns |  1.71 |   13896 B |        1.45 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | None  |  15,525.58 ns |  5.40 |   17216 B |        1.79 |
|                                                              |            |       |               |       |           |             |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        | Token |   5,242.70 ns |     ? |   12296 B |           ? |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        | Token |   5,290.97 ns |     ? |   12296 B |           ? |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        | Token |   5,726.57 ns |     ? |   12296 B |           ? |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        | Token |   5,786.60 ns |     ? |   12296 B |           ? |
| PooledAsTaskContSync                                         | 100        | Token |   7,165.53 ns |     ? |   20296 B |           ? |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        | Token |  43,293.76 ns |     ? |   40000 B |           ? |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | Token | 174,224.80 ns |     ? |   23642 B |           ? |

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

The new .NET9 `Lock` and `LockEnterScope` methods are slightly faster than a classic lock statement. Apparently its interesting to see here that an Interlocked operation is still significantly faster than any locking mechanism with an increment.

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
| LockUnlockPooledTaskMultipleAsync    | 0          |     13.57 ns |  0.64 |         - |          NA |
| LockUnlockPooledMultipleAsync        | 0          |     13.68 ns |  0.64 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          |     19.66 ns |  0.92 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          |     21.29 ns |  1.00 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          |     23.98 ns |  1.13 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          |     42.33 ns |  1.99 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          |     62.68 ns |  2.94 |     208 B |          NA |

The case with 1 iteration measures the overhead of a single waiter for the contested lock. Noticable the pooled implementation is still the fastest here, followed by SemaphoreSlim and the reference implementation.
But the pooled implementation with an AsTask() conversion, due to the RunContinuationsAsynchronously=true causes a nightmare performance degradation and a moderate allocation in the underlying IValueTaskSource implementation.
However only because the Task is awaited outside the lock, which causes to hit that less efficient code path in the IValueTaskSource.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 1          |     40.94 ns |  0.50 |         - |        0.00 |
| LockUnlockSemaphoreSlimMultipleAsync | 1          |     47.17 ns |  0.57 |      88 B |        0.41 |
| LockUnlockRefImplMultipleAsync       | 1          |     82.71 ns |  1.00 |     216 B |        1.00 |
| LockUnlockNitoMultipleAsync          | 1          |    106.64 ns |  1.29 |     728 B |        3.37 |
| LockUnlockNeoSmartMultipleAsync      | 1          |    126.39 ns |  1.53 |     416 B |        1.93 |
| LockUnlockPooledTaskMultipleAsync    | 1          |    464.20 ns |  5.61 |     264 B |        1.22 |
| LockUnlockNonKeyedMultipleAsync      | 1          |    497.59 ns |  6.02 |     336 B |        1.56 |

The case with 10 iterations manifests the same behavior with moderate contention, as the ObjectPool is not exhausted. But SemaphoreSlim is now the fastest implementation, although using moderate allocations, followed by the pooled implementation.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 10         |    289.79 ns |  0.41 |     880 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 10         |    380.25 ns |  0.53 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 10         |    582.42 ns |  0.82 |    4400 B |        2.04 |
| LockUnlockNeoSmartMultipleAsync      | 10         |    700.31 ns |  0.99 |    2288 B |        1.06 |
| LockUnlockRefImplMultipleAsync       | 10         |    710.91 ns |  1.00 |    2160 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 10         |  3,070.15 ns |  4.32 |    1344 B |        0.62 |
| LockUnlockNonKeyedMultipleAsync      | 10         |  3,195.60 ns |  4.50 |    2208 B |        1.02 |

On the case with 100 iterations the pooled implementation is again slower than the semaphore slim implementation but still allocates less memory, likely due to the exhaustion on the ObjectPool or allocations on the internal queue. Still the pooled implementation has significantly lower allocations than the other implementations.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 100        |  2,747.09 ns |  0.42 |    8800 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 100        |  3,364.13 ns |  0.51 |    6432 B |        0.30 |
| LockUnlockNitoMultipleAsync          | 100        |  5,902.79 ns |  0.90 |   41120 B |        1.90 |
| LockUnlockNeoSmartMultipleAsync      | 100        |  6,414.06 ns |  0.97 |   21008 B |        0.97 |
| LockUnlockRefImplMultipleAsync       | 100        |  6,584.20 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 100        | 31,842.52 ns |  4.84 |   18640 B |        0.86 |
| LockUnlockNonKeyedMultipleAsync      | 100        | 34,731.84 ns |  5.28 |   20992 B |        0.97 |

