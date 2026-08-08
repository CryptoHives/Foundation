```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                               | Iterations | cancellationType | Mean         | Ratio | Allocated | 
|------------------------------------------ |----------- |----------------- |-------------:|------:|----------:|
| Multiple · AsyncLock · Pooled (Task)      | 0          | None             |     11.00 ns |  0.99 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | None             |     11.09 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | None             |     11.60 ns |  1.05 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | None             |     17.67 ns |  1.59 |         - | 
| Multiple · AsyncLock · RefImpl            | 0          | None             |     19.27 ns |  1.74 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | None             |     19.39 ns |  1.75 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | None             |     23.50 ns |  2.12 |         - | 
| Multiple · AsyncLock · Nito               | 0          | None             |     38.77 ns |  3.50 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | None             |     68.33 ns |  6.16 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (Task)      | 0          | NotCancelled     |     10.73 ns |  0.98 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | NotCancelled     |     10.90 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 0          | NotCancelled     |     12.64 ns |  1.16 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | NotCancelled     |     17.76 ns |  1.63 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | NotCancelled     |     19.24 ns |  1.76 |         - | 
| Multiple · AsyncLock · NonKeyed           | 0          | NotCancelled     |     24.37 ns |  2.24 |         - | 
| Multiple · AsyncLock · Nito               | 0          | NotCancelled     |     40.59 ns |  3.72 |     320 B | 
| Multiple · AsyncLock · NeoSmart           | 0          | NotCancelled     |     59.60 ns |  5.47 |     208 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 0          | Timed            |     10.42 ns |  1.00 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 0          | Timed            |     18.25 ns |  1.75 |         - | 
| Multiple · AsyncLock · VS.Threading       | 0          | Timed            |     19.09 ns |  1.83 |         - | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | None             |     34.14 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | None             |     37.48 ns |  1.10 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | None             |     43.03 ns |  1.26 |      88 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | None             |     66.24 ns |  1.94 |     168 B | 
| Multiple · AsyncLock · RefImpl            | 1          | None             |     84.97 ns |  2.49 |     216 B | 
| Multiple · AsyncLock · Nito               | 1          | None             |     99.62 ns |  2.92 |     728 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | None             |    120.28 ns |  3.52 |     416 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | None             |    478.99 ns | 14.03 |     272 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | None             |    523.87 ns | 15.34 |     352 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | NotCancelled     |     50.80 ns |  1.00 |         - | 
| Multiple · AsyncLock · ProtoPromise       | 1          | NotCancelled     |     62.11 ns |  1.22 |         - | 
| Multiple · AsyncLock · VS.Threading       | 1          | NotCancelled     |     83.67 ns |  1.65 |     168 B | 
| Multiple · AsyncLock · NeoSmart           | 1          | NotCancelled     |    123.43 ns |  2.43 |     416 B | 
| Multiple · AsyncLock · Nito               | 1          | NotCancelled     |    406.16 ns |  8.00 |     968 B | 
| Multiple · AsyncLock · Pooled (Task)      | 1          | NotCancelled     |    535.38 ns | 10.54 |     272 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | NotCancelled     |    576.32 ns | 11.35 |     504 B | 
| Multiple · AsyncLock · NonKeyed           | 1          | NotCancelled     |    675.84 ns | 13.30 |     640 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 1          | Timed            |     78.20 ns |  1.00 |     152 B | 
| Multiple · AsyncLock · VS.Threading       | 1          | Timed            |    127.29 ns |  1.63 |     312 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 1          | Timed            |    613.50 ns |  7.85 |     600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | None             |    263.03 ns |  0.79 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | None             |    280.57 ns |  0.84 |     880 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | None             |    334.87 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 10         | None             |    534.22 ns |  1.60 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | None             |    569.33 ns |  1.70 |    4400 B | 
| Multiple · AsyncLock · RefImpl            | 10         | None             |    641.51 ns |  1.92 |    2160 B | 
| Multiple · AsyncLock · NeoSmart           | 10         | None             |    646.81 ns |  1.93 |    2288 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | None             |  3,198.19 ns |  9.55 |    1352 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | None             |  3,331.00 ns |  9.95 |    2296 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 10         | NotCancelled     |    474.95 ns |  0.91 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | NotCancelled     |    524.30 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 10         | NotCancelled     |    651.62 ns |  1.24 |    2288 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | NotCancelled     |    755.69 ns |  1.44 |    1680 B | 
| Multiple · AsyncLock · Nito               | 10         | NotCancelled     |  3,225.34 ns |  6.15 |    6800 B | 
| Multiple · AsyncLock · Pooled (Task)      | 10         | NotCancelled     |  3,506.06 ns |  6.69 |    1352 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | NotCancelled     |  4,408.93 ns |  8.41 |    3888 B | 
| Multiple · AsyncLock · NonKeyed           | 10         | NotCancelled     |  5,160.57 ns |  9.84 |    5176 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 10         | Timed            |    831.38 ns |  1.00 |    1520 B | 
| Multiple · AsyncLock · VS.Threading       | 10         | Timed            |  1,129.52 ns |  1.36 |    3120 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 10         | Timed            |  4,395.43 ns |  5.29 |    4848 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | None             |  2,572.37 ns |  0.81 |         - | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | None             |  2,628.70 ns |  0.83 |    8800 B | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | None             |  3,182.07 ns |  1.00 |         - | 
| Multiple · AsyncLock · VS.Threading       | 100        | None             |  4,976.51 ns |  1.56 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | None             |  5,495.30 ns |  1.73 |   41120 B | 
| Multiple · AsyncLock · NeoSmart           | 100        | None             |  6,006.67 ns |  1.89 |   21008 B | 
| Multiple · AsyncLock · RefImpl            | 100        | None             |  6,236.29 ns |  1.96 |   21600 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | None             | 33,714.67 ns | 10.60 |   12215 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | None             | 35,804.70 ns | 11.25 |   21799 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · ProtoPromise       | 100        | NotCancelled     |  4,690.41 ns |  0.90 |         - | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | NotCancelled     |  5,224.93 ns |  1.00 |         - | 
| Multiple · AsyncLock · NeoSmart           | 100        | NotCancelled     |  6,087.87 ns |  1.17 |   21008 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | NotCancelled     |  7,036.47 ns |  1.35 |   21120 B | 
| Multiple · AsyncLock · Nito               | 100        | NotCancelled     | 33,042.89 ns |  6.32 |   65120 B | 
| Multiple · AsyncLock · Pooled (Task)      | 100        | NotCancelled     | 34,909.02 ns |  6.68 |   12216 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | NotCancelled     | 43,936.30 ns |  8.41 |   37792 B | 
| Multiple · AsyncLock · NonKeyed           | 100        | NotCancelled     | 54,232.96 ns | 10.38 |   50600 B | 
|                                           |            |                  |              |       |           | 
| Multiple · AsyncLock · Pooled (ValueTask) | 100        | Timed            |  8,082.92 ns |  1.00 |   15200 B | 
| Multiple · AsyncLock · VS.Threading       | 100        | Timed            | 10,935.97 ns |  1.35 |   35520 B | 
| Multiple · AsyncLock · SemaphoreSlim      | 100        | Timed            | 43,970.16 ns |  5.44 |   47392 B | 
