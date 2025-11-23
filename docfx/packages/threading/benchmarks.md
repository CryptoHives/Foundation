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
  [Host]   : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v4
  .NET 9.0 : .NET 9.0.11 (9.0.11, 9.0.1125.51716), X64 RyuJIT x86-64-v4

Job=.NET 9.0  Runtime=.NET 9.0  Toolchain=net9.0  
```

For this documentation all results were manually sorted by Mean execution time, fastest first.

### AsyncAutoResetEvent Benchmarks

#### AsyncAutoResetEvent Set Benchmark

Just the overhead of setting the event without any waiters. There is no contention and no allocation cost in all implementations.

| Method                        | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventSet  |   4.091 ns |  0.70 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   5.839 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   5.905 ns |  1.01 |         - |          NA |
| AutoResetEventSet             | 234.790 ns | 40.21 |         - |          NA |

#### AsyncAutoResetEvent SetThenWait Benchmark

This is the fast path if the event is already Set and an immediate return is possible. There is no contention and no allocation cost in all implementations.

| Method                                          | Mean     | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------ |---------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventSetThenWaitAsync       | 12.46 ns |  0.60 |         - |          NA |
| PooledAsTaskAsyncAutoResetEventSetThenWaitAsync | 14.64 ns |  0.71 |         - |          NA |
| RefImplAsyncAutoResetEventSetThenWaitAsync      | 20.66 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSetThenWaitAsync         | 20.95 ns |  1.01 |         - |          NA |

#### AsyncAutoResetEvent Task Wait Benchmark

The benchmark measures the overhead of waiting on an unset event with no contention. Here the implementations have to start to allocate waiter objects. The pooled implementations can handle the requests without allocation and with better performance.

| Method                                      | Mean     | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------- |---------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventTaskWaitAsync      | 29.69 ns |  0.94 |         - |        0.00 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | 29.82 ns |  0.94 |         - |        0.00 |
| RefImplAsyncAutoResetEventTaskWaitAsync     | 31.70 ns |  1.00 |      96 B |        1.00 |
| NitoAsyncAutoResetEventTaskWaitAsync        | 47.23 ns |  1.49 |     160 B |        1.67 |

#### AsyncAutoResetEvent WaitThenSet Benchmark with varying contention (Iterations)

The series of tests measures the overhead of waiting on an unset event with varying contention levels (Iterations). Due to the different behavior of the pooled implementations with AsTask(), ValueTask and the RunContinuationAsynchronously flag, these variations are measured separately.
PooledAsTask is allocating a Task for awaiting, hence it adds to memory. ContSync is the tag that uses disabled RunContinuationsAsynchronously. Nevertheless, all of the pooled implementations using ValueTask avoid allocations and show better performance under contention.

With one iteration, the result is similar to the previous Wait benchmark, but the pooled implementations with ValueTask show slightly better performance. It can be seen that awaiting with AsTask adds heavy overhead and extra allocations. This is due to the implementation in ManualResetValueTaskSource when RunContinuationsAsynchronously is enabled.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          |     31.67 ns |  0.87 |         - |        0.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          |     31.72 ns |  0.87 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          |     32.24 ns |  0.88 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          |     32.87 ns |  0.90 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          |     36.44 ns |  1.00 |      96 B |        1.00 |
| PooledAsTaskContSync                                         | 1          |     46.29 ns |  1.27 |      80 B |        0.83 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 1          |     50.18 ns |  1.38 |     160 B |        1.67 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          |    344.76 ns |  9.46 |     224 B |        2.33 |

With two iterations, contention starts to increase in a linear fashion. The pooled implementations with ValueTask again show the best performance and no allocations. The RefImpl and Nito implementations start to allocate more memory due to multiple waiters. The PooledAsTask implementation again shows the highest overhead due to Task allocations per waiter.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          |     67.12 ns |  0.95 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          |     68.32 ns |  0.97 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          |     68.79 ns |  0.97 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          |     70.58 ns |  1.00 |     192 B |        1.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          |     71.56 ns |  1.01 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 2          |     99.70 ns |  1.41 |     320 B |        1.67 |
| PooledAsTaskContSync                                         | 2          |    100.83 ns |  1.43 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          |    833.87 ns | 11.82 |     336 B |        1.75 |

With ten iterations, contention increases further. The pooled implementations with ValueTask continue to show strong performance and zero allocations. The RefImpl and Nito implementations allocate even more memory due to the increased number of waiters. The PooledAsTask implementation continues to show the highest overhead due to Task allocations per waiter, but remain as fast as the pooled implementations.
The pooled AsTask implementations loses more ground.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         |    348.64 ns |  0.98 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         |    357.49 ns |  1.00 |     960 B |        1.00 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         |    358.62 ns |  1.00 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         |    381.08 ns |  1.07 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         |    385.14 ns |  1.08 |         - |        0.00 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 10         |    469.88 ns |  1.31 |    1600 B |        1.67 |
| PooledAsTaskContSync                                         | 10         |    514.68 ns |  1.44 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         |  2,476.21 ns |  6.93 |    1232 B |        1.28 |

With 100 iterations, contention is high. The pooled implementations with ValueTask still show the best performance but get into allocations with the queue and ObjectPool exhaustion. The RefImpl and Nito implementations allocate significant memory due to the large number of waiters. The PooledAsTask version can not keep up with the other implementations by means of perf and memory.

| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        |  3,694.08 ns |  0.94 |    4288 B |        0.45 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        |  3,744.47 ns |  0.95 |    4288 B |        0.45 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        |  3,934.43 ns |  1.00 |    9600 B |        1.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        |  3,991.22 ns |  1.01 |    4288 B |        0.45 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        |  4,009.52 ns |  1.02 |    4288 B |        0.45 |
| NitoAsyncAutoResetEventWaitThenSetAsync                      | 100        |  4,656.00 ns |  1.18 |   16000 B |        1.67 |
| PooledAsTaskContSync                                         | 100        |  5,316.66 ns |  1.35 |   12288 B |        1.28 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | 14,475.79 ns |  3.68 |   15600 B |        1.62 |

### AsyncLock Benchmarks

#### AsyncLock Single Benchmark

The overhead of various synchronization methods without contention.
The standard lock patterns including the new .NET 9 `Lock` and `LockEnterScope` method are measured alongside interlocked increment and a simple increment baseline.

First the classic synchronization methods, increment and Interlocked.Increment as reference:

| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| IncrementSingle                    |  0.0072 ns | 0.000 |         - |          NA |
| InterlockedIncrementSingle         |  0.2064 ns | 0.010 |         - |          NA |
| LockUnlockSingle                   |  3.4771 ns | 0.177 |         - |          NA |
| LockEnterScopeSingle               |  3.4744 ns | 0.176 |         - |          NA |
| ObjectLockUnlockSingle             |  4.8094 ns | 0.244 |         - |          NA |

The new .NET9 `Lock` and `LockEnterScope` methods are slightly faster than a classic lock statement. Apparently its interesting to see here that an Interlocked operation is still significantly faster than any locking mechanism with an increment.

Next, various AsyncLock implementations without contention:

| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| LockUnlockPooledSingleAsync        | 13.6403 ns | 0.692 |         - |          NA |
| LockUnlockRefImplSingleAsync       | 19.6995 ns | 1.000 |         - |          NA |
| LockUnlockSemaphoreSlimSingleAsync | 22.2831 ns | 1.131 |         - |          NA |
| LockUnlockNonKeyedSingleAsync      | 29.2499 ns | 1.485 |         - |          NA |
| LockUnlockNitoSingleAsync          | 48.6693 ns | 2.471 |     320 B |          NA |
| LockUnlockNeoSmartSingleAsync      | 69.9028 ns | 3.549 |     208 B |          NA |

The pooled implementation is the fastest AsyncLock implementation, followed by the reference implementation.
SemaphoreSlim and NonKeyedAsyncLock have moderate overhead, while Nito.AsyncEx and NeoSmart's AsyncLock have the highest overhead and they need allocations.

#### AsyncLock Multiple Benchmark with varying contention (Iterations)

The case with 0 iterations measures the uncontested lock/unlock overhead with multiple concurrent waiters.
Benchmarks with 1, 10, and 100 iterations measure the behavior under contention with increasing number of concurrent waiters.
In addition to the previous uncontested benchmark, the pooled implementation with AsTask() is included to show the overhead of ValueTask/IValueTaskSource management with conversion to Task.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 0          |     14.94 ns |  0.56 |         - |          NA |
| LockUnlockPooledTaskMultipleAsync    | 0          |     15.39 ns |  0.58 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          |     25.89 ns |  0.98 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          |     26.52 ns |  1.00 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          |     31.04 ns |  1.17 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          |     50.30 ns |  1.90 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          |     73.21 ns |  2.76 |     208 B |          NA |

The case with 1 iteration measures the overhead of a single waiter for the contested lock. Noticable the pooled implementation is still the fastest here, followed by SemaphoreSlim and the reference implementation.
But the pooled implementation with an AsTask() conversion, due to the RunContinuationsAsynchronously=true causes a nightmare performance degradation and a moderate allocation in the underlying IValueTaskSource implementation.
However only because the Task is awaited outside the lock, which causes to hit that less efficient code path in the IValueTaskSource.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 1          |     50.61 ns |  0.49 |         - |        0.00 |
| LockUnlockSemaphoreSlimMultipleAsync | 1          |     55.35 ns |  0.54 |      88 B |        0.41 |
| LockUnlockRefImplMultipleAsync       | 1          |    102.39 ns |  1.00 |     216 B |        1.00 |
| LockUnlockNitoMultipleAsync          | 1          |    133.00 ns |  1.30 |     728 B |        3.37 |
| LockUnlockNeoSmartMultipleAsync      | 1          |    152.96 ns |  1.49 |     416 B |        1.93 |
| LockUnlockNonKeyedMultipleAsync      | 1          |    536.01 ns |  5.24 |     336 B |        1.56 |
| LockUnlockPooledTaskMultipleAsync    | 1          |    509.18 ns |  4.97 |     264 B |        1.22 |

The case with 10 iterations manifests the same behavior with moderate contention, as the ObjectPool is not exhausted.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 10         |    380.00 ns |  0.47 |         - |        0.00 |
| LockUnlockSemaphoreSlimMultipleAsync | 10         |    403.64 ns |  0.50 |     880 B |        0.41 |
| LockUnlockNitoMultipleAsync          | 10         |    770.50 ns |  0.96 |    4400 B |        2.04 |
| LockUnlockNeoSmartMultipleAsync      | 10         |    799.80 ns |  0.99 |    2288 B |        1.06 |
| LockUnlockRefImplMultipleAsync       | 10         |    804.64 ns |  1.00 |    2160 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 10         |  3,232.97 ns |  4.02 |    1344 B |        0.62 |
| LockUnlockNonKeyedMultipleAsync      | 10         |  3,476.44 ns |  4.32 |    2208 B |        1.02 |

On the case with 100 iterations the pooled implementation is slower than the semaphore slim implementation, likely due to the exhaustion on the ObjectPool or allocations on the internal queue. Still the pooled implementation has significantly lower allocations than the other implementations.

| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockSemaphoreSlimMultipleAsync | 100        |  3,721.31 ns |  0.49 |    8800 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 100        |  3,805.69 ns |  0.50 |    4824 B |        0.22 |
| LockUnlockNeoSmartMultipleAsync      | 100        |  7,173.92 ns |  0.94 |   21008 B |        0.97 |
| LockUnlockNitoMultipleAsync          | 100        |  7,389.93 ns |  0.97 |   41120 B |        1.90 |
| LockUnlockRefImplMultipleAsync       | 100        |  7,651.58 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 100        | 33,279.19 ns |  4.35 |   17032 B |        0.79 |
| LockUnlockNonKeyedMultipleAsync      | 100        | 36,695.27 ns |  4.80 |   20992 B |        0.97 |

