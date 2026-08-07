```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                               | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |      9.811 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     10.416 ns |  1.06 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     12.010 ns |  1.22 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     18.017 ns |  1.84 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.239 ns |  1.96 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     20.366 ns |  2.08 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     21.383 ns |  2.18 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     39.268 ns |  4.00 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     58.886 ns |  6.00 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |      9.644 ns |  1.00 |         - | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.664 ns |  1.11 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     12.269 ns |  1.27 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     17.886 ns |  1.85 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     19.308 ns |  2.00 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     21.077 ns |  2.19 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     41.693 ns |  4.32 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     59.136 ns |  6.13 |     208 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     31.762 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     37.937 ns |  1.19 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     43.509 ns |  1.37 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     64.610 ns |  2.03 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     78.677 ns |  2.48 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     98.582 ns |  3.10 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    117.881 ns |  3.71 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    468.972 ns | 14.77 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    525.562 ns | 16.55 |     352 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     47.385 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     61.550 ns |  1.30 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     84.033 ns |  1.77 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    122.163 ns |  2.58 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    393.100 ns |  8.30 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    522.285 ns | 11.02 |     272 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    573.794 ns | 12.11 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    679.445 ns | 14.34 |     640 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    266.265 ns |  0.72 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    275.463 ns |  0.75 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    367.921 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    528.640 ns |  1.44 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    559.288 ns |  1.52 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    652.087 ns |  1.77 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    660.035 ns |  1.79 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,229.534 ns |  8.78 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,312.058 ns |  9.00 |    2296 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    474.584 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    529.797 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    638.576 ns |  1.21 |    2288 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    738.238 ns |  1.39 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,326.068 ns |  6.28 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,487.993 ns |  6.58 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  4,288.901 ns |  8.10 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,070.855 ns |  9.57 |    5176 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,582.582 ns |  0.79 |    8800 B | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,584.971 ns |  0.80 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,249.935 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,910.911 ns |  1.51 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,345.513 ns |  1.64 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  5,913.327 ns |  1.82 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,209.612 ns |  1.91 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 33,507.516 ns | 10.31 |   12216 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,857.309 ns | 11.03 |   21799 B | 
|                                           |            |                  |               |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,569.210 ns |  0.87 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,259.852 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,050.827 ns |  1.15 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  6,873.537 ns |  1.31 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 32,787.472 ns |  6.23 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 35,393.784 ns |  6.73 |   12216 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 47,276.002 ns |  8.99 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 52,017.472 ns |  9.89 |   50600 B | 
