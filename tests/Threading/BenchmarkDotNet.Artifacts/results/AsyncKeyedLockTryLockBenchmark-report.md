```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 15.40 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 37.14 ns |  2.41 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 41.04 ns |  2.66 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 70.08 ns |  4.55 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 85.97 ns |  5.58 |     200 B | 
