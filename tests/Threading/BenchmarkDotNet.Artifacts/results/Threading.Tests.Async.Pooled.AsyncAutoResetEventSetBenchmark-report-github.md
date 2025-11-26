```

BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                        | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------:|----------:|------------:|
| PooledAsyncAutoResetEventSet  |   3.811 ns |  0.88 |         - |          NA |
| RefImplAsyncAutoResetEventSet |   4.350 ns |  1.00 |         - |          NA |
| NitoAsyncAutoResetEventSet    |   4.383 ns |  1.01 |         - |          NA |
| AutoResetEventSet             | 235.773 ns | 54.20 |         - |          NA |
