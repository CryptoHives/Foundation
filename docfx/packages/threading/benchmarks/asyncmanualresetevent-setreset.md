```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                               | Mean       | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |-----------:|------:|----------:|------------:|
| ManualResetEventSlimSet              |   5.850 ns |  0.71 |         - |          NA |
| PooledAsyncManualResetEventSetReset  |   8.243 ns |  1.00 |         - |          NA |
| RefImplAsyncManualResetEventSetReset |  10.641 ns |  1.29 |      96 B |          NA |
| NitoAsyncManualResetEventSetReset    |  19.161 ns |  2.32 |      96 B |          NA |
| ManualResetEventSet                  | 453.439 ns | 55.01 |         - |          NA |
