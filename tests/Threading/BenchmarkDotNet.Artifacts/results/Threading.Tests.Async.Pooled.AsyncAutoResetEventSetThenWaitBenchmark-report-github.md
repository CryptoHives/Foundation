```

BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                                          | Mean     | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------ |---------:|------:|----------:|------------:|
| PooledAsTaskAsyncAutoResetEventSetThenWaitAsync | 11.03 ns |  0.65 |         - |          NA |
| PooledAsyncAutoResetEventSetThenWaitAsync       | 11.58 ns |  0.68 |         - |          NA |
| NitoAsyncAutoResetEventSetThenWaitAsync         | 14.84 ns |  0.87 |         - |          NA |
| RefImplAsyncAutoResetEventSetThenWaitAsync      | 17.02 ns |  1.00 |         - |          NA |
