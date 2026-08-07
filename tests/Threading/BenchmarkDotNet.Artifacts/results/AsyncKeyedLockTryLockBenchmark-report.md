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
| TryLock · AsyncKeyedLock · Pooled                    | 14.89 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 36.19 ns |  2.43 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 40.40 ns |  2.71 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 68.98 ns |  4.63 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 84.15 ns |  5.65 |     200 B | 
