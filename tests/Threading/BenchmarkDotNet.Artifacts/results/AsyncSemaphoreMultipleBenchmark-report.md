```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Description                               | InitialCount | Iterations | cancellationType | Mean          | Ratio | Allocated | 
|------------------------------------------ |------------- |----------- |----------------- |--------------:|------:|----------:|
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 0          | None             |      8.109 ns |  0.72 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | None             |     11.327 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 0          | None             |     17.875 ns |  1.58 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | None             |     18.280 ns |  1.61 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 0          | None             |     21.429 ns |  1.89 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | None             |     25.295 ns |  2.23 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | NotCancelled     |     11.269 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | NotCancelled     |     18.128 ns |  1.61 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 0          | NotCancelled     |     23.785 ns |  2.11 |      32 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 0          | Timed            |     10.880 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 0          | Timed            |     20.494 ns |  1.88 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 10         | None             |    210.884 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | None             |    264.640 ns |  0.68 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 10         | None             |    289.701 ns |  0.75 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 10         | None             |    335.987 ns |  0.87 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | None             |    387.594 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | None             |    538.472 ns |  1.39 |    1712 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | NotCancelled     |    558.652 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 10         | NotCancelled     |    741.878 ns |  1.33 |    1712 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | NotCancelled     |  4,399.287 ns |  7.88 |    3880 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 10         | Timed            |    853.864 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 10         | Timed            |  4,438.701 ns |  5.20 |    4840 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 1            | 100        | None             |  2,054.104 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | None             |  2,591.241 ns |  0.68 |    8800 B | 
| Multiple · AsyncSemaphore · RefImpl       | 1            | 100        | None             |  2,762.380 ns |  0.72 |    9600 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 1            | 100        | None             |  3,182.599 ns |  0.83 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | None             |  3,818.810 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | None             |  4,918.248 ns |  1.29 |   21152 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | NotCancelled     |  5,586.586 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 1            | 100        | NotCancelled     |  6,997.805 ns |  1.25 |   21152 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | NotCancelled     | 44,902.349 ns |  8.04 |   37784 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 1            | 100        | Timed            |  8,456.376 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 1            | 100        | Timed            | 44,502.254 ns |  5.26 |   47383 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 0          | None             |     14.765 ns |  0.73 |         - | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | None             |     20.259 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | None             |     38.103 ns |  1.88 |         - | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 0          | None             |     51.453 ns |  2.54 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 0          | None             |     52.365 ns |  2.59 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | None             |     66.339 ns |  3.27 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | NotCancelled     |     20.861 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | NotCancelled     |     38.201 ns |  1.83 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 0          | NotCancelled     |     65.232 ns |  3.13 |      56 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 0          | Timed            |     20.351 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 0          | Timed            |     41.572 ns |  2.04 |         - | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 10         | None             |    220.579 ns |  0.55 |         - | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | None             |    305.198 ns |  0.75 |     880 B | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 10         | None             |    316.592 ns |  0.78 |     960 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 10         | None             |    371.929 ns |  0.92 |    1600 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | None             |    404.306 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | None             |    588.999 ns |  1.46 |    1736 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | NotCancelled     |    572.950 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 10         | NotCancelled     |    800.576 ns |  1.40 |    1736 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | NotCancelled     |  3,171.490 ns |  5.54 |    3877 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 10         | Timed            |    901.354 ns |  1.00 |    1520 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 10         | Timed            |  3,298.796 ns |  3.66 |    4836 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · ProtoPromise  | 4            | 100        | None             |  2,091.692 ns |  0.54 |         - | 
| Multiple · AsyncSemaphore · RefImpl       | 4            | 100        | None             |  2,601.120 ns |  0.67 |    9600 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | None             |  3,114.121 ns |  0.80 |    8800 B | 
| Multiple · AsyncSemaphore · Nito.AsyncEx  | 4            | 100        | None             |  3,245.756 ns |  0.84 |   16000 B | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | None             |  3,873.088 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | None             |  4,948.359 ns |  1.28 |   21176 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | NotCancelled     |  5,573.882 ns |  1.00 |         - | 
| Multiple · AsyncSemaphore · VS.Threading  | 4            | 100        | NotCancelled     |  7,157.626 ns |  1.28 |   21176 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | NotCancelled     | 38,436.141 ns |  6.90 |   37774 B | 
|                                           |              |            |                  |               |       |           | 
| Multiple · AsyncSemaphore · Pooled        | 4            | 100        | Timed            |  8,518.660 ns |  1.00 |   15200 B | 
| Multiple · AsyncSemaphore · SemaphoreSlim | 4            | 100        | Timed            | 39,554.518 ns |  4.64 |   47371 B | 
