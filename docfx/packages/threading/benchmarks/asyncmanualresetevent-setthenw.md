```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                                            | Mean     | Ratio | Allocated | Alloc Ratio |
|-------------------------------------------------- |---------:|------:|----------:|------------:|
| RefImplAsyncManualResetEventSetThenWaitAsync      | 14.64 ns |  0.84 |      96 B |          NA |
| PooledAsyncManualResetEventSetThenWaitAsync       | 17.42 ns |  1.00 |         - |          NA |
| PooledAsTaskAsyncManualResetEventSetThenWaitAsync | 18.27 ns |  1.05 |         - |          NA |
| NitoAsyncManualResetEventSetThenWaitAsync         | 25.83 ns |  1.48 |      96 B |          NA |
