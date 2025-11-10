```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  .NET 8.0 : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

Job=.NET 8.0  Runtime=.NET 8.0  Toolchain=net8.0  

```
| Method                                      | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| NitoAsyncAutoResetEventTaskWaitAsync        | 48.60 ns | 0.334 ns | 0.313 ns |  1.46 |    0.02 | 0.0191 | 0.0001 |     160 B |        1.67 |
| PooledAsyncAutoResetEventTaskWaitAsync      | 49.17 ns | 0.246 ns | 0.230 ns |  1.48 |    0.02 | 0.0095 |      - |      80 B |        0.83 |
| PooledAsyncAutoResetEventValueTaskWaitAsync | 35.06 ns | 0.108 ns | 0.095 ns |  1.05 |    0.01 |      - |      - |         - |        0.00 |
| RefImplAsyncAutoResetEventTaskWaitAsync     | 33.26 ns | 0.456 ns | 0.405 ns |  1.00 |    0.02 | 0.0114 |      - |      96 B |        1.00 |
