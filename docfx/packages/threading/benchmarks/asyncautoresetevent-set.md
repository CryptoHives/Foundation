```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                        | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventSet  |   3.922 ns |  1.00 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   4.449 ns |  1.13 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   4.527 ns |  1.15 |         - |          NA |
| AutoResetEventSet             | 230.080 ns | 58.66 |         - |          NA |
