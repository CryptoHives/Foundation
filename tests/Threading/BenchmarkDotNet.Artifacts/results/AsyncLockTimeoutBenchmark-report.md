```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                       | Iterations | Mean          | Ratio | Allocated | 
|-------------------------------------------------- |----------- |--------------:|------:|----------:|
| MultipleTimeout · AsyncLock · Pooled (no timeout) | 0          |      8.531 ns |  1.00 |         - | 
| MultipleTimeout · AsyncLock · Pooled (ValueTask)  | 0          |      8.929 ns |  1.05 |         - | 
| MultipleTimeout · AsyncLock · SemaphoreSlim       | 0          |     18.036 ns |  2.11 |         - | 
| MultipleTimeout · AsyncLock · VS.Threading        | 0          |     19.356 ns |  2.27 |         - | 
|                                                   |            |               |       |           | 
| MultipleTimeout · AsyncLock · Pooled (no timeout) | 1          |     32.996 ns |  1.00 |         - | 
| MultipleTimeout · AsyncLock · Pooled (ValueTask)  | 1          |     77.547 ns |  2.35 |     152 B | 
| MultipleTimeout · AsyncLock · VS.Threading        | 1          |    124.279 ns |  3.77 |     312 B | 
| MultipleTimeout · AsyncLock · SemaphoreSlim       | 1          |    591.947 ns | 17.94 |     608 B | 
|                                                   |            |               |       |           | 
| MultipleTimeout · AsyncLock · Pooled (no timeout) | 10         |    335.064 ns |  1.00 |         - | 
| MultipleTimeout · AsyncLock · Pooled (ValueTask)  | 10         |    805.129 ns |  2.40 |    1520 B | 
| MultipleTimeout · AsyncLock · VS.Threading        | 10         |  1,106.928 ns |  3.30 |    3120 B | 
| MultipleTimeout · AsyncLock · SemaphoreSlim       | 10         |  4,327.961 ns | 12.92 |    4856 B | 
|                                                   |            |               |       |           | 
| MultipleTimeout · AsyncLock · Pooled (no timeout) | 100        |  3,198.963 ns |  1.00 |         - | 
| MultipleTimeout · AsyncLock · Pooled (ValueTask)  | 100        |  7,854.538 ns |  2.46 |   15200 B | 
| MultipleTimeout · AsyncLock · VS.Threading        | 100        | 10,625.994 ns |  3.32 |   35520 B | 
| MultipleTimeout · AsyncLock · SemaphoreSlim       | 100        | 46,561.707 ns | 14.56 |   47400 B | 
